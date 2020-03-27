using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Separador_arq.Etities;


namespace Separador_arq
{
    class Program
    {
        static void Main(string[] args)

        {

            Console.WriteLine("Digite o caminho completo do arquivo: ");
            string sourcepath = Console.ReadLine();

            //sourcePath = @"C:\Users\vtr_p\Licao\File1.txt";
            //string targetPath = @"C:\Users\vtr_p\Licao\summary.txt";



            try
            {
                string[] lines = File.ReadAllLines(sourcepath);
                string targetPath = Path.GetDirectoryName(sourcepath);

                //Criando uma pasta out
                string targetFolderPath = targetPath + @"\out";
                //Detro da pasta Out cria o arquivo txt
                string targetFilePath = targetFolderPath + @"\summary.txt";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))


                    foreach (string line in lines)
                    {
                        //Corta o arquivo a cada "," encontrada
                        string[] fields = line.Split(',');

                        string nome = fields[0];
                        double preco = double.Parse(fields[1]);
                        int quantidade = int.Parse(fields[2]);

                        Produtos prod = new Produtos(nome, preco, quantidade);
                        sw.WriteLine(prod.Nome + "," + prod.Total().ToString("F2"));
                    }

            }
            catch (IOException e)
            {
                Console.WriteLine("Erro");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
