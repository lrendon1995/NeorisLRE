using NeorisLRE.Code;
using NeorisLRE.Filters;
using NeorisLRE.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace NeorisLRE.Controllers
{
    public class ClienteController : ApiController
    {
        /// <summary>
        /// Registra un cliente del tipo de proceso que se le envíe desde el Conector.
        /// </summary>
        /// <param name="objeto">Modelo de Request para Cliente.</param>
        /// <remarks>
        /// Ejemplo:
        ///
        ///     POST /CrearCliente
        ///     {
        ///        "idcliente": 1,
        ///        "idpersona": "1112",
        ///        "estado": "activo",
        ///        "nombrecliente": "Luiggi Rendon"
        ///     }
        ///
        /// </remarks>
        /// <returns>El Número de Ticket CRM creado</returns>
        /// <response code="200">Ok. Devuelve el objeto registrado.</response>
        /// <response code="400">Request Mal Formado. Debe enviar los parámetros adecuados para poder registrar el caso.</response>
        /// <response code="500">Ocurrió algún error en el proceso.</response>
        [HttpPost]
        [Route("api/CrearCliente")]
        [ResponseType(typeof(ResponseModel))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Ok. Devuelve el objeto registrado.", Type = typeof(ResponseModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Request Mal Formado. Debe enviar los parámetros adecuados para poder registrar el caso.", Type = typeof(ResponseModel))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Error en el proceso. Ocurrió un error no controlado en el proceso.", Type = typeof(ResponseModel))]
        [SwaggerResponseRemoveDefaults]
        /*Similar para consultar, actualizar y eliminar cliente*/
        public HttpResponseMessage CrearCaso([FromBody] ClienteModel objeto)
        {
            var resp = new ResponseModel();
            try
            {
                resp.Referencia = ClienteCode.CrearCliente(objeto);
                resp.Codigo = 0;
                resp.Mensaje = "OK";
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (NegocioException ex)
            {
                resp.Codigo = 99;
                resp.Mensaje = ex.Message;
                resp.Referencia = ex.StackTrace + " --- " + ex.InnerException?.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, resp);
            }
            catch (Exception ex)
            {
                resp.Codigo = -1;
                resp.Mensaje = "Ocurrió un error en la creación del cliente.";
                resp.Referencia = ex.Message + " --- " + ex.StackTrace + " --- " + ex.InnerException?.Message;
                return Request.CreateResponse(HttpStatusCode.InternalServerError, resp);
            }
        }

    }
}
