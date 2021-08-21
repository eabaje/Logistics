using Logistics.Infrastructure.Helpers;
using Logistics.Infrastructure.Managers.Abstract;
using Logistics.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Infrastructure.Managers.Implemetations
{
   public  class EmailManager :IEmailManager
    {
        private readonly IConfiguration _config;
        private readonly string _sendGridApiKey;
        private readonly string _fromEmail;
        private readonly string _fromUser;
        private readonly string _plainTextContent ;
        private readonly string _htmlContent;
        public EmailManager(IConfiguration config)
        { 
            //,string plainTextContent,string htmlContent
            _config = config;
            _sendGridApiKey = _config.GetValue<string>("SENDGRID_API_KEY");
            _sendGridApiKey = _config.GetValue<string>("SENDGRID_API_KEY");
            _fromEmail = _config.GetValue<string>("FROMEMAIL");
            _fromUser = _config.GetValue<string>("FROMUSER");
            //_plainTextContent = plainTextContent;
            //_htmlContent = htmlContent;
           


        }
        public async Task<string> SendTemplateEmail(string templatePath,string email, string name,string subject, AccountViewModel Account, string message)
        {
          var  template= String.IsNullOrEmpty(templatePath) ?  "Templates.AccountTemplate": templatePath;

            RazorParser renderer = new RazorParser(typeof(EmailClient).Assembly);
            var body = renderer.UsingTemplateFromEmbedded(template,
                Account);
            var response = await SendGridEmailAsync(email, name,subject, body);
            return response;
        }

        public async Task<string> SendGridEmailAsync(string receiverAddress, string receiverName, string subject, string message)
        {
           
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress(_fromEmail, _fromUser);

            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = message;
            subject = subject ?? "Welcome to Load Dispatch";
           
            var to = new EmailAddress(receiverAddress, receiverName);
          
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                message = "Thank you for your message, someone will be in touch soon!";
            }
            return message;



        }
    }
}
