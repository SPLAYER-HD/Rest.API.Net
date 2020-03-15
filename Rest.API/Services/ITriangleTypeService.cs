using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rest.API.Services
{
    public interface ITriangleTypeService
    {
        String TrianlgeType(int a, int b, int c);
    }

}
