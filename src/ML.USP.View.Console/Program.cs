using ML.USP.PriAtividade;
using System;

namespace ML.USP.View.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultadoImpresso = string.Empty;

            // ===== Gradiente Descente
            var gradiente = new GradienteDescente();
            gradiente.CalculaGradienteDescente(0, 0, out resultadoImpresso);
            Console.WriteLine(resultadoImpresso);

            // ===== Gradiente Conjugado
            var conjugado = new GradienteConjugado();
            conjugado.CalculaGradienteConjugado(0, 0, out resultadoImpresso);
            Console.WriteLine(resultadoImpresso);

            Console.ReadKey();


        }
    }
}
