using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetclipattern.Domain;
public class MiscNumberValidation : IMiscNumberValidation
{
    public bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (IsEvenNumber(number)) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }
    public bool IsEvenNumber(int number)
    {
        if (number % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsPalandrome(int number)
    {
        int rem, sum = 0, temp;
        temp = number;
        while (number > 0)
        {
            rem = number % 10;
            number = number / 10;
            sum = sum * 10 + rem;
        }
        if (temp == sum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
