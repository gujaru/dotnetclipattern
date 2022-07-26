using dotnetclipattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dotnetclipattern.Program;

namespace dotnetclipattern
{
    public class MainApp
    {
        private IMiscNumberValidation _numberValidation;
        public MainApp(IMiscNumberValidation numberValidation)
        {
            _numberValidation = numberValidation;
        }

        public void Run(Options option)
        {
            Console.WriteLine($"Options received => number : {option.Number}, prime : {option.Prime}, even : {option.Even}, palindrome : {option.Palindrome}");

            if (option.Prime)
            {
                Console.WriteLine($"{option.Number} is {(_numberValidation.IsPrime(option.Number)? "":"not")} a prime number.");
            }
            if (option.Even)
            {
                Console.WriteLine($"{option.Number} is an {(_numberValidation.IsEvenNumber(option.Number)? "even":"odd")} number.");
            }
            if (option.Palindrome)
            {
                Console.WriteLine($"{option.Number} is {(_numberValidation.IsEvenNumber(option.Number)? "":"not")} a palindrome.");
            }
        }
    }
}
