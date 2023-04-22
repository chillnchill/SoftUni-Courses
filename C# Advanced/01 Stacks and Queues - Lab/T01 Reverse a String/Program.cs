using System;
using System.Collections;
using System.Collections.Generic;

namespace T01_Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //it needs to be for [chars] so that it can hold the inidvidual string elements
            Stack<char> stack = new Stack<char>();
            //adding each char into the stack makes it so once it is read at the end, the letters(chars) will be reveresed. LIFO
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
                
            }
            //the accepted way to view a stack or queue is to while cycle that bish
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
