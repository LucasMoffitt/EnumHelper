using System;

namespace EnumHelperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("@LucasMoffitt - EnumHelper Demo");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine();
            Console.WriteLine("Plain old boring .ToString()");
            var boringEnum = Enum.GetValues(typeof (Cars));
            foreach (var enumText in boringEnum)
            {
                Console.WriteLine(enumText);
            }

            Console.WriteLine();
            Console.WriteLine("Get a list of enum descriptions with no prefix"); 
            var enumList = EnumHelper.GetList<Cars>(string.Empty);
            foreach (var enumText in enumList)
            {
                Console.WriteLine(enumText);
            }

            Console.WriteLine();
            Console.WriteLine("Give an enum context for an action with a prefix. i.e Buy or Sell");
            var prefixedEnumList = EnumHelper.GetList<Cars>("Buy a");
            foreach (var enumText in prefixedEnumList)
            {
                Console.WriteLine(enumText);
            }
            
            Console.ReadLine();
        }
    }
}
