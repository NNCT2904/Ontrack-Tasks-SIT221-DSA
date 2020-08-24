namespace solution
{
    public class FindTwoInt
    {
        public bool FindTwoIntForSum(int[] inputArray, int sum)
        {
            int left = 0;
            int right = inputArray.Length - 1;

            //Sort the array using mergesort algorithm, 
            //Mergesort will run with the complexity of Theta(n.Log(n))
            MergeSort(inputArray, Comparer<K>.Default);

            /*
            Scan the array,
            left is the left most index (0)
            right is right most index (length-1)
            if element in left most + rightmost is the wanted number return true
            if < the wanted number then increase left by 1
            if > the wanted number then decrease right by 1
            if can not find the 2 numbers, then return false

            This will run with the complexity of Theta(n)
             */
            while (left < right)
            {
                if (inputArray[left] + inputArray[right] == sum)
                    return true;
                else if (inputArray[left] + inputArray[right] < sum)
                    left++;
                else
                    right--;
            }
            return false;
        }
        private void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;
            //when array length is 1, it is sorted
            if (n < 2) return;

            //chop chop
            int mid = n / 2;
            K[] s1 = sequence.Take(mid).ToArray();
            K[] s2 = sequence.Skip(mid).ToArray();

            //conquer, sort the 2 sequences recursively
            MergeSort(s1, comparer);
            MergeSort(s2, comparer);

            //Merge result to original
            Merge(s1, s2, sequence, comparer);
        }
        private void Merge<K>(K[] s1, K[] s2, K[] s, IComparer<K> comparer) where K : IComparable<K>
        {
            int i = 0, j = 0;
            while (i + j < s.Length)
            {
                if (j == s2.Length || (i < s1.Length && comparer.Compare(s1[i], s2[j]) < 0))
                    s[i + j] = s1[i++];
                else
                    s[i + j] = s2[j++];
            }
        }
    }

    public class DummyStack<T>
    {
        //The main stack
        private Stack<T> _stack;
        //Auxiliary stack for minimum element storing
        private Stack<T> _auxStack;

        //Constructor
        public DummyStack()
        {
            _stack = new Stack();
            _auxStack = new Stack();
        }

        public int Minimum
        {
            get
            {
                if (_auxStack.IsEmpty)
                {
                    throw new InvalidOperationException("Stack Underflow!");
                }
                return _auxStack.Peek();
            }
        }

        public void Push(T x)
        {
            //Push the item to stack
            _stack.Push(x);

            //Also push to the Auxiliary stack if it is empty
            if (_auxStack.IsEmpty)
            {
                _auxStack.Push(x);
            }
            else
            {
                if (_auxStack.Peek() >= x)
                {
                    _auxStack.Push(x);
                }
            }
        }

        public int Pop()
        {
            if (_stack.IsEmpty)
            {
                throw new InvalidOperationException("Stack Underflow!");
            }

            //Remove the top element
            T theTop = _stack.Pop();

            //Peak the Auxiliary stack, 
            //if it is equal to that top element then remove it also
            if (theTop == _auxStack.Peek())
            {
                _auxStack.Pop();
            }

            //Return the top element
            return theTop;
        }
    }

    public interface Stack<K>
    {
        void Push(K input);
        K Pop();
        K Peek();
    }
}