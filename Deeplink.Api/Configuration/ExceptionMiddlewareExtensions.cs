using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Deeplink.Api.Configuration
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var ex = contextFeature.Error;
                        if (ex == null) return;

                        var error = new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = ex.Message
                        };

                        using (var writer = new StreamWriter(context.Response.Body))
                        {
                            new JsonSerializer().Serialize(writer, error);
                            await writer.FlushAsync().ConfigureAwait(false);
                        }
                    }
                });
            });
        }
    }
}
