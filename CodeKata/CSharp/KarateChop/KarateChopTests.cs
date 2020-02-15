using NUnit.Framework;

namespace KarateChop
{
    public class BinarySearcher
    {
        // Attemp1 1
        //public int Chop(int searchTarget, int[] sortedArray)
        //{
        //    if (sortedArray == null || sortedArray.Length == 0) return -1;

        //    int index = 0;
        //    foreach (var item in sortedArray)
        //    {
        //        if (item == searchTarget) return index;
        //        index++;
        //    }

        //    return -1;
        //}

        // Attempt 2
        //public int Chop(int searchTarget, int[] sortedArray)
        //{
        //    if (sortedArray == null || sortedArray.Length == 0) return -1;

        //    int lower = 0;
        //    int upper = sortedArray.Length;
        //    while (true)
        //    {
        //        int halfIndex = (upper - lower) / 2 + lower;
        //        int halfIndexValue = sortedArray[halfIndex];
        //        if (searchTarget == halfIndexValue) return halfIndex;
        //        else if (upper - lower <= 1) break;
        //        else if (searchTarget < halfIndexValue) upper = halfIndex;
        //        else if (searchTarget > halfIndexValue) lower = halfIndex;
        //    }

        //    return -1;
        //}

        // Attempt 3 Recursive
        public int Chop(int searchTarget, int[] sortedArray)
        {
            if (sortedArray == null || sortedArray.Length == 0) return -1;

            return RecursiveChop(searchTarget, sortedArray, 0, sortedArray.Length);
        }

        private int RecursiveChop(int searchTarget, int[] sortedArray, int lower, int upper)
        {
            int index = (upper - lower) / 2 + lower;
            if (searchTarget == sortedArray[index]) return index;
            else if (upper - lower <= 1) return -1;
            else if (searchTarget < sortedArray[index]) return RecursiveChop(searchTarget, sortedArray, lower, index);
            else return RecursiveChop(searchTarget, sortedArray, index, upper);
        }
    }

    public class BinarySearcherTests
    {
        // Write a binary search method that takes an interger target and an array of integers,
        // returns the integer index of the target in that array,
        // returns -1 if the target is not in array

        private BinarySearcher searcher;

        [SetUp]
        public void Setup()
        {
            searcher = new BinarySearcher();
        }

        [Test]
        public void Null_array_returns_not_found_indicator()
        {
            Assert.That(searcher.Chop(3, null), Is.EqualTo(-1));
        }

        [Test]
        public void Empty_array_returns_not_found_indicator()
        {
            Assert.That(searcher.Chop(3, new int[] { }), Is.EqualTo(-1));
        }

        [Test]
        public void Not_found_returns_not_found_indicator()
        {
            Assert.That(searcher.Chop(3, new int[] { 1 }), Is.EqualTo(-1));
        }

        [Test]
        public void Finds_target_index_in_array_of_1_items()
        {
            Assert.That(searcher.Chop(3, new int[] { 3 }), Is.EqualTo(0));
        }

        [Test]
        public void Finds_target_index_in_array_of_2_items()
        {
            Assert.That(searcher.Chop(3, new int[] { 1, 3 }), Is.EqualTo(1));
        }

        [TestCase(1, new int[] { 0, 1 }, 1, TestName = "Finds target in 2 Item Array")]
        [TestCase(1, new int[] { 0, 1, 2 }, 1, TestName = "Finds target in 3 Item Array")]
        [TestCase(3, new int[] { 0, 1, 2, 3 }, 3, TestName = "Finds target in 4 Item Array")]
        public void Finds_target_index_in_array(int target, int[] array, int targetIndex)
        {
            Assert.That(searcher.Chop(target, array), Is.EqualTo(targetIndex));
        }

        //[Test]
        //public void Really_Long_Array_Performance()
        //{
        //    var list = new List<int>();
        //    for (int i = 0; i < 66666666; i++)
        //        list.Add(i);
        //    Assert.That(searcher.Chop(0, list.ToArray()), Is.EqualTo(0));
        //}
    }
}