using AppParqueadero.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Aplicaciones.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> Login(string username, string password);
        Task<bool> ExisteUsuario(string username);
    }
}
