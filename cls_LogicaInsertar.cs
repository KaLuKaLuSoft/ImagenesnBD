using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImagenesnBD
{
     public class cls_LogicaInsertar
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public DateTime fechaCumple { get; set; }
        public byte[] imagen { get; set; }
    }
}
