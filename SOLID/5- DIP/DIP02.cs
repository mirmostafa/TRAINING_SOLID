using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP02
{
	namespace Invalid
	{
        public class EmailService
        {
            public void SendEmail(string to, string subject, string body)
            {
                // پیاده‌سازی برای ارسال ایمیل
            }
        }

        public class Invoice
        {
            private EmailService _emailService;

            public Invoice()
            {
                _emailService = new EmailService();
            }

            public void Send()
            {
                // کد برای تولید فاکتور
                _emailService.SendEmail("customer@example.com", "Invoice", "Your invoice details");
            }
        }
    }

    namespace Valid
    {
        public interface IEmailService
        {
            void SendEmail(string to, string subject, string body);
        }
        public class EmailService : IEmailService
        {
            public void SendEmail(string to, string subject, string body)
            {
                // پیاده‌سازی برای ارسال ایمیل
            }
        }
        public class Invoice
        {
            private IEmailService _emailService;

            public Invoice(IEmailService emailService)
            {
                _emailService = emailService;
            }

            public void Send()
            {
                // کد برای تولید فاکتور
                _emailService.SendEmail("customer@example.com", "Invoice", "Your invoice details");
            }
        }

        public class GmailService : IEmailService
        {
            public void SendEmail(string to, string subject, string body) => throw new NotImplementedException();
        }
        public class YahooMailService : IEmailService
        {
            public void SendEmail(string to, string subject, string body) => throw new NotImplementedException();
        }
        public class HotMailService : IEmailService
        {
            public void SendEmail(string to, string subject, string body) => throw new NotImplementedException();
        }
    }
}
