using AppParqueadero.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Text;
using AppParqueadero.infraestructura.API.Models.Usuario;
using AutoMapper;
using System.Threading.Tasks;

namespace AppParqueadero.infraestructura.API.Service
{
    public class JwtService
    {
        private readonly SymmetricSecurityKey key;
        private readonly IMapper mapper;
        public JwtService(IConfiguration configuration, IMapper mapper_)
        {
            mapper = mapper_;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token"]));
        }
        public  UsuarioLog GenerarToken(Usuario usuario)
        {
            if (usuario == null)
            {
                return null;
            }

            var response = mapper.Map<UsuarioLog>(usuario);
            var tokenManejo = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimTypes.Name, usuario.Empleado.Nombre.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Empleado.Email.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Cargo.ToString()),
                }),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenManejo.CreateToken(tokenDescriptor);
            response.Token = tokenManejo.WriteToken(token);
            return response;
        }
    }
}
