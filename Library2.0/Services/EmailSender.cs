using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class EmailSender
    {
        //public Task SendEmailAsync(string email, string message, string subject)
        //{
        //    var myMessage = new MimeMessage();

        //    myMessage.From.Add(new MailboxAddress("SomeName", "prenkufitim@gmail.com"));
        //    myMessage.To.Add(new MailboxAddress("", email));
        //    myMessage.Subject = subject;
        //    myMessage.Body = new TextPart("plain") { Text = message };

        //    using (var client = new SmtpClient())
        //    {
        //        await client.ConnectAsync("smtp.gmail.com", 587, false);
        //        client.AuthenticationMechanisms.Remove("XOAUTH2");
        //        try
        //        {

        //            await client.AuthenticateAsync
        //                ("prenkufitim@gmail.com",
        //                "bbzhoqfbsskhstqu");
        //        }
        //        catch
        //        {
        //        }

        //        await client.SendAsync(myMessage);
        //        await client.DisconnectAsync(true);
        //    }
    }
}
