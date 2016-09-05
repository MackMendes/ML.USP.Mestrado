﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ML.USP.PriAtividade.Test
{
    [TestClass]
    public class GradienteConjugadoTest
    {
        [TestMethod]
        public void Teste_Inicial_Verificar_Convergencia()
        {
            var gradConjugado = new GradienteConjugado();
            var resultCalc = string.Empty;

            //Random randNum = new Random(); (double)randNum.Next(0, 100), (double)randNum.Next(0, 100)
            var resultado = gradConjugado.CalculaGradienteConjugado(0, 0, out resultCalc);

            // Valores para convergi (resultado esperado)
            Assert.AreEqual(2, resultado[0]); // x0 = 2
            Assert.AreEqual(3, resultado[1]); // x1 = 3
        }
    }
}