using Aplicacion.Interface;
using Dominio.Modelo;
using DTO.DTO;
using GestionTareaAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestGestionTareaAPI.Controller
{
    [TestFixture]
    public class TareaControllerTests
    {
        private TareaController _tareaController;
        private Mock<IServTarea<TareaDom, int>> _mockServicio;

        [SetUp]
        public void Setup()
        {
            _mockServicio = new Mock<IServTarea<TareaDom, int>>();
            _tareaController = new TareaController(_mockServicio.Object);
        }

        [Test]
        public void ObtenerTodo_DebeRetornarOkConListaDeTareas()
        {
            // Arrange
            var orden = "ASC";
            var tareas = new List<TareaDom>
            {
                new TareaDom { tareaID = 1, codTarea = "001", fechaAdicion = DateTime.Now, descripcion = "", personaAsignada = "wtabera",
                    codEstado = "nueva", codPrioridad = "baja", fechaInicio = new DateTime(2024, 4, 22), fechaFin = new DateTime(2024, 4, 30), comentario = "" },

                new TareaDom { tareaID = 1, codTarea = "002", fechaAdicion = DateTime.Now, descripcion = "", personaAsignada = "wtabera",
                    codEstado = "nueva", codPrioridad = "alta", fechaInicio = new DateTime(2024, 4, 22), fechaFin = new DateTime(2024, 4, 23), comentario = "prueba" },

                new TareaDom { tareaID = 1, codTarea = "003", fechaAdicion = DateTime.Now, descripcion = "", personaAsignada = "wtabera",
                    codEstado = "nueva", codPrioridad = "baja", fechaInicio = new DateTime(2024, 4, 30), fechaFin = new DateTime(2024, 5, 10), comentario = "" }
            };
            _mockServicio.Setup(s => s.ObtenerTodo(orden)).Returns(tareas);

            // Act
            var resultado = _tareaController.ObtenerTodo(orden).Result as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
            Assert.That(resultado.Value, Is.InstanceOf<List<TareaObtDTO>>());
            Assert.That(((List<TareaObtDTO>)resultado.Value).Count, Is.EqualTo(tareas.Count));
        }

        [Test]
        public void ObtenerPorFiltro_DebeRetornarOkConListaDeTareasFiltradas()
        {
            // Arrange
            var orden = "ASC";
            var filtro = new TareaDom
            {
                personaAsignada = "wtabera",
                codEstado = "nueva",
                codPrioridad = "baja",
                fechaInicio = new DateTime(2024, 4, 22)
            };
            var tareas = new List<TareaDom>
            {
                new TareaDom { tareaID = 1, codTarea = "001", fechaAdicion = DateTime.Now, descripcion = "", personaAsignada = "wtabera",
                    codEstado = "nueva", codPrioridad = "baja", fechaInicio = new DateTime(2024, 4, 22), fechaFin = new DateTime(2024, 4, 30), comentario = "",
                    Persona = new PersonaDom { usuario = "wtabera", nombre = "William Tabera" },
                    Estado = new EstadoDom { codEstado = "nueva", nombreEstado = "Nueva" },
                    Prioridad = new PrioridadDom { codPrioridad = "baja", nombrePrioridad = "Baja" }}
            };

            // Configurar el mock del servicio
            _mockServicio.Setup(s => s.ObtenerPorFiltro(It.IsAny<TareaDom>(), orden))
                 .Returns((TareaDom paraDTO, string ord) =>
                 {
                     var tareasFiltradas = tareas.Where(t =>
                         t.personaAsignada == paraDTO.personaAsignada &&
                         t.codEstado == paraDTO.codEstado &&
                         t.codPrioridad == paraDTO.codPrioridad &&
                         t.fechaInicio == paraDTO.fechaInicio).ToList();
                     return tareasFiltradas;
                 });

            // Act
            var resultado = _tareaController.ObtenerPorFiltro(order: orden, personaAsignada: "wtabera", codEstado: "nueva", codPrioridad: "baja", 
                fechaInicio: new DateTime(2024, 4, 22)).Result as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
            Assert.That(resultado.Value, Is.InstanceOf<List<TareaObtDTO>>());
            Assert.That(((List<TareaObtDTO>)resultado.Value).Count, Is.EqualTo(tareas.Count));
        }

        [Test]
        public void Insertar_DebeRetornarOk()
        {
            // Arrange
            var nuevaTarea = new TareaInsertDTO
            {
                codTarea = "001",
                descripcion = "",
                personaAsignada = "wtabera",
                codEstado = "nueva",
                codPrioridad = "baja",
                fechaInicio = new DateTime(2024, 4, 22),
                fechaFin = new DateTime(2024, 4, 30),
                comentario = ""
            };

            // Act
            var resultado = _tareaController.Insertar(nuevaTarea) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Actualizar_DebeRetornarOk()
        {
            // Arrange
            var tareaActualizada = new TareaDTO
            {
                tareaID = 1,
                codTarea = "001",
                fechaAdicion = DateTime.Now,
                descripcion = "",
                personaAsignada = "wtabera",
                codEstado = "nueva",
                codPrioridad = "baja",
                fechaInicio = new DateTime(2024, 4, 22),
                fechaFin = new DateTime(2024, 4, 30),
                comentario = ""
            };

            // Act
            var resultado = _tareaController.Actualizar(tareaActualizada) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Eliminar_DebeRetornarOk()
        {
            // Arrange
            var idTarea = 1;

            // Act
            var resultado = _tareaController.Eliminar(idTarea) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.That(resultado.StatusCode, Is.EqualTo(200));
        }
    }
}