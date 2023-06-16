using SOLID._0___S.Solution;
using SOLID._1___O.Solution;

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
        }
    }
}