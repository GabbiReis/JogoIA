using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIA
{
    internal class Program
    {
        static void Main(string[] args)
        {

            JogoDaVelha jogo = new JogoDaVelha();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu do Jogo da Velha ===");
                Console.WriteLine("1. Jogar contra o Computador");
                Console.WriteLine("2. Sair");
                Console.Write("Escolha uma opção: ");
                string escolha = Console.ReadLine();

                if (escolha == "1")
                {
                    JogarContraComputador(jogo);
                }
                else if (escolha == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                }
            }
        }

        static void JogarContraComputador(JogoDaVelha jogo)
        {
            bool fimDeJogo = false;

            while (!fimDeJogo)
            {
                Console.Clear();
                ExibirTabuleiro(jogo);
                Console.WriteLine("Seu turno. Escolha uma posição ( Primeiro a linha e depois a coluna): ");

                int linha = -1, coluna = -1;
                while (linha < 0 || linha > 2 || coluna < 0 || coluna > 2)
                {
                    Console.Write("Linha entre as opções (0, 1, 2): ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write("Coluna entre as opções (0, 1, 2): ");
                    coluna = int.Parse(Console.ReadLine());
                }

                jogo.Jogar(linha, coluna);

                if (jogo.VerificaVitoria('X'))
                {
                    Console.Clear();
                    ExibirTabuleiro(jogo);
                    Console.WriteLine("Você venceu!");
                    fimDeJogo = true;
                }
                else if (jogo.TabuleiroCheio())
                {
                    Console.Clear();
                    ExibirTabuleiro(jogo);
                    Console.WriteLine("Empate!");
                    fimDeJogo = true;
                }
                else
                {
                    jogo.JogarComputador();

                    if (jogo.VerificaVitoria('O'))
                    {
                        Console.Clear();
                        ExibirTabuleiro(jogo);
                        Console.WriteLine("O computador venceu!");
                        fimDeJogo = true;
                    }
                    else if (jogo.TabuleiroCheio())
                    {
                        Console.Clear();
                        ExibirTabuleiro(jogo);
                        Console.WriteLine("Empate!");
                        fimDeJogo = true;
                    }
                }
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        static void ExibirTabuleiro(JogoDaVelha jogo)
        {
            char[,] tabuleiro = jogo.ObterTabuleiro();

            Console.Clear();
            Console.WriteLine("   0   1   2 ");
            Console.WriteLine("0  {0} | {1} | {2}", Formatar(tabuleiro[0, 0]), Formatar(tabuleiro[0, 1]), Formatar(tabuleiro[0, 2]));
            Console.WriteLine("  ---|---|---");
            Console.WriteLine("1  {0} | {1} | {2}", Formatar(tabuleiro[1, 0]), Formatar(tabuleiro[1, 1]), Formatar(tabuleiro[1, 2]));
            Console.WriteLine("  ---|---|---");
            Console.WriteLine("2  {0} | {1} | {2}", Formatar(tabuleiro[2, 0]), Formatar(tabuleiro[2, 1]), Formatar(tabuleiro[2, 2]));
        }

        static char Formatar(char c)
        {
            return c == '\0' ? ' ' : c;
        }
    }
}
