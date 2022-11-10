using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EShop.Contracts.Exceptions;
using Newtonsoft.Json;

namespace EShop.Presentation.Extensions
{
    public class ErrorHandlers
    {
        private readonly RequestDelegate _next;

        public ErrorHandlers(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            try 
            {
                await _next(context);
            }
            catch(Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string errMessage;

                switch(error)
                {
                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errMessage = error.Message;
                        break;

                    case ErrorException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errMessage = error.Message;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errMessage = "Something go wrong";
                        break;

                }

                var result = JsonConvert.SerializeObject(new { error = true, message = errMessage});
                
                await response.WriteAsync(result);
            }
        }
    }
}