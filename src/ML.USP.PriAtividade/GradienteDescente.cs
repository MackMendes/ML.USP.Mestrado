using System;
using System.Text;

namespace ML.USP.PriAtividade
{
    public sealed class GradienteDescente
    {
        /*
            A função ser otimiza:
            f(x1,x2) = 2*(x1 - 2)^2 + 2*(x2 - 3)^2;
         */

        public double[] CalculaGradienteDescente(double x0, double x1, out string printResult)
        {
            StringBuilder sb = new StringBuilder();
            double alfa = 0.1;
            decimal norma = 0;
            int k = 0;
            double preCalcNorma;

            // Direção do Vetor
            double[] direcao = new double[2];

            double[] gradiente = CalculaGradiente(x0, x1);
            double result = CalculaFuncao(x0, x1);

            // Imprimindo os valores iniciais
            sb.AppendFormat("======== Gradiente Descente ===========\n");
            sb.AppendFormat("\n**INICIANDO **X0: {0} , X1: {1} .**Função: {2} **Gradiente: dX0: {3} , dX1: {4}", x0, x1, result, gradiente[0], gradiente[1]);

            do
            {
                k += 1;

                //Calculando distância
                direcao = CalculaDistancia(gradiente);

                // Calculando os novos valores de X0 e X1
                x0 = Math.Round(x0 + (alfa * direcao[0]), 4);
                x1 = Math.Round(x1 + (alfa * direcao[1]), 4);

                //Calculando função
                result = CalculaFuncao(x0, x1);
                // Calculando Gradiente
                gradiente = CalculaGradiente(x0, x1);

                // No calcula da norma, tive que utilizar duas casas decimais para conseguir convergi...
                preCalcNorma = Math.Sqrt((Math.Pow(gradiente[0], 2)) + (Math.Pow(gradiente[1], 2)));
                norma = Math.Round(Convert.ToDecimal(preCalcNorma), 2);

                // Imprimindo os valores iniciais
                sb.AppendFormat("\n**Passo: {0} **X0: {1} , X1: {2} .**Função: {3} **Gradiente: dX0: {4} , dX1: {5} **Norma: {6}", 
                    k, Math.Round(x0, 2), Math.Round(x1, 2), result, gradiente[0], gradiente[1], norma);

            } while (norma >= Convert.ToDecimal(Math.Pow(10.0, -6.0)));

            printResult = sb.ToString();
            return new double[] { Math.Round(x0, 2), Math.Round(x1, 2) };
        }

        private double CalculaFuncao(double x0, double x1)
        {
            return 2 * ((x0 - 2) * (x0 - 2)) + 2 * ((x1 - 3) * (x1 - 3));
        }

        private double[] CalculaGradiente(double x0, double x1)
        {
            double[] gradiente = new double[2];
            gradiente[0] = Math.Round(4 * (x0 - 2), 4);
            gradiente[1] = Math.Round(4 * (x1 - 3), 4);
            return gradiente;
        }

        private double[] CalculaDistancia(double[] gradiente)
        {
            double[] direcao = new double[2];
            direcao[0] = gradiente[0] * -1;
            direcao[1] = gradiente[1] * -1;
            return direcao;
        }
    }
}
