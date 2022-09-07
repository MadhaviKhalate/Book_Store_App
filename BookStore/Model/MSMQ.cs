using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Model
{
    public class MSMQ
    {
        MessageQueue messageQueue = new MessageQueue();

        public void sendData2Queue(string Token)
        {

            messageQueue.Path = @".\private$\Token";

            if (!MessageQueue.Exists(messageQueue.Path))
            {

                //Exists
                MessageQueue.Create(messageQueue.Path);

            }

            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
            messageQueue.Send(Token);
            messageQueue.BeginReceive();
            messageQueue.Close();
        }

        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = messageQueue.EndReceive(e.AsyncResult);
            string Token = msg.Body.ToString();
            string subject = "Book Store Reset Link";
            string Body = Token;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("madhavikhalate123@gmail.com");
            mail.To.Add("madhavikhalate123@gmail.com");
            mail.Subject = "subject";

            mail.IsBodyHtml = true;
            string htmlBody;

            htmlBody = "Write some HTML code here";

            mail.Body = "<body><p>Dear Lakshmi,<br><br>" +
                "We have sent you a link for resetting your password.<br>" +
                "Please copy it and paste in your swagger authorization.</body>" + Token;


            var SMTP = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("madhavikhalate123@gmail.com", "ovhlontshvyrnmbd"),
                EnableSsl = true
            };
            SMTP.Send(mail);
            messageQueue.BeginReceive();
        }
    }
}
