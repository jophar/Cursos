using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos
{
    internal class Curso
    {
        private double duracaoHoras = 0;
        protected double numeroMedioSessoes = 10;
        private Dictionary<int, Curso> listaCursos = new Dictionary<int, Curso>();

        // Field
        private string nomeCurso = string.Empty;

        // Classic Property
        internal string NomeCurso
        {
            get { return nomeCurso; }
            set { nomeCurso = value; }
        }

        internal int CursoID { get; set; }
        internal string NumeroSessoes { get; set; }
        internal string NumeroHorasPorSessao { get; set; }

        internal static double CalcularNumeroHoras(Curso c)
        { 
            return Convert.ToDouble(c.NumeroHorasPorSessao) * Convert.ToDouble(c.NumeroSessoes);
        }

        internal static string TransformarNomeCursoMaiusculas(Curso c)
        {
            return c.nomeCurso.ToUpper();
        }

        internal void InserirCurso()
        {
            Curso c = new Curso();

            Console.Write("Nome do Curso: ");
            c.NomeCurso = Console.ReadLine();
            Console.Write("Numero de Sessões: ");
            c.NumeroSessoes = Console.ReadLine();
            Console.Write("Quantas Horas por Sessão: ");
            c.NumeroHorasPorSessao = Console.ReadLine();

            int chave = 0;
            int contagemChave = listaCursos.Count(p => p.Key.Contains(chave));

            if (contagemChave == 0)
            {
                listaCursos.Add(chave, c);
            }
            else
            {
                listaCursos.Add($"{chave}{contagemChave + 1}", c);
            }
        }
    }
}
