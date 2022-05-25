using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DUVIDAS:
// como é que criando duas instancias do objecto ele grava na mesma lista?
// é errado criar um objecto dentro da própria classe?
namespace Cursos
{
    internal class Curso
    {
        // Variáveis
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
        internal int NumeroSessoes { get; set; }
        internal int NumeroHorasPorSessao { get; set; }

        // Constructos

        internal Curso()
        {
            CursoID = 0;
            NomeCurso = string.Empty;
            NumeroSessoes = 0;
            NumeroHorasPorSessao = 0;
        }

        internal Curso(int id, string nome, int sessoes, int horas)
        {
            CursoID = id;
            NomeCurso = nome;
            NumeroSessoes = sessoes;
            NumeroHorasPorSessao = horas;
        }

        // TODO MRS: assim não usas a variável duracaoHoras
        private static int CalcularNumeroHoras(Curso c) // ver melhor, é só para fazer por curso
        {
            return c.NumeroHorasPorSessao * c.NumeroSessoes;
        }

        // TODO MRS: assim não usas a variável nomeCurso
        private static string TransformarNomeCursoMaiusculas(string s) // não é preciso passar o objecto.
        {
            return s.ToUpper();
        }

        // TODO MRS: não se deve usar o try...catch desta forma, mas sim um no método Main, onde o objeto e os métodos são chamados
        protected internal void InserirCurso()
        {
            string nomeCurso;
            int numSessoes, numHoras, id;

            Console.WriteLine("Inserção de Curso\n");

            Console.Write("Nome do Curso: ");
            nomeCurso = Console.ReadLine();

            try // teste ao numero de sessoes
            {
                Console.Write("Numero de Sessões: ");
                numSessoes = Convert.ToInt16(Console.ReadLine());
            } 
            catch(System.FormatException)
            { 
                Console.WriteLine("Numero inválido, inserido valor default: (1)");
                numSessoes = 1;
            }

            try // teste ao numero de horas por sessao
            {
                Console.Write("Quantas Horas por Sessão: ");
                numHoras = Convert.ToInt16(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Numero inválido, inserido valor default: (1)");
                numHoras = 1;
            }

            // Calculo automatico do ID a partir do tamanho da lista
            // TODO MRS: isto não é realista, porque num cenário real posso ter o id 100 e fisicamente ter somente 2 cursos. Deve ser sempre pesquisado o maaior valor do ID e incrementar
            if (listaCursos.Count == 0)
                id = 1;
            else
            {
                id = listaCursos.Count + 1;
            }

            nomeCurso = TransformarNomeCursoMaiusculas(nomeCurso);

            Curso c = new Curso(id, nomeCurso, numSessoes, numHoras);

            listaCursos.Add(c);

            Console.WriteLine($"Curso inserido com sucesso com id {id}");
            Console.WriteLine("Premir enter para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        internal List<Curso> DevolverLista()
        {
            return listaCursos;
        }

        protected internal static void ListarCurso(List<Curso> l)
        {

            foreach (Curso item in l)
            {
                int duracaoTotal = 0;
                duracaoTotal = CalcularNumeroHoras(item);

                Console.WriteLine($"Curso ID: {item.CursoID} \n" +
                                  $"\tNome: {item.NomeCurso} \n" +
                                  $"\tNumero Sessoes: {item.NumeroSessoes} \n" +
                                  $"\tNumero de Horas por Sessao: {item.NumeroHorasPorSessao}\n" +
                                  $"\tNumero Total de Horas: {duracaoTotal}\n\n");
            }

            Console.ReadKey();
        }
    }
}
  
