using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.That(PlusOne(new int[] { 9 }), Is.EqualTo(new int[] { 1, 0 }));
        }

        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                    if (i == 0)
                    {
                        int[] newDigits = new int[digits.Length + 1];
                        newDigits[0] = 1;
                        for (int j = 0; j < digits.Length; j++)
                        {
                            newDigits[j + 1] = digits[j];
                        }
                        return newDigits;
                    }
                    continue;
                }

                digits[i] += 1;
                break;
            }

            return digits;
        }
    }
}