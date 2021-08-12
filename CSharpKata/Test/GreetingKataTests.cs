using CSharpKata.Src;
using FluentAssertions;
using NUnit.Framework;

namespace CSharpKata.Test
{
    //https://github.com/testdouble/contributing-tests/wiki/Greeting-Kata

    [TestFixture]
    public class GreetingKataTests
    {
        private string result;

        [Test]
        public void Simple_greeting()
        {
            Greet("Bob");

            ShouldReturn("Hello, Bob.");
        }

        [Test]
        public void Handle_null()
        {
            Greet((string)null);

            ShouldReturn("Hello, my friend.");
        }

        [Test]
        public void Shout()
        {
            Greet("JERRY");

            ShouldReturn("HELLO JERRY!");
        }

        [Test]
        public void Two_names()
        {
            Greet(new string[] { "Jack", "Jill" });

            ShouldReturn("Hello, Jack and Jill.");
        }

        private void Greet(string[] names)
        {
            result = GreetingKata.Greet(names);
        }

        private void Greet(string name)
        {
            result = GreetingKata.Greet(name);
        }

        private void ShouldReturn(string expected)
        {
            result.Should().Be(expected);
        }
    }
}
