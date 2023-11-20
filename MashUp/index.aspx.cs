using MashUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MashUp
{
    public partial class index : System.Web.UI.Page
    {
        HelperPuebla Helper;
        Helper NuevoHelper;

        public index()
        {
            Helper= new HelperPuebla();
            NuevoHelper = new Helper();
        }
        
        protected async void Page_Load(object sender, EventArgs e)
        {

            //Todos los métodos para obtener información del Clima de PUEBLA
            await Helper.ObtenerDatosPuebla();

            Label2.Text = Helper.ObtenerNombre();
            LabelTempActual.Text = Helper.ObtenerTemperatura();
            LabelTempMaxima.Text = Helper.ObtenerTemperaturaMaxima();
            LabelTempMinima.Text = Helper.ObtenerTemperaturaMinima();
            ImagenDescriptiva.Attributes.Add("src", Helper.ObtenerImagen());
            Nubosidad.Text = Helper.ObtenerNubosidad();
            Humedad.Text = Helper.ObtenerHumedad();
            Label4.Text = Helper.ObtenerDescripcion();
            HoraSalida.Text = Helper.ObtenerHoraSalidaSol();
            HoraPuesta.Text = Helper.ObtenerHoraPuestaSol();

            await NuevoHelper.ObtenerData();
            latitudNuevo.Text = NuevoHelper.obtenerLatitud();

        }
    }
}