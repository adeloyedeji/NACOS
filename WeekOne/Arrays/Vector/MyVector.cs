using System;

namespace Vector
{
    public class MyVector
    {
        public int Size;
        public int Index;
        public int[] Data;

        public MyVector()
        {
            Size = 1;
            Index = 0;
            Data = new int[Size];
        }

        public void Add(int newData)
        {
            if (Index == Size)
            {
                Size *= 2;
                int[] tempData = new int[Size];
                for (int i = 0; i < Data.Length; i++) {
                    tempData[i] = Data[i];
                }
                Data = tempData;
            }
            Data[Index] = newData;
            Index++;
        }

        public int Get(int idx)
        {
            if (idx < Size)
            {
                return Data[idx];
            }

            return 0;
        }

        public int Length()
        {
            return (Index+1);
        }
    }
}