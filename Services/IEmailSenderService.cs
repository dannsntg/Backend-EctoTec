using Ecto_TecBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecto_TecBE.Services
{
    interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string nombre, string ciudad, string fecha);
    }
}
