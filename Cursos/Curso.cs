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
        // MARIZ: Done!
        private int CalcularNumeroHoras() // ver melhor, é só para fazer por curso
        {
            return NumeroHorasPorSessao * NumeroSessoes;
        }

        // TODO MRS: assim não usas a variável nomeCurso
        // MARIZ: Done?! (não consigo usar para gravar no objecto já em maiusculas mas consigo usar para escrever em maiusculas)
        private string TransformarNomeCursoMaiusculas() // não é preciso passar o objecto.
        {
            return nomeCurso.ToUpper();
        }

        // TODO MRS: não se deve usar o try...catch desta forma, mas sim um no método Main, onde o objeto e os métodos são chamados
        // MARIZ: atualizado para TryParse // TODO: Refaturar o metodo
        protected internal void InserirCurso()
        {
            bool validate;
            string nomeCurso;
            int numSessoes, numHoras, parser;

            Console.WriteLine("Inserção de Curso\n");

            Console.Write("Nome do Curso: ");
            nomeCurso = Console.ReadLine();

            Console.Write("Numero de Sessões: ");
            validate = int.TryParse(Console.ReadLine(), out parser);
            if(validate)    
                numSessoes = parser;
            else
	        {
                Console.WriteLine("Numero inválido, inserido valor default: (1)");
                numSessoes = 1;
	        }

            // Reset Bools and Parser
            validate = true;
            parser = 0;

            Console.Write("Quantas Horas por Sessão: ");
            validate = int.TryParse(Console.ReadLine(), out parser);
            if(validate)    
                numHoras = parser;
            else
	        {
                Console.WriteLine("Numero inválido, inserido valor default: (1)");
                numHoras = 1;
	        }
            

            // Calculo automatico do ID a partir do tamanho da lista
            // TODO MRS: isto não é realista, porque num cenário real posso ter o id 100 e fisicamente ter somente 2 cursos. Deve ser sempre pesquisado o maaior valor do ID e incrementar
            // MARIZ: reescrito o bloco para ler a lista e extrair o ID fazendo comparação de teste e gravando o incremento. Zero Based
            
            // reaproveitar a variavel
            parser = 0; 

            foreach (Curso item in listaCursos)
	        {
                if(item.CursoID > parser)
                    parser = item.CursoID; 
                else
	            {
                    parser++;
	            }

	        }

            Curso c = new Curso(parser, nomeCurso, numSessoes, numHoras);

            listaCursos.Add(c);

            Console.WriteLine($"Curso inserido com sucesso com id {parser}");
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
                string capsCurso = item.TransformarNomeCursoMaiusculas();
                int duracaoTotal = item.CalcularNumeroHoras();

                Console.WriteLine($"Curso ID: {item.CursoID} \n" +
                                  $"\tNome: {capsCurso} \n" +
                                  $"\tNumero Sessoes: {item.NumeroSessoes} \n" +
                                  $"\tNumero de Horas por Sessao: {item.NumeroHorasPorSessao}\n" +
                                  $"\tNumero Total de Horas: {duracaoTotal}\n\n");
            }

            Console.ReadKey();
        }
    }
}