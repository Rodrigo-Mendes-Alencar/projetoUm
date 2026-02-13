using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Projetodois
{
    internal class Sistema
    {


        public void ReceberDados()
        {
            Console.WriteLine("Digite o nome do aluno: ");
            Aluno aluno1 = new Aluno(Console.ReadLine());
            Console.WriteLine("Digite a primeira nota: ");
            this.VerificarNota(float.Parse(Console.ReadLine()),aluno1);
            Console.WriteLine("Digite a segunda nota: ");
            
            Console.WriteLine("Digite a terceira nota");
            

        }
        private void VerificarNota(float nota,Aluno aluno)
        {
        
            if (aluno.AdicionarNota(nota))
            {
                return;
            }
            else
            {
                do
                {
                    Console.WriteLine("Nota inválida,digite uma nota entre 0 e 10: ");
                    nota = float.Parse(Console.ReadLine());

                } while (!aluno.AdicionarNota(nota));
                return;
            }
        }


    }
}
