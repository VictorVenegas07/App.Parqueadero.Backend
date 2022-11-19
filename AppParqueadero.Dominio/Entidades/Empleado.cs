﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppParqueadero.Dominio.Entidades
{
    public class Empleado:Persona
    {
        [JsonIgnore]
        public Guid EmpleadoId { get; set; }
        public List<Horario> Horarios  { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public Usuario Usuario { get; set; }
        [JsonIgnore]
        public List<Ticket> Tickets { get; set; }
    }
}
