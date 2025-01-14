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

        static void ExibirContatos(string[] nome, string[] email, int tl) // 'tl' é o tamanho lógico da agenda
        {
            Console.WriteLine("Exibindo Contatos:");
            for (int i = 0; i < tl; i++)
            {
                Console.WriteLine("Nome: {0} - E-mail: {1}", nome[i], email[i]); // {0} e {1} são placeholders para os valores de nome[i] e email[i]
            }
            Console.WriteLine("Lista de contato exibida com sucesso.");

            Console.ReadKey(); // Aguarda uma tecla ser pressionada
        }

        #endregion

        #region Inserir Contato

        static void InserirContato(ref string[] nome, ref string[] email, ref int tl) // 'ref' permite passar variáveis por referência, permitindo modificá-las no método
        {
            try
            {
                if (tl >= 200)
                {
                    Console.WriteLine("Agenda cheia.");
                }
                else
                {
                    Console.WriteLine("Inserir Contato:");
                    Console.Write("Nome: ");
                    nome[tl] = Console.ReadLine();
                    Console.Write("E-mail: ");
                    email[tl] = Console.ReadLine();
                    int pos = LocalizarContato(email, tl, email[tl]); // Verifica se o e-mail já está cadastrado
                    if (pos == -1)
                    {
                        tl++; // Incrementa o tamanho lógico da agenda
                        Console.WriteLine("Contato cadastrado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("E-mail já cadastrado.");
                    }
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

        static int LocalizarContato(string[] email, int tl, string emailContato)
        {
            int pos = -1;
            int i = 0;
            while (i < tl && email[i] != emailContato) // Enquanto 'i' for menor que o tamanho lógico e o e-mail for diferente do e-mail do contato
            {
                i++; // Incrementa 'i'
            }

            if (i < tl) // Se 'i' for menor que o tamanho lógico
            {
                pos = i; // Atribui 'i' a 'pos'
            }

            return pos;
        }

        #endregion

        #region Alterar Contato

        static void AlterarContato(ref string[] nome, ref string[] email, ref int tl)
        {
            try
            {
                Console.WriteLine("Alterar Contato:");
                Console.Write("E-mail: ");
                string emailContato = Console.ReadLine();
                int pos = LocalizarContato(email, tl, emailContato); // Verifica se o e-mail já está cadastrado
                if (pos != -1) // Se o contato foi localizado
                {
                    Console.WriteLine("Novos dados do Contato:");
                    Console.Write("Nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("E-mail: ");
                    string novoEmail = Console.ReadLine();
                    int posValidacao = LocalizarContato(email, tl, novoEmail);  
                    if (posValidacao == -1 || posValidacao == pos) // -1 significa que nao achou nada
                    {
                        nome[pos] = novoNome; // Altera o nome do contato
                        email[pos] = novoEmail; // Altera o e-mail do contato
                        Console.WriteLine("Contato alterado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Já existe um contato com este e-mail");

                    }
                    Console.ReadKey();
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

        #region Excluir Contato

        static bool ExcluirContato(ref string[] nome, ref string[] email, ref int tl, string emailContato)
        {
            bool excluido = false; // Variável que indica se o contato foi excluído
            int pos = -1;  
            pos = LocalizarContato(email, tl, emailContato);
            if (pos != -1) // Se o contato foi localizado
            {
                for (int i = pos; i < tl - 1; i++) // Percorre a agenda
                {
                    nome[i] = nome[i + 1];
                    email[i] = email[i + 1];
                }
                excluido = true;
                tl--;
            }
            return excluido;
        }
        #endregion

        #region Dados

        // Armazenamento de dados da agenda
        string[] nome = new string[200];
        string[] email = new string[200];

        int tl = 0; // Tamanho lógico da agenda
        int op = 0; // Opção do menu 
        int pos = 0; // Posição do contato

        string emailLocalizar = "";

        BackupAgenda.nomeArquivo = "agenda.txt";
        BackupAgenda.RestaurarDados(ref nome, ref email, ref tl);

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
                    Console.WriteLine("Excluir Contato:");
                    Console.Write("E-mail: ");
                    emailLocalizar = Console.ReadLine();
                    if (ExcluirContato(ref nome, ref email, ref tl, emailLocalizar))
                    {
                        Console.WriteLine("Contato excluído com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Contato não localizado.");
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    Console.WriteLine("Localizar Contato:");
                    Console.Write("E-mail: ");
                    emailLocalizar = Console.ReadLine();
                    pos = LocalizarContato(email, tl, emailLocalizar);
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
        BackupAgenda.SalvarDados(ref nome, ref email, ref tl);
        #endregion
    }
}
