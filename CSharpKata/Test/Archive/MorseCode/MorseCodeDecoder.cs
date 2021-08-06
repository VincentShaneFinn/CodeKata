namespace CodeWars.Tests.MorseCode
{
    public class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            return new Decoder(morseCode).GetTranslatedSentence();
        }

        private class Decoder
        {
            private readonly string morseCode;

            private int cursor;

            public Decoder(string morseCode)
            {
                this.morseCode = morseCode;
            }

            public string GetTranslatedSentence()
            {
                cursor = 0;
                string translatedSentence = "";

                MoveCursorToNextWord();
                while (HasMoreCharacters())
                {
                    translatedSentence += MorseCode.Get(GetNextMorseLetter());
                    if (MoveCursorToNextWord() && HasMoreCharacters()) translatedSentence += " ";
                }

                return translatedSentence;
            }

            private bool HasMoreCharacters() => cursor < morseCode.Length;

            private string GetNextMorseLetter()
            {
                string morseLetter = morseCode[cursor++].ToString();

                if (morseLetter == " ") return "";
                if (!HasMoreCharacters()) return morseLetter;
                return morseLetter += GetNextMorseLetter();
            }

            private bool MoveCursorToNextWord()
            {
                if (!HasMoreCharacters()) return false;

                string spaceLetter = morseCode[cursor].ToString();
                if (spaceLetter != " ") return false;
                cursor++;

                if (spaceLetter == " ") MoveCursorToNextWord();

                return true;
            }
        }
    }
}