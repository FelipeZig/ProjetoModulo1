using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoModulo1
{
    class Program
    {

        static List<Candidato> ListaCandidato = new List<Candidato>();
        static List<int> ListaVotos = new List<int>();

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
                    StringBuilder menuv = new StringBuilder();
                    menuv.Append("\n### Escolha uma opcao:   ###");
                    menuv.Append($"\n1 - Candidato {ListaCandidato[0].Nome}");
                    menuv.Append($"\n2 - Candidato {ListaCandidato[1].Nome}");
                    menuv.Append($"\n3 - {ListaCandidato[2].Nome}");
                    menuv.Append($"\n4 - {ListaCandidato[3].Nome}");
                        
                    Console.WriteLine(menuv);

                    int opv = int.Parse(Console.ReadLine());                        
                    if (opv == 1)
                    {
                        Console.WriteLine("Voto computado com sucesso!");
                        ListaVotos.Add(1);
                    }
                    else if (opv == 2)
                    {
                        Console.WriteLine("Voto computado com sucesso!");
                    }
                    else if (opv == 3)
                    {
                        Console.WriteLine("Voto computado com sucesso!");
                    }
                    else if (opv == 4)
                    {
                        Console.WriteLine("Voto computado com sucesso!");
                    }
                    else
                    Console.WriteLine("Opcao invalida, tente novamente.");         
                    
                }
                else if (opm == 2)
                {
                    //total de votos: x
                    //porcentagem de nulos: %
                    //porcentagem de brancos: %
                    //votos por candidato: Candidato 1: X / Candidato 2: X
                    //candidato vencedor: Candidato x.
                }
                else
                    Console.WriteLine("Opcao invalida, tente novamente.");
            }
            while (menusair);
        }

        static void CriarCandidatoS()
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

        }

        static void Contagem()
        {

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
