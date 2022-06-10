using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyVector obj = new MyVector();
            for(int i = 0; i < 10; i++)
            {
                int newData = i + 1;
                obj.Add(newData);
            }

            foreach(var entry in obj.Data)
            {
                Console.Write(entry + "\t");
            }
            Console.WriteLine();

            var inputArr = EvenFirst(new int[] { 1, 2, 3, 5, 4, 7, 10 }); //2, 4, 10
            for(int i = 0; i < inputArr.Length; i++)
            {
                Console.Write(inputArr[i] + "\t");
            }
            Console.WriteLine();
        }

        static void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        static int[] EvenFirst(int[] inputArr)
        {
            int len = inputArr.Length;
            if (len > 0)
            {
                for(int j = 0; j < inputArr.Length; j++)
                {
                    int i = 0;
                    while((i+1) < len)
                    {
                        int x = inputArr[i];
                        int y = inputArr[i+1];
                        if (!IsEven(x))
                        {
                            x = x + y;
                            y = x - y;
                            x = x - y;
                            inputArr[i] = x;
                            inputArr[i+1] = y;
                        }
                        i++;
                    }

                }
            }

            return inputArr;
        }

        static bool IsEven(int num)
        {
            return ((num & 1) != 1);
        }
    }
}
