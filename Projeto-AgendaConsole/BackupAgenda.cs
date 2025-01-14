using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_AgendaConsole;

internal class BackupAgenda
{
    public static string nomeArquivo = "agenda.txt";

    public static void SalvarDados(ref string[] nome, ref string[] email, ref int tl)
    {
        StreamWriter arquivo = new StreamWriter(nomeArquivo);
        for(int i = 0; i < tl; i++)
        {
            arquivo.WriteLine("Nome: " + nome[i] + " - Email: " + email[i]); 
        }
        arquivo.Close();
    }  

    public static void RestaurarDados(ref string[] nome, ref string[] email, ref int tl)
    {

    }
}
