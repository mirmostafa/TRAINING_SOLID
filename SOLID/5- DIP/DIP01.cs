namespace SOLID.DIP
{
	namespace Invalid
	{
        // کلاس ناقض DIP
        public class LightBulb
        {
            public void On()
            {
                // روشن کردن لامپ
            }
        }
        public class LightSwitch
        {
            private LightBulb _lightBulb;
            public LightSwitch(LightBulb lightBulb)
            {
                _lightBulb = lightBulb;
            }
            public void TurnOn()
            {
                _lightBulb.On();
            }
        }

        // اشکال این کد چیست؟
        // Multi-inheritance
        //فقط یک کلاس را میپذیرد. همه کالاسها، باید از همین کلاس ارث‌بری شوند تا توسط این کلاس قابل استفاده باشند.
    }

    namespace Valid
	{
        // اصلاح شده بر اساس DIP
        public interface ILightBulb
        {
            void On();
        }

        public class LightBulb : ILightBulb
        {
            public void On()
            {
                // روشن کردن لامپ
            }
        }

        public class LightSwitch
        {
            private readonly ILightBulb _lightBulb;
            public LightSwitch(ILightBulb lightBulb)
            {
                _lightBulb = lightBulb;
            }
            public void TurnOn()
            {
                _lightBulb.On();
            }
        }
    }
}
