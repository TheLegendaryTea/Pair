using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = 0;
            Money firstValue = new Money();
            Money secondValue = new Money();
            Console.WriteLine("Работа с Money. Введите первое число, рубли:");
            string result = Console.ReadLine();
            if (int.TryParse(result, out res))
                firstValue.Roubles = res;


            Console.WriteLine("Теперь копейки для первого числа:");
            result = Console.ReadLine();
            if (int.TryParse(result, out res))
                firstValue.Copeck = res;
            Console.WriteLine("Введено число " + firstValue.ToString() + ". Введите второе число, рубли:");
            result = Console.ReadLine();
            if (int.TryParse(result, out res))
                secondValue.Roubles = res;


            Console.WriteLine("Теперь копейки для второго числа:");
            result = Console.ReadLine();
            if (int.TryParse(result, out res))
                secondValue.Copeck = res;
            Console.WriteLine("Введено число " + secondValue.ToString());

            Console.WriteLine("------------");
            Console.WriteLine("Сумма: {0} + {1} = {2}", firstValue.ToString(), secondValue.ToString(), (firstValue.Add(secondValue).ToString()));
            Console.WriteLine("Разница: {0} - {1} = {2}", firstValue.ToString(), secondValue.ToString(), (firstValue.Substract(secondValue).ToString()));
            Console.ReadLine();

        }
    }

    public abstract class Pair
    {
        protected int FirstPairElement { get; set; }
        protected int SeconPairElement { get; set; }

        public abstract Pair Substract(Pair value);
        public abstract Pair Add(Pair value);

    }

    public class Money : Pair
    {
        public int Roubles
        {
            get
            {
                return FirstPairElement;
            }
            set { FirstPairElement = value; }
        }

        public int Copeck
        {
            get
            {
                return SeconPairElement;
            }
            set
            {
                SeconPairElement = value;
                if (SeconPairElement > 99)
                {
                    SeconPairElement -= 100;
                    Roubles += 1;
                }
                if (SeconPairElement < 0)
                {
                    SeconPairElement += 100;
                    Roubles -= 1;
                }
            }
        }

        public override Pair Add(Pair value)
        {
            Money newValue = new Money();
            newValue.Roubles = this.Roubles + (value as Money).Roubles;
            newValue.Copeck = this.Copeck + (value as Money).Copeck;
            return newValue;
        }

        public override Pair Substract(Pair value)
        {
            Money newValue = new Money();
            newValue.Roubles = this.Roubles - (value as Money).Roubles;
            newValue.Copeck = this.Copeck - (value as Money).Copeck;
            return newValue;
        }

        public override string ToString()
        {
            return string.Format("{0} руб. {1} коп.", this.Roubles, this.Copeck);
        }
    }
}