using System;
using System.Collections.Generic;
using System.Linq;

namespace Soduku_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>()
            {
                "0 0 4 0 5 0 0 0 0",
                "9 0 0 7 3 4 6 0 0",
                "0 0 3 0 2 1 0 4 9",
                "0 3 5 0 9 0 4 8 0",
                "0 9 0 0 0 0 0 3 0",
                "0 7 6 0 1 0 9 2 0",
                "3 1 0 9 7 0 2 0 0",
                "0 0 9 1 8 2 0 0 3",
                "0 0 0 0 6 0 1 0 0"
            };

            Solve(list);

            //string[] numList = new string[] { "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth" };
            //List<string> inputs = new List<string>();

            //for (int i = 0; i < 9; i++)
            //{
            //Start:
            //    Console.WriteLine("Enter the {0} number. Split each cell using spaces and denote empty cells using 0.", numList[i]);

            //    string[] input = Console.ReadLine().Split(" ");

            //    if(Array.TrueForAll(input, value => {
            //        int s;
            //        return int.TryParse(value, out s);
            //    }) && input.Length == 9)
            //    {
            //        inputs.Add(string.Join("", input));
            //    }
            //    else
            //    {
            //        Console.WriteLine("Please enter a valid input");
            //        goto Start;
            //    }
            //}

            //Console.WriteLine("Please check that your inputs are correct");
            //inputs.ForEach(v =>
            //{
            //    Console.WriteLine(v);
            //});
        }

        static void Solve(List<string> list)
        {
            string[] rows = list.ToArray();

            while(rows.All(v => v.Contains("0")))
            {
                // Initialise columns
                string[] columns = new string[9];

                // Goes through numbers 0 to 8 to assign column values to columns array
                for(int i = 0; i < 9; i++)
                {
                    string o = "";

                    for(int j = 0; j < 9; j++)
                    {
                        o += rows[j].Split(" ")[i];
                    }

                    columns[i] = string.Join(" ", o.ToCharArray());
                }

                // Initialise subsquares
                string[] subsquares = new string[9];

                // Loops through each row
                for(int i = 0; i < 9; i++)
                {

                }

                foreach (string s in rows)
                {
                    Console.WriteLine(s);
                }

                Console.ReadKey();
            }
        }

        static bool CheckColumnForValueExist()
        {
            return false;   
        }
    }
}
