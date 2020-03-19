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
            
            if (repeats == 2){
                return Triangle.EQUILATERAL.ToString();
            }
            else if(repeats == 1){
                if(IsRuleInvalid(singleNumber, numberDuplicated, 1)){
                    return Triangle.Error.ToString();
                }
                return Triangle.ISOSCELES.ToString();
            }

            if(array[0]+1 == array[1]){
                if(IsRuleInvalid(array[2], array[0], 0)){
                    return Triangle.Error.ToString();;
                }
                return Triangle.SCALENE.ToString();
            }
            else if(array[1]+1 == array[2]){
                if(IsRuleInvalid(array[0], array[1], 0)){
                    return Triangle.Error.ToString();;
                }
                return Triangle.SCALENE.ToString();
            }
            else {
                return Triangle.Error.ToString();;
            }
        }

        public bool IsRuleInvalid(int validateNumber, int baseNumber, int variance){
            if(validateNumber> baseNumber + (baseNumber - variance) ){
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
