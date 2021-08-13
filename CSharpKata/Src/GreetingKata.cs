using Castle.Core.Internal;

namespace CSharpKata.Src
{
    public static class GreetingKata
    {
        public static string Greet(string name) => Greet(new string[] { name });

        public static string Greet(string[] names)
        {
            if (names.IsNullOrEmpty()) names = new string[] { "my friend" };
            names = SpreadCommaSeparatedNames(names);
            StandardGreetings standardGreetings = new();
            ShoutGreetings shoutGreetings = new();

            var standardNames = names.Where(word => !IsAllCaps(word)).ToArray();
            var shoutNames = names.Where(word => IsAllCaps(word)).ToArray();

            var conjuction = !standardNames.IsNullOrEmpty() && !shoutNames.IsNullOrEmpty() ? " AND " : string.Empty;
            return standardGreetings.Greet(standardNames) + conjuction + shoutGreetings.Greet(shoutNames);
        }

        private static string[] SpreadCommaSeparatedNames(string[] names)
        {
            var newNames = new List<string>();

            foreach (var name in names) newNames.AddRange(name.Split(','));

            return newNames.ToArray();
        }

        private static bool IsAllCaps(string name) =>
            name.ToCharArray().All(character => char.IsUpper(character) || char.IsWhiteSpace(character));

        private abstract class GreetingsBase
        {
            public string Greet(string[] names)
            {
                if (names.IsNullOrEmpty()) return string.Empty;
                if (names.Length == 1) return GreetOne(names[0]);
                if (names.Length == 2) return GreetTwo(names[0], names[1]);
                return Finish(GreetMultipleStart(names));
            }

            protected abstract string GreetOne(string name);
            protected abstract string GreetTwo(string name1, string name2);
            protected abstract string Finish(string greeting);

            private static string GreetMultipleStart(string[] names)
            {
                string greeting = "Hello";
                for (int i = 0; i < names.Length; i++)
                {
                    bool isLast = i == names.Length - 1;
                    if (isLast) greeting += ", and ";
                    else greeting += ", ";
                    greeting += names[i];
                }
                return greeting;
            }
        }

        private class StandardGreetings : GreetingsBase
        {
            protected override string GreetOne(string name) => $"Hello, { name }.";
            protected override string GreetTwo(string name1, string name2) => GreetOne(name1 + " and " + name2);
            protected override string Finish(string greeting) => greeting += ".";
        }

        private class ShoutGreetings : GreetingsBase
        {
            protected override string GreetOne(string name) => $"HELLO {name}!";
            protected override string GreetTwo(string name1, string name2) => GreetOne(name1 + " AND " + name2);
            protected override string Finish(string greeting) => greeting.ToUpper() + "!";
        }
    }
}