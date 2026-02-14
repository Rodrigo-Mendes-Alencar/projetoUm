using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjetoUm.classes
{
    internal class Sistema
    {
        int proximoId = 1;

        private List<Aluno> alunos { get; }
        enum opcaoMenu{ CadastrarAluno = 1, InserirNotas, ListarAlunos, VerBoletim, Sair }

        public Sistema()
        {
            alunos = new List<Aluno>();
        }

        public void inicar()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("\nBem vindo ao sistema de notas, escolha uma opção: ");
                Console.WriteLine("|1| Cadastrar aluno");
                Console.WriteLine("|2| Inserir notas em Aluno");
                Console.WriteLine("|3| Listar Alunos");
                Console.WriteLine("|4| Ver boletim de um Aluno");
                Console.WriteLine("|5| Sair");
                Console.Write("Bem vindo ao sistema de notas, escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                while(opcao > 5 || opcao < 0)
                {
                    Console.Write("Digite uma opção valida do menu: ");
                    opcao = int.Parse(Console.ReadLine());
                }
                opcaoMenu opcaoSelecionada = (opcaoMenu)opcao;

                switch (opcaoSelecionada)
                {
                    case opcaoMenu.CadastrarAluno:
                        CadastrarAluno();
                        break;
                    case opcaoMenu.InserirNotas:
                        ListarAlunos();
                        Console.Write("Digite o numero do aluno para inserir as notas: ");
                        int numAluno = int.Parse(Console.ReadLine());
                        CompararAluno(numAluno, Recebernotas);
                        break;
                    case opcaoMenu.ListarAlunos:
                        ListarAlunos();
                        break;
                    case opcaoMenu.VerBoletim:
                        ListarAlunos();
                        Console.Write("Digite o numero do aluno para ver o boletim: ");
                        int numAluno2 = int.Parse(Console.ReadLine());
                        CompararAluno(numAluno2, MostrarNotas);
                        break;
                    case opcaoMenu.Sair:
                        Console.WriteLine("Saindo..");
                        break;
                }

            } while (opcao != 5);
    
        }

        private void CompararAluno(int numAluno,Action<Aluno> metodo)
        {
            do
            {
                if (numAluno <= alunos.Count && numAluno > 0)
                {
                    for (int i = 0; i < alunos.Count; i++)
                    {
                        if (alunos[i].id == numAluno)
                        {
                            metodo(alunos[i]);
                            return;
                        }
                    }
                }
                else
                {
                    Console.Write("Digite um numero coerente com a lista! : ");
                    numAluno = int.Parse(Console.ReadLine());
                }

            } while (numAluno > alunos.Count || numAluno < 0);
        }
 
        public void CadastrarAluno()
        {
            Console.Write("Digite o nome do aluno: ");
            Aluno novoAluno = new Aluno(Console.ReadLine(),proximoId);
            alunos.Add(novoAluno);
            Console.WriteLine("\nAluno cadastrado com sucesso!");
            proximoId++;
        }

        public void ListarAlunos()
        {
            Console.WriteLine("\n");
            for (int i = 0; i< alunos.Count; i++)
            {
                Console.WriteLine($"Aluno {i + 1} : {alunos[i].Nome}");
            }
            Console.WriteLine("\n");
        }

        public void Recebernotas(Aluno aluno)
        {
            Console.Write("Digite a primeira nota: ");
            this.VerificarNota(float.Parse(Console.ReadLine()), aluno);
            Console.Write("Digite a segunda nota: ");
            this.VerificarNota(float.Parse(Console.ReadLine()), aluno);
            Console.Write("Digite a terceira nota");
            this.VerificarNota(float.Parse(Console.ReadLine()), aluno);

        }
        private void VerificarNota(float nota,Aluno aluno)
        {
            while(!aluno.AdicionarNota(nota))
            {
                Console.Write("Nota inválida, digite nota entre 0 e 10: ");
                nota = float.Parse(Console.ReadLine());
            }
        }

        private void MostrarNotas(Aluno aluno)
        {
            List<float> notas = new List<float>();
            notas = aluno.EnviarNotas();
            for(int i =0; i < notas.Count; i++)
            {
                Console.WriteLine($"A nota {i+1} é {notas[i]}");           
            }
            float media = 0;
            media = aluno.CalcularMedia();
            Console.WriteLine($"\nA media do aluno {aluno.Nome} é {media}");
            if (media > 6)
            {
                Console.WriteLine(" Aluno aprovado!");
            }
            else if (media > 4.5)
            {
                Console.WriteLine("Aluno em recuperação");
            }
            else
                Console.WriteLine("Aluno reprovado!");

        }
     
    }
}
