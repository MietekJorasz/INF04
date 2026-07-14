namespace ConsoleApp_15
{
    internal class Program
    {
        abstract class Device
        {
            public void ShowMessage(string message)
            {
                Console.WriteLine(message);
            }
        }

        class WashingMachine : Device
        {
            private static int ProgramCode = 0;

            public int setProgram(int code)
            {
                if(code >= 1 && code <= 12)
                {
                    ProgramCode = code;
                }
                else
                {
                    ProgramCode = 0;
                }

                return ProgramCode;
            }
		}

        class Hoover : Device
        {
            private static bool HooverStatus = false;

            public void On()
            {
                if (!HooverStatus)
                {
                    HooverStatus = true;
                    ShowMessage("Odkurzacz włączono");
                }
            }

			public void Off()
			{
				if (HooverStatus)
				{
					HooverStatus = false;
					ShowMessage("Odkurzacz wyłączono");
				}
			}
		}
        static void Main(string[] args)
        {
            WashingMachine washingMachine = new WashingMachine();
            Hoover hoover = new Hoover();

            Console.WriteLine("Podaj numer prania 1..12");
            int code = int.Parse(Console.ReadLine());
            if(washingMachine.setProgram(code) == 0)
            {
				washingMachine.ShowMessage("Podano niepoprawny numer programu");
			}
            else
            {
                washingMachine.ShowMessage("Program został ustawiony");
            }

            hoover.On();
			hoover.On();
			hoover.On();

            hoover.ShowMessage("Odkurzacz wyładował się");

            hoover.Off();

		}
    }
}
