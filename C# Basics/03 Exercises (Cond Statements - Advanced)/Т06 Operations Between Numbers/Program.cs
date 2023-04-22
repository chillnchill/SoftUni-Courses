﻿using System;

namespace Т06_Operations_Between_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            if (operation == '+' || operation == '-' || operation == '*')
            {
                int result = 0;
                string evenOrOdd = "even";

                switch (operation)
                {
                    case '+':
                        result = num1 + num2; break;
                    case '-':
                        result = num1 - num2; break;
                    case '*':
                        result = num1 * num2; break;


                }
                if (result % 2 != 0)
                {
                    evenOrOdd = "odd";
                }
                Console.WriteLine($"{num1} {operation} {num2} = {result} - {evenOrOdd}");
            }
            else if (operation == '/' || operation == '%')
            {
                double result = 0;

                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else if (operation == '/')
                {
                    result = (1.0 * num1) / num2;
                    Console.WriteLine($"{num1} / {num2} = {result:f2}");
                }
               else
                {
                    Console.WriteLine($"{num1} % {num2} = {num1 % num2}");
                }
                
            }
        }
    }
}
