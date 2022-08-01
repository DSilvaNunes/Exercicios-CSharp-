using System;
using System.Collections.Generic;

namespace Uniube_Folha_Pagamento
{
	public class Program
	{
		public static List<Funcionario> funcionarios;

		static void Main(string[] args)
		{
			funcionarios = new List<Funcionario>();
			funcionarios.Clear();

			int opcao;
			bool ok = false;
			string nomeFuncionario = "";

			do
			{
				try
				{
					Console.Clear();
					Console.WriteLine("Folha de pagamento - Escolha uma das opções:");
					Console.WriteLine("1-Gerente");
					Console.WriteLine("2-Vendedor");
					Console.WriteLine("3-Faxineiro Noturno");
					Console.WriteLine("4-Faxineiro Diurno");
					Console.WriteLine("5-Programador Junior");
					Console.WriteLine("6-Programador Senior");
					Console.WriteLine("7-Programador Pleno");
					Console.WriteLine("8-Listar Todos");
					Console.WriteLine("9-Consultar Valor Total");
					Console.WriteLine("10-Sair");


					opcao = int.Parse(Console.ReadLine());

					if (opcao > 10 || opcao < 0)
					{
						Console.WriteLine("Opção inválida - Digite de 1 a 10 ");
						Console.ReadKey();
						continue;
					}

				}
				catch
				{
					Console.WriteLine("Opção inválida - Digite de 1 a 10");
					Console.ReadKey();
					continue;
				}


				if (opcao != 8 && opcao != 9 && opcao != 10)
				{
					Console.WriteLine("Insira o nome do(a) funcionário(a):");
					nomeFuncionario = Console.ReadLine();
				}

				switch (opcao)
				{

					case 1: //metodo gerente
						funcionarios.Add(new Funcionario().InsereGerente(nomeFuncionario));

						break;

					case 2: //metodo vendedor
						funcionarios.Add(new Funcionario().InsereVendedor(nomeFuncionario));

						break;

					case 3: // método faxineiro
					case 4: // método faxineiro

						if (opcao == 3)
						{
							funcionarios.Add(new Funcionario().InsereFaxineiro(nomeFuncionario, "Faxineiro noturno", true));
						}
						else if (opcao == 4)
						{
							funcionarios.Add(new Funcionario().InsereFaxineiro(nomeFuncionario, "Faxineiro diurno", false));
						}

						break;

					case 5: //método programador//
					case 6: //método programador//
					case 7: //método programador//

						if (opcao == 5)
						{
							funcionarios.Add(new Funcionario().InsereProgramador(nomeFuncionario, "Programador Júnior", 30));
						}
						else if (opcao == 6)
						{
							funcionarios.Add(new Funcionario().InsereProgramador(nomeFuncionario, "Programador Senior", 80));
						}
						else if (opcao == 7)
						{
							funcionarios.Add(new Funcionario().InsereProgramador(nomeFuncionario, "Programador Pleno", 45));
						}
						break;

					case 8:

						FolhaDePagamento();

						break;

					case 9:

						double valorTotal = 0;

						if (funcionarios.Count > 0)
						{
							foreach (Funcionario funcionario in funcionarios)
							{
								valorTotal = valorTotal + funcionario.CalculaSalario();
							}
							Console.Write("Valor total: " + valorTotal.ToString());
							Console.ReadKey();
						}
						else
						{
							Console.WriteLine("Nenhum funcionário cadastrado");
							Console.ReadKey();
						}

						break;

					case 10:

						ok = true;

						break;
				}


			} while (!ok);

		}
		static void FolhaDePagamento()
		{
			double valorTotal = 0;
			double salario = 0;

			if (funcionarios.Count > 0)
			{
				Console.WriteLine("".PadRight(136, '-'));
				Console.Write("|");
				Console.Write("Nome".PadRight(30));
				Console.Write("|");
				Console.Write("Função".PadRight(20));
				Console.Write("|");
				Console.Write("Bônus".PadRight(10));
				Console.Write("|");
				Console.Write("Horas trabalhadas");
				Console.Write("|");
				Console.Write("Vendas realizadas");
				Console.Write("|");
				Console.Write("Valor fixo".PadRight(17));
				Console.Write("|");
				Console.Write("Salário total".PadRight(17));
				Console.WriteLine("|");

				Console.WriteLine("".PadRight(136, '-'));
				foreach (Funcionario funcionario in funcionarios)
				{
					salario = funcionario.CalculaSalario();
					valorTotal = valorTotal + salario;

					Console.Write("|");
					Console.Write(funcionario.nome.PadRight(30));
					Console.Write("|");
					Console.Write(funcionario.funcao.PadRight(20));
					Console.Write("|");
					Console.Write(funcionario.bonus.ToString().PadRight(10));
					Console.Write("|");
					Console.Write(funcionario.horasTrabalhadas.ToString().PadRight(17));
					Console.Write("|");
					Console.Write(funcionario.vendasRealizadas.ToString().PadRight(17));
					Console.Write("|");
					Console.Write(funcionario.valorFixo.ToString().PadRight(17));
					Console.Write("|");
					Console.Write(salario.ToString().PadRight(17));
					Console.WriteLine("|");
				}

				Console.WriteLine("".PadRight(136, '-'));
				Console.Write("Valor total: " + valorTotal.ToString());
				Console.ReadKey();
			}
			else
			{
				Console.WriteLine("Nenhum funcionário cadastrado");
			}
		}

	}

	public class Funcionario
	{
		public String nome;
		public String funcao;
		public float valorHora;
		public float bonus;
		public int horasTrabalhadas;
		public float vendasRealizadas;
		public float valorFixo;
		public bool hasAdicionalNoturno;

		public Funcionario() { }

		public Funcionario(String nome, String funcao, float valorHora, float bonus, int horasTrabalhadas, float vendasRealizadas, float valorFixo, bool hasAdicionalNoturno)
		{
			this.nome = nome;
			this.funcao = funcao;
			this.valorHora = valorHora;
			this.horasTrabalhadas = horasTrabalhadas;
			this.vendasRealizadas = vendasRealizadas;
			this.valorFixo = valorFixo;
			this.hasAdicionalNoturno = hasAdicionalNoturno;
			this.bonus = bonus;
		}

		public Funcionario InsereGerente(String nomeGerente)
		{
			int horas;

			Console.WriteLine("Insira a quantidade de horas trabalhadas:");
			horas = int.Parse(Console.ReadLine());

			return new Funcionario(nomeGerente, //nome
				"Gerente", //função
				160,//valor da hora 
				1000, //bônus fixo 
				horas, //horas trabalhadas
				0,//vendas realizadas
				0,//valor fixo de salário
				false //adicional noturno
				);

		}

		public Funcionario InsereVendedor(String nomeVendedor)
		{
			float valorSalario = 0;
			float vendasRealizadas = 0;

			Console.WriteLine("Insira o valor fixo do salário:");
			valorSalario = float.Parse(Console.ReadLine());

			Console.WriteLine("Insira a quantidade de vendas realizadas:");
			vendasRealizadas = float.Parse(Console.ReadLine());

			return new Funcionario(nomeVendedor, //nome
				"Vendedor", //função
				0, //valor da hora 
				0, //bônus fixo 
				0, //horas trabalhadas
				vendasRealizadas, //vendas realizadas
				valorSalario, //valor fixo de salário
				false //adicional noturno
			);
		}

		public Funcionario InsereFaxineiro(String nomeFaxineiro, String funcao, bool hasAdicionalNoturno)
		{

			float valorSalario = 0;

			Console.WriteLine("Insira o valor fixo do salário:");
			valorSalario = float.Parse(Console.ReadLine());

			return new Funcionario(nomeFaxineiro, //nome
				funcao, //função
				0,//valor da hora 
				0, //bônus fixo 
				0, //horas trabalhadas
				0,//vendas realizadas
				valorSalario,//valor fixo de salário
				hasAdicionalNoturno //adicional noturno
			);

		}

		public Funcionario InsereProgramador(String nomeProgramador, String funcao, float valor_hora)
		{
			int horas = 0;

			Console.WriteLine("Insira a quantidade de horas trabalhadas:");
			horas = int.Parse(Console.ReadLine());

			return new Funcionario(nomeProgramador, //nome
			funcao, //função
			valor_hora,//valor da hora 
			0, //bônus fixo 
			horas, //horas trabalhadas
			0,//vendas realizadas
			0,//valor fixo de salário
			false //adicional noturno
			);
		}


		public double CalculaSalario()
		{
			return (valorHora * horasTrabalhadas) + bonus + valorFixo +
				   (vendasRealizadas * 0.2) +
				   (hasAdicionalNoturno ? valorFixo * 0.05 : 0);
		}
	}
}