using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PP_lab1
{
    public class Frame
    {
        public static void GenerateData(BitArray array)
        {
            array[0] = false;
            array[8] = false;
            array[56] = false;
            array[63] = false;

            for (int i = 1; i < 7; i++)
            {
                array[i] = true;
            }
            for (int i = 8; i < 15; i++)
            {
                array[i] = false;
            }
            array[15] = true;
            for (int i = 57; i < 63; i++)
            {
                array[i] = true;
            }

            for (int i = 16; i < 55; i++)
            {
                if (i % 2 == 0)
                    array[i] = true;
                else
                    array[i] = false;
            }
        }
        public static void GenerateReceipt(BitArray array, bool isValid)
        {
            if (isValid == true)
            {
                array[0] = true;
            }
            else
            {
                array[0] = false;
            }
        }


    }
}
