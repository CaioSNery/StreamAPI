using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Stream.Interfaces;

namespace Stream.Services
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        
            public async Task EnviarEmailAsync(string para, string assunto, string corpoHtml)
        {
             var remetente = _config["EmailSettings:Remetente"];
             var senha = _config["EmailSettings:Senha"];

             var mensagem = new MailMessage();
             mensagem.From = new MailAddress(remetente);
             mensagem.To.Add(para);
             mensagem.Subject = assunto;
             mensagem.Body = corpoHtml;
             mensagem.IsBodyHtml = true;

              using var smtp = new SmtpClient("smtp.gmail.com", 587)
           {
            Credentials = new NetworkCredential(remetente, senha),
            EnableSsl = true
           };

            await smtp.SendMailAsync(mensagem);
        }
    }
}
