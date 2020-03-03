using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoModulo1
{
    class Program
    {
        static List<Candidato> ListaCandidato = new List<Candidato>();
        static List<int> ListaVotos = new List<int>();
        static int cand1 = 0;
        static int cand2 = 0;
        static int nulo = 0;
        static int branco = 0;

        static void Main(string[] args)
        {
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

        static void CriarCandidatos()
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
            StringBuilder menuv = new StringBuilder();
            menuv.Append("\n### Escolha uma opcao:   ###");
            menuv.Append($"\n1 - Candidato Abobrinha");
            menuv.Append($"\n2 - Candidato Berinjela");
            menuv.Append($"\n3 - Nulo");
            menuv.Append($"\n4 - Branco");

            Console.WriteLine(menuv);

            int opv = int.Parse(Console.ReadLine());
            if (opv == 1)
            {
                Console.WriteLine("Voto computado com sucesso!");
                ListaVotos.Add(opv);
                cand1++;
            }
            else if (opv == 2)
            {
                Console.WriteLine("Voto computado com sucesso!");
                ListaVotos.Add(opv);
                cand2++;
            }
            else if (opv == 3)
            {
                Console.WriteLine("Voto computado com sucesso!");
                ListaVotos.Add(opv);
                nulo++;
            }
            else if (opv == 4)
            {
                Console.WriteLine("Voto computado com sucesso!");
                ListaVotos.Add(opv);
                branco++;
            }
            else
                Console.WriteLine("Opcao invalida, tente novamente.");
        }

        static void Contagem()
        {
            Console.WriteLine("### Contagem de Votos: ###");
            Console.WriteLine($"\nTotal de votos computados: {ListaVotos.Count}");
            Console.WriteLine($"Porcentagem de votos nulos: {(nulo / ListaVotos.Count) * 100}%");
            Console.WriteLine($"Porcentagem de votos brancos: {(branco / ListaVotos.Count) * 100}%");
            Console.WriteLine($"Votos por candidato: Candidato Abobrinha: {cand1} / Candidato Berinjela: {cand2}");
            if (cand1 > cand2)
            {
                Console.WriteLine($"Candidato vencedor: Abobrinha {cand1}");
            }
            else if (cand2 > cand1)
            {
                Console.WriteLine($"Candidato vencedor: Berinjela {cand2}");
            }
            else
                Console.WriteLine($"Os candidatos estao empatados em votos.");
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

    public class Eleicao
    {
        
    }
}
