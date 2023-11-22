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
        HelperPuebla otroHelper;
        Helper NuevoHelper;
        HelperGasolina helperGaso;
        HelperDivisas helperDivisa;

        public index()
        {
            Helper = new HelperPuebla();
            NuevoHelper = new Helper();
            otroHelper = new HelperPuebla();
            helperGaso = new HelperGasolina();
            helperDivisa = new HelperDivisas();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {

            //Todos los métodos para obtener información del Clima de PUEBLA

            await Helper.ObtenerDatosPuebla("18.833333", "-98.0");


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


            if (!IsPostBack)
            {
                await helperDivisa.ObtenerDivisa();
                labelDivisa.Text = helperDivisa.Obtener();
                NuevoHelper.ciudad = "Puebla";
                NuevoHelper.pais = "mx";
                await NuevoHelper.ObtenerData();
                labelError.Text = "";
                await otroHelper.ObtenerDatosPuebla(NuevoHelper.obtenerLatitud(), NuevoHelper.obtenerLongitud());

                nombre.Text = otroHelper.ObtenerNombre();
                temp.Text = otroHelper.ObtenerTemperatura();
                tempMin.Text = otroHelper.ObtenerTemperaturaMinima();
                tempMax.Text = otroHelper.ObtenerTemperaturaMaxima();
                nubo.Text = otroHelper.ObtenerNubosidad();
                hume.Text = otroHelper.ObtenerHumedad();
                Image1.Attributes.Add("src", otroHelper.ObtenerImagen());
                descripcion.Text = otroHelper.ObtenerDescripcion();
                horaSa.Text = otroHelper.ObtenerHoraSalidaSol();
                horaPu.Text = otroHelper.ObtenerHoraPuestaSol();
            }


        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            helperGaso.ciudad = labelCiudad.Text;


            if (labelCiudad.Text == "" || labelPais.Text == "")
            {
                labelError.Text = "Ha ocurrido un error";
            }
            else
            {
                NuevoHelper.ciudad = labelCiudad.Text;
                NuevoHelper.pais = labelPais.Text;
                await NuevoHelper.ObtenerData();


                await otroHelper.ObtenerDatosPuebla(NuevoHelper.obtenerLatitud(), NuevoHelper.obtenerLongitud());
                if (NuevoHelper.obtenerLatitud() == null || NuevoHelper.obtenerLongitud() == null)
                {
                    labelError.Text = NuevoHelper.Error;

                }
                else
                {
                    labelError.Text = "";

                    nombre.Text = otroHelper.ObtenerNombre();
                    temp.Text = otroHelper.ObtenerTemperatura();
                    tempMin.Text = otroHelper.ObtenerTemperaturaMinima();
                    tempMax.Text = otroHelper.ObtenerTemperaturaMaxima();
                    nubo.Text = otroHelper.ObtenerNubosidad();
                    hume.Text = otroHelper.ObtenerHumedad();

                    Image1.Attributes.Add("src", otroHelper.ObtenerImagen());
                    descripcion.Text = otroHelper.ObtenerDescripcion();
                    horaSa.Text = otroHelper.ObtenerHoraSalidaSol();
                    horaPu.Text = otroHelper.ObtenerHoraPuestaSol();
                }

            }
            gasolina.Attributes.Add("src", $"https://petrointelligence.com/api/api_precios.html?consulta=estado&estado={helperGaso.ObtenerAbreviatura()}"); 
        }

    }
}