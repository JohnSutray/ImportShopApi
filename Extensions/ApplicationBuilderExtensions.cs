﻿using System.Net;
using System.Threading.Tasks;
using ImportShopApi.Extensions.Common;
using ImportShopCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ImportShopApi.Extensions {
  public static class ApplicationBuilderExtensions {
    public static IApplicationBuilder UseJsonExceptionHandler(this IApplicationBuilder app) => app
      .UseExceptionHandler(applicationBuilder => applicationBuilder.Run(SerializeError));

    private static async Task SerializeError(this HttpContext context) {
      context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
      context.Response.ContentType = "application/json";
      if (context.Features.Get<IExceptionHandlerFeature>()?.Error.Message is {} errorMessage)
        await context.Response.WriteAsync(errorMessage.WrapIntoEnumerable().ToJson());
    }
  }
}