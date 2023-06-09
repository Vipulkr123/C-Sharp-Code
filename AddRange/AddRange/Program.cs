﻿using System;
using System.Collections.Generic;
namespace AddRange
{
    

    class Program
    {
        static void Main()
        {
            List<int> list = new List<int>();
            list.Add(100);
            list.Add(200);
            list.Add(300);
            list.Add(400);

            // array of 4 elements
            int[] arr = new int[4];
            arr[0] = 500;
            arr[1] = 600;
            arr[2] = 700;
            arr[3] = 800;

            list.AddRange(arr);

            foreach (int val in list)
            {
                Console.WriteLine(val);
            }
        }
    }
}