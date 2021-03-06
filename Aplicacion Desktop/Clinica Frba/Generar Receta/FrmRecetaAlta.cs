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
using GestionDomain.Resultados;
using Clinica_Frba.Afiliados;

namespace Clinica_Frba.Recetas
{
    public partial class FrmRecetaAlta : FormularioBaseAlta
    {
        private Afiliado _afiliado;
        private Profesional _profesional;
        private BonoFarmacia bonoFarmacia;
        private ResultadoTurno _resultadoTurno;
 
        private Medicamento nuevo;
        private int cantidadMedicamentos;

        private CompraDomain _domain;

        public FrmRecetaAlta(ResultadoTurno rt, Profesional p, Afiliado a)
            : this(rt, p)
        {
            this.CargarAfiliado(a);
        }
        public FrmRecetaAlta(ResultadoTurno rt, Profesional p)
            :base()
        {
            InitializeComponent();
            _domain = new CompraDomain(Program.ContextoActual.Logger);
            this.CargarProfesional(p);
            this._resultadoTurno = rt;
        }

        private void CargarProfesional(Profesional p)
        {
            this._profesional = p;
            this.tbProfesional.Text = p.NombreCompleto;
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
                this.GuardarReceta();
                DialogResult otraReceta = MensajePorPantalla.MensajeInterrogativo(this, "¿Quiere crear otra receta?", MessageBoxButtons.YesNo);
                if (otraReceta == DialogResult.Yes)
                {
                    using (FrmRecetaAlta frm = new FrmRecetaAlta(_resultadoTurno, _profesional, _afiliado))
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

        private void GuardarReceta()
        {
            try
            {
                Receta r = new Receta();
                r.IdResultadoTurno = _resultadoTurno.IdResultadoTurno;
                r.IdBonoFarmacia = Convert.ToDecimal(tbBonoFarmacia.Text);
                r.Fecha = dateTimePicker1.Value;

                IResultado<Receta> resultado = _domain.RegistrarReceta(r);
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<Receta>(resultado);

                r = resultado.Retorno;
             

                foreach (var item in this.lstMedicamentos.Items.Cast<ItemReceta>())
                {
                    item.IdReceta = r.IdReceta;
                    r.Items.Add(item);
                }


                foreach (ItemReceta ir in r.Items)
                {

                    IResultado<ItemReceta> resIR = _domain.RegistrarItemReceta(ir);
                    if (!resIR.Correcto)
                        throw new ResultadoIncorrectoException<ItemReceta>(resIR);
                }

                using (FrmRecetaVista frm = new FrmRecetaVista(r, _afiliado.NombreCompleto, _profesional.NombreCompleto))
                {
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError (this, ex.Message);
            }
        }

        private void FrmRecetaAlta_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = FechaHelper.Ahora();
            this.ndCantidad.Value = 1;
            this.tbCantidad.Text = "Uno";
            this.cantidadMedicamentos = 0;

            this.AgregarValidacion(new ValidadorString(tbMedicamento, 1, 255));
            this.dateTimePicker1.Value = FechaHelper.Ahora();
            this.btnAceptar.Enabled = false;
            
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnBuscar.Enabled = false;
            
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
                this.btnBuscar.Enabled = true;
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
                this.btnBuscar.Enabled = false;
            }
            this.btnAceptar.Enabled = lstMedicamentos.Items.Count < 6;
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
            this.btnBuscar.Enabled = cantidadMedicamentos < 5;
            this.btnAceptar.Enabled = lstMedicamentos.Items.Count < 0;
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
            try
            {
                decimal idBono = Convert.ToDecimal(tbBonoFarmacia.Text);
                IResultado<BonoFarmacia> resultado = _domain.ValidarBonoFarmacia(idBono, _afiliado.NroPrincipal, FechaHelper.Ahora());
                if (!resultado.Correcto)
                    throw new ResultadoIncorrectoException<BonoFarmacia>(resultado);
                
                bonoFarmacia = resultado.Retorno;

                groupBox2.Enabled = true;
                this.tbBonoFarmacia.ReadOnly = true;
                this.btnBuscar.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnQuitar.Enabled = true;
                this.dateTimePicker1.Enabled = false;
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError(this, ex.Message);
            }
            
        }

        private void btnBuscarAfiliado_Click(object sender, EventArgs e)
        {
            using (FrmAfiliadoListado frm = new FrmAfiliadoListado(true))
            {
                frm.ShowDialog(this);
                if (frm.EntidadSeleccionada as Afiliado != null)
                {
                    this.CargarAfiliado((Afiliado)frm.EntidadSeleccionada);
                }
            }
        }

        private void CargarAfiliado(Afiliado afiliado)
        {
            this._afiliado = afiliado;
            this.tbAfiliado.Text = _afiliado.NombreCompleto;
            this.btnBuscarAfiliado.Enabled = false;
            this.btnValidar.Enabled = true;
            this.groupBox3.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbMedicamento_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMedicamento.Text))
            {
                this.ndCantidad.Enabled = true;
            }
            else
            {
                this.ndCantidad.Enabled = false;
            }
        }
    }
}
