using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjetoUm.classes
{
    internal class Sistema
    {

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
                opcaoMenu opcaoSelecionada = (opcaoMenu)opcao;

                switch (opcaoSelecionada)
                {
                    case opcaoMenu.CadastrarAluno:
                        CadastrarAluno();
                        break;
                    case opcaoMenu.InserirNotas:
                        ListarAlunos();
                        Console.WriteLine("Digite o numero do aluno para inserir as notas: ");
                        Console.ReadLine();
                        break;
                }

            } while (opcao != 5);
    
        }
 
        public void CadastrarAluno()
        {
            Console.WriteLine("Digite o nome do aluno: ");
            Aluno novoAluno = new Aluno(Console.ReadLine());
                alunos.Add(novoAluno);
            Console.WriteLine("\nAluno cadastrado com sucesso!");
        }

        public void ListarAlunos()
        {
            for (int i = 0; i< alunos.Count; i++)
            {
                Console.WriteLine($"Aluno {i + 1} {alunos[i].Nome}");
            }
        }

        public void Recebernotas(Aluno aluno)
        {
            

        }
        private void VerificarNota(float nota,Aluno aluno)
        {
            while(!aluno.AdicionarNota(nota))
            {
                Console.WriteLine("Nota inválida, digite nota entre 0 e 10: ");
                nota = float.Parse(Console.ReadLine());
            }
        }
    }
}



/*
 * 
 *          Console.WriteLine("Digite a primeira nota: ");
            this.VerificarNota(float.Parse(Console.ReadLine()),aluno);
            Console.WriteLine("Digite a segunda nota: ");
            this.VerificarNota(float.Parse(Console.ReadLine()), aluno);
            Console.WriteLine("Digite a terceira nota");
            this.VerificarNota(float.Parse(Console.ReadLine()), aluno);         */