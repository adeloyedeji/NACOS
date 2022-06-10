using System;
using System.Threading;
using System.Collections.Generic;

namespace WeekTwo
{
    public class Program
    {
        static string[] samples = new string[] { "John Doe", "Hawk Girl", "Shazaam", "Super Man", "Green Lantern", "Flash", "Wonder Woman", "", string.Empty };
        public static void Main(string[] args)
        {
            // CallFirstNonRepeating();
            // HashMapTest();
            // BinaryHeapTest();
        }

        public static void BinaryHeapTest()
        {
            BinaryHeap heapObj = new BinaryHeap(5);
            heapObj.Add(10);
            heapObj.Add(20);
            heapObj.Add(30);
            heapObj.Add(40);
            heapObj.Add(50);
            heapObj.Add(80);

            Console.WriteLine($"Size = {heapObj.Size()}");
        }

        public static void HashMapTest()
        {
            HashMap<string, int> map = new HashMap<string, int>();
            map.Add("John Doe", 10);
            map.Add("Hawk Girl", 20);
            map.Add("Shazaam", 30);
            map.Add("Super Man", 40);
            map.Add("Green Lantern", 50);
            map.Add("Flash", 60);
            map.Add("Wonder Woman", 70);
            map.Add("Super Girl", 80);

            Console.WriteLine($"Size = {map.Size}");
            Console.WriteLine($"Remove \'John Doe\': {map.Remove("John Doe")}");
            Console.WriteLine($"Size = {map.Size}");
            Console.WriteLine($"Get value of \'Super Girl\': {map.Get("Super Girl")}");
        }

        public static void CallFirstNonRepeating()
        {
            for(int i = 0; i < samples.Length; i++)
            {
                string input = samples[i];
                int result = FirstNonRepeating(input);
                if (result == -1)
                {
                    Console.WriteLine("All characters repeat or empty string.");
                }
                else
                {
                    Console.WriteLine($"First non-repeating character in [{input}] is:\t{input[result]}");
                }
                Console.WriteLine("\n");
                Thread.Sleep(3000);
            }
        }

        public static int FirstNonRepeating(string str)
        {
            // https://www.geeksforgeeks.org/given-a-string-find-its-first-non-repeating-character/
            int[] fi = new int[256]; // array to store First Index
    
            // initializing all elements to -1
            for (int i = 0; i < 256; i++)
                fi[i] = -1;
                
            for (int i = 0; i < str.Length; i++) 
            {
                if (fi[str[i]] == -1) 
                {
                    fi[str[i]] = i;
                }
                else 
                {
                    fi[str[i]] = -2;
                }
            }
    
            int res = Int32.MaxValue;
    
            for (int i = 0; i < 256; i++) 
            {
    
                // If this character is not -1 or -2 then it
                // means that this character occurred only once
                // so find the min index of all characters that
                // occur only once, that's our first index
                if (fi[i] >= 0)
                    res = Math.Min(res, fi[i]);
            }
    
            // if res remains  Integer.MAX_VALUE, it means there
            // are no characters that repeat only once or the
            // string is empty
            if (res == Int32.MaxValue)
                return -1;
            else
                return res;
        }
    }
}