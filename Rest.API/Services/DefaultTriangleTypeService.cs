using System;
using System.Linq;

namespace Rest.API.Services
{
    public class DefaultTriangleTypeService : ITriangleTypeService
    {
        public String TrianlgeType(int a, int b, int c)
        {
            int[] array = new int[] { a, b, c };
            Array.Sort(array); 
            Console.WriteLine(array[0]);
            Console.WriteLine(array[1]);
            Console.WriteLine(array[2]);
            Console.WriteLine("-----------------");

            int repeats = 0;
            int numberDuplicated = 0;
            int singleNumber = 0;
            foreach (var number in array.GroupBy(x => x))
            {
                if(repeats < number.Count() - 1){
                    numberDuplicated = number.Key;
                    repeats = number.Count() - 1;
                }
                if(number.Count() - 1 == 0){
                    singleNumber = number.Key;
                }
            }
            Console.WriteLine(" repeats "+repeats);
            Console.WriteLine(" numberDuplicated "+numberDuplicated);
            Console.WriteLine(" singleNumber "+singleNumber);
            
            if (repeats == 2){
                return Triangle.EQUILATERAL.ToString();
            }
            else if(repeats == 1){
                if(IsRuleInvalid(singleNumber, numberDuplicated, 1)){
                    Console.WriteLine("Error 2");
                    return Triangle.Error.ToString();
                }
                return Triangle.ISOSCELES.ToString();
            }

            if(array[0]+1 == array[1]){
                if(IsRuleInvalid(array[2], array[0], 0)){
                    Console.WriteLine("Error 3");
                    return Triangle.Error.ToString();;
                }
                return Triangle.SCALENE.ToString();
            }
            else if(array[1]+1 == array[2]){
                if(IsRuleInvalid(array[0], array[1], 0)){
                    Console.WriteLine("Error 4");
                    return Triangle.Error.ToString();;
                }
                return Triangle.SCALENE.ToString();
            }
            else {
                Console.WriteLine("Error 5");
                return Triangle.Error.ToString();;
            }
        }

        public bool IsRuleInvalid(int validateNumber, int baseNumber, int variance){
            Console.WriteLine("validateNumber "+validateNumber);
            Console.WriteLine("baseNumber "+baseNumber);
            if(validateNumber> baseNumber + (baseNumber - variance) ){
                Console.WriteLine("IsRuleInvalid error");
                return true;
            }
            return false;
        }
    }

    public enum Triangle
    {
        EQUILATERAL,
        ISOSCELES,
        SCALENE,
        Error
    }
}
