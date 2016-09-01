using System;
using Caelum.Leilao;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    class PalindromoTest
    {
        [Test]
        public void DeveIdentificarPalindromo()
        {
            Palindromo palindromo = new Palindromo();
            bool res = palindromo.EhPalindromo("Socorram-me subi no onibus em Marrocos");
            Assert.IsTrue(res);
        }

        [Test]
        public void DeveIdentificarSeNaoEhPalindromo()
        {
            Palindromo palindromo = new Palindromo();
            bool res = palindromo.EhPalindromo("E preciso amar as pessoas como se nao houvesse amanha");
            Assert.IsFalse(res);
        }
    }
}
