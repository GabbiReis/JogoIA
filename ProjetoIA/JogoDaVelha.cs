using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIA
{
    public class JogoDaVelha
    {
        private char[,] tabuleiro = new char[3, 3];
        private char jogador = 'X';
        private char computador = 'O';

        public int CalcularPontuacao(int linha, int coluna)
        {
            int pontos = 0;

            if (linha == 1 && coluna == 1) pontos += 2;

            if ((linha == 0 || linha == 2) && (coluna == 0 || coluna == 2)) pontos += 1;

            if (VerificarAmeaca(linha, coluna)) pontos -= 2;

            if (ImpedeVitoriaAdversario(linha, coluna)) pontos += 4;

            if (LevaAVitoria(linha, coluna)) pontos += 4;

            return pontos;
        }

        private bool VerificarAmeaca(int linha, int coluna)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[linha, i] == jogador || tabuleiro[i, coluna] == jogador) return true;
            }
            if (linha == coluna)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (tabuleiro[i, i] == jogador) return true;
                }
            }
            if (linha + coluna == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (tabuleiro[i, 2 - i] == jogador) return true;
                }
            }
            return false;
        }
        private bool ImpedeVitoriaAdversario(int linha, int coluna)
        {
            tabuleiro[linha, coluna] = computador;
            bool impede = VerificaVitoria(jogador);
            tabuleiro[linha, coluna] = '\0';
            return impede;
        }

        public bool LevaAVitoria(int linha, int coluna)
        {
            tabuleiro[linha, coluna] = computador;
            bool vitoria = VerificaVitoria(computador);
            tabuleiro[linha, coluna] = '\0';
            return vitoria;
        }

        public bool VerificaVitoria(char jogador)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == jogador && tabuleiro[i, 1] == jogador && tabuleiro[i, 2] == jogador) return true;
                if (tabuleiro[0, i] == jogador && tabuleiro[1, i] == jogador && tabuleiro[2, i] == jogador) return true;
            }
            if (tabuleiro[0, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 2] == jogador) return true;
            if (tabuleiro[0, 2] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 0] == jogador) return true;

            return false;
        }

        public (int, int) EscolherMelhorPosicao()
        {
            int melhorPontuacao = int.MinValue;
            (int, int) melhorPosicao = (-1, -1);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == '\0')
                    {
                        int pontuacao = CalcularPontuacao(i, j);
                        if (pontuacao > melhorPontuacao)
                        {
                            melhorPontuacao = pontuacao;
                            melhorPosicao = (i, j);
                        }
                    }
                }
            }
            return melhorPosicao;
        }

        public void Jogar(int linha, int coluna)
        {
            if (tabuleiro[linha, coluna] == '\0')
            {
                tabuleiro[linha, coluna] = jogador;
            }
        }

        public void JogarComputador()
        {
            var (linha, coluna) = EscolherMelhorPosicao();
            tabuleiro[linha, coluna] = computador;
        }

        public char[,] ObterTabuleiro()
        {
            return tabuleiro;
        }

        public bool TabuleiroCheio()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] == '\0') return false;
                }
            }
            return true;
        }
    }


}
