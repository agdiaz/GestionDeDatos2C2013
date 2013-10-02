using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestionCommon;
using GestionCommon.Helpers;
using System.IO;
using GestionGUIHelper.Helpers;

namespace Clinica_Frba
{
    static class Program
    {
        public static IContexto ContextoActual { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = AppConfigReader.Get("log_path");
            string filename = Path.Combine(path, string.Format("{0}.log", DateTime.Now.ToString("yyyyMMddhhmmss")));

            ContextoActual = new Contexto(filename, FechaHelper.Ahora());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                ContextoActual.Logger.Iniciar();
                Application.Run(new FrmPrincipal());
            }
            catch (Exception ex)
            {
                MensajePorPantalla.MensajeError("Ha ocurrido un error fatal. Revise el archivo de log para obtener más información al respecto.");
                ContextoActual.Logger.Log(ex);
            }
            finally
            {
                ContextoActual.Logger.Finalizar();
            }
        }
    }
}
