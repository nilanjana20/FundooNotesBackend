using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Model
{
    public class MsmqModel
    {
        MessageQueue msgQueue = new MessageQueue();

        public void MsmqSend(string token)
        {
            msgQueue.Path = @".\private$\Token";  //windows msmq path
            if (!MessageQueue.Exists(msgQueue.Path))
            {
                MessageQueue.Create(msgQueue.Path);
            }

            msgQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            msgQueue.ReceiveCompleted += MsgQueue_ReceiveCompleted;
            msgQueue.Send(token);
            msgQueue.BeginReceive();
            msgQueue.Close();
        }

        private void MsgQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = msgQueue.EndReceive(e.AsyncResult);
            string token = msg.Body.ToString();

            string subject = "Fundoo note password reset";
            string body = token;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("nilachakraborty09@gmail.com", "cmwgiwfslffivphu"),
                EnableSsl = true,
            };

            smtpClient.Send("nilachakraborty09@gmail.com", "nilachakraborty09@gmail.com", subject, body);
            msgQueue.BeginReceive();
        }
    }
}
