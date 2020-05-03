using System;
using System.Collections;
using System.Collections.Generic;

namespace Interview_Preparation_Kit.Stacks_and_Queues.Balanced_Brackets
{
    class Solution
    {
        static Dictionary<char, char> brackets = new Dictionary<char, char> {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };
        static Stack stack;

        static string isBalanced(string s)
        {
            stack = new Stack();

            for (int i = 0; i < s.Length; i++)
            {
                if (brackets.ContainsKey(s[i]))
                {
                    // If it's a closing bracket, the first item from the stack must be the match openning bracket
                    if (stack.Count == 0 || (char)stack.Pop() != brackets[s[i]])
                        return "NO";
                }
                else
                {
                    // If it's an openning bracket, push to the stack
                    stack.Push(s[i]);
                }
            }

            return stack.Count > 0 ? "NO" : "YES";
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = Console.ReadLine();

                string result = isBalanced(s);

                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
