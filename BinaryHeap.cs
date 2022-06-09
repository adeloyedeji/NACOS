using System;

namespace WeekTwo
{
    public class BinaryHeap
    {
        int[] elements;
        int size = 0;

        public BinaryHeap(int size)
        {
            elements = new int[size];
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Peek()
        {
            if (size == 0)
                throw new Exception("Empty Heap");

            return elements[0];
        }

        public int Pop()
        {
            if (size == 0)
                throw new Exception("Empty Heap");

            int result = elements[0];
            elements[0] = elements[size - 1];
            size--;

            ReCalculateInvariant();

            return result;
        }

        public void Add(int newItem)
        {
            if (size == elements.Length)
            {
                throw new Exception("out of range");
            }

            elements[size] = newItem;
            size++;

            ReCalculateHeapInvariant();
        }

        private void ReCalculateInvariant()
        {
            int index = 0;
            while(HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (elements[smallerIndex] >= elements[index])
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        private void ReCalculateHeapInvariant()
        {
            int index = size - 1;
            while(!IsRoot(index) && elements[index] < GetParent(index))
            {
                int parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private int GetParentIndex(int index)
        {
            return ((index - 1) / 2);
        }

        private bool HasLeftChild(int index)
        {
            return (GetLeftChildIndex(index) < size);
        }

        private bool HasRightChild(int index)
        {
            return (GetRightChildIndex(index) < size);
        }

        private bool IsRoot(int index)
        {
            return index == 0;
        }

        private int GetLeftChild(int index)
        {
            return elements[GetLeftChildIndex(index)];
        }

        private int GetRightChild(int index)
        {
            return elements[GetRightChildIndex(index)];
        }

        public int GetParent(int index)
        {
            return elements[GetParentIndex(index)];
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            elements[firstIndex] = elements[firstIndex] + elements[secondIndex];
            elements[secondIndex] = elements[firstIndex] - elements[secondIndex];
            elements[firstIndex] = elements[firstIndex] - elements[secondIndex];
        }
    }
}