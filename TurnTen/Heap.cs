using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnTen
{
    public class Heap<TPriority, TValue> : IReadOnlyCollection<TValue> where TPriority : IComparable<TPriority>
    {
        const int DefaultCapacity = 4;
        const int GrowthFactor = 2;

        KeyValuePair<TPriority, TValue>[] heap;
        int count;

        public Heap(int capacity)
        {
            heap = new KeyValuePair<TPriority, TValue>[capacity];
        }

        public Heap()
            : this(DefaultCapacity)
        { }

        public int Count => count;

        private void ValidateUp(KeyValuePair<TPriority, TValue>[] heap, int index)
        {
            if (index == 0)
                return;

            int parent = GetParent(index);
            if (heap[index].Key.CompareTo(heap[parent].Key) < 0)
            {
                Switch(heap, index, parent);
                ValidateUp(heap, parent);
            }
        }

        private void ValidateDown(KeyValuePair<TPriority, TValue>[] heap, int index)
        {
            var (child1, child2) = GetChildren(index);
            if (heap[index].Key.CompareTo(heap[child1].Key) > 0 && child1 < count)
            {
                Switch(heap, index, child1);
                ValidateDown(heap, child1);
            }

            if (heap[index].Key.CompareTo(heap[child2].Key) > 0 && child2 < count)
            {
                Switch(heap, index, child2);
                ValidateDown(heap, child2);
            }
        }

        private void Switch(KeyValuePair<TPriority, TValue>[] heap, int index1, int index2)
        {
            KeyValuePair<TPriority, TValue> temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }

        private int GetParent(int index)
        {
            return (index - 1) << 1;
        }

        private (int child1, int child2) GetChildren(int index)
        {
            return (index >> 1 + 1, index >> 1 + 2);
        }

        private void Allocate()
        {
            var newHeap = new KeyValuePair<TPriority, TValue>[heap.Length * GrowthFactor];
            Array.Copy(heap, newHeap, count);
            heap = newHeap;
        }

        public TValue Pop()
        {
            if(count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            TValue value = heap[0].Value;
            heap[0] = heap[--count];
            heap[count] = default(KeyValuePair<TPriority, TValue>);
            ValidateDown(heap, 0);
            return value;
        }

        public void Push(TPriority priority, TValue value)
        {
            Push(new KeyValuePair<TPriority, TValue>(priority, value));
        }

        public void Push(KeyValuePair<TPriority, TValue> item)
        {
            heap[count] = item;
            ValidateUp(heap, count++);
        }

        public IEnumerator<TValue> GetEnumerator() => heap.OrderBy(o => o.Key).Select(o => o.Value).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}