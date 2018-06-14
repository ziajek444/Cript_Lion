using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ZiajkowskiCriptCsharp
{

    //using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            //Test : verify Python function results with C# function results (wanted 6 digits assert)
            ZiajkowskiCriptCsLion Lion = new ZiajkowskiCriptCsLion();
            
            Console.WriteLine(Lion.GetFunction(5.654321, 35.654321));
            Console.WriteLine(Lion.GetFunction(5.65432, 35.65432));
            Console.WriteLine(Lion.GetFunction(5.6543, 35.6543));
            Console.WriteLine(Lion.GetFunction(5.654, 35.654));
            Console.WriteLine(Lion.GetFunction(5.65, 35.65));
            Console.WriteLine(Lion.GetFunction(5.6, 35.6));
            Console.WriteLine(Lion.GetFunction(5.0, 35.0));
            Console.WriteLine(Lion.GetFunction(5.0, 30.0));
            /* 
             * 
             *                          Python:                 C#:   

             * 5.654321 / 35.654321     12.797716056612439      12,7977160566124
             * 5.65432 / 35.65432       12.7977097449901        12,7977097449901
             * 5.6543 / 35.6543         12.797583510912602      12,7975835109126
             * 5.654 / 35.654           12.795689626912178      12,7956896269122
             * 5.65 / 35.65             12.770371073429807      12,7703710734298
             * 5.6 / 35.6               12.443478968631734      12,4434789686317
             * 5.0 / 35.0               7.229449952702343       7,22944995270234
             * 5.0 / 30.0               12.674075376897138      12,6740753768971
             * 
            */
            Console.ReadKey();
        }
    }
    class ZiajkowskiCriptCsLion : IFunction
    {
        public readonly double first_offset_x1; //internal variable, private access / Offset to generate firsts xs variables
        public readonly double first_offset_x2;
        public readonly double first_shift; //internal variable, tell us how much next variables will be shifted from offset to make next x 
        public double first_number; //inital random number created in client (first x)

        public ZiajkowskiCriptCsLion()
        {
            this.first_offset_x1 = 1.65625;  //(ver. Lion 0.1 ______ 1 + 1*0.5 + 0*0.25 + 1*0.125 + 0*0.0625 + 1*0.03125) 
            this.first_offset_x2 = 35.12500;
            this.first_shift = 4.44000; //(ver. Lion 0.1 ______I just like digit 4)
        }
        public ZiajkowskiCriptCsLion(double _offset1,double _offset2,double _shift) //Typical for lion
        {
            this.first_shift = _shift;
            this.first_offset_x1 = _offset1;
            this.first_offset_x2 = _offset2;
        }
        public double GetFunction(double x1, double x2)
        {
            //From python test:
            // y = (0.5)*x1 + x1**math.cos(x2) - (0.3)*x2*math.sin(x2)
            double result = (0.5)*x1 + Math.Pow(x1,Math.Cos(x2)) - (0.3)*x2*Math.Sin(x2);
            return result;
        }

    }
    public interface IFunction
    {
        
        double GetFunction(double x1,double x2); //No linear function of 2 variables (like a Lapunov :D )

    }
}
