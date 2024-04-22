using Aplicacion.Interface;
using Dominio.Modelo;
using DTO.DTO;
using GestionTareaAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestGestionTareaAPI.Controller
{
    public class EstadoControllerTests
    {

        private EstadoController _estadoController;
        private Mock<IServBase<EstadoDom, string>> _mockServicio;

        [SetUp]
        public void Setup()
        {
            _mockServicio = new Mock<IServBase<EstadoDom, string>>();
            _estadoController = new EstadoController(_mockServicio.Object);
        }

        [Test]
        public void ObtenerTodo_DebeRetornarOkConListaDeEstados()
        {
            // Arrange
            var estados = new List<EstadoDom>
            {
                new EstadoDom { codEstado = "nueva", nombreEstado = "Nueva" },
                new EstadoDom { codEstado = "activa", nombreEstado = "Activa" },
                new EstadoDom { codEstado = "enProceso", nombreEstado = "En Proceso" },
                new EstadoDom { codEstado = "finalizada", nombreEstado = "Finalizada" },
                new EstadoDom { codEstado = "cancelada", nombreEstado = "Cancelada" },
            };
            _mockServicio.Setup(s => s.ObtenerTodo()).Returns(estados);

            // Act
            var resultado = _estadoController.ObtenerTodo().Result as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
            Assert.That(resultado.Value, Is.InstanceOf<List<EstadoDTO>>());
            Assert.That(((List<EstadoDTO>)resultado.Value).Count, Is.EqualTo(estados.Count));
        }

        [Test]
        public void ObtenerPorID_DebeRetornarOkConEstadoExistente()
        {
            // Arrange
            var codEstado = "nueva";
            var nombreEstado = "Nueva";

            var estado = new EstadoDom { codEstado = codEstado, nombreEstado = nombreEstado };
            _mockServicio.Setup(s => s.ObtenerPorID(codEstado)).Returns(estado);

            // Act
            var resultado = _estadoController.ObtenetPorID(codEstado).Result as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
            Assert.That(resultado.Value, Is.InstanceOf<EstadoDTO>());
            Assert.That(((EstadoDTO)resultado.Value).codEstado, Is.EqualTo(estado.codEstado));
        }

        [Test]
        public void Insertar_DebeRetornarOk()
        {
            // Arrange
            var nuevoEstado = new EstadoDTO { codEstado = "nueva", nombreEstado = "Nueva" };

            // Act
            var resultado = _estadoController.Insertar(nuevoEstado) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Actualizar_DebeRetornarOk()
        {
            // Arrange
            var estadoActualizado = new EstadoDTO { codEstado = "nueva", nombreEstado = "Nueva" };

            // Act
            var resultado = _estadoController.Actualizar(estadoActualizado) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Eliminar_DebeRetornarOk()
        {
            // Arrange
            var codEstado = "nueva";

            // Act
            var resultado = _estadoController.Eliminar(codEstado) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }
    }
}