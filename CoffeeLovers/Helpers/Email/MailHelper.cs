using CoffeeLovers.Common.Extensions;
using CoffeeLovers.Common.Options;
using CoffeeLovers.Helpers.Email;
using CoffeeLovers.NotificationService.Message;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text;

namespace CoffeeLovers.Helpers
{
    public class MailHelper
    {
        private readonly BasicEmailSettings _basicEmailSettings;
        private readonly IConfiguration _configuration;

        public MailHelper(IOptionsSnapshot<BasicEmailSettings> options, IConfiguration Configuration)
        {
            _basicEmailSettings = options.Value;
            _configuration = Configuration;
             CheckArguments();
        }

        internal EmailMessage GetEmailMessage(string topicName, object obj)
        {
            StringBuilder emailBody = GetEmailBodyTemplate(topicName);
            emailBody = ReplaceGenericPlaceHolders(emailBody, topicName, obj);

            SetTopicSpecificEmailSettings(topicName, obj);

            return EmailMessageBuilder
                            .Init()
                            .AddSubject(_basicEmailSettings.Subject)
                            .AddFrom(_basicEmailSettings.From)
                            .AddBody(emailBody.ToString())
                            .AddTo(_basicEmailSettings.To)
                            .Build();
        }

        internal StringBuilder GetEmailBodyTemplate(string topicName)
        {
            var builder = new StringBuilder();

            string targetFile = Path.Combine("EmailTemplates",Path.GetFileName("AddOwner.html"));

            if (File.Exists(targetFile))
            {
                builder.Append(File.ReadAllText(targetFile));
            }
            else
            {
                throw new FileNotFoundException("AddOwner.html");
            }
          

            return builder;
        }

        private StringBuilder ReplaceGenericPlaceHolders(StringBuilder emailBody, string topicName, dynamic obj)
        {
            switch (topicName)
            {
                case "AddOwner":
                    emailBody.Replace("{{UserName}}", obj.FullName);
                    emailBody.Replace("{{Link}}", obj.ConfirmationLink);
                    break;

                default: break;
            }

            return emailBody;
        }

        private BasicEmailSettings SetTopicSpecificEmailSettings(string topicName, dynamic obj)
        {
            switch (topicName)
            {
                case "AddOwner":
                    _basicEmailSettings.Subject = _configuration["MailSettings:Topics:AddOwner:Subject"];
                    _basicEmailSettings.To = obj.EmailId;
                    break;

                default: break;
            }

            return _basicEmailSettings;
        }

        private void CheckArguments()
        {
            _basicEmailSettings.CheckArgumentIsNull(nameof(_basicEmailSettings));
            _configuration.CheckArgumentIsNull(nameof(_configuration));
        }
    }
}