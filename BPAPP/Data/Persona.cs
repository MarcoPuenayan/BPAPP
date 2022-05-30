﻿using System.ComponentModel.DataAnnotations;

namespace BPAPP.Data
{
    public class Persona
    {
        public Guid IdPersona { get; set; }

        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}