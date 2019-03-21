using System;

namespace InterestCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //these are declaration statements
            double prin;
            double rate;
            int year;

            prin = Double.Parse(Prompt("Original Principle:"));
            rate = Double.Parse(Prompt("Interest Rate (%):"));
            rate = rate / 100; // this is an assignment expression 
            year = Int32.Parse(Prompt("Number of Years:"));

            CheckValidity(prin, rate, year);

            Console.WriteLine("Print out the sequence of balance over the time period of {0} year(s)--", year);
            Console.WriteLine("--Press 1 or 2:--");
            Console.WriteLine("(1) Yearly Simple Interest");
            Console.WriteLine("(2) Yearly Compound Interest");

            char key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            //this is an use of case statements 
            switch (key)
            {
                case '1':
                    {
                        PrintSimpleInterestSeq(prin,rate,year);
                        break;
                    }
                case '2':
                    {
                        PrintCompoundInterestSeq(prin,rate,year);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Input!!!");
                        break;
                    }
            }
            Console.ReadKey();
        }

        //this procedure helps to eliminate repetition of instructing users to input
        //this procedure both carries out an action and returns an value
        static string Prompt(string _txt)
            /* the use of underscore (_) indicates an private variable
               which enhance readability */
        {
            Console.WriteLine("Input {0}", _txt);
            return Console.ReadLine();
        }

        //this procedure checks if input is legitimate
        //if the input is illegitimate, the program end
        static void CheckValidity(double _prin, double _rate, int _year)
        {
            bool _isPrinInvalid = _prin < 0;
            bool _isRateInvalid = _rate < 0 || _rate > 100;
            bool _isYearInvalid = _year < 0;

            //this is an use of conditional statements
            if (_isPrinInvalid || _isRateInvalid || _isYearInvalid)
            // || is conditional logical operator "OR"
            {
                Console.WriteLine("Invalid Input!!!");
                Console.ReadKey();
                Environment.Exit(0); 
            }
        }

        /* this procedure deal with the subproblem of printing out
           the sequence of sequence of accumulated amount over the years 
           in cases of compound interest.*/
        static void PrintCompoundInterestSeq(double _prin, double _rate, int _yrs)
        {
            double _bal = _prin;

            Console.WriteLine();
            //this is an use of iteration statements
            for (int i = 1; i <= _yrs; i++)
            {
                _bal *= (1 + _rate);
                Console.WriteLine("{0,5}{1,3}{2,25:C0}", "Year ", i, RoundMoney(_bal));
            }
        }

        /* this procedure deal with the subproblem of printing out
        the sequence of sequence of accumulated amount over the years 
        in cases of simple interest.*/
        static void PrintSimpleInterestSeq(double _prin, double _rate, int _yrs)
        {
            double _bal = _prin;

            Console.WriteLine();
            for (int i = 1; i <= _yrs; i++)
            {
                _bal += _prin * _rate;
                Console.WriteLine("{0,5}{1,3}{2,25:C0}", "Year ", i, RoundMoney(_bal));
            }
        }

        /* this procedure helps to eliminate repetition of rounding a decimal number
         which make the code more clear and readble */ 
        static double RoundMoney(double _rawNum)
        {
            return Math.Round(_rawNum, 0, MidpointRounding.AwayFromZero);
        }
    }
}
