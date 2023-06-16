using SOLID.Model;

namespace SOLID._1___O.Solution
{
    internal interface IReportGenerator
    {
        void CreateReport(List<Order> orders);
    }
}