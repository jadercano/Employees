using Employees.Common.Exceptions;
using Employees.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Employees.Common.Attributes
{
    /// <summary>
    /// Attribute for intercepting exceptions
    /// </summary>
    public class EmployeesHttpExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Sobreescribe el método para controlar las excepciones que se generan desde los web api controllers de la capa de servicios api.
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var controllerName = (string)context.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = (string)context.ActionContext.ActionDescriptor.ActionName;
            DateTime startDateTime = DateTime.Now;

            var message = context.Exception is EmployeesException
                ? context.Exception
                : new EmployeesException(string.Format(Messages.Error_UmanagedExceptions, controllerName, actionName), context.Exception);

            var excepcion = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(message), System.Text.Encoding.UTF8, "application/json")
            };
            context.Response = excepcion;

            //TODO Logging
        }
    }
}
