﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.Generar_Receta;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionGUIHelper.Formularios;
using GestionGUIHelper.Helpers;
using GestionGUIHelper.Validaciones;
using GestionDomain;

namespace Clinica_Frba.Recetas
{
    public partial class FrmRecetaAlta : FormularioBaseAlta
    {
        private BonoFarmacia bonoFarmacia;
        private Medicamento nuevo;
        private int cantidadMedicamentos;

        private CompraDomain _domain;
        
        public FrmRecetaAlta()
            :base()
        {
            _domain = new CompraDomain(Program.ContextoActual.Logger);
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (FrmMedicamentoListado frm = new FrmMedicamentoListado())
            {
                frm.ShowDialog(this);
                if (frm.EntidadSeleccionada as Medicamento != null)
                {
                    nuevo = (Medicamento)frm.EntidadSeleccionada;
                    tbMedicamento.Text = nuevo.Nombre;
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            base.Aceptar();
        }
        protected override void Aceptar()
        {
            if (lstMedicamentos.Items.Count > 0)
            {
                AccionAceptar();
            }
        }
        protected override void AccionAceptar()
        {
            try
            {

                DialogResult otraReceta = MensajePorPantalla.MensajeInterrogativo(this, "¿Quiere crear otra receta?", MessageBoxButtons.YesNo);
                if (otraReceta == DialogResult.Yes)
                {
                    using (FrmRecetaAlta frm = new FrmRecetaAlta())
                    {
                        frm.ShowDialog(this);
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MensajePorPantalla.MensajeError(this, ex.Message);
            }
        }

        private void FrmRecetaAlta_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = FechaHelper.Ahora();
            this.ndCantidad.Value = 1;
            this.tbCantidad.Text = "Uno";
            this.cantidadMedicamentos = 0;

            this.AgregarValidacion(new ValidadorString(tbMedicamento, 1, 255));
            
        }

        private void ndCantidad_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)ndCantidad.Value)
            {
                case 1:
                    tbCantidad.Text = "Uno";
                    break;
                case 2:
                    tbCantidad.Text = "Dos";
                    break;
                case 3:
                    tbCantidad.Text = "Tres";
                    break;
                default:
                    break;
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (this.Validar() && cantidadMedicamentos < 5)
            {
                ItemReceta ir = new ItemReceta();
                ir.NombreMedicamento = tbMedicamento.Text;
                ir.CantidadEnLetras = tbCantidad.Text;
                ir.Cantidad = (int)ndCantidad.Value;
                ir.IdMedicamento = nuevo.IdMedicamento;

                var repetidos = lstMedicamentos.Items.Cast<ItemReceta>().Count(i => i.IdMedicamento == ir.IdMedicamento);
                if (repetidos == 0)
                {
                    lstMedicamentos.Items.Add(ir);
                    cantidadMedicamentos++;
                    tbCantMedicamentos.Text = cantidadMedicamentos.ToString();
                }
                else
                {
                    MensajePorPantalla.MensajeError(this, "Este medicamento ya está recetado");
                }
            }
            else
            {
                MensajePorPantalla.MensajeError(this, "Solo pueden cargarse 5 (cinco) medicamentos por receta. Guarde y cree una nueva receta");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            var selected = lstMedicamentos.SelectedItem;
            if (selected != null)
            {
                lstMedicamentos.Items.Remove(selected);
                cantidadMedicamentos--;
            }
            tbCantMedicamentos.Text = cantidadMedicamentos.ToString();
        }

        protected override void AccionLimpiar()
        {
            this.nuevo = null;
            this.tbCantidad.Text = "Uno";
            this.ndCantidad.Value = 1;
            this.tbMedicamento.Text = string.Empty;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            decimal idBono = Convert.ToDecimal(tbBonoFarmacia.Text);
            _domain.ObtenerBonoFarmacia(idBono);
            groupBox2.Enabled = true;
        }
    }
}
