﻿using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Devoluciones
{
    public class NotaDebito
    {
        public NotaDebito()
        {
           // DetalleNotaCreditos = new List<DetalleNotaCredito>();
        }
        public Guid Id { get; set; }
        public string NoDocumento { get; set; }
        public decimal MontoDisponible { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public DateTime? FechaAceptacion { get; set; }
        public string NombreVendedor { get; set; }
        public Guid FacturaId { get; set; }
        public bool Estado { get; set; }
        public Factura Factura { get; set; }
        public bool NdbyItem { get; set; }
        //public ICollection<DetalleNotaCredito> DetalleNotaCreditos { get; set; }
    }
}
