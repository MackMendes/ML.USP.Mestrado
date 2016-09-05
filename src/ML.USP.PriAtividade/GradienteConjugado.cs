using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.USP.PriAtividade
{
    public sealed class GradienteConjugado
    {
        public decimal[] CalculaGradienteConjugado(decimal x0, decimal x1, out string printResult)
        {
            StringBuilder sb = new StringBuilder();
            decimal[] auxiliar = new decimal[2];
            decimal beta;
            decimal[] direcao = new decimal[2];
            decimal alfa;
            // k = Passo
            int k = 0;
            // Hessiana calculada na mão
            decimal[,] hessiana = { { 4, 0 }, { 0, 4 } };
            decimal norma = 0;
            // Calculando Gradiente
            var gradiente = CalculaGradiente(x0, x1);
            // Calculando função
            var funcao = CalculaFuncao(x0, x1);
            // Calculando Distância
            var distancia = CalculaDistancia(gradiente);

            // Imprindo os valores iniciais
            sb.AppendFormat("\n\n======== Gradiente Conjugado ===========");
            sb.AppendFormat("\n\nX0: {0} , X1: {1}", x0, x1);
            sb.AppendFormat("\nFuncao: {0}", funcao);
            sb.AppendFormat("\nGradiente: dX0: {0} , dX1: {1}", gradiente[0], gradiente[1]);
            sb.AppendFormat("\nDireção: D0: {0} , D1: {1}", distancia[0], distancia[1]);

            do
            {
                alfa = CalculaAlfa(distancia, hessiana);
                x0 = x0 + (alfa * distancia[0]);
                x1 = x1 + (alfa * distancia[1]);

                // Movendo o gradiente para uma variávei auxiliadora
                auxiliar = gradiente;

                // Calculando Gradiente
                gradiente = CalculaGradiente(x0, x1);

                // Calculando o Beta
                beta = CalculaBeta(gradiente, auxiliar);
                
                // Pegando as novas direções
                direcao[0] = -(gradiente[0] + (beta * direcao[0]));
                direcao[1] = -(gradiente[1] + (beta * direcao[1]));
 
                k += 1;
                funcao = CalculaFuncao(x0, x1);

                // Imprimindo as informações
                sb.AppendFormat("\n\n ******* Passo {0} *********", k);
                sb.AppendFormat("\n\nX0: {0} , X1: {1}", x0, x1);
                sb.AppendFormat("\nFuncao: {0}", funcao);
                sb.AppendFormat("\nGradiente: dX0: {0} , dX1: {1}", gradiente[0], gradiente[1]);
                sb.AppendFormat("\nDireção: D0: {0} , D1: {1}", distancia[0], distancia[1]);
                sb.AppendFormat("\nAlfa: {0}", alfa);
                sb.AppendFormat("\nBeta: {0}", beta);

                double preCalcNorma = Math.Sqrt((Math.Pow(Convert.ToDouble(gradiente[0]), 2)) + (Math.Pow(Convert.ToDouble(gradiente[1]), 2)));
                norma = Math.Round(Convert.ToDecimal(preCalcNorma), 2);

            } while (norma >= Convert.ToDecimal(Math.Pow(10.0, -6.0)));

            printResult = sb.ToString();
            return new decimal[] { Math.Round(x0, 2), Math.Round(x1, 2) };
        }

        private decimal CalculaAlfa(decimal[] direcao, decimal[,] hessiana)
        {
            return ((direcao[0] * direcao[0]) + (direcao[1] * direcao[1])) /
                ((direcao[0] * hessiana[0, 0] + direcao[1] * hessiana[1, 0]) * direcao[0] + (direcao[0] * hessiana[0, 1] + direcao[1] * hessiana[1, 1]) * direcao[1]);
        }

        private decimal[] CalculaGradiente(decimal x0, decimal x1)
        {
            decimal[] gradiente = new decimal[2];
            gradiente[0] = Math.Round(4 * (x0 - 2), 4);
            gradiente[1] = Math.Round(4 * (x1 - 3), 4);
            return gradiente;
        }

        private decimal CalculaFuncao(decimal x0, decimal x1)
        {
            return 2 * ((x0 - 2) * (x0 - 2)) + 2 * ((x1 - 3) * (x1 - 3));
        }

        private decimal[] CalculaDistancia(decimal[] gradiente)
        {
            decimal[] direcao = new decimal[2];
            direcao[0] = gradiente[0] * -1;
            direcao[1] = gradiente[1] * -1;
            return direcao;
        }

        private decimal CalculaBeta(decimal[] gradiente, decimal[] auxiliar)
        {
            return ((gradiente[0] * gradiente[0]) + (gradiente[1] * gradiente[1])) / ((auxiliar[0] * auxiliar[0]) + (auxiliar[1] * auxiliar[1]));
        }
    }
}
