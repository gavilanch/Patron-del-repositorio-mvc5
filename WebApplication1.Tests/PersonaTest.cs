using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Models;

namespace WebApplication1.Tests
{
    [TestClass]
    public class PersonaTest
    {
        [TestMethod]
        public void ValidarModelo_EdadEsMayorQue18_RetornaVerdadero()
        {
            var persona = new Persona();
            persona.Edad = 19;
            persona.Nombre = "Felipe";

            bool resultado = persona.Validar();

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ValidarModelo_NombreEsVacio_RetornaFalso()
        {
            var persona = new Persona();
            persona.Edad = 19;

            bool resultado = persona.Validar();

            Assert.IsFalse(resultado);
        }
    }
}
