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
            return op;
        }

        // Armazenamento de dados da agenda
        String[] nome = new string[200];
        String[] email = new string[200];

        int tl = 0; // Tamanho lógico da agenda
        int op = 0; // Opção do menu

        while (op != 6)
        {
            op = ExibirMenu();

            switch (op)
            {
                case 1:
                    //Exibir Dados
                    break;
                case 2:
                    //Inserir Contato
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