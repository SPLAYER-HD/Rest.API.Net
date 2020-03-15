using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Rest.API.Services
{
    public class DefaultFibonacciService : IFibonacciService
    {
        public Int64  Fibonacci(int n)
        {
            Dictionary<int, Int64> memory = new Dictionary<int, Int64>();
            return RecursiveFibonacci(n-1, memory);
        }

        public Int64 RecursiveFibonacci(int n, Dictionary<int, Int64> memory)
        {
            if (n == 0 || n ==1)
            {
                return (long)1;
            }
            //Console.WriteLine(memory[n]);
            Int64 value = memory.GetValueOrDefault(n, (long)-1);
            if(value != -1){
                return value; 
            }else{
                Int64 resultado = RecursiveFibonacci(n-1, memory) + RecursiveFibonacci(n-2, memory);
                memory.Add(n, resultado);
                return resultado;
            }
        }
    }
}
