namespace LogMeIn.Areas.Visitor.Controllers;

using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class CustomError : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);

        if (context.Response.StatusCode == StatusCodes.Status404NotFound)
        {
            // Return a custom error image for 404 Not Found
            context.Response.ContentType = "image/jpeg"; // Set the content type for the image
            await context.Response.SendFileAsync("wwwroot/pictures/Error_cz.png"); // Replace with the path to your error image
        }
        // Add more conditions for other status codes if needed
    }
}
