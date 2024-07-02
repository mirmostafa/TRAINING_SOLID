using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SOLID.OCP.Valid;

namespace SOLID.OCP
{
    public class OfflinePayment : IPaymentMethod
    {
        public void ProcessPayment()
        {
            // تغییر الگوریتم، بدون درگیری با کلاسهای مشابه
        }
    }

}