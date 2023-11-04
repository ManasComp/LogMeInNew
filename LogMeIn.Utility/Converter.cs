using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LogMeIn.Utility;

public class Converter

{
    private readonly IEmailSender _emailSender;

    public Converter(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task Invoice<T>(IView view, T model, ControllerContext controllerContext, ITempDataDictionary tempData,
        string email, string subject)
    {
        using (var stringWriter = new StringWriter())
        {
            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            await view.RenderAsync(
                new ViewContext(
                    controllerContext,
                    view,
                    viewDictionary,
                    tempData,
                    stringWriter,
                    new HtmlHelperOptions()
                )
            );

            await _emailSender.SendEmailAsync(email, subject, stringWriter.ToString());
        }
    }
}