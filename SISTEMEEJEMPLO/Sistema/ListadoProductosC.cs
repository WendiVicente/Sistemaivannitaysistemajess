﻿using CapaDatos.ListasPersonalizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    public class ListadoProductosC
    {
        public static IList<ListarProductos> ListaDeProductos { get; set; }

        /// <summary>
        /// Buscar el producto según el número de referencia.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="includeRelatedEntities"></param>
        /// <returns></returns>
        public static ListarProductos GetProducto(string codigo)
        {
            return ListaDeProductos.Where(s => s.CodigoReferencia == codigo && s.Deleted == false)
                .SingleOrDefault();
        }
    }
}
