﻿using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Repository;
using ComponentFactory.Krypton.Toolkit;
using Sistema.Reports.Reports_Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Forms.modulo_producto
{
    public partial class ListaProductos : BaseContext
    {
        private ProductosRepository _productosRepository = null;
        private bool mostrarTodas = false;

        public ListaProductos()
        {
            _productosRepository = new ProductosRepository(_context);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            RefrescarDataGridProductos(false);
            base.OnLoad(e);
        }

        public void RefrescarDataGridProductos(bool loadNewContext = true)
        {
            if (loadNewContext)
            {
                _context = null;
                _context = new Context();
                _productosRepository = null;
                _productosRepository = new ProductosRepository(_context);
            }

            BindingSource source = new BindingSource();
            var Productos = _productosRepository.GetList(UsuarioLogeadoSistemas.User.SucursalId);
            source.DataSource = Productos;
            listproductos.DataSource = typeof(List<>);
            listproductos.DataSource = source;
            if (mostrarTodas == false)
            {
                listproductos.Columns[2].Visible = false;
                listproductos.Columns[4].Visible = false;
                listproductos.Columns[6].Visible = false;
                listproductos.Columns[7].Visible = false;
                listproductos.Columns[9].Visible = false;
                listproductos.Columns[17].Visible = false; 
                listproductos.Columns[19].Visible = false;
                listproductos.Columns[20].Visible = false;
                listproductos.Columns[21].Visible = false;
                listproductos.Columns[22].Visible = false;
                listproductos.Columns[23].Visible = false;
                listproductos.Columns[25].Visible = false;
                listproductos.Columns[28].Visible = false;
            }
            //listproductos.AutoResizeColumns();
           
        }

        private void btnDetalleP_Click(object sender, EventArgs e)
        {
            if (listproductos.CurrentRow == null)
            {
                return;
            }

            var producto = (ListarProductos)listproductos.CurrentRow.DataBoundItem;
            var Getproducto = _productosRepository.Get(producto.Id);

            DetalleProducto childForm = new DetalleProducto(Getproducto, this); // me sirve para refrescar el dg cie el thiscunado regrese
            childForm.Show();
        }

        private void buscarprod_Click(object sender, EventArgs e)
        {
            BuscarProducto buscarproducto = new BuscarProducto(listproductos);
            buscarproducto.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            RefrescarDataGridProductos(true); // al refrescar activa el nuevo contexto()

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (listproductos.CurrentRow == null)
            {
                return;
            }

            var dialog = KryptonMessageBox.Show("¿Está seguro que desea eliminar el producto de la lista?", "Eliminar producto",
               MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            // dale proba okoko

            if (dialog== DialogResult.Yes)
            {
                var productolista = (ListarProductos)listproductos.CurrentRow.DataBoundItem;
                var productoObtenido = _productosRepository.Get(productolista.Id);
                productoObtenido.Deleted = true;
                _productosRepository.Update(productoObtenido);
                RefrescarDataGridProductos(true);
            }            

        }

        private void listproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaProductos_Load(object sender, EventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ReporteProducto reporte = new ReporteProducto();
            reporte.Show();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (mostrarTodas == true)
            {
                tsbMostrarOcultar.Text = "Mostrar Todas";
                mostrarTodas = false;
                RefrescarDataGridProductos(false);
            }
            else 
            {
                tsbMostrarOcultar.Text = "Mostrar Menos";
                mostrarTodas = true;
                RefrescarDataGridProductos(false);
            }
            
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
