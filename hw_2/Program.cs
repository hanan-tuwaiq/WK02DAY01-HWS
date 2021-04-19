using System;
using System.Collections;
using System.Collections.Generic;

namespace hw_2
{
    class Program
    {
        //Builder HW
        class QuotesBuilder
        {
            private string quote;
            public QuotesBuilder()
            {
                this.quote = "";
            }
            public QuotesBuilder start()
            {
                this.quote += "“";
                return this;
            }
            public QuotesBuilder content(string content)
            {
                this.quote += content;
                return this;
            }
            public QuotesBuilder end(string name)
            {
                this.quote += ".”\n - " + name;
                return this;
            }
            public string get()
            {
                return this.quote;
            }
        }
        //Matching HW:
        //using ({[ and )}]
        static bool checkOrderBraces(string src)
        {
            int flag = 0;
            foreach (var c in src)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    flag++;
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    flag--;
                }
            }
            return flag == 0;
            
        }
        //using numbers
        static bool checkOrder(string src)
        {
            string braces = "0123456789";
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < src.Length / 2; i++)
            {
                if (braces.Contains(src[i]))
                {
                    stack.Push(src[i]);
                }
            }
            if (src.Length % 2 == 0)
            {
                for (int i = src.Length / 2; i < src.Length; i++)
                {
                    if (stack.Peek() == src[i])
                    {
                        stack.Pop();
                    } 
                }
            } 
            return stack.Count == 0;
        }
        

        static void Main(string[] args)
        {
            //Builder HW
            QuotesBuilder q = new QuotesBuilder();
            Console.WriteLine(q.start()
                                .content("Be yourself; everyone else is already taken")
                            .end("Oscar Wilde")
                            .get());

            //Matched HW -> using braces
            Console.WriteLine(checkOrderBraces("(({{[]}}))"));
            //Matched HW -> using numbers but only if they mirrored each other
            Console.WriteLine(checkOrder("23700732"));

        }
    }
}
