using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetores
{
    class Program
    {
        static void Main(string[] args)
        {

            //int soma = 0;
            //int[] num = new int[5];


            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write("Digite um número: ");
            //    num[i] = int.Parse(Console.ReadLine());
            //    soma += num[i];
            //}


            //num[0] = 40;
            //num[1] = 60;
            //num[2] = 80;
            //num[3] = 100;
            //num[4] = 120;

            // maneira burra
            //soma = num[0] + num[1] + num[2] + num[3] + num[4];

            //for (int i = 0; i < 5; i++)
            //{
            //    soma += num[i];
            //}

            string[] bandas = new string[6];

            bandas[0] = "The Beatles";
            bandas[1] = "Iron Maiden";
            bandas[2] = "Megadeth";
            bandas[3] = "Aerosmith";
            bandas[4] = "Metallica";
            bandas[5] = "Black Sabath";

            //for (int i = 0; i < 6; i++)
            //{
            //    Console.WriteLine("índice {0} Banda {1}",i, bandas[i]);
            //}

            //int indice = 0;
            //Console.Write("Digite o índice para a substituição: ");
            //indice = int.Parse(Console.ReadLine());

            //Console.Write("Digite a nova banda: "); 
            //bandas[indice] = Console.ReadLine();

            //for (int i = 0; i < 6; i++)
            //{
            //    Console.WriteLine("índice {0} Banda {1}", i, bandas[i]);
            //}

            string nomeBanda;
            Console.Write("Digite o nome de uma banda: ");
            nomeBanda = Console.ReadLine();
            bool ok = false;

            for (int i = 0; i < bandas.Length; i++)
            {
                if (nomeBanda.ToUpper().Trim() == bandas[i].ToUpper().Trim())
                {
                    ok = true;
                    break;
                }
            }


            // o foreach só deve ser usado quando não se necessita  
            // saber o valor do índice

            //foreach (string item in bandas)
            //{
            //    if (nomeBanda.ToUpper().Trim() == item.ToUpper().Trim())
            //    {
            //        ok = true;
            //        break;
            //    }
            //}



            if (ok)
            {
                Console.WriteLine("A banda {0} existe na lista!", nomeBanda.Trim());
            }
            else
            {
                Console.WriteLine("A banda {0} NÃO existe na lista!", nomeBanda.Trim());

            }



            double[] real = new double[4];

            real[0] = 25.8;
            real[1] = 4.8;
            real[2] = 76.41;
            real[3] = 3.9;


            // alguns métodos utilizados com vetores numéricos
            Console.WriteLine(real.Max()); // retorna o maior valor
            Console.WriteLine(real.Min()); // retorna o menor valor
            Console.WriteLine(real.Length); // retorna a quantidade de itens do vetor
            Console.WriteLine(real.Sum()); // retorna a soma total de todos os itens do vetor
            Console.WriteLine(real.Average()); // retorna mádia aritmética de todos os itens do vetor

            // alguns métodos utilizados com vetores string
            // o método Max() em um vetor string retorna o
            // maior valor da ordem alfabética
            // e o método Min() retorna o menor valor
            Console.WriteLine(bandas.Max());
            Console.WriteLine(bandas.Min());

            //    Console.WriteLine(soma);
            Console.ReadKey();


        }
    }
}

