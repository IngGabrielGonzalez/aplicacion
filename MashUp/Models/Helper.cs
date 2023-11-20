using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using static MashUp.Models.Location;

namespace MashUp.Models
{
    public class Helper
    {
        Location locations;
        string DirBase;
        string Error { get; set; }

        string ciudad { get; set; }
        string pais { get; set; }

        HttpMessageHandler HandlerDatos;

        public Helper()
        {
            HandlerDatos = new HttpClientHandler();
        }

        public async Task ObtenerData()
        {
            // Nuestro EndPoint https://nominatim.openstreetmap.org/search?q=puebla&countrycodes=mx&format=json&addressdateils=1

            //Definimos nuestra Dirección Base
            DirBase = "https://nominatim.openstreetmap.org";

            //Y nuestro URI
            string solicitudCliente = "/search?q=puebla&countrycodes=mx&format=json&addressdateils=1";


            try
            {
                //Se crea la instancia HttpCliente, el objeto se destruye al 
                // terminar la ejecución delk bloque using 
                using (var Cliente = new HttpClient(HandlerDatos))
                {
                    //configuramos la cabecera de la solicitud del servicio web
                    Cliente.BaseAddress = new Uri(DirBase);
                    Cliente.DefaultRequestHeaders.Accept.Clear();
                    Cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

                    //se hace la solicitud del servicio web, y se verifica que la solicitud sea exitosa
                    HttpResponseMessage respuesta = await Cliente.GetAsync($"{solicitudCliente}");
                    respuesta.EnsureSuccessStatusCode();
                    //I$SuccessStatusCode= True, para una respuesta válida
                    if (respuesta.IsSuccessStatusCode)
                    {
                        //obtenemos el Json como un string 'ReadAsStringAsync'
                        var jsoncadena = await respuesta.Content.ReadAsStringAsync();
                        //Deserializaremos el json a la clase 'DatosClimaPuebla'
                        //la clase
                        locations = JsonConvert.DeserializeObject<Location>(jsoncadena);

                    }
                    else
                    {
                        Error = "Se ha producido un error al olicitar el servivio web";
                        throw new Exception();
                    }
                }
            }
            catch (HttpRequestException ex)
            {

                Error = ex.Message;
            }
            return;


        }
        public string obtenerLatitud()
        {
            var variable = locations.Lat[0];
            return variable.ToString();
        }

    }

}