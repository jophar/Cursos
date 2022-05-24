using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos
{
    internal class Curso
    {
        // 
        private double duracaoHoras = 0;
        protected double numeroMedioSessoes = 10;
        private List<Curso> listaCursos = new List<Curso>();

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

        internal void CalcularNumerHoras()
        {
            double acc = 0;

            foreach (Curso item in listaCursos)
            {
                acc += (Convert.ToDouble(item.NumeroHorasPorSessao) * Convert.ToDouble(item.NumeroSessoes));
            }

            duracaoHoras = acc;
        }

        internal void MostrarNumeroHorasTotal()
        {
            Console.WriteLine($"Numero total de horas de Formação: {duracaoHoras}h");
            Console.Write("Premir enter para continuar...");
            Console.ReadLine();   
        }

        internal static string TransformarNomeCursoMaiusculas(Curso c)
        {
            return c.NomeCurso.ToUpper();
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

            if (listaCursos.Count == 0)
                c.CursoID = 0;
            else
            {
                c.CursoID = listaCursos.Count + 1;
            }

            listaCursos.Add(c);
        }

        internal List<Curso> DevolverLista()
        {
            return listaCursos;
        }

        internal static void ListarCurso(List<Curso> l)
        {

            foreach (Curso item in l)
            {
                Console.WriteLine($"Nome: {item.NomeCurso}");
            }

            Console.ReadKey();
        }
    }
}
