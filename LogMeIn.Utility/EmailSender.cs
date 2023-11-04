using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace LogMeIn.Utility;

public class EmailSender : IEmailSender
{
    private readonly string emailFrom;
    private readonly string password;

    public EmailSender(IConfiguration configuration)
    {
        emailFrom = configuration.GetValue<string>("Email:Mail");
        password = configuration.GetValue<string>("Email:Password");
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var message = new MailMessage();
        message.From = new MailAddress(emailFrom);
        message.Subject = subject;
        message.To.Add(new MailAddress(email));
        message.Body = htmlMessage;
        message.IsBodyHtml = true;


        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(emailFrom, password),
            EnableSsl = true
        };

        smtpClient.Send(message);
        return Task.CompletedTask;
    }

    // public async Task<string> Invoice()
    // {
    //     using (var stringWriter = new StringWriter())
    //     {
    //         var viewResult = _compositeViewEngine.FindView(ControllerContext, "Cat", false);
    //
    //         if (viewResult.View == null) throw new ArgumentNullException("View", "View not found");
    //
    //         var helper = new Helper1(UnitOfWork);
    //         var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
    //         {
    //             Model = helper.Cat(1)
    //         };
    //
    //         var viewContext = new ViewContext(
    //             ControllerContext,
    //             viewResult.View,
    //             viewDictionary,
    //             TempData,
    //             stringWriter,
    //             new HtmlHelperOptions()
    //         );
    //
    //         await viewResult.View.RenderAsync(viewContext);
    //
    //         await _emailSender.SendEmailAsync("ondrejman1@gmail.com", "panda", stringWriter.ToString());
    //
    //         return stringWriter.ToString();
    //     }
    // }
}