using Aplicacion.Interface;
using Dominio.Modelo;
using DTO.DTO;
using GestionTareaAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestGestionTareaAPI.Controller
{
    [TestFixture]
    public class PersonaControllerTests
    {

        private PersonaController _PersonaController;
        private Mock<IServBase<PersonaDom, string>> _mockServicio;

        [SetUp]
        public void Setup()
        {
            _mockServicio = new Mock<IServBase<PersonaDom, string>>();
            _PersonaController = new PersonaController(_mockServicio.Object);
        }

        [Test]
        public void ObtenerTodo_DebeRetornarOkConListaDePersonas()
        {
            // Arrange
            var Personas = new List<PersonaDom>
            {
                new PersonaDom { usuario = "wtabera", nombre = "William Tabera" }
            };
            _mockServicio.Setup(s => s.ObtenerTodo()).Returns(Personas);

            // Act
            var resultado = _PersonaController.ObtenerTodo().Result as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
            Assert.That(resultado.Value, Is.InstanceOf<List<PersonaDTO>>());
            Assert.That(((List<PersonaDTO>)resultado.Value).Count, Is.EqualTo(Personas.Count));
        }

        [Test]
        public void ObtenerPorID_DebeRetornarOkConPersonaExistente()
        {
            // Arrange
            var usuario = "wtabera";
            var nombre = "William Tabera";

            var Persona = new PersonaDom { usuario = usuario, nombre = nombre };
            _mockServicio.Setup(s => s.ObtenerPorID(usuario)).Returns(Persona);

            // Act
            var resultado = _PersonaController.ObtenetPorID(usuario).Result as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
            Assert.That(resultado.Value, Is.InstanceOf<PersonaDTO>());
            Assert.That(((PersonaDTO)resultado.Value).usuario, Is.EqualTo(Persona.usuario));
        }

        [Test]
        public void Insertar_DebeRetornarOk()
        {
            // Arrange
            var nuevoPersona = new PersonaDTO { usuario = "wtabera", nombre = "William Tabera" };

            // Act
            var resultado = _PersonaController.Insertar(nuevoPersona) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Actualizar_DebeRetornarOk()
        {
            // Arrange
            var PersonaActualizado = new PersonaDTO { usuario = "wtabera", nombre = "William Tabera" };

            // Act
            var resultado = _PersonaController.Actualizar(PersonaActualizado) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Eliminar_DebeRetornarOk()
        {
            // Arrange
            var usuario = "wtabera";

            // Act
            var resultado = _PersonaController.Eliminar(usuario) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }
    }
}