namespace SOLID.OCP01
{
	namespace Invalid
	{
        // کلاس ناقض OCP
        public class PaymentProcessor
        {
            public void ProcessPayment(string paymentMethod)
            {
                // Magic Words
                if (paymentMethod == "CreditCard")
                {
                    // پردازش کارت اعتباری
                }
                else if (paymentMethod == "PayPal")
                {
                    // پردازش PayPal
                }
            }
        }
    }

    namespace Valid
	{
        // اصلاح شده بر اساس OCP
        public interface IPaymentMethod
        {
            void ProcessPayment();
        }

        public class CreditCardPayment : IPaymentMethod
        {
            public void ProcessPayment()
            {
                // پردازش کارت اعتباری
            }
        }

        public class PayPalPayment : IPaymentMethod
        {
            public void ProcessPayment()
            {
                // پردازش PayPal
            }
        }

        public class PaymentProcessor
        {
            private readonly IPaymentMethod _paymentMethod;
            public PaymentProcessor(IPaymentMethod paymentMethod)
            {
                _paymentMethod = paymentMethod;
            }
            public void ProcessPayment()
            {
                _paymentMethod.ProcessPayment();
            }
        }
    }
}
