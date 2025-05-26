using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using SupportTick.Models;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;
using static System.Net.WebRequestMethods;

namespace SupportTick.Services.service
{
    public class GmailSendService
    {
        public readonly GmailService _service;

        public GmailSendService(GmailService service)
        {
            _service = service;
        }

        public void SendGmail(Ticket ticket)
        {

            //email.setFrom(new InternetAddress(fromEmailAddress));
            //email.addRecipient(javax.mail.Message.RecipientType.TO,
            //    new InternetAddress(toEmailAddress));
            //email.setSubject(subject);
            //email.setText(bodyText);
            var message = new MailMessage();
            message.Subject = $"your ticket {ticket.FullName} is opened";
            message.Body = $"to follow your ticket state enter here http://localhost:4200/tickets/{ticket.TicketId}";


            var res = _service.Users.Messages.Send(message, "me").Execute();
        }

    }
}
.