using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Servicios;
using WebApplication1.Tests;
using Moq;

namespace WebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _homeController;

        [TestInitialize]
        public void Inicializar()
        {
            var mockServicioPersonas = new Mock<IServicioPersonas>();
            _homeController = new HomeController(mockServicioPersonas.Object);
        }

        [TestMethod]
        public void Index()
        {
            // Act
            ViewResult result = _homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Act
            ViewResult result = _homeController.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {   
            // Act
            ViewResult result = _homeController.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CrearPersona_SiObjetoPersonaEsInvalidoSeAsignaMensajeAViewBag()
        {
            Persona persona = new Persona();
            var mockServicioPersonas = new Mock<IServicioPersonas>();
            mockServicioPersonas.Setup(sp => sp.EsValido(persona)).Returns(false);
            mockServicioPersonas.SetupGet(x => x.Errores).Returns(new List<string>() { "Error" });

            _homeController.ServicioPersonas = mockServicioPersonas.Object;

            var resultado = _homeController.CrearPersona(persona);

            Assert.IsNotNull(resultado.ViewBag.MensajeError);
        }
    }
}
