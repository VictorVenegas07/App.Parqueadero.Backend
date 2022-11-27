using AppParqueadero.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Interfaces.Repositorios
{
    public interface IAuthRepositorio:IListar<Usuario, Guid>
    {
        Task<Usuario> Login(string username, string password);
        Task<bool> ExisteUsuario(string username);
        Task<Usuario> GetUsuarioAsync(Guid empleadoId);


    }
}
