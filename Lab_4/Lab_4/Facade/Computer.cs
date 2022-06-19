using Lab_4.Subsystems;
using System;

namespace Lab_4.Facade
{
    //FACADE
    public class Computer
    {
        ComputerPower computerPower { get; set; }
        OpSystem operatingSystem { get; set; }
        ComputerPrograms computerPrograms { get; set; }

        private bool isComputerSwithcedOn;


        public Computer(ComputerPower computerPower, OpSystem operatingSystem, ComputerPrograms computerPrograms)
        {
            this.computerPower = computerPower;
            this.operatingSystem = operatingSystem;
            this.computerPrograms = computerPrograms;
            isComputerSwithcedOn = false;
        }

        public void SwitchOnComputer()
        {
            if (isComputerSwithcedOn)
            {
                Console.WriteLine("Computer is already switched on");
                return;
            }
            computerPower.SwitchOnComputer();

            isComputerSwithcedOn = true;

            operatingSystem.IntializeOS();
        }

        public void SwitchOffComputer()
        {
            if (!isComputerSwithcedOn)
            {
                Console.WriteLine("Computer is already switched off");
                return;
            }
            operatingSystem.DisposeOS();

            computerPower.SwitchOffComputer();

            isComputerSwithcedOn = false;
        }

        public void RunVisualStudio()
        {
            computerPrograms.RunVisualStudio();
        }

        public void RunTelegram()
        {
            computerPrograms.RunTelegram();
        }
    }
}
