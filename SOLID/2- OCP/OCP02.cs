namespace SOLID.OCP02
{
	namespace Invalid
	{
        // مثال کد بدون رعایت OCP
        public class ReportGenerator
        {
            public void GenerateReport(string reportType)
            {
                if (reportType == "PDF")
                {
                    // تولید گزارش PDF
                }
                else if (reportType == "Excel")
                {
                    // تولید گزارش Excel
                }
            }
        }
    }
	namespace Valid
	{
        // مثال کد با رعایت OCP
        public interface IReportGenerator
        {
            void Generate();
        }

        public class PDFReportGenerator : IReportGenerator
        {
            public void Generate()
            {
                // تولید گزارش PDF
            }
        }

        public class ExcelReportGenerator : IReportGenerator
        {
            public void Generate()
            {
                // تولید گزارش Excel
            }
        }

        public class ReportGenerator
        {
            private IReportGenerator reportGenerator;

            public ReportGenerator(IReportGenerator reportGenerator)
            {
                this.reportGenerator = reportGenerator;
            }

            public void GenerateReport()
            {
                reportGenerator.Generate();
            }
        }
    }
}
