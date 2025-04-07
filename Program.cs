using System;

namespace LabWork
{

    interface IDigitalSignal
    {
        string GetDigitalData();
    }


    class AnalogSignal
    {
        public int AnalogValue { get; }

        public AnalogSignal(int value)
        {
            AnalogValue = value;
        }
    }


    class SignalAdapter : IDigitalSignal
    {
        private readonly AnalogSignal _analogSignal;

        public SignalAdapter(AnalogSignal analogSignal)
        {
            _analogSignal = analogSignal;
        }

        public string GetDigitalData()
        {
            return Convert.ToString(_analogSignal.AnalogValue, 2); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Перетворення аналогового сигналу на цифровий:");
            Console.Write("Введіть аналогове значення: ");
            int input = int.Parse(Console.ReadLine());

            AnalogSignal analogSignal = new AnalogSignal(input);
            IDigitalSignal adapter = new SignalAdapter(analogSignal);

            Console.WriteLine("Отримано цифрові дані: " + adapter.GetDigitalData());
        }
    }
}
