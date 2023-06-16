using SOLID.Model;

namespace SOLID._1___O.Problem
{
    public class ReportingService
    {
        internal void GenerateReport(List<Order> orders, ReportType type)
        {
            //Generic code to create report

            //Specific conversion depending on type

            switch (type)
            {
                case ReportType.Pdf:
                    CreatePdfReport(orders);
                    break;

                case ReportType.Excel:
                    CreateExcelReport(orders);
                    break;

                case ReportType.Json:
                    CreateJsonReport(orders);
                    break;

                case ReportType.Xml:
                    CreateXmlReport(orders);
                    break;

                default:
                    break;
            }
        }

        private void CreatePdfReport(List<Order> orders)
        {
            //Create Pdf Report
        }

        private void CreateExcelReport(List<Order> orders)
        {
            //Create Excel Report
        }

        private void CreateJsonReport(List<Order> orders)
        {
            //Create Json Report
        }

        private void CreateXmlReport(List<Order> orders)
        {
            //Create Xml Report
        }
    }
}