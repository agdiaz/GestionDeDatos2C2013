using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionCommon.Helpers;

namespace GestionGUIHelper.Helpers
{
    public static class MensajePorPantalla
    {
        public static DialogResult MensajeInformativo(IWin32Window formulario, string mensaje)
        {
            return MessageBox.Show(formulario, mensaje, "Clínica FRBA - Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult MensajeInformativo(IWin32Window formulario, string mensaje, MessageBoxButtons botones)
        {
            return MessageBox.Show(formulario, mensaje, "Clínica FRBA - Información", botones, MessageBoxIcon.Information);
        }

        public static DialogResult MensajeInterrogativo(IWin32Window formulario, string mensaje, MessageBoxButtons botones)
        {
            return MessageBox.Show(formulario, mensaje, "Clínica FRBA - Consulta", botones, MessageBoxIcon.Question);
        }

        public static DialogResult MensajeError(IWin32Window formulario, string mensaje)
        {
            return MessageBox.Show(formulario, mensaje, "Clínica FRBA - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult MensajeError(string mensaje)
        {
            return MessageBox.Show(mensaje, "Clínica FRBA - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult MensajeValidacionNumerico(string controlName)
        {
            return MessageBox.Show(string.Format("El valor ingresado en el campo {0} debe ser numérico", controlName), "Error al validar");
        }

        public static DialogResult MensajeValidacionString(string controlName, int minSize, int maxSize)
        {
            return MessageBox.Show(string.Format("El valor ingresado en el campo {0} debe tener entre {1} y {2} caracteres", controlName, minSize, maxSize), "Error al validar");
        }

        public static DialogResult MensajeValidacionDateTime(string controlName, DateTime until)
        {
            return MessageBox.Show(string.Format("El valor ingresado en el campo {0} debe ser menor a la fecha {1}", controlName, FechaHelper.Format(until)), "Error al validar");
        }

        public static DialogResult MensajeValidacionDateTime(string controlName, DateTime from, DateTime until)
        {
            var sUntil = FechaHelper.Format(until);
            var sFrom = FechaHelper.Format(from);
            return MessageBox.Show(string.Format("El valor ingresado en el campo {0} debe ser mayor a {1} y menor a {2}", controlName, sFrom, sUntil), "Error al validar");
        }

        internal static void MensajeValidacionCombobox(string controlName)
        {
            MessageBox.Show(string.Format("Debe seleccionar un elemento del control {0}", controlName), "Error al validar");
        }
    }
}
