using SOLID.Model;

namespace SOLID._1___O.Solution
{
    internal class ProgramO
    {
        public void EjecutarProgramO()
        {
            List<Order> orders = new List<Order>(); //Get orders from data source

            ReportingService service = new ReportingService(new ReportGeneratorPdf()); //Send implementation
            //ReportingService service = new ReportingService(new ReportGeneratorExcel()); //Send implementation
            //ReportingService service = new ReportingService(new ReportGeneratorJson()); //Send implementation
            //ReportingService service = new ReportingService(new ReportGeneratorXml()); //Send implementation
            service.GenerateReport(orders);
        }
    }
}