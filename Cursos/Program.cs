using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos
{
    class Program
    {
        static void Main()
        {
            Curso c = new Curso();

            c.InserirCurso();
            c.InserirCurso();
            Console.Clear();   

            List<Curso> lista = new List<Curso>();
            lista = c.DevolverLista(); // Metodo interno para extrair a variável da classe
            Curso.ListarCurso(lista);


        }
    }
}
