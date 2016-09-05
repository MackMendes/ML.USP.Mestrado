using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.USP.PriAtividade
{
    public sealed class Levenberg
    {
        public decimal[] CalculaGradienteConjugado(decimal x0, decimal x1, out string printResult)
        {
            StringBuilder sb = new StringBuilder();
            int k = 0;
            // Hessiana calculada na mão
            decimal[,] hessiana = { { 4, 0 }, 
                                    { 0, 4 } };
            decimal norma = 0;

            do
            {
                var hessianaT = Transposto(hessiana);





            } while (true);

            printResult = sb.ToString();
            return new decimal[] { Math.Round(x0, 2), Math.Round(x1, 2) };
        }

        private decimal[,] Transposto(decimal[,] matriz)
        {
            decimal[,] transposto = { { matriz[0,0], matriz[1,0] },
                                    { matriz[0,1], matriz[1,1] } };

            return transposto;
        }

        private decimal[,] CalculaGradiente(decimal x0, decimal x1)
        {
            decimal[,] gradiente = new decimal[2,2];
            gradiente[0,0] = Math.Round(4 * (x0 - 2), 4);
            gradiente[1,0] = Math.Round(4 * (x1 - 3), 4);
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
    }
}
