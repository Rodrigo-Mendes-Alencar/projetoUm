using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoUm.classes
{
    internal class Aluno
    {
        public String Nome { get; }
        private List<float> notas { get; }
        public int id{get;}

        public Aluno(string nome, int id)
        {
            this.Nome = nome;
            this.id = id;
            notas = new List<float>();
        }

        public List<float> EnviarNotas()
        {
            return notas;
        }

        public float CalcularMedia()
        {
            if (notas.Count == 0) 
            {
                return 0;
            }

            float media = 0;
            for (int i =0; i < notas.Count; i++)
            {
                media = (notas[i] + media);
            }
            media = media / notas.Count;
            
            return media;
        }
      
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
