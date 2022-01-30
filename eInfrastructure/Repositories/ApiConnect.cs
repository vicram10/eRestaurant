using eGeek.ApiWebClient.Helpers;
using eInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace eInfrastructure.Repositories
{
    public class ApiConnect
    {

        /// <summary>
        /// Nos perite invocar de manera generica a la Api
        /// </summary>
        /// <param name="header">Para agregar parametros al header</param>
        /// <param name="metodo"></param>
        /// <param name="url"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public string Invocar(Dictionary<string, string> header, MetodoHttp metodo, string url, string controller, object parameter, ref ResponseModel respuesta)
        {
            string metodoHttp = "";

            string result = "";

            switch (metodo)
            {
                case MetodoHttp.Get:

                    metodoHttp = "GET";

                    break;

                case MetodoHttp.Post:

                    metodoHttp = "POST";

                    break;

                case MetodoHttp.Put:

                    metodoHttp = "PUT";

                    break;

                case MetodoHttp.Delete:

                    metodoHttp = "DELETE";

                    break;
            }

            ApiActionInvoke apiActionInvoke = new ApiActionInvoke(metodoHttp, url, controller, header, parameter);

            try
            {
                apiActionInvoke.InvokeAction();

                HttpResponseMessage responseMessage = apiActionInvoke.HttpMessageResponse;

                ///respuesta
                ///
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK
                    || responseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden
                    || responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized
                    || responseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    result = responseMessage.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    respuesta.CodRespuesta = EstadoRespuesta.Error;

                    respuesta.MensajeRespuesta = String.Format("Url: {0}, Controlador: {1} \r\n{2}", url, controller, responseMessage);
                }
            }

            catch (Exception ex)
            {

                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = ex.Message.Trim();

            }

            return result;
        }

    }

    /// <summary>
    /// Metodos HTTP
    /// </summary>
    public enum MetodoHttp
    {
        Post,
        Get,
        Put,
        Delete
    }
}
