using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Models.Usuario;
using AppParqueadero.infraestructura.API.Service;
using AppParqueadero.Infraestructura.Datos.Repositorios;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppParqueadero.infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepositorio repositorio;
        private readonly JwtService jwtService;
        private readonly AuthService service;
        public AuthController(ParqueaderoContexto contexto, IMapper mapper_, JwtService jwtService_)
        {
            repositorio = new AuthRepositorio(contexto);
            service = new AuthService(repositorio);
            jwtService = jwtService_;
        }
        // POST api/<AuthController>
        [HttpPost]
        public async Task<ActionResult<UsuarioLog>> Post(UserCredencial value)
        {
            var res = await service.Login(value.Username, value.password);
           return  Ok(jwtService.GenerarToken(res));
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<Usuario>> GetUsuariosId(string idEmpleado)
        {
            var res = await service.GetUsuarioAsync(Guid.Parse(idEmpleado));
            return Ok(res);
        }

        [HttpGet("[action]")]
        public  ActionResult<Usuario> GetUsuarios()
        {
            var res =  service.Listar();
            return Ok(res);
        }
    }
}
