using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace MongoDbFoodMart.Controllers
{
    public class SendMailController : Controller
    {
        private readonly IConfiguration _configuration;

        public SendMailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Send(string name, string email)
        {
          
               
                MimeMessage mimeMessage = new MimeMessage();

             
                MailboxAddress mailboxAddressFrom = new MailboxAddress("FoodMart", "iskitoglu.berk@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

         
                MailboxAddress mailboxAddressTo = new MailboxAddress(name, email);
                mimeMessage.To.Add(mailboxAddressTo);

                mimeMessage.Subject = "🎉 Açılışa Özel %25 İndirim Fırsatı!";

           
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $@"
            <html>
            <body style='font-family:Arial,sans-serif; background:#f4f4f4; padding:20px;'>
                <div style='max-width:600px; background:#fff; padding:20px; border-radius:10px; box-shadow:0 0 10px rgba(0,0,0,0.1);'>
                    <h2 style='color:#ff6600;'>Merhaba {name},</h2>
                    <p>FoodMart olarak açılışımıza özel <b>%25 indirim</b> fırsatı sunuyoruz!</p>
                    <p>Aşağıdaki indirim kodunu kullanarak alışverişinizde avantaj sağlayabilirsiniz:</p>
                    
                    <h3 style='background:#ff6600; color:#fff; padding:10px; display:inline-block; border-radius:5px;'>INDIRIM25</h3>
                    
                    <p style='margin-top:20px;'>Bu fırsattan hemen yararlanmak için aşağıdaki butona tıklayın:</p>
                    
                    <a href='https://foodmart.com' 
                       style='display:inline-block; background:#ff6600; color:#fff; padding:12px 20px; text-decoration:none; font-size:16px; border-radius:5px;'>
                       🛍 Alışverişe Başla
                    </a>
                    
                    <p style='margin-top:20px; font-size:14px; color:#666;'>Eğer herhangi bir sorunuz olursa, bizimle <a href='mailto:support@foodmart.com'>iletişime</a> geçebilirsiniz.</p>
                    <p>Sevgiler,<br><b>FoodMart Ekibi</b></p>
                </div>
            </body>
            </html>";

                mimeMessage.Body = bodyBuilder.ToMessageBody();

             
                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("iskitoglu.berk@gmail.com", "thvvxmaroclpvhbd");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }

            return RedirectToAction("UILayout", "Default");
        }


    }
    }

