using CSharpKata.Src.Archive;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpKata.Test.Archive
{
    public class ZeroSumSubarrayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Zero_sum_game()
        {
            List<int[]> output = new ZeroSumSubarray().Call(new int[] { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 });

            output.Should().ContainEquivalentOf(new int[] { 3, 4, -7 });
            output.Should().ContainEquivalentOf(new int[] { 4, -7, 3 });
            output.Should().ContainEquivalentOf(new int[] { -7, 3, 1, 3 });
            output.Should().ContainEquivalentOf(new int[] { 3, 1, -4 });
            output.Should().ContainEquivalentOf(new int[] { 3, 1, 3, 1, -4, -2, -2 });
            output.Should().ContainEquivalentOf(new int[] { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 });
        }
    }
}