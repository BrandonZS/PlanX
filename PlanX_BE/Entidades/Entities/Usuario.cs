﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanXBackend.Entidades.Entities
{
    public class Usuario
    {
        public Int64 Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string codPais { get; set; }
        public string contrasenha { get; set; }
        public string token {  get; set; }

    }
}
