﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionGUIHelper.Helpers;
using GestionGUIHelper.Validaciones;
using GestionDomain;
using GestionCommon.Entidades;
using GestionDomain.Resultados;
using GestionCommon.Filtros;

namespace Clinica_Frba.Usuarios
{
    public partial class FrmUsuarioListado : FormularioBaseListado
    {
        UsuarioDomain _usuarioDomain = new UsuarioDomain(Program.ContextoActual.Logger);

        public FrmUsuarioListado()
        {
            InitializeComponent();
        }

        protected override void AccionAlta()
        {
            using (FrmUsuarioAlta frm = new FrmUsuarioAlta())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionModificar()
        {
            using (FrmUsuarioModificacion frm = new FrmUsuarioModificacion())
            {
                frm.ShowDialog(this);
            }
        }

        protected override void AccionBorrar()
        {
            MensajePorPantalla.MensajeInformativo(this, "No se implementa");
        }

        protected override void AccionFiltrar()
        {
            var filtro = new FiltroUsuario();
            filtro.Username = tbUsername.Text;

            Rol rol = cbRol.SelectedItem as Rol;
            if (rol != null)
                filtro.IdRol = rol.Id;

            IResultado<IList<Usuario>> resultadoUsuarios = _usuarioDomain.Filtrar(filtro);

            if (!resultadoUsuarios.Correcto)
                throw new ResultadoIncorrectoException<IList<Usuario>>(resultadoUsuarios);

            this.dgvBusqueda.DataSource = resultadoUsuarios.Retorno;

            this.dgvBusqueda.Columns["IdUsuario"].Visible = false;
            this.dgvBusqueda.Columns["Habilitado"].Visible = false;
            this.dgvBusqueda.Columns["Password"].Visible = false;
        }

        protected override void AccionIniciar()
        {
            this.CargarRoles();
            this.Filtrar();
        }

        private void CargarRoles()
        {
            RolDomain rolDomain = new RolDomain(Program.ContextoActual.Logger);
            IResultado<IList<Rol>> roles = rolDomain.ObtenerTodos();

            if (roles.Correcto)
            {
                this.cbRol.DataSource = roles.Retorno;
                this.cbRol.DisplayMember = "Nombre";
                this.cbRol.ValueMember = "Id";
            }

        }

        protected override void AccionLimpiar()
        {
            this.tbUsername.Text = string.Empty;
            if (this.cbRol.Items.Count > 0)
            {
                this.cbRol.SelectedIndex = 0;
            }
        }

    }
}
