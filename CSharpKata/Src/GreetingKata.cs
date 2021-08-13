using Castle.Core.Internal;

namespace CSharpKata.Src
{
    public static class GreetingKata
    {
        public static string Greet(string name)
        {
            if (name == null) name = "my friend";
            else if (IsAllCaps(name)) return $"HELLO {name}!";
            return $"Hello, { name }.";
        }

        public static string Greet(string[] names)
        {
            if (names.IsNullOrEmpty()) return Greet((string)null);

            var standardNames = names.Where(word => !IsAllCaps(word)).ToArray();
            var shoutNames = names.Where(word => IsAllCaps(word)).ToArray();

            if (shoutNames.IsNullOrEmpty()) return GreetArray(standardNames);
            if (standardNames.IsNullOrEmpty()) return GreetArray(shoutNames);
            return GreetArray(standardNames) + " AND " + GreetArray(shoutNames);
        }

        private static string GreetArray(string[] names)
        {
            if (names.Length == 1) return Greet(names[0]);
            if (names.Length == 2) return GreetTwo(names);
            return GreetMultiple(names);
        }

        private static string GreetTwo(string[] names)
        {
            var conjunction = " and ";
            if (AreAllCaps(names)) conjunction = " AND ";
            return Greet(names[0] + conjunction + names[1]);
        }

        private static string GreetMultiple(string[] names)
        {
            string greeting = "Hello";
            for (int i = 0; i < names.Length; i++)
            {
                bool isFirst = i == 0, isLast = i == names.Length - 1;
                if (isFirst) greeting += " ";
                else if (isLast) greeting += ", and ";
                else greeting += ", ";
                greeting += names[i];
            }

            if (AreAllCaps(names)) greeting = greeting.ToUpper() + "!";
            else greeting += ".";

            return greeting;
        }

        private static bool AreAllCaps(string[] names) => 
            names.All(word => IsAllCaps(word));

        private static bool IsAllCaps(string name) =>
            name.ToCharArray().All(character => char.IsUpper(character) || char.IsWhiteSpace(character));
    }
}