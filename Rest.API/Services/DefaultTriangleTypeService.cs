using System;
using System.Linq;

namespace Rest.API.Services
{
    public class DefaultTriangleTypeService : ITriangleTypeService
    {
        public String TrianlgeType(int a, int b, int c)
        {
            if (a == b && b == c){
                return Triangle.EQUILATERAL.ToString();
            }
            else if(a == b || b == c || a == c){
                return Triangle.ISOSCELES.ToString();
            }
            return Triangle.SCALENE.ToString();
        }
    }

    public enum Triangle
    {
        EQUILATERAL,
        ISOSCELES,
        SCALENE,
    }
}
