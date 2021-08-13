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

        public class Given_string : GreetingKataTests
        {

            [Test]
            public void Simple_greeting_with_string()
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

            private void Greet(string name)
            {
                result = GreetingKata.Greet(name);
            }
        }

        public class Given_array : GreetingKataTests
        {
            [Test]
            public void Simple_greeting()
            {
                Greet("Tim");

                ShouldReturn("Hello, Tim.");
            }

            [Test]
            public void Handle_null_or_empty()
            {
                Greet(null);
                ShouldReturn("Hello, my friend.");

                Greet(Array.Empty<string>());
                ShouldReturn("Hello, my friend.");
            }

            [Test]
            public void Two_names()
            {
                Greet("Jack", "Jill");

                ShouldReturn("Hello, Jack and Jill.");
            }

            [Test]
            public void Arbitrary_amount_of_names()
            {
                Greet(new string[] { "John", "Joe", "Jim" });

                ShouldReturn("Hello John, Joe, and Jim");
            }

            [Test]
            public void Single_shout()
            {

            }

            [Ignore("todo")]
            [Test]
            public void Mixin_shouts()
            {

            }

            private void Greet(params string[] names)
            {
                result = GreetingKata.Greet(names);
            }
        }

        private void ShouldReturn(string expected)
        {
            result.Should().Be(expected);
        }
    }
}
