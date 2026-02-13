using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjetoUm.classes
{
    internal class Sistema
    {
        enum opcaoMenu{ CadastrarAluno = 1, InserirNotas, ListarAlunos, VerBoletim, Sair }
        public void ExibirMenu()
        {

            Console.WriteLine("Bem vindo ao sistema de notas, escolha uma opção: ");
            Console.WriteLine("|1| Cadastrar aluno");
            Console.WriteLine("|2| Inserir notas em Aluno");
            Console.WriteLine("|3| Listar Alunos");
            Console.WriteLine("|4| Ver boletim de um Aluno");
            Console.WriteLine("|5| Sair");
            Console.WriteLine("Bem vindo ao sistema de notas, escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());

        }
        public void ExecutarMenu(int opcao)
        {
            opcaoMenu opcaoSelecionada = (opcaoMenu)opcao;
            switch (opcao)
            {
                case opcaoMenu.CadastrarAluno:

                break;
            }
        }


        public void CadastrarAluno()
        {
            Console.WriteLine("Digite o nome do aluno: ");
            Aluno aluno1 = new Aluno(Console.ReadLine());
        }

        public void ListarAlunos(Aluno aluno)
        {
            Console.WriteLine("Lista de alunos: ");
            Console.WriteLine($"Aluno 1:{aluno.Nome}");
        }

        public void Recebernotas(Aluno aluno)
        {
            Console.WriteLine("Digite a primeira nota: ");
            this.VerificarNota(float.Parse(Console.ReadLine()),aluno1);
            Console.WriteLine("Digite a segunda nota: ");
            this.VerificarNota(float.Parse(Console.ReadLine()), aluno1);
            Console.WriteLine("Digite a terceira nota");
            this.VerificarNota(float.Parse(Console.ReadLine()), aluno1);

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
