using System;
using Caelum.Leilao;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    class PalindromoTest
    {
        private Palindromo palindromo;

        [SetUp]
        public void SetUp()
        {
            palindromo = new Palindromo();
        }

        [Test]
        public void DeveIdentificarPalindromo()
        {
            Assert.IsTrue(palindromo.EhPalindromo("Socorram-me subi no onibus em Marrocos"));
        }

        [Test]
        public void DeveIdentificarSeNaoEhPalindromo()
        {
            Assert.IsFalse(palindromo.EhPalindromo("E preciso amar as pessoas como se nao houvesse amanha"));
        }
    }
}
