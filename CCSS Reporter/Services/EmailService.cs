using CCSS_Reporter.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace CCSS_Reporter.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailService : ControllerBase
    {
        [HttpPost("SendEmail")]
        public async void SendEmail([FromBody] Profesional profesional)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Sistema de reportes", "ccssservicereporter@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", profesional.Correo));
            emailMessage.Subject = "Reporte de registro de usuario en CCSS  Reporter";
            emailMessage.Body = new TextPart("html") { Text = "Su registro se a realizado de forma correcta, el los sistemas de CCSS Reporter su numero unico de registro es: " + profesional.NumeroRegistro1 };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("ccssservicereporter@gmail.com", "tlqyodmdzcxgbmbf");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        [HttpPost("SendEmailReport")]
        public async void SendReportMail([FromBody] Reporte reporte)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Sistema de reportes", "ccssservicereporter@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", reporte.Profesional.Correo));
            emailMessage.To.Add(new MailboxAddress("", reporte.Paciente.CorreoElectronico));

            emailMessage.Subject = "Comprobante de atencion de pacientes";
            emailMessage.Body = new TextPart("html")
            {
                Text = $@"<!DOCTYPE html>
    <html>
    <head>
    <meta charset=utf-8 />
    <title>Editor JavaScript online - www.cubicfactory.com</title>
    </head>
    <body style=""color: black;"">
    <section style=""text-align: center; background-color: aqua;"">
       
    <div id=""image"" style=""width: 30px; height: 30px;"">
    <img width=""100"" height=""95"" src=""https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.crnova.com%2Fcontent%2Fimages%2Fclients%2Flogo-ccss.png&f=1&nofb=1&ipt=08979d7f5ae90461e79338d5235de9438f6f1e6acafb0b3aab9cf56dc2fb0e83&ipo=images"" alt="""">
    </div>

    <h1>Reporte de atencion CCSS Reporter</h1>
    <h1></h1>
    <h3>En atencion a: {reporte.Paciente.Nombre}</h3>
    <h3>Genero: {reporte.Paciente.Genero}</h3>
    <h3>Fecha de nacimiento: {reporte.Paciente.FechaNacimiento}</h3>
    </section>

    <section style=""text-align: center; background-color: aqua;"">
        <h1>Datos de quien atiende</h1>
    <h1></h1>
    <h3>Profesional: {reporte.Profesional.NombreCompleto1}</h3>
    <h3>Identificacion: {reporte.Profesional.Identificacion1}</h3>
    </section>
    </body>
    <footer style=""background-color: rgb(207, 231, 253);"">
         <h4 style=""float: right; margin-right: 50px;"">Fecha del la atención: {reporte.fechaAtencion}</h4>
    </footer>
    </html>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("ccssservicereporter@gmail.com", "tlqyodmdzcxgbmbf");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
