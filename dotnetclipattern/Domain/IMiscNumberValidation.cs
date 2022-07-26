namespace dotnetclipattern.Domain
{
    public interface IMiscNumberValidation
    {
        bool IsEvenNumber(int number);
        bool IsPalandrome(int number);
        bool IsPrime(int number);
    }
}