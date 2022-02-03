using System;
using System.Net;

namespace LearnNico_Presentation.Middelware
{
	public class ErrorHandlingMiddelware
	{
        private readonly RequestDelegate next;
        public ErrorHandlingMiddelware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            try
            {
                await next(context);
            }
            catch (Exception error)
            {
                switch (error)
                {
                    case KeyNotFoundException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;


                    default:
                        break;
                }
            }

        }
    }
}

