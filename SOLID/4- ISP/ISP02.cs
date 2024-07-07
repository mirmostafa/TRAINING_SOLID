namespace SOLID.ISP02
{
    namespace Invalid
    {
        public interface IEmployee
        {
            void AttendMeeting();
            void GetSalary();
            void SubmitTimesheet();
            void Work();
        }

        public class Manager : IEmployee
        {
            public void Work() { /* Implementation */ }
            public void AttendMeeting() { /* Implementation */ }
            public void GetSalary() { /* Implementation */ }
            public void SubmitTimesheet() { /* Implementation */ }
        }

        public class RegularEmployee : IEmployee
        {
            public void Work() { /* Implementation */ }
            public void AttendMeeting() { /* Implementation */ }
            public void GetSalary() { /* Implementation */ }
            public void SubmitTimesheet() { /* Implementation */ }
        }

        public class Contractor : IEmployee
        {
            public void Work() { /* Implementation */ }
            public void AttendMeeting() { /* Implementation */ }
            public void GetSalary() { /* Implementation */ }
            public void SubmitTimesheet() { /* Implementation */ }
        }
        // در اینجا یک مشکل وجود دارد. پیمانکاران نیاز ندارند که به جلسات شرکت کنند یا حقوق بگیرند. با این حال، مجبور هستند این متدها را پیاده‌سازی کنند. این تخطی از اصل جداسازی رابط است.
    }

    namespace Valid
    {
        public interface IWorker
        {
            void Work();
        }

        public interface IMeetingAttendee
        {
            void AttendMeeting();
        }

        public interface ISalariedEmployee
        {
            void GetSalary();
        }

        public interface ITimesheetSubmittable
        {
            void SubmitTimesheet();
        }
        public class Manager : IWorker, IMeetingAttendee, ISalariedEmployee
        {
            public void Work() { /* Implementation */ }
            public void AttendMeeting() { /* Implementation */ }
            public void GetSalary() { /* Implementation */ }
        }

        public class RegularEmployee : IWorker, IMeetingAttendee, ISalariedEmployee, ITimesheetSubmittable
        {
            public void Work() { /* Implementation */ }
            public void AttendMeeting() { /* Implementation */ }
            public void GetSalary() { /* Implementation */ }
            public void SubmitTimesheet() { /* Implementation */ }
        }

        public class Contractor : IWorker, ITimesheetSubmittable
        {
            public void Work() { /* Implementation */ }
            public void SubmitTimesheet() { /* Implementation */ }
        }

    }
}