using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios02
{
    class Program
    {
        static void Main(string[] args)
        {
            //*** declarando as variáveis necessárias
            string nome, pNome, uNome, email, cpf, sn;
            char sexo;
            byte curso, nProvas, ini, fim;
            // variáveis só para o CPF
            int d1 = 0, d2 = 0;
            int conta = 10, soma = 0, resto = 0;
            bool cpfOk = true;
            // CPF **********
            float nota = 0, media = 0;

            // **************** looping principal**************
            do
            {
                nota = 0; media = 0;
                Console.Clear();
                Console.Write("Digite seu nome Completo: ");
                nome = Console.ReadLine();

                // o método IndexOf() procura um caractere determinado (o primeiro) 
                // em uma string e retorna a posição a partir do ZERO
                ini = (byte)nome.IndexOf(" ");

                // o comando Substring(x, y) retorna um conjunto de caracteres especificados em x e y  
                // onde x é a posição inicial e y é a contagem de quantos caracteres deve-se contar 
                // depois da posição inicial
                pNome = nome.Substring(0, ini);

                // o método LastIndexOf() procura um caractere determinado (o último) 
                // em uma string e retorna a posição a partir do ZERO
                fim = (byte)nome.LastIndexOf(" ");
                uNome = nome.Substring(fim);

                //***** checagem do sexo = só se aceita S ou N
                do
                {
                    Console.Write("Sexo (M/F): ");
                    sexo = char.Parse(Console.ReadLine()); // precisamos converter uma string em char
                    if (char.ToUpper(sexo) != 'M' && char.ToUpper(sexo) != 'F')
                        Console.WriteLine("Sexo inválido! digite novamente");
                } while (char.ToUpper(sexo) != 'M' && char.ToUpper(sexo) != 'F');

                //******************* Checagem do email

                do
                {
                    Console.Write("Email: ");
                    email = Console.ReadLine();
                    // quando usamos o método IndexOf() ou LastIndexOf() e ele não achar o caractere, ele retorna -1
                    if (email.IndexOf("@") < 0 || email.IndexOf(".") < 0 || email.IndexOf(" ") >= 0)
                        Console.WriteLine("Email inválido! digite novamente");
                } while (email.IndexOf("@") < 0 || email.IndexOf(".") < 0 || email.IndexOf(" ") >= 0);

                // *****************Checagem do CPF ********
                //******************************************
                do
                {
                    Console.Write("CPF: ");
                    cpf = Console.ReadLine();
                    // *********** verificar se o CPF tem 11 caracteres
                    // o comanado "continue" em uma estrurura de repetição
                    // força o programa a voltar ao começo do laço

                    if (cpf.Length != 11)
                    {
                        cpfOk = false;
                        continue;
                    }

                    // *** verificar o primeiro dígito
                    d1 = int.Parse(cpf.Substring(9, 1));
                    conta = 10; soma = 0; resto = 0;
                    cpfOk = true;

                    for (int i = 0; i < 9; i++)
                    {
                        soma += int.Parse(cpf.Substring(i, 1)) * conta;
                        conta--;
                    }

                    resto = soma % 11;
                    //**  isto se chama condição ternária
                    //** a variável "resto" recebe o valor 0
                    //** se for verdadeiro 
                    //** o símbolo : represeda "senão"
                    //** senão o resto recebe o valor de 11 - resto
                    resto = (resto < 2) ? (0) : (11 - resto);

                    // ** a expressão -  resto = (resto < 2) ? (0) : (11 - resto);
                    // ** é o mesmo que a condição mostrada abaixo
                    //if (resto < 2)
                    //{
                    //    resto = 0;
                    //}
                    //else
                    //{
                    //    resto = 11 - resto;
                    //}

                    //    Console.WriteLine(resto); usado da verificar o 1° dígito
                    //    Console.ReadKey();

                    if (resto != d1)
                    {
                        cpfOk = false;
                        continue;
                    }

                    d2 = int.Parse(cpf.Substring(10, 1));
                    conta = 11; soma = 0; resto = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        soma += int.Parse(cpf.Substring(i, 1)) * conta;
                        conta--;
                    }

                    resto = soma % 11;
                    resto = (resto < 2) ? (0) : (11 - resto);

                    //if (resto < 2)
                    //{
                    //    resto = 0;
                    //}
                    //else
                    //{
                    //    resto = 11 - resto;
                    //}

                    if (resto != d2)
                    {
                        cpfOk = false;
                        continue;
                    }
                    // Console.WriteLine(resto); usado da verificar o 2° dígito
                    // Console.ReadKey();
                } while (!cpfOk);

                // Fim da checagem do CPF *********************

                // **** seleção do curso
                Console.WriteLine("Selecione o Curso: (1 a 5)");
                Console.WriteLine("1. Básico");
                Console.WriteLine("2. Pré-Intermediário");
                Console.WriteLine("3. Intermediário");
                Console.WriteLine("4. Intermediário-avançado");
                Console.WriteLine("5. Avançado");

                // ***** checagem do curso
                do
                {
                    curso = byte.Parse(Console.ReadLine());
                    if (curso < 1 || curso > 5)
                        Console.WriteLine("Curso inválido! somente de 1 a 5 - digite novamente");
                } while (curso < 1 || curso > 5);

                Console.Write("Digite o número de Provas: ");
                nProvas = byte.Parse(Console.ReadLine());

                // neste looping de for, ele pede ao usuário que insira as notas por quantas vezes o usuário 
                // inseriu na varável nProvas, inseridas na linha anterior
                for (int x = 1; x <= nProvas; x++)
                {
                    Console.Write("{0}° nota:", x);
                    nota = float.Parse(Console.ReadLine());

                    media += nota; // não esqueça:  isso é o mesmo que media = media + nota
                }

                Console.WriteLine("Média Final: {0}", media /= nProvas);

                // ao colocarmos o \n no meio da mensagem, ele pula uma linha
                if (media >= 6)
                    Console.WriteLine("Sr(a). {0} {1}, você está aprovado(a), podendo assim dar \ncontinuidade ao seu curso.", pNome.ToUpper(), uNome.ToUpper());
                else if (media < 6 && media >= 4)
                    Console.WriteLine("Sr(a). {0} {1}, você se encontra de exame, estando pendente \npara o próximo seu módulo.", pNome.ToUpper(), uNome.ToUpper());
                else
                    Console.WriteLine("Sr(a). {0} {1}, você se encontra de reprovado(a), estando \nimpedido de cursar o próximo seu módulo.", pNome.ToUpper(), uNome.ToUpper());

                do
                {
                    Console.Write("Continuar cadastro? (S/N): ");
                    sn = Console.ReadLine();
                    if (sn.ToUpper() != "N" && sn.ToUpper() != "S")
                        Console.WriteLine("Opção Inválida!");
                } while (sn.ToUpper() != "N" && sn.ToUpper() != "S");

            } while (sn.ToUpper() == "S");

        }
    }
}

