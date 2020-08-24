using NUnit.Framework;
using ArrayListAllMethods;
using ArrayListHomeWork;

namespace ArrayList_Test
{

    public class ArrayListTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]

        [TestCase(new int[] { 1, 2, 3, 0 }, 3, new int[] { 3, 1, 2, 3, 0 })]
        [TestCase(new int[] { }, 0, new int[] { 0 })]
        [TestCase(new int[] { 1 }, 1, new int[] { 1, 1 })]
        [TestCase(new int[] { 200, 0, 0, 0, 0 }, 1, new int[] { 1, 200, 0, 0, 0, 0 })]
        public void AddFirstTest(int[] _array, int val, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            arrayList.AddFirst(val);
            int[] actual = arrayList.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 0 }, new int[] { 98, 99, 100 }, new int[] { 98, 99, 100, 1, 2, 3, 0 })]
        [TestCase(new int[] { }, new int[] { 98, 99, 100 }, new int[] { 98, 99, 100 })]
        [TestCase(new int[] { 1 }, new int[] { 98, 99, 100 }, new int[] { 98, 99, 100, 1 })]
        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, new int[] { 98, 99, 100 }, new int[] { 98, 99, 100, 200, 400, 600, 800, 1000 })]
        public void AddFirstArrayTest(int[] _array, int[] vals, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            arrayList.AddFirstArray(vals);
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 5, 5, new int[] { 200, 400, 600, 800, 1000, 5 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 4, 4, new int[] { 200, 400, 600, 800, 4 })]
        [TestCase(new int[] { }, 10, 0, new int[] { 10 })]
        [TestCase(new int[] { 1 }, 52, 1, new int[] { 1, 52 })]
        [TestCase(new int[] { 200, 0, 0, 0, 0 }, 1, 1, new int[] { 200, 1 })]
        public void AddLastTest(int[] _array, int val, int currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, currentIndex);
            arrayList.AddLast(val);
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, new int[] { 98, 99, 100 }, 5, new int[] { 200, 400, 600, 800, 1000, 98, 99, 100 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, new int[] { 98, 99, 100 }, 4, new int[] { 200, 400, 600, 800, 98, 99, 100 })]
        [TestCase(new int[] { }, new int[] { 98, 99, 100 }, 0, new int[] { 98, 99, 100 })]
        [TestCase(new int[] { 1 }, new int[] { 98, 99, 100 }, 1, new int[] { 1, 98, 99, 100 })]
        [TestCase(new int[] { 200, 0, 0, 0, 0 }, new int[] { 98, 99, 100 }, 1, new int[] { 200, 98, 99, 100 })]
        public void AddLastArrayTest(int[] _array, int[] vals, int currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, currentIndex);
            arrayList.AddLastArray(vals);
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 2, 5, 5, new int[] { 200, 400, 5, 600, 800, 1000 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 1, 4, 4, new int[] { 200, 4, 400, 600, 800 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 9, 4, 4, new int[] { 200, 400, 600, 800, 0 })]
        [TestCase(new int[] { }, 0, 10, 0, new int[] { 10 })]
        [TestCase(new int[] { 1 }, 0, 52, 1, new int[] { 52, 1 })]
        [TestCase(new int[] { 200, 0, 0, 0, 0 }, 1, 1, 1, new int[] { 200, 1 })]
        public void AddAtTest(int[] _array, int idx, int val, int currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, currentIndex);
            try
            {
                arrayList.AddAt(idx, val);
                int[] actual = arrayList.ToArray();
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.IndexError());
            }
        }

        [TestCase(new int[] { 1, 2, 3, 0 }, new int[] { 98, 99, 100 }, 7)]
        [TestCase(new int[] { }, new int[] { 98, 99, 100 }, 3)]
        [TestCase(new int[] { 1 }, new int[] { 98, 99, 100 }, 4)]
        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, new int[] { 98, 99, 100 }, 8)]
        public void GetSizeTest(int[] _array, int[] vals, int expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            arrayList.AddFirstArray(vals);
            int actual = arrayList.GetSize();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 2, new int[] { 98, 99, 100 }, 5, new int[] { 200, 400, 98, 99, 100, 600, 800, 1000 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 1, new int[] { 98, 99, 100 }, 4, new int[] { 200, 98, 99, 100, 400, 600, 800 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 9, new int[] { 98, 99, 100 }, 4, new int[] { 200, 400, 600, 800, 0 })]
        [TestCase(new int[] { }, 0, new int[] { 98, 99, 100 }, 0, new int[] { 98, 99, 100 })]
        [TestCase(new int[] { 1 }, 0, new int[] { 98, 99, 100 }, 1, new int[] { 98, 99, 100, 1 })]
        [TestCase(new int[] { 200, 0, 0, 0, 0 }, 1, new int[] { 98, 99, 100 }, 1, new int[] { 200, 98, 99, 100 })]
        public void AddAtArrayTest(int[] _array, int idx, int[] vals, int currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, currentIndex);
            try
            {
                arrayList.AddAt(idx, vals);
                int[] actual = arrayList.ToArray();
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.IndexError());
            }
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 2, 5, new int[] { 200, 400, 5, 800, 1000 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 1, 4, new int[] { 200, 4, 600, 800, 0 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 9, 4, new int[] { })]
        [TestCase(new int[] { }, 0, 10, new int[] { })]
        [TestCase(new int[] { 1 }, 0, 52, new int[] { 52 })]
        [TestCase(new int[] { 200, 0, 0, 0, 0 }, 1, 1, new int[] { 200, 1, 0, 0, 0 })]
        public void SetTest(int[] _array, int idx, int val, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            try
            {
                arrayList.Set(idx, val);
                int[] actual = arrayList.ToArray();
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.IndexError());
            }
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 5, new int[] { 400, 600, 800, 1000 })]
        [TestCase(new int[] { 1, 2, 3, 0 }, 3, new int[] { 2, 3 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void RemoveFirstTest(int[] _array, int _currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            try
            {
                arrayList.RemoveFirst();
                int[] actual = arrayList.ToArray();
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.EmptyArray());
            }
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 5, new int[] { 200, 400, 600, 800 })]
        [TestCase(new int[] { 1, 2, 3, 0 }, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, 1, new int[] { })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void RemoveLastTest(int[] _array, int _currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            try
            {
                arrayList.RemoveLast();
                int[] actual = arrayList.ToArray();
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.EmptyArray());
            }
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 2, new int[] { 200, 400, 800, 1000 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]
        public void RemoveAtTest(int[] _array, int idx, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            arrayList.RemoveAt(idx);
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 600, new int[] { 200, 400, 800, 1000 })]
        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 12, new int[] { 200, 400, 600, 800, 1000 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -4, new int[] { -8, -7, -98, -125, -987, -8 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -8, new int[] { -4, -7, -4, -98, -125, -4, -987 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 11, new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 })]
        public void RemoveAllValueTest(int[] _array, int val, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            arrayList.RemoveAll(val);
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -4, 0)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -8, 1)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987 }, -987, 7)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 11, -1)]
        public void IndexOfValTest(int[] _array, int val, int expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            int actual = arrayList.IndexOf(val);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -4, true)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -8, true)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987 }, -987, true)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 11, false)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 0, false)]
        [TestCase(new int[] { }, 0, false)]
        public void ContainsTest(int[] _array, int val, bool expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            bool actual = arrayList.Contains(val);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000, 0, 0, 0 }, 5, new int[] { 200, 400, 600, 800, 1000 })]
        [TestCase(new int[] { 1, 2, 3, 0 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, 1, new int[] { 1 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void ToArrayTest(int[] _array, int _currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000, 0, 0, 0 }, 200)]
        [TestCase(new int[] { 1, 2, 3, 0 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void GetFirstTest(int[] _array, int expected)
        {
            ArrayList arrayList = new ArrayList(_array);
            try
            {
                int actual = arrayList.GetFirst();
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.EmptyArray());
            }
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000, 0, 0, 0 }, 5, 1000)]
        [TestCase(new int[] { 1, 2, 3, 0 }, 3, 3)]
        [TestCase(new int[] { 1 }, 1, 1)]
        [TestCase(new int[] { }, 0, 0)]
        public void GetLastTest(int[] _array, int _curretnIndex, int expected)
        {
            ArrayList arrayList = new ArrayList(_array, _curretnIndex);
            try
            {
                int actual = arrayList.GetLast();
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.EmptyArray());
            }
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000, 0, 0, 0 }, 5, 3, 800)]
        [TestCase(new int[] { 1, 2, 3, 0 }, 3, 1, 2)]
        [TestCase(new int[] { 1 }, 1, 0, 1)]
        [TestCase(new int[] { }, 0, 0, 0)]
        public void GetTest(int[] _array, int _curretnIndex, int idx, int expected)
        {
            ArrayList arrayList = new ArrayList(_array, _curretnIndex);
            try
            {
                int actual = arrayList.Get(idx);
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.EmptyArray());
            }
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000, 0, 0, 0 }, 5, new int[] { 1000, 800, 600, 400, 200 })]
        [TestCase(new int[] { 1, 2, 3, 0 }, 3, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1 }, 1, new int[] { 1 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void ReverseTest(int[] _array, int _currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            arrayList.Reverse();
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 1624, 800, 1000, 0, 0, 0 }, 5, 2)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 9, 0)]
        [TestCase(new int[] { -12, -8, -7, -4, -98, -125, -4, -987, -8 }, 9, 3)]
        public void IndexOfMaxTest(int[] _array, int _currentIndex, int expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            int actual = arrayList.IndexOfMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 1624, 800, 1000, 0, 0, 0 }, 5, 1624)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 9, -4)]
        [TestCase(new int[] { -12, -8, -7, -4, -98, -125, -4, -987, -8 }, 9, -4)]
        public void MaxTest(int[] _array, int _currentIndex, int expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            int actual = arrayList.Max();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 1624, 800, 1000, 0, 0, 0 }, 5, 0)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8, 0, 0 }, 9, 7)]
        [TestCase(new int[] { -12, -8, -7, -4, -98, -125, -4, -87, -8359 }, 9, 8)]
        public void IndexOfMinTest(int[] _array, int _currentIndex, int expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            int actual = arrayList.IndexOfMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 1624, 800, 1000, 0, 0, 0 }, 5, 200)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8, 0, 0 }, 9, -987)]
        [TestCase(new int[] { -12, -8, -7, -4, -98, -125, -4, -87, -8359 }, 9, -8359)]
        public void MinTest(int[] _array, int _currentIndex, int expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            int actual = arrayList.Min();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 600, 1000, 200, 800, 400, 0, 0, 0 }, 5, new int[] { 200, 400, 600, 800, 1000 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 9, new int[] { -987, -125, -98, -8, -8, -7, -4, -4, -4 })]
        [TestCase(new int[] { -4, -8, -7, 0, -98, 125, -4, -987, -8 }, 9, new int[] { -987, -98, -8, -8, -7, -4, -4, 0, 125 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void SortTest(int[] _array, int _currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            arrayList.Sort();
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 600, 1000, 200, 800, 400, 0, 0, 0 }, 5, new int[] { 1000, 800, 600, 400, 200 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 9, new int[] { -4, -4, -4, -7, -8, -8, -98, -125, -987 })]
        [TestCase(new int[] { -4, -8, -7, 0, -98, 125, -4, -987, -8 }, 9, new int[] { 125, 0, -4, -4, -7, -8, -8, -98, -987 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        public void SortDescTest(int[] _array, int _currentIndex, int[] expected)
        {
            ArrayList arrayList = new ArrayList(_array, _currentIndex);
            arrayList.SortDesc();
            int[] actual = arrayList.ToArray();
            Assert.AreEqual(expected, actual);
        }

    }
}
