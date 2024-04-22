﻿
using Aplicacion.Interface;
using Dominio.Maestras;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using static Dominio.Maestras.MensajesBase;

namespace Aplicacion.Servicio
{
    public class PersonaServ
        : IServBase<PersonaDom, string>
    {
        private readonly IRepoBase<PersonaDom, string> repo;
        private Excepcion excepcion = new Excepcion();

        public PersonaServ(IRepoBase<PersonaDom, string> _repo)
        {
            repo = _repo;            
        }

        public void Actualizar(PersonaDom entidad)
        {
            try
            {
                repo.Actualizar(entidad);
                repo.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }
        }

        public void Eliminar(string entidadID)
        {
            try
            {
                repo.Eliminar(entidadID);
                repo.SalvarTodo();
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Eliminar.GetEnumDescription());
            }
        }

        public PersonaDom Insertar(PersonaDom entidad)
        {
            try
            {
                var result = repo.Insertar(entidad);
                repo.SalvarTodo();
                return result;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }
        }

        public PersonaDom ObtenerPorID(string entidadID)
        {
            try
            {
                return repo.ObtenerPorID(entidadID);
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Obtener.GetEnumDescription());
            }
        }

        public List<PersonaDom> ObtenerTodo()
        {
            try
            {
                return repo.ObtenerTodo();
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Obtener.GetEnumDescription());
            }
        }
    }
}
