using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos
{
    class Program
    {
        static void Main(string[] args)
        {
            Curso c = new Curso();

            c.InserirCurso();
            Console.ReadLine();
            c.InserirCurso();
            Console.ReadLine();
            c.InserirCurso();
            Console.ReadLine();

            c.CalcularNumerHoras();
            c.MostrarNumeroHorasTotal();
            Console.ReadLine();

            Console.WriteLine($"{Curso.TransformarNomeCursoMaiusculas(c)}");
            Console.ReadLine();

            c.ListarCurso();


        }
    }
}
