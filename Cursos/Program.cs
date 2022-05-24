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
            c.MostrarNumeroHorasTotal(); // Metodo interno para extrair a variavel da classe
            Console.ReadLine();

            List<Curso> lista = new List<Curso>();

            lista = c.DevolverLista(); // Metodo interno para extrair a variável da classe
            Curso.ListarCurso(lista);


        }
    }
}
