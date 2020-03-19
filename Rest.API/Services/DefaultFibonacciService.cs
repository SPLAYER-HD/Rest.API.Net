using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Rest.API.Services
{
    public class DefaultFibonacciService : IFibonacciService
    {
        public Int64  Fibonacci(Int64 n)
        {
            Dictionary<Int64, Int64> memory = new Dictionary<Int64, Int64>();
            return RecursiveFibonacci(n-1, memory);
        }

        public Int64 RecursiveFibonacci(Int64 n, Dictionary<Int64, Int64> memory)
        {
            if (n == 0 || n ==1 )
            {
                return (long)1;
            }            
            //Console.WriteLine(memory[n]);
            Int64 value = memory.GetValueOrDefault(n, (long)-1);
            if(value != -1){
                return value; 
            }else{
                /*Console.WriteLine("--------");
                Console.WriteLine(n);
                Console.WriteLine(n-1);
                Console.WriteLine(n-2);
                */
                Int64 resultado = RecursiveFibonacci(n-1, memory) + RecursiveFibonacci(n-2, memory);
                //Console.WriteLine(resultado);
                memory.Add(n, resultado);
                return resultado;
            }
        }
    }
}
