using eInfrastructure.Contexts;
using eInfrastructure.Languages;
using eInfrastructure.Models;
using eInfrastructure.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eInfrastructure.Repositories
{
    public class UsuarioRepository
    {
        private readonly ConfiguracionesModel configuraciones;

        private readonly ApplicationDbContext dbContext;

        private readonly ISession session;

        private readonly Localization language;

        public UsuarioRepository(ConfiguracionesModel configuraciones, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.configuraciones = configuraciones;

            this.dbContext = dbContext;

            session = httpContextAccessor.HttpContext.Session;

            language = new Localization(httpContextAccessor);
        }

        /// <summary>
        /// login del usuario
        /// </summary>
        /// <param name="_usuario"></param>
        /// <returns></returns>
        public ResponseModel Login(UsuarioLoginModel _usuario)
        {
            ResponseModel respuesta = new ResponseModel();

            if (_usuario == null)
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = language.getText(texto: "msgNoUsuarioLogin", fileName: "Usuario");

                return respuesta;
            }

            int horaSesion = configuraciones.TiempoSesionHora;

            ///vemos primeramente si el usuario existe 
            ///
            int vExiste = dbContext.Usuarios.Where(xx => xx.Cedula.ToUpper() == _usuario.Cedula.ToUpper()).Count();

            if (vExiste == 0)
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = language.getText(texto: "msgUsuarioNoExiste", fileName:"Usuario");

                return respuesta;
            }

            ///controlamos que la contrase#a sea la adecuada
            ///
            var usuario = dbContext.Usuarios.Include(ee => ee.Estado)
                                            .Where(u => u.Cedula.ToUpper() == _usuario.Cedula.ToUpper()).First();

            if (!BCrypt.Net.BCrypt.Verify(_usuario.Password, usuario.Contraseña))
            {
                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = language.getText(texto: "PasswordIncorrecto", fileName: "Usuario");

                return respuesta;
            }

            ///el usuario no se encuentra activo
            ///
            if (usuario.IdEstado != 1)
            {

                respuesta.CodRespuesta = EstadoRespuesta.Error;

                respuesta.MensajeRespuesta = String.Format(language.getText("msgUsuarioNoActivo"), usuario.Estado.DescripcionEstado);

                return respuesta;
            }

            ///ok todo correcto arriba, vemos para poder loguearnos y enviar los datos de session del token.
            ///
            string token = BCrypt.Net.BCrypt.HashPassword(
                String.Format("{0}/{1}/{2}",
                    usuario.Cedula,
                    DateTime.Now.ToLongTimeString(),
                    "@@eRestaurant.2022--")
            );

            string urlAvatar = $"{configuraciones.UrlPrincipal}/Imagenes/avatar-default.png";

            DatosUsuarioModel datosUsuario = new DatosUsuarioModel() 
            {
                IdUsuario = usuario.IdUsuario,

                NroCedula = usuario.Cedula,

                NombreUsuario = usuario.Nombre,

                Idioma = usuario.IdiomaElegido,

                Correo = usuario.Correo,

                esAdministrador = usuario.esAdministrador,

                Imagen = urlAvatar,

                IdEstado = usuario.IdEstado,

                Estado = usuario.Estado.DescripcionEstado
            };

            session.SetString("datosUsuario", JsonConvert.SerializeObject(datosUsuario));

            session.SetString("Token", token);

            session.SetString("Configuraciones", JsonConvert.SerializeObject(configuraciones));

            respuesta.CodRespuesta = EstadoRespuesta.Ok;

            respuesta.MensajeRespuesta = "[OK]";

            return respuesta;
        }

        /// <summary>
        /// para poder registrar usuarios
        /// </summary>
        /// <returns></returns>
        public ResponseModel Registrar(ParamUsuarioRegistroModel parametros)
        {
            ResponseModel respuesta = new ResponseModel();



            return respuesta;
        }
    }
}
