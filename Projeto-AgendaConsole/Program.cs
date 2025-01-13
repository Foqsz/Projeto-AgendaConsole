using System.Runtime.InteropServices;

namespace Projeto_AgendaConsole;

class Program
{
    static void Main(string[] args)
    {
        #region Exibir Menu

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

        #endregion

        #region Exibir Contatos

        static void ExibirContatos(String[] nome, String[] email, int tl)
        {
            Console.WriteLine("Exibindo Contatos:");
            for (int i = 0; i < tl; i++)
            {
                Console.WriteLine("Nome: {0} - E-mail: {1}", nome[i], email[i]);
            }

            Console.ReadKey(); // Aguarda uma tecla ser pressionada
        }

        #endregion

        #region Inserir Contato

        static void
            InserirContato(ref String[] nome, ref String[] email,
                ref int tl) // 'ref' permite passar variáveis por referência, permitindo modificá-las no método
        {
            try
            {
                Console.WriteLine("Inserir Contato:");
                Console.Write("Nome: ");
                nome[tl] = Console.ReadLine();
                Console.Write("E-mail: ");
                email[tl] = Console.ReadLine();
                int pos = LocalizarContato(email, tl, email[tl]);
                if (pos == -1)
                {
                    tl++;
                }
                else
                {
                    Console.WriteLine("E-mail já cadastrado.");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey(); // Aguarda uma tecla ser pressionada
            }
        }

        #endregion

        #region Localizar Contato

        static int LocalizarContato(String[] email, int tl, String emailContato)
        {
            int pos = -1;
            int i = 0;
            while (i < tl && email[i] != emailContato)
            {
                i++;
            }

            if (i < tl)
            {
                pos = i;
            }

            return pos;
        }

        #endregion

        #region Alterar Contato

        static void AlterarContato(ref String[] nome, ref String[] email, ref int tl)
        {
            try
            {
                Console.WriteLine("Alterar Contato:");
                Console.Write("E-mail: ");
                string emailContato = Console.ReadLine();
                int pos = LocalizarContato(email, tl, emailContato);
                if (pos != -1)
                {
                    Console.WriteLine("Novos dados do Contato:");
                    Console.Write("Nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string novoEmail = Console.ReadLine();
                    int posValidacao = LocalizarContato(email, tl, novoEmail);
                    if (posValidacao == -1 || posValidacao == pos) // -1 significa que nao achou nada
                    {
                        nome[pos] = novoNome;
                        email[pos] = novoEmail;
                    }
                    else
                    {
                        Console.WriteLine("Já existe um contato com este e-mail");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Contato não encontrado.");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey(); // Aguarda uma tecla ser pressionada
            }
        }

        #endregion

        #region Dados

        // Armazenamento de dados da agenda
        String[] nome = new string[200];
        String[] email = new string[200];

        int tl = 0; // Tamanho lógico da agenda
        int op = 0; // Opção do menu

        String emailLocalizar = "";

        #endregion

        #region Métodos

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
                    AlterarContato(ref nome, ref email, ref tl);
                    break;
                case 4:
                    //Excluir Contato
                    break;
                case 5:
                    Console.WriteLine("Localizar Contato:");
                    Console.Write("E-mail: ");
                    emailLocalizar = Console.ReadLine();
                    int pos = LocalizarContato(email, tl, emailLocalizar);
                    if (pos != -1)
                    {
                        Console.WriteLine("Nome: {0} - E-mail: {1}", nome[pos], email[pos]);
                    }
                    else
                    {
                        Console.WriteLine("Contato não localizado.");
                    }
                    Console.ReadKey();
                    break;
            }
        }

        #endregion
    }
}