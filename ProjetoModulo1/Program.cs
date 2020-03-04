using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoModulo1
{
    public class Program
    {
        public static List<Candidato> ListaCandidato = new List<Candidato>();
        public static Dictionary<int, double> ListaVotos = new Dictionary<int, double>();       

        static void Main(string[] args)
        {
            CriarCandidatos();
            
            bool menusair = true;
            do
            {
                StringBuilder menup = new StringBuilder();
                menup.Append("\n###   Escolha uma opcao:   ###");
                menup.Append("\n1 - Votar num candidato");
                menup.Append("\n2 - Conferir contagem");
                menup.Append("\n3 - Sair");

                Console.WriteLine(menup);

                int opm = int.Parse(Console.ReadLine());
                
                if (opm == 3)
                    menusair = false;
                else if (opm == 1)
                {
                    Votar();                     
                }
                else if (opm == 2)
                {
                    Contagem();
                }
                else
                    Console.WriteLine("Opcao invalida, tente novamente.");
            }
            while (menusair);
        }

        public static void CriarCandidatos()
        {
            Candidato candidato1 = new Candidato("Abobrinha", 1, TipoCandidato.Valido);
            Candidato candidato2 = new Candidato("Berinjela", 2, TipoCandidato.Valido);
            Candidato candidato3 = new Candidato("Nulo", 3, TipoCandidato.Nulo);
            Candidato candidato4 = new Candidato("Branco", 4, TipoCandidato.Branco);

            ListaCandidato.Add(candidato1);
            ListaCandidato.Add(candidato2);
            ListaCandidato.Add(candidato3);
            ListaCandidato.Add(candidato4);
        }

        static void Votar()
        {
            Eleicao.Votar();
        }    

        static void Contagem()
        {
            Eleicao.Contagem();           
        }
    }
    
    public enum TipoCandidato
    {
        Valido = 0,
        Nulo = 1,
        Branco = 2
    }
    
    public class Candidato
    {
        public string Nome { get; set; }
        public int Numero { get; }
        public TipoCandidato Tipo { get; set; }

        public Candidato(string nom, int num, TipoCandidato tipo)
        {
            Nome = nom;
            Numero = num;
            Tipo = tipo;
        }
    }

    public static class Eleicao
    {
        public static void Votar()
        {
            StringBuilder menuv = new StringBuilder();
            menuv.Append("\n### Escolha uma opcao:   ###");            
            menuv.Append($"\n1) - Candidato {Program.ListaCandidato[0].Nome}");
            menuv.Append($"\n2) - Candidato {Program.ListaCandidato[1].Nome}");
            menuv.Append($"\n3) - {Program.ListaCandidato[2].Nome}");
            menuv.Append($"\n4) - {Program.ListaCandidato[3].Nome}");

            Console.WriteLine(menuv);

            int opv = int.Parse(Console.ReadLine());

            if (opv == 0 | opv > 4)
            {
                Console.WriteLine("Opcao invalida, tente novamente.");
            }
            else if (opv < 5 && opv > 0)
            {
                double votos = 1;
                Console.WriteLine("Voto computado com sucesso!");
                if (!Program.ListaVotos.ContainsKey(opv))
                {
                    Program.ListaVotos.Add(opv, 1);
                }
                else
                {
                    Program.ListaVotos.TryGetValue(opv, out votos);
                    Program.ListaVotos.Remove(opv);
                    Program.ListaVotos.Add(opv, votos + 1);
                }
            }
        }

        public static void Contagem()
        {
            double total = 0;
            foreach (KeyValuePair<int, double> entry in Program.ListaVotos)
            {
                total += entry.Value;
            }
            Console.WriteLine("### Contagem de Votos: ###");
            Console.WriteLine($"Total de votos computados: {total} (100%)");

            //neste lugar usarei o try/catch

            double nulo;
            if (Program.ListaVotos.TryGetValue(3, out nulo))
            {
                Console.WriteLine($"Total de votos nulos: {nulo} ({((nulo / total) * 100).ToString("F2")}%)");
            }
            else
            {
                Console.WriteLine("Total de votos nulos: 0 (0.00%)");
            }

            double branco;
            if (Program.ListaVotos.TryGetValue(4, out branco))
            {
                Console.WriteLine($"Total de votos brancos: {branco} ({((branco / total) * 100).ToString("F2")}%)");
            }
            else
            {
                Console.WriteLine("Total de votos brancos: 0 (0.00%)");
            }
            double cand1 = 0;
            double cand2 = 0;
            if (Program.ListaVotos.TryGetValue(1, out cand1) && Program.ListaVotos.TryGetValue(2, out cand2))
            {
                Console.WriteLine($"Total de votos por candidato: {Program.ListaCandidato[0].Nome}: {cand1} ({((cand1 / total) * 100).ToString("F2")}%) / {Program.ListaCandidato[1].Nome}: {cand2}({((cand2 / total) * 100).ToString("F2")}%)");
            }
            else if (Program.ListaVotos.TryGetValue(1, out cand1) && !Program.ListaVotos.TryGetValue(2, out cand2))
            {
                Console.WriteLine($"Total de votos por candidato: {Program.ListaCandidato[0].Nome}: {cand1} ({((cand1 / total) * 100).ToString("F2")}%) / {Program.ListaCandidato[1].Nome}: 0 (0.00%)");
            }
            else if (!Program.ListaVotos.TryGetValue(1, out cand1) && Program.ListaVotos.TryGetValue(2, out cand2))
            {
                Console.WriteLine($"Total de votos por candidato: {Program.ListaCandidato[0].Nome}: 0 (0.00%) / {Program.ListaCandidato[1].Nome}: {cand1} ({((cand1 / total) * 100).ToString("F2")}%)");
            }
            else
            {
                Console.WriteLine($"Total de votos do candidato {Program.ListaCandidato[0].Nome}: 0 (0.00%) / {Program.ListaCandidato[1].Nome}: 0 (0.00%)");
            }

            if (cand1 > cand2)
            {
                Console.WriteLine($"Candidato vencedor: {Program.ListaCandidato[0].Nome} {cand1}");
            }
            else if (cand2 > cand1)
            {
                Console.WriteLine($"Candidato vencedor: {Program.ListaCandidato[1].Nome} {cand2}");
            }
            else
                Console.WriteLine($"Os candidatos estao empatados em votos.");
        }
    }
}
