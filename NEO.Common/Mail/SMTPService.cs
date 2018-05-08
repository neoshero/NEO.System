using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;

namespace NEO.Common
{
    public class SmtpService
    {
        public void SendMail(string to, string subject, string body, bool isBodyHtml = true)
        {
            SendMail(null, new List<string>() { to }, subject, body, null, isBodyHtml);
        }

        public void SendMail(IEnumerable<string> to, string subject, string body, bool isBodyHtml = true)
        {
            SendMail(null, to, subject, body, null, isBodyHtml);
        }

        public void SendMail(string to, string subject, string body, IEnumerable<string> attachments, bool isBodyHtml = true)
        {
            SendMail(null, new List<string>() { to }, subject, body, attachments, isBodyHtml);
        }

        public void SendMail(IEnumerable<string> to, string subject, string body, IEnumerable<string> attachments, bool isBodyHtml = true)
        {
            SendMail(null, to, subject, body, attachments, isBodyHtml);
        }

        public void SendMail(string from, string to, string subject, string body, IEnumerable<string> attachments, bool isBodyHtml = true)
        {
            SendMail(from, new List<string>() { to }, subject, body, attachments, isBodyHtml);
        }

        public void SendMail(string from, IEnumerable<string> to, string subject, string body, IEnumerable<string> attachments, bool isBodyHtml = true)
        {
            if (to.Count() == 0)
                return;

            MailMessage message = new MailMessage();

            if (!string.IsNullOrWhiteSpace(from))
                message.From = new MailAddress(from);

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isBodyHtml;

            string bcc = System.Configuration.ConfigurationManager.AppSettings["BCC"];
            if (!string.IsNullOrWhiteSpace(bcc))
            {
                message.Bcc.Add(new MailAddress(bcc));
            }

            foreach (string t in to)
            {
                message.To.Add(new MailAddress(t));
            }

            if (attachments != null)
            {
                foreach (string attachment in attachments)
                {
                    if (File.Exists(attachment))
                    {
                        message.Attachments.Add(new Attachment(attachment));
                    }
                }
            }

            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
            }
            catch (Exception exp)
            {
                WriteSmtpExceptionLog(to, exp);
            }
        }

        private void WriteSmtpExceptionLog(IEnumerable<string> emailList, Exception exp)
        {
            var logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Log");
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            File.WriteAllText(logFolder + "mail-" + Guid.NewGuid() + ".log",
                string.Format("Email: {0}\r\nException Message: {1}", string.Join(";",emailList), exp.Message)
                );
        }

        public void SendMail(string to, string subject, string templatePath, IDictionary<string, string> templateArgs)
        {
            SendMail(null, new List<string>() { to }, subject, null, templatePath, templateArgs);
        }

        public void SendMail(string to, string subject, IEnumerable<string> attachments, string templatePath, IDictionary<string, string> templateArgs)
        {
            SendMail(null, new List<string>() { to }, subject, attachments, templatePath, templateArgs);
        }

        public void SendMail(IEnumerable<string> to, string subject, string templatePath, IDictionary<string, string> templateArgs)
        {
            SendMail(null, to, subject, null, templatePath, templateArgs);
        }

        public void SendMail(IEnumerable<string> to, string subject, IEnumerable<string> attachments, string templatePath, IDictionary<string, string> templateArgs)
        {
            SendMail(null, to, subject, attachments, templatePath, templateArgs);
        }

        public void SendMail(string from, string to, string subject, IEnumerable<string> attachments, string templatePath, IDictionary<string, string> templateArgs)
        {
            SendMail(from, new List<string>() { to }, subject, attachments, templatePath, templateArgs);
        }

        public void SendMail(string from, IEnumerable<string> to, string subject, IEnumerable<string> attachments, string templatePath, IDictionary<string, string> templateArgs)
        {
            string templateContent = File.ReadAllText(templatePath, Encoding.UTF8);

            if (templateArgs != null)
            {
                foreach (KeyValuePair<string, string> arg in templateArgs)
                {
                    string target = string.Format("<?{0}?>", arg.Key.ToUpper());
                    templateContent = templateContent.Replace(target, arg.Value);
                }
            }

            SendMail(from, to, subject, templateContent, attachments);
        }
    }
}
