using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace SpaceApp.Controllers
{
    public class MailerController : Controller
    {
        // GET: Mailer
        public ActionResult Send(String mail)
        {
            Mail.Send(mail,"123","Launch this weekend!");
            return RedirectToAction("Index","Home");
        }
    }
    public static class Mail
    {
        private static string from = "spacelaunchpublic@gmail.com";
        private static string password = "spacelaunch123";
        public static void Send(string to,string launchId, string subject)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(from,password);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            /*
            LinkedResource res = new LinkedResource("C:/Users/MIlos/source/repos/spaceapps/SpaceApp/SpaceApp/Content/images/rocket.jpg");
            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = @"<img src='cid:" + res.ContentId + @"'/>";
            
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            */
            mail.Body = @"
                    <html>
	<head>
     <link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css' integrity='sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO' crossorigin='anonymous'>
	<script src='https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js' integrity='sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy' crossorigin='anonymous'></script>
    </head>
	<body>
	<div class='container' >
	<div class='row'>
		<h1 class='col-sm-12'>Rocket Launch Reminder</h1>
	</div>
	<div class='row'>
	<img src='https://media.defense.gov/2006/Jan/23/2000569399/-1/-1/0/060123-F-0000S-001.JPG' class='img-fluid' style='max-height:600px'  alt='Image not available' ></img>
	</div>
	<div class='row'>
		<p class='col-sm-12'>The rocket is scheduled to launch on Oct 21<sup>st</sup>.</p>
		<p class='col-sm-12'>Be sure not to miss it! For more details check our <b><a href='#'>website</a></b>.</p>
	</div>
	</div>
	
	</body>
</html>
                        ";
           // mail.AlternateViews.Add(alternateView);
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
    }
}
