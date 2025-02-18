using azure_ai_practices.translator;

namespace azure_ai_practices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = "I would really like to drive your car around the block a few times!";
            var translatorResult = TranslatorService.Translate(text).Result;

            Console.WriteLine(translatorResult);

            Console.ReadKey();
        }
    }
}
