using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PP_lab1
{
    public static class ConsoleHelper
    {
        public static object LockObject = new Object();
        public static void WriteToConsole(string info, string write)
        {
            lock (LockObject)
            {
                Console.WriteLine(info + " : " + write);
            }

        }
        public static void WriteToConsoleReceipt(string info, BitArray array)
        {
            lock (LockObject)
            {
                Console.Write(info + " : ");
                if (array[0] == true)
                    Console.Write("True");
                else
                    Console.Write("False");
            }
        }
        public static void WriteToConsoleArray(string info, BitArray array)
        {
            lock (LockObject)
            {
                    Console.Write(info + " : ");
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == true)
                            Console.Write("1");
                        else
                            Console.Write("0");

                    }
                
                    Console.WriteLine();
                    Console.Write("Открывающий флаг:");
                    for (int i = 0; i < 8; i++)
                    {
                        if (array[i] == true)
                            Console.Write("1");
                        else
                            Console.Write("0");
                    }
                    Console.WriteLine();
                    int j = 0;
                    string[] controlArray = new string[8];
                    Console.Write("Поле управления: ");
                    for (int i = 8; i < 16; i++)
                    {
                        if (array[i] == true)
                        {
                            Console.Write("1");
                            controlArray[j] = "1";
                        }

                        else
                        {
                            Console.Write("0");
                            controlArray[j] = "0";
                        }
                        j++;

                    }

                    Console.WriteLine();
                    string controlStr = String.Join("", controlArray);
                    switch (Convert.ToInt32(controlStr, 2))
                    {
                        case 0:
                            Console.WriteLine("Пакет с настройками");
                            break;
                        case 1:
                            Console.Write("Даные:");
                            for (int i = 16; i < 54; i++)
                            {
                                if (array[i] == true)
                                    Console.Write("1");
                                else
                                    Console.Write("0");
                            }
                            Console.WriteLine();
                            break;

                    }
                    Console.Write("Закрывающий флаг:");
                    for (int i = 56; i < 64; i++)
                    {
                        if (array[i] == true)
                            Console.Write("1");
                        else
                            Console.Write("0");
                    }
                Console.WriteLine();

            }
     


        }
    }
}
