using NUnit.Framework;
using System;

namespace CodeWars.Test.MorseCode
{
    [TestFixture]
    public class MorseCodeDecoderTests
    {
        [Test]
        public void Reads_morse_code_for_the_letter_A()
        {
            string input = ".-";
            string expected = "A";

            string actual = MorseCodeDecoder.Decode(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void The_letter_Z()
        {
            string input = "--..";
            string expected = "Z";

            string actual = MorseCodeDecoder.Decode(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void The_number_1()
        {
            string input = ".----";
            string expected = "1";

            string actual = MorseCodeDecoder.Decode(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void The_reserved_character_SOS()
        {
            string input = "...---...";
            string expected = "SOS";

            string actual = MorseCodeDecoder.Decode(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void The_word_TEST()
        {
            string input = "- . ... -";
            string expected = "TEST";

            string actual = MorseCodeDecoder.Decode(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void The_sentence_HEY_JUDE()
        {
            string input = ".... . -.--   .--- ..- -.. .";
            string expected = "HEY JUDE";

            string actual = MorseCodeDecoder.Decode(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void The_sentence_morse___morse()
        {
            string input = ".-    -...";
            string expected = "A B";

            string actual = MorseCodeDecoder.Decode(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void The_sentence___morse___morse___()
        {
            string input = "   -.-.   -..   ";
            string expected = "C D";

            string actual = MorseCodeDecoder.Decode(input);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void t()
        {
            string morseCode = "  test          test2         ";
            var chars = morseCode.Trim().Split("   ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}