using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionGUIHelper.Formularios;
using GestionCommon.Entidades;

namespace Clinica_Frba.Agendas
{
    public partial class FrmAgendaConsultar : Form
    {
        private Profesional _profesional;
        public Turno TurnoSeleccionado { get; private set; }
        
        public FrmAgendaConsultar()
        {
            InitializeComponent();
        }

        public FrmAgendaConsultar(Profesional profesional)
            :this()
        {
            _profesional = profesional;    
        }

        private void FrmAgendaConsultar_Load(object sender, EventArgs e)
        {

        }
    }
}
