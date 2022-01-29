using eInfrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWebApi.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = (Controller)context.Controller;

            ///controlamos que este logueado
            ///
            if (String.IsNullOrEmpty(context.HttpContext.Session.GetString("datosUsuario")))
            {
                context.Result = controller.RedirectToAction("Iniciar", "Usuario");
            }

            ///si todo esta correcto
            ///
            if (!String.IsNullOrEmpty(context.HttpContext.Session.GetString("datosUsuario")))
            {
                var datosUsuario = JsonConvert.DeserializeObject<DatosUsuarioModel>(context.HttpContext.Session.GetString("datosUsuario"));

                //controlamos que le hayamos sacado los permisos cuando ya estaba logueado

                if (datosUsuario.IdEstado != 1)
                {
                    context.HttpContext.Session.Clear();

                    context.Result = controller.RedirectToAction("Iniciar", "Usuario");
                }
                else
                {
                    ///aca validamos que sea el administrador que usa algunos controladores/acciones
                    ///

                    
                    ///vemos algunos datos extras para trasladar a todos los controladores
                    ///
                    ConfiguracionesModel configuraciones = new ConfiguracionesModel();

                    try
                    {
                        configuraciones = JsonConvert.DeserializeObject<ConfiguracionesModel>(context.HttpContext.Session.GetString("Configuraciones"));
                    }
                    catch { }

                    controller.ViewBag.DatosUsuario = datosUsuario;

                    controller.ViewBag.Configuraciones = configuraciones;
                }
            }
        }
    }
}
