using SOLID._0___S.Solution;
using SOLID._1___O.Solution;
using SOLID._3___I.Solution;
using SOLID._4___D.Solution;

namespace SOLID
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var programS = new ProgramS();
            programS.EjecutarProgramS();

            var programO = new ProgramO();
            programO.EjecutarProgramO();

            var programI = new ProgramI();
            programI.EjecutarProgramI();

            var programD = new ProgramD();
            programD.EjecutarProgramD();
        }
    }
}