using AppParqueadero.Aplicaciones.Excepciones;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces.Servicios
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepositorio Repositorio;
        public AuthService(IAuthRepositorio repositorio_)
        {
            Repositorio = repositorio_;
        }
        public async Task<bool> ExisteUsuario(string username)
        {
           return await Repositorio.ExisteUsuario(username);
        }

        public async Task<Usuario> Login(string username, string password)
        {
            if (await ExisteUsuario(username))
            {
                var user = await Repositorio.Login(username, password);
                if (user is null)
                    throw new ValidarExceptions($"Contraseña incorrecta");
                return user ;
            }
            else
                throw new ValidarExceptions($"El usuario {username} no existe");
        }

        public async Task<Usuario> GetUsuarioAsync(Guid empleadoId)
        {
            var resp = await Repositorio.GetUsuarioAsync(empleadoId);
            if (resp is null)
                throw new ValidarExceptions("El empleado no esta disponible");

            return  resp;
        }

        public List<Usuario> Listar()
        {
            var resp = Repositorio.Listar();
            if (resp is null)
                throw new ValidarExceptions("No hay usuarios registrados");
            return resp;
        }

        public Usuario SeleccionarPorId(Guid entidad)
        {
            throw new NotImplementedException();
        }
    }
}
