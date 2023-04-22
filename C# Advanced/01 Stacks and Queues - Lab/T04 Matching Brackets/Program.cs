﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace T04_Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {

                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                if (expression[i] == ')')
                {
                    int startIndex = stack.Pop();

                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
                
            }

             
        }
    }
}
