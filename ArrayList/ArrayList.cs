using ArrayListHomeWork;
using System;

namespace ArrayListAllMethods
{      
    public class ArrayList
    {
        public ArrayList() { }
        private int _currentIndex = 0;
        private int[] _array = new int[20];        

        public ArrayList(int[] array)
        {
            _array = new int[array.Length + 5];
            for (int i = 0; i < array.Length; i ++)
            {
                _array[i] = array[i];
            }

            _currentIndex = array.Length;
        }

        public ArrayList(int[] array, int currentIndex)
        {
            _array = new int[array.Length + 5];
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _currentIndex = currentIndex;
        }

        public void AddFirst(int val)
        {
            _array = CheckArraySize();

            if (_currentIndex > 0)
            {
                _array = MoveElementsRightToOne(_currentIndex);
                _array[0] = val;
            }
            else
            {
                _array[0] = val;
            }
            _currentIndex++;
        }

        public void AddFirstArray(int[] vals)
        {
            _array = CheckArraySizeForNewArray(vals.Length);

            if (_currentIndex > 0)
            {
                int count = _currentIndex;
                for (int i = 0; i < vals.Length; i++)
                {
                    _array = MoveElementsRightToOne(count);
                    count++;
                }
                for (int i = 0; i < vals.Length; i++)
                {
                    _array[i] = vals[i];
                }
            }
            else
            {
                for (int i = 0; i < vals.Length; i++)
                {
                    _array[i] = vals[i];
                }
            }
            _currentIndex += vals.Length;
        }

        public void AddLast(int val)
        {
            _array = CheckArraySize();
            _array[_currentIndex] = val;
            _currentIndex++;
        }

        public void AddLastArray(int[] vals)
        {
            _array = CheckArraySizeForNewArray(vals.Length);
            for (int i = 0; i < vals.Length; i++)
            {
                _array[_currentIndex + i] = vals[i];
            }
            _currentIndex += vals.Length;
        }

        public void AddAt(int idx, int val)
        {
            if(idx > _currentIndex)
            {
               Errors.IndexError();
               return;
            }
            _array = CheckArraySize();            
            _array = MoveElementsRightToArray(idx, 1);
            _array[idx] = val;
            _currentIndex++;
        }

        public void AddAt(int idx, int[] vals)
        {
            if (idx > _currentIndex)
            {
                Errors.IndexError();
                return;
            }

            _array = CheckArraySizeForNewArray(vals.Length);
            _array = MoveElementsRightToArray(idx, vals.Length);
            for (int i = 0; i < vals.Length; i++)
            {
                _array[idx + i] = vals[i];
            }
            _currentIndex += vals.Length;
        }

        public int GetSize()
        {
            return _currentIndex;            
        }

        public void Set(int idx, int val)
        {
            if (idx > _currentIndex)
                Errors.IndexError();
            _array[idx] = val;
        }
        
        public void RemoveFirst()
        {
            if (_currentIndex == 0)
                Errors.EmptyArray();

            int[] array2 = _array;
            for (int i = 0; i < _currentIndex; i++)
            {
                _array[i] = array2[i + 1];
            }            
            _currentIndex--;
        }

        public void RemoveLast()
        {
            if (_currentIndex == 0)
                Errors.EmptyArray();

            _array[_currentIndex - 1] = 0;
            _currentIndex--;
        }

        public void RemoveAt(int idx)
        {
            if (_currentIndex == 0)
                Errors.EmptyArray();

            if (idx > _currentIndex)
                Errors.IndexError();

            _array[idx] = 0;
            int[] array2 = _array;
            for (int i = 0; idx + i < _array.Length - 1; i++)
            {
                _array[idx + i] = array2[idx + i + 1];
            }

            for (int i = 0; i < idx; i++)
            {
                _array[i] = array2[i];
            }
            _currentIndex--;
        }

        public void RemoveAll(int val) 
        {
            int count = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == val)
                {
                    count++;
                }
            }

            _currentIndex -= count;

            if (_array.Length - count != 0)
            {
                int[] arrayIndexVal = new int[_array.Length - count];
                int counter = 0;
                for (int i = 0; i < _array.Length; i++)
                {
                    if (_array[i] != val)
                    {
                        arrayIndexVal[counter] = _array[i];
                        counter++;
                    }
                }

                _array = arrayIndexVal;
            }
        }

        public bool Contains(int val)
        {
            bool answer = false;
            _array = ToArray();
            int index = IndexOf(val);
            if (index > -1)
            {
                answer = true;
            }

            return answer;
        }

        public int IndexOf(int val)
        {
            int index = -1;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == val)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public int[] ToArray() 
        {
            int[] visibleArray = new int[_currentIndex];
            for (int i = 0; i < _currentIndex; i++)
            {
                visibleArray[i] = _array[i];
            }

            return visibleArray;
        }

        public int GetFirst()
        {
            if (_array != null)
            {
                int a = _array[0];
                return a;
            }
            else
            {
                Errors.EmptyArray();
                return 0;
            }            
        }

        public int GetLast()
        {
            if(_array != null)
            {
                int a = _array[_currentIndex - 1];
                return a;
            }
            else
            {
                Errors.EmptyArray();
                return 0;
            }            
        }

        public int Get(int idx)
        {
            if (_currentIndex == 0)
                Errors.EmptyArray();
            if (idx > _currentIndex)
                Errors.IndexError();

            int number = _array[idx];
            return number;
        }

        public void Reverse()
        {
            _array = ToArray();

            int currentNumber;
            for (int i = 0; i < _currentIndex / 2; i++)
            {
                currentNumber = _array[i];
                _array[i] = _array[_currentIndex - i - 1];
                _array[_currentIndex - i - 1] = currentNumber;
            }
        }

        public int Max()
        {
            int indexMax = IndexOfMax();
            int max = _array[indexMax];
            return max;
        }

        public int Min()
        {
            int indexMin = IndexOfMin();
            int min = _array[indexMin];
            return min;
        }

        public int IndexOfMax()
        {
            int maxNumber = _array[0];
            int index = 0;

            for (int i = 0; i < _currentIndex; i++)
            {

                if (_array[i] > maxNumber)
                {
                    maxNumber = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public int IndexOfMin()
        {
            int minNumber = _array[0];
            int index = 0;

            for (int i = 0; i < _currentIndex; i++)
            {

                if (_array[i] < minNumber)
                {
                    minNumber = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public void Sort()
        {
            _array = ToArray();
            int copyCurrentIndex = _currentIndex;
            for (int i = 0; i < _array.Length; i++)
            {
                _currentIndex = _array.Length - i;
                int indexMax = IndexOfMax();
                int tmp = _array[_currentIndex - 1];
                _array[_currentIndex - 1] = _array[indexMax];
                _array[indexMax] = tmp;
            }
            _currentIndex = copyCurrentIndex;            
        }

        public void SortDesc()
        {
            _array = ToArray();
            int copyCurrentIndex = _currentIndex;
            for (int i = 0; i < _array.Length; i++)
            {
                _currentIndex = _array.Length - i;
                int indexMin = IndexOfMin();
                int tmp = _array[_currentIndex - 1];
                _array[_currentIndex - 1] = _array[indexMin];
                _array[indexMin] = tmp;
            }
            _currentIndex = copyCurrentIndex;
        }

        private int[] NewBiggerArray()
        {
            int[] biggerArray = new int[_array.Length + (_array.Length / 2 + 1)];

            for (int i = 0; i < _array.Length; i++)
            {
                biggerArray[i] = _array[i];
            }

            return biggerArray;
        }

        private int[] CheckArraySize()
        {
            if (_currentIndex == _array.Length - 1)
            {
                int[] newArray = NewBiggerArray();
                return newArray;
            }
            else
            {
                return _array;
            }
        }

        private int[] CheckArraySizeForNewArray(int sizeOfNewArray)
        {
            while (_array.Length < _currentIndex + sizeOfNewArray + 1)
            {
                _array = NewBiggerArray();
            }
            return _array;
        }

        private int[] MoveElementsRightToOne(int currentIndex)
        {
            while (currentIndex >= _array.Length - 1)
            {
                _array = NewBiggerArray();
            }

            int[] array2 = new int[_array.Length];
            for (int i = 0; i < currentIndex + 1; i++)
            {
                array2[i + 1] = _array[i];
            }
            return array2;
        }

        private int[] MoveElementsRightToArray(int idx, int amountOfNumbers)
        {
            while (_array.Length < _currentIndex + amountOfNumbers + 1)
            {
                _array = NewBiggerArray();
            }

            int[] array2 = new int[_array.Length];
            int counter = _currentIndex + 1 - idx;
            for (int i = 0; i < counter; i++)
            {
                array2[idx + amountOfNumbers + i] = _array[idx + i];
            }

            for (int i = 0; i < idx; i++)
            {
                array2[i] = _array[i];
            }
            return array2;
        }       

    }
}

