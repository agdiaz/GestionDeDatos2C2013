using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionGUIHelper.Helpers;
using System.Windows.Forms;

namespace GestionGUIHelper.Formularios
{
    public class FormularioBaseListado<T> : FormularioBase
    {
        public FormularioBaseListado()
            :base()
        {

        }

        /// <summary>
        /// Permite indicar si se retornara un objeto de la grilla al salir
        /// del formulario.
        /// </summary>
        public bool ModoSeleccion { get; set; }
        public T EntidadSeleccionada { get; set; }

        /// <summary>
        /// Devuelve la lista de objetos filtrados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual IList<T> Filtrar()
        {
            IList<T> resultado = null;
            if (base.Validar())
            {
                resultado = this.AccionFiltrar();

                Type tipoEntidad = typeof(T);
                var properties = tipoEntidad.GetProperties(System.Reflection.BindingFlags.Public);

                foreach (var prop in properties)
                {
                    ;
                }
            }


            return resultado;
        }

        protected virtual IList<T> AccionFiltrar()
        {
            throw new NotImplementedException();
        }
        protected virtual void AccionBorrar()
        {
            throw new NotImplementedException();
        }

        protected virtual void Seleccionar()
        {
            throw new NotImplementedException();
        }
        protected void Borrar()
        {
            base.Validar();
            DialogResult dr = MensajePorPantalla.MensajeInformativo(this, "¿Está seguro que desea borrar el registro?", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                this.AccionBorrar();
            }

        }
        protected void Modificar()
        {
            base.Validar();
            DialogResult dr = MensajePorPantalla.MensajeInformativo(this, "¿Está seguro que desea borrar el registro?", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                this.AccionBorrar();
            }

        }

        protected void Alta()
        {
            ;
        }
    }
}