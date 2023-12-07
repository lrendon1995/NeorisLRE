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
    public class MovimiientoController : ApiController
    {



        [HttpPost]
        [Route("api/registroMovimiento")]
        [ResponseType(typeof(ResponseModel))]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Ok. Devuelve el objeto registrado.", Type = typeof(ResponseModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Request Mal Formado. Debe enviar los parámetros adecuados para poder registrar el caso.", Type = typeof(ResponseModel))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Error en el proceso. Ocurrió un error no controlado en el proceso.", Type = typeof(ResponseModel))]
        [SwaggerResponseRemoveDefaults]
        public HttpResponseMessage registrarMovimiento([FromBody] ClienteModel objeto)
        {
            var resp = new ResponseModel();
            try
            {
                resp.Referencia = MovimientoCode.CrearMovimiento(objeto);
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
