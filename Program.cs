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
                "1 6 4 0 0 0 0 0 2",
                "2 0 0 4 0 3 9 1 0",
                "0 0 5 0 8 0 4 0 7",
                "0 9 0 0 0 6 5 0 0",
                "5 0 0 1 0 2 0 0 8",
                "0 0 8 9 0 0 0 3 0",
                "8 0 9 0 4 0 2 0 0",
                "0 7 3 5 0 9 0 0 1",
                "4 0 0 0 0 0 6 7 9"
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

            while(CheckForSudokuDone(rows))
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

                string[] sub = new string[3];

                // Loops through each row
                for(int i = 0; i < 9; i++)
                {
                    string r = rows[i].Replace(" ", "");

                    sub[0] += r.Substring(0, 3);
                    sub[1] += r.Substring(3, 3);
                    sub[2] += r[6..];
                }

                // Set values to each value in subsquare array
                for(int i = 0; i < 9; i++)
                {
                    if(i < 3)
                    {
                        subsquares[i] = sub[i % 3].Substring(0, 9);
                    } else if (i < 6)
                    {
                        subsquares[i] = sub[i % 3].Substring(9, 9);
                    }
                    else
                    {
                        subsquares[i] = sub[i % 3][18..];
                    }
                }

                // Solve the soduku
                // Starts by looping through each row
                for(int i = 0; i < 9; i++)
                {
                    string[] row = rows[i].Split(" ");

                    // Loops through each value in the row
                    // Also represents the column the value is in
                    for(int j = 0; j < 9; j++)
                    {
                        if(row[j] == "0")
                        {
                            List<string> possibleValues = new List<string>();

                            // Tries each value in row to see if it works
                            for(int k = 1; k <= 9; k++)
                            {
                                if (!rows[i].Contains(k.ToString()) && !columns[j].Contains(k.ToString()) && CheckSubsquare(i, j, k, subsquares))
                                {
                                    possibleValues.Add(k.ToString());
                                    //Console.WriteLine(k);
                                }
                            }

                            if (possibleValues.Count() == 1)
                            {
                                row[j] = possibleValues[0];
                            } else if(possibleValues.Count() == 0)
                            {
                                Console.WriteLine("This soduku is impossible");
                                Console.ReadKey();
                            }

                            //foreach(string s in possibleValues)
                            //{
                            //    Console.WriteLine(s);
                            //}

                            //Console.WriteLine("");
                        }
                    }

                    rows[i] = string.Join(" ", row);
                }

                foreach (string s in rows)
                {
                    Console.WriteLine(s);
                }
                
                Console.WriteLine("");
            }
        }

        static bool CheckSubsquare(int row, int column, int value, string[] subsquares)
        {
            int[,] subsquareColumns = { { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 } };

            int subsquare = subsquareColumns[(int)(column / 3), (int)(row / 3)];

            if (!subsquares[subsquare].Contains(value.ToString()))
            {
                return true;
            }
            return false;
        }

        static bool CheckForSudokuDone(string[] sudoku)
        {
            foreach(string s in sudoku)
            {
                if (s.Contains("0"))
                {
                    return true;
                }
            }

            Console.WriteLine("Sudoku completed!");
            return false;
        }
    }
}
