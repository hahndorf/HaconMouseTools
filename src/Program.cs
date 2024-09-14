using System;

namespace Hacon.MouseTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool beVerbose = false;
            bool operationPicked = false;

            foreach (var arg in args)
            {
                if (arg.StartsWith("-v"))
                {
                    beVerbose = true;
                }
            }

            foreach (var arg in args)
            {
                if (arg.StartsWith("-w"))
                {
                    MouseMover movr = new MouseMover();
                    movr.ConsoleOutput = beVerbose;
                    movr.TryMouseRepositioning();
                    operationPicked = true;
                }
                else if (arg.StartsWith("-?"))
                {
                    ShowHelp();
                    operationPicked = true;
                }
            }

            if (!operationPicked)
            {
                ShowHelp();
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("HaconMouseTools.exe -w [-v]");
            Console.WriteLine("-w to move the mouse cursor to the current windows");
            Console.WriteLine("-v print out debug information");
        }
    }
}