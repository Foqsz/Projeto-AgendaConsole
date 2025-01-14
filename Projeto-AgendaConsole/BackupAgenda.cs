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
            arquivo.WriteLine(nome[i] + "-" + email[i]); 
        }
        arquivo.Close();
    }  

    public static void RestaurarDados(ref string[] nome, ref string[] email, ref int tl)
    {
        tl = 0;
        int pos = 0;

        StreamReader streamReader = new StreamReader(nomeArquivo);
        string linha = streamReader.ReadLine(); 
        while(linha != null)
        {
            pos = linha.IndexOf('-');
            nome[tl] = linha.Substring(0, pos);
            email[tl] = linha.Substring(pos + 1);
            tl++;
            linha = streamReader.ReadLine();
        }
        streamReader.Close();
    }
}
