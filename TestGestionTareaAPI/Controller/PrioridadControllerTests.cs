using Aplicacion.Interface;
using Dominio.Modelo;
using DTO.DTO;
using GestionTareaAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestGestionTareaAPI.Controller
{
    [TestFixture]
    public class PrioridadControllerTests
    {

        private PrioridadController _PrioridadController;
        private Mock<IServBase<PrioridadDom, string>> _mockServicio;

        [SetUp]
        public void Setup()
        {
            _mockServicio = new Mock<IServBase<PrioridadDom, string>>();
            _PrioridadController = new PrioridadController(_mockServicio.Object);
        }

        [Test]
        public void ObtenerTodo_DebeRetornarOkConListaDePrioridads()
        {
            // Arrange
            var Prioridads = new List<PrioridadDom>
            {
                new PrioridadDom { codPrioridad = "baja", nombrePrioridad = "Baja" },
                new PrioridadDom { codPrioridad = "media", nombrePrioridad = "Media" },
                new PrioridadDom { codPrioridad = "alta", nombrePrioridad = "Alta" }
            };
            _mockServicio.Setup(s => s.ObtenerTodo()).Returns(Prioridads);

            // Act
            var resultado = _PrioridadController.ObtenerTodo().Result as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
            Assert.That(resultado.Value, Is.InstanceOf<List<PrioridadDTO>>());
            Assert.That(((List<PrioridadDTO>)resultado.Value).Count, Is.EqualTo(Prioridads.Count));
        }

        [Test]
        public void ObtenerPorID_DebeRetornarOkConPrioridadExistente()
        {
            // Arrange
            var codPrioridad = "baja";
            var nombrePrioridad = "Baja";

            var Prioridad = new PrioridadDom { codPrioridad = codPrioridad, nombrePrioridad = nombrePrioridad };
            _mockServicio.Setup(s => s.ObtenerPorID(codPrioridad)).Returns(Prioridad);

            // Act
            var resultado = _PrioridadController.ObtenetPorID(codPrioridad).Result as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
            Assert.That(resultado.Value, Is.InstanceOf<PrioridadDTO>());
            Assert.That(((PrioridadDTO)resultado.Value).codPrioridad, Is.EqualTo(Prioridad.codPrioridad));
        }

        [Test]
        public void Insertar_DebeRetornarOk()
        {
            // Arrange
            var nuevoPrioridad = new PrioridadDTO { codPrioridad = "baja", nombrePrioridad = "Baja" };

            // Act
            var resultado = _PrioridadController.Insertar(nuevoPrioridad) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Actualizar_DebeRetornarOk()
        {
            // Arrange
            var PrioridadActualizado = new PrioridadDTO { codPrioridad = "baja", nombrePrioridad = "Baja" };

            // Act
            var resultado = _PrioridadController.Actualizar(PrioridadActualizado) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Eliminar_DebeRetornarOk()
        {
            // Arrange
            var codPrioridad = "baja";

            // Act
            var resultado = _PrioridadController.Eliminar(codPrioridad) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }
    }
}