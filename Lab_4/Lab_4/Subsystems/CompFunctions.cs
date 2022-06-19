using System;
using System.Threading;

namespace Lab_4.Subsystems
{
    public class ComputerPower
    {
        public void SwitchOnComputer()
        {
            Console.WriteLine("Loading...");
            //... very complicated process for switching on the computer
            Thread.Sleep(1000);
            Console.WriteLine("Computer is switched on");
        }

        public void SwitchOffComputer()
        {
            Console.WriteLine("Waiting...");
            //... very complicated process for switching off the computer
            Thread.Sleep(1000);
            Console.WriteLine("Computer is switched off");
        }
    }

    public class OpSystem
    {
        public void IntializeOS()
        {
            Console.WriteLine("Waiting...");
            //... very complicated process for initialazing OS
            Thread.Sleep(1000);
            Console.WriteLine("OS System is initialized");
        }

        public void DisposeOS()
        {
            Console.WriteLine("Waiting...");
            //... very complicated process for disposing OS
            Thread.Sleep(1000);
            Console.WriteLine("OS System is disposed");
        }
    }

    public class ComputerPrograms
    {
        public void RunVisualStudio()
        {
            Console.WriteLine("Visual studio is running");
        }

        public void RunTelegram()
        {
            Console.WriteLine("Telegram is running");
        }
    }
}
