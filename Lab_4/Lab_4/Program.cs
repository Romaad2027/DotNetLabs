using Lab_4.Facade;
using Lab_4.Subsystems;
using System;

namespace Lab_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer(new ComputerPower(), new OpSystem(), new ComputerPrograms());

            Console.WriteLine("Trying to switch on Computer");
            computer.SwitchOnComputer();
            Console.WriteLine();

            Console.WriteLine("Trying to switch on Computer again");
            computer.SwitchOnComputer();
            Console.WriteLine();

            Console.WriteLine("Trying to run Visual Studio");
            computer.RunVisualStudio();
            Console.WriteLine();

            Console.WriteLine("Trying to run Telegram");
            computer.RunTelegram();
            Console.WriteLine();

            Console.WriteLine("Trying to switch of Computer");
            computer.SwitchOffComputer();
            Console.WriteLine();

            Console.WriteLine("Trying to switch of Computer again");
            computer.SwitchOffComputer();
            Console.WriteLine();

        }
    }
}
