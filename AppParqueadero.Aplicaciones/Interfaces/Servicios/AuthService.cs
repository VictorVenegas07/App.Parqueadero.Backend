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
    }
}
