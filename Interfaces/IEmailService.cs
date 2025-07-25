using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stream.Interfaces
{
    public interface IEmailService
    {
        Task EnviarEmailAsync(string para, string assunto, string mensagemHtml);
    }
}