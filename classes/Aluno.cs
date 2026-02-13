using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUm.classes
{
    internal class Aluno
    {
        String Nome { get; }
        private List<float> notas { get; }


        public Aluno(string nome)
        {
            Nome = nome;
            notas = new List<float>();
        }

        /*public float CalcularMedia()
        {

        }
        */
        public bool AdicionarNota(float nota)
        {
            if (this.ValidarNota(nota))
            {
                notas.Add(nota);
                return true;
            }
            return false;
        }

        private bool ValidarNota(float nota)
        {
          if (nota < 0f || nota > 10f)
          {
              return false ; 
          }
          return true;
        }
    }

}
