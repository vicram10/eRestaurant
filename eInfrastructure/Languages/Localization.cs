using eInfrastructure.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace eInfrastructure.Languages
{
    public class Localization
    {
        private readonly IHttpContextAccessor _httpContext;

        private readonly ISession _session;

        /// <summary>
        /// Constructor principal
        /// </summary>
        /// <param name="httpContext"></param>
        public Localization(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;

            _session = _httpContext.HttpContext.Session;
        }


        /// <summary>
        /// Obtenemos el texto
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public string getText(string texto, string fileName = "Language")
        {
            DatosUsuarioModel datosUsuario = new DatosUsuarioModel();

            string idioma;

            string retorno;

            try
            {
                datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(_session.GetString("datosUsuario"));

                idioma = datosUsuario.Idioma.ToUpper();
            }
            catch
            {

                idioma = "ES";
            }

            string vArchivoIdioma = String.Format("eInfrastructure.Languages.{0}{1}", fileName, idioma);

            string vArchivoIdiomaAux = String.Format("eInfrastructure.Languages.{0}{1}", fileName, "ES");

            Object global = Activator.CreateInstance(Type.GetType(vArchivoIdioma));

            Object globalAux = Activator.CreateInstance(Type.GetType(vArchivoIdiomaAux));

            try
            {
                retorno = global.GetType().GetProperty(texto).GetValue(global).ToString();
            }
            catch
            {
                retorno = globalAux.GetType().GetProperty(texto).GetValue(globalAux).ToString();
            }

            return retorno;
        }
    }
}
