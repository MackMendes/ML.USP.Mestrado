using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.USP.PriAtividade
{
    public sealed class Levenberg
    {
        private readonly decimal[,] gradienteR = { { 4, 0 }, { 0, 4 } };

        public decimal[] CalculaLevenberg(decimal x0, decimal x1, out string printResult)
        {
            StringBuilder sb = new StringBuilder();
            int k = 0;
         
            decimal norma = 0;
            decimal[,] hessiana;

            do
            {
                var gradienteRTransp = Transposto(gradienteR);
                hessiana = Hessiana();




            } while (true);

            printResult = sb.ToString();
            return new decimal[] { Math.Round(x0, 2), Math.Round(x1, 2) };
        }

        private decimal[,] Hessiana()
        {
            var gradienteRTransp = Transposto(gradienteR);
            var gradienteRJob = gradienteR;

            return MultiMatriz (gradienteRJob, gradienteRJob);
        }

        private decimal[,] MultiMatriz(decimal[,] matriz1, decimal[,] matriz2)
        {
            decimal[,] multi = { { matriz1[0, 0] * matriz2[0, 0], matriz1[0, 1] * matriz2[0, 1] },
                                    { matriz1[1, 0] * matriz2[1, 0], matriz1[1, 1] * matriz2[1, 1] }
            };

            return multi;
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
