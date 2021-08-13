using CSharpKata.Src.Archive;
using FluentAssertions;
using NUnit.Framework;

namespace CSharpKata.Test.Archive
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
                Greet("John", "Joe", "Jim");

                ShouldReturn("Hello, John, Joe, and Jim.");
            }

            [Test]
            public void Single_shout()
            {
                Greet("ELVIS");

                ShouldReturn("HELLO ELVIS!");
            }

            [Test]
            public void Double_shout()
            {
                Greet("ONE", "TWO");

                ShouldReturn("HELLO ONE AND TWO!");
            }

            [Test]
            public void Arbitrary_amount_shout()
            {
                Greet("ONE", "TWO", "THREE");

                ShouldReturn("HELLO, ONE, TWO, AND THREE!");
            }

            [Test]
            public void Mixin_shouts()
            {
                Greet("Bonnie", "STEVE", "Clyde");

                ShouldReturn("Hello, Bonnie and Clyde. AND HELLO STEVE!");
            }

            [Test]
            public void Comma_separated()
            {
                Greet("One", "Two,Three", "Four");

                ShouldReturn("Hello, One, Two, Three, and Four.");
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
