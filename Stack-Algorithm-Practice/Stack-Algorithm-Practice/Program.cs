using System;
using System.Collections;
using System.Text;

namespace Stack_Algorithm_Practice
{
    class Program
    {
        private static ArrayList openingBrackets = new ArrayList() { '(', '[', '<', '{' };
        private static ArrayList closingBrackets = new ArrayList() { ')', ']', '>', '}' };

        static void Main(string[] args)
        {
            Console.WriteLine(ReverseString2("Liz throws like a girl!"));
            Console.WriteLine(hasBalancedBrackets("((<>))"));
        }

        private static bool isOpeningBracket(char bracket)
        {
            return openingBrackets.Contains(bracket);
        }

        private static bool isClosingBracket(char bracket)
        {
            return closingBrackets.Contains(bracket);
        }

        private static bool bracketsMatch(char left, char right)
        {
            return openingBrackets.IndexOf(left) == closingBrackets.IndexOf(right);
        }

        public static string ReverseString(string input)
        {
            var stack = new Stack();
            string output = "";
            for (int i = 0; i < input.Length; i++) stack.Push(input[i]);
            for (int i = 0; i < input.Length; i++) output += stack.Pop();
            return output;
        }

        public static string ReverseString2(string input)
        {
            if (input == null) throw new InvalidOperationException();
            var stack = new Stack();
            var output = new StringBuilder();
            foreach (var letter in input) stack.Push(letter);
            while (stack.Count > 0) output.Append(stack.Pop());
            return output.ToString();
        }

        public static bool hasBalancedBrackets(string input)
        {
            var stack = new Stack();

            foreach(var character in input)
            {
                if (isOpeningBracket(character)) stack.Push(character);
                else if (isClosingBracket(character))
                {
                    if (stack.Count == 0) return false; //closing without an opening

                    if (bracketsMatch((char)stack.Pop(), character)) continue;
                    else return false;

                }
            }

            if(stack.Count == 0) return true;
            return false;
        }

       class CustomStack
        {
            private int[] stack = new int[0];

            public bool isEmpty()
            {
                return stack.Length == 0;
            }

            public void push(int item)
            {
                int[] newStack = new int[stack.Length + 1];
                for (int i = 0; i < stack.Length; i++)
                {
                    newStack[i] = stack[i];
                }
                newStack[stack.Length] = item;
                stack = newStack;
            }

            public int pop()
            {
                if (isEmpty()) throw new InvalidOperationException();

                int popped = stack[stack.Length - 1];
                int[] newStack = new int[stack.Length - 1];
                for (int i = 0; i < stack.Length - 1; i++)
                {
                    newStack[i] = stack[i];
                }
                stack = newStack;
                return popped;
            }

            public int peek()
            {
                if (isEmpty()) throw new InvalidOperationException();
                return stack[stack.Length - 1];
            }
        }

    }
}
