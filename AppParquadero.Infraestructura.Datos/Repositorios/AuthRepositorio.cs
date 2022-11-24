using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParqueadero.Infraestructura.Datos.Repositorios
{
    public class AuthRepositorio : IAuthRepositorio
    {
        private readonly ParqueaderoContexto contexto;
        public AuthRepositorio(ParqueaderoContexto contexto_)
        {
            contexto = contexto_;
        }
        public async Task<bool> ExisteUsuario(string username)
        {
            return await contexto.Usuarios.AnyAsync(x => x.NombreUsuario == username);
        }

        public async Task<Usuario> Login(string username, string password)
        {
            return await contexto.Usuarios.Include(x=> x.Empleado).FirstOrDefaultAsync(x => x.NombreUsuario == username && x.Contraseña == password);
        }
    }
}
