using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsertionSortVisualizer_MP01_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int toInsert = 0;
            int insertIndex = -1;
            bool insertFlag = false;
            int[] visualizerSize = { 29, 120 };
            Random rnd = new Random();
            int[] arr = new int[visualizerSize[1]];
            int[] newDispl = new int[visualizerSize[1]];
            int[] curDispl = new int[visualizerSize[1]];

            for (int x = 0; x < arr.Length; x++)
            {
                arr[x] = rnd.Next(visualizerSize[0]) + 1;
                newDispl[x] = 0;
                curDispl[x] = 0;
            }

            Console.SetWindowSize(visualizerSize[1], visualizerSize[0] + 1);

            #region Visualizing initial display
            for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
            {
                for (int b = 0; b < arr.Length; b++) // dictate number of columns
                {
                    if (arr[b] >= a)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
            }
            Console.Write("To be sorted using Insertion Sort... Press any key to begin...");
            Console.ReadKey();
            #endregion

            for (int x = 1; x < arr.Length; x++)
            {
                insertIndex = -1;
                insertFlag = false;

                for (int y = x - 1; y >= 0; y--)
                {
                    //This is the only important thing I changed - Denzel
                    newDispl[x] = 1;
                    newDispl[y] = 2;
                    //Before:
                    //newDispl[y] = 1;
                    //newDispl[y + 1] = 2;

                    #region Visualizing Column Selection
                    for (int a = 0; a < arr.Length; a++)
                    //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = visualizerSize[0]; b > 0; b--)
                        //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                        {
                            if (newDispl[a] != curDispl[a])
                            {
                                Console.SetCursorPosition(a, b - 1);
                                switch (newDispl[a])
                                {
                                    case 0:
                                        Console.ResetColor();
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                }

                                if (arr[a] > visualizerSize[0] - b)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        curDispl[a] = newDispl[a];
                        newDispl[a] = 0;
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Thinking. . .                                               ", x);
                    #endregion

                    Thread.Sleep(500);

                    if (arr[x] < arr[y])
                    {
                        insertFlag = true;
                        insertIndex = y;
                    }
                    else
                    {
                        //Second thing I added/changed but only affects display (Basically it'll turn green once it finds where it will insert)
                        //Denzel diff
                        newDispl[x] = 3;
                        newDispl[y] = 3;
                        //Denzel diff
                        break;
                    }
                }

                if (insertFlag)
                {

                    toInsert = arr[x];
                    arr[x] = -1;

                    // this is the logic that moves values around
                    for (int y = x - 1; y >= insertIndex; y--)
                    {
                        arr[y + 1] = arr[y];
                        arr[y] = -1;
                    }


                    arr[insertIndex] = toInsert;

                    #region Visualizing Swap display!
                    for (int a = 0; a < arr.Length; a++)
                    //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = visualizerSize[0]; b > 0; b--)
                        //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                        {
                            if (newDispl[a] != curDispl[a])
                            {
                                Console.SetCursorPosition(a, b - 1);
                                switch (newDispl[a])
                                {
                                    case 0:
                                        Console.ResetColor();
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                }

                                if (arr[a] > visualizerSize[0] - b)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        curDispl[a] = newDispl[a];
                        newDispl[a] = 0;
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Swapping . . .                                             ", x);
                    #endregion

                    Thread.Sleep(500);

                    #region Reset color
                    for (int a = 0; a < arr.Length; a++)
                    //for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
                    {
                        for (int b = visualizerSize[0]; b > 0; b--)
                        //for (int b = 0; b < arr.Length; b++) // dictate number of columns
                        {
                            if (newDispl[a] != curDispl[a])
                            {
                                Console.SetCursorPosition(a, b - 1);
                                switch (newDispl[a])
                                {
                                    case 0:
                                        Console.ResetColor();
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                }

                                if (arr[a] > visualizerSize[0] - b)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        curDispl[a] = newDispl[a];
                        newDispl[a] = 0;
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Resetting. . .                                             ", x);
                    #endregion

                }
            }
            Console.SetCursorPosition(0, 29);
            Console.Write("Done!!!!!!!!!                                              ");
            Console.ReadKey();
        }
    }
}
