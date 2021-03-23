using Ecto_TecBE.Models;
using Ecto_TecBE.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecto_TecBE.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        // POST: Emailcontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string email, string nombre, string ciudad, string fecha)
        {
            MailRequest mail = new MailRequest();
            mail.Email = email;
            mail.Subject = "Test";
            mail.Body = "Estimado " + nombre + "Hemos recibido sus datos y nos pondremos en contacto con" +
                "usted en la brevedad posible. Enviaremos un correo con información a su cuenta: " + email +
                "<br>" +
                "Atte. Green Leaves" + ciudad + "a " + fecha;
            try
            {
              //  using ()
              //  {
                    //emailSenderService.SendEmailAsync(mail);
                    return Ok();
              //  }


            }
            catch
            {
                return Ok(false);
            }
        }

    }
}
