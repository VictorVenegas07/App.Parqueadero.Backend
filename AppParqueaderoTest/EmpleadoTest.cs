using AppParquadero.Infraestructura.Datos.Contexto;
using AppParqueadero.Aplicaciones.Interfaces.Servicios;
using AppParqueadero.Dominio.Entidades;
using AppParqueadero.infraestructura.API.Controllers;
using AppParqueadero.infraestructura.API.Models.Empleado;
using AppParqueadero.infraestructura.API.Models.Usuario;
using AppParqueadero.infraestructura.API.utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace AppParqueaderoTest
{
    public class EmpleadoTest
    {
        private static IMapper _mapper;
        private readonly EmpleadoController empleadoController;

        public EmpleadoTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMap());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            empleadoController = new EmpleadoController(new ParqueaderoContexto(), _mapper);
        }
        [Fact]
        public void TestEmpleado()
        {
            var empleado = new EmpleadoInput
            {
                TipoDocumuento = "CC",
                Identificacion = "1192905323",
                Nombre = "Maria",
                Telefono = "3006314418",
                Email = "vvenegas@unicesar.edu.co",
                Usuario = new UsuarioInput
                {
                    Cargo = "Administrador",
                    NombreUsuario ="vvene1ga",
                    Contraseña="12345678"
                }

            };
            Assert.True(empleado.TipoDocumuento.Equals("TI") || empleado.TipoDocumuento.Equals("CC") || empleado.TipoDocumuento.Equals("CE"));
            Assert.True(100000000 <= Double.Parse(empleado.Identificacion) && Double.Parse(empleado.Identificacion) <= 9999999999);
            Assert.True(5 <= empleado.Nombre.Length && empleado.Nombre.Length <= 10);
            Assert.True(3000000000 < Double.Parse(empleado.Telefono) && Double.Parse(empleado.Telefono) < 3999999999);
            Assert.True(10 <= empleado.Email.Length && empleado.Email.Length <= 25);
            Assert.True(empleado.Usuario.Cargo.Equals("Administrador") || empleado.Usuario.Cargo.Equals("Empleado"));
            Assert.True(5 <= empleado.Usuario.NombreUsuario.Length && empleado.Usuario.NombreUsuario.Length <= 15);
            Assert.True(8 <= empleado.Usuario.Contraseña.Length && empleado.Usuario.Contraseña.Length <= 15);
            var result = empleadoController.Post(empleado);
            Assert.IsNotType<OkObjectResult>(result);

        }
    }
}
