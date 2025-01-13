using System.Runtime.InteropServices;

namespace Projeto_AgendaConsole;

class Program
{
    static void Main(string[] args)
    {
        static int ExibirMenu() //Função que pertence a classe
        {
            int op = 0;
            Console.Clear();
            Console.WriteLine("Agenda Modo Console");
            Console.WriteLine("1 - Exibir Contatos");
            Console.WriteLine("2 - Inserir Contato");
            Console.WriteLine("3 - Alterar Contato");
            Console.WriteLine("4 - Excluir Contato");
            Console.WriteLine("5 - Localizar Contato");
            Console.WriteLine("6 - Sair");
            Console.Write("Opção: ");
            op = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return op;
        }

        static void ExibirContatos(String[] nome, String[] email, int tl)
        {
            Console.WriteLine("Exibindo Contatos:");
            for (int i = 0; i < tl; i++)
            {
                Console.WriteLine("Nome: {0} - E-mail: {1}", nome[i], email[i]);
            } 
            Console.ReadKey(); // Aguarda uma tecla ser pressionada
        }

        static void InserirContato(ref String[] nome, ref String[] email, ref int tl) // 'ref' permite passar variáveis por referência, permitindo modificá-las no método
        {
            try
            {
                Console.WriteLine("Inserir Contato:");
                Console.Write("Nome: ");
                nome[tl] = Console.ReadLine();
                Console.Write("E-mail: ");
                email[tl] = Console.ReadLine();
                tl++;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey(); // Aguarda uma tecla ser pressionada
            } 
        }

        // Armazenamento de dados da agenda
        String[] nome = new string[200];
        String[] email = new string[200];

        int tl = 0; // Tamanho lógico da agenda
        int op = 0; // Opção do menu

        //nome[0] = "João";
        //email[0] = "joao@gmail.com";
        //tl++;

        //nome[tl] = "Maria";
        //email[tl] = "maria@gmail.com";
        //tl++;

        //nome[tl] = "José";
        //email[tl] = "jose@gmail.com";
        //tl++;

        while (op != 6)
        {
            op = ExibirMenu();

            switch (op)
            {
                case 1:
                    ExibirContatos(nome, email, tl);
                    break;
                case 2:
                    InserirContato(ref nome, ref email, ref tl);
                    break;
                case 3:
                    //Alterar Contato
                    break;
                case 4:
                    //Excluir Contato
                    break;
                case 5:
                    //Localizar Contato
                    break;
            }
        }
    }
}