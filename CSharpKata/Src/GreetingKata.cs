using Castle.Core.Internal;

namespace CSharpKata.Src
{
    public static class GreetingKata
    {
        public static string Greet(string name) => GreetArray(new string[] { name });

        // use polymorphism on caps and normal instead of the wierd checks
        public static string Greet(string[] names)
        {
            if (names.IsNullOrEmpty()) names = new string[] { "my friend" };

            names = SplitCommSeparatedNames(names);

            var standardNames = names.Where(word => !IsAllCaps(word)).ToArray();
            var shoutNames = names.Where(word => IsAllCaps(word)).ToArray();

            if (shoutNames.IsNullOrEmpty()) return GreetArray(standardNames);
            if (standardNames.IsNullOrEmpty()) return GreetArray(shoutNames);
            return GreetArray(standardNames) + " AND " + GreetArray(shoutNames);
        }

        private static string[] SplitCommSeparatedNames(string[] names)
        {
            var newNames = new List<string>();

            foreach(var name in names)
            {
                var splitNames = name.Split(',');
                newNames.AddRange(splitNames);
            }

            return newNames.ToArray();
        }

        private static string GreetOne(string name)
        {
            if (IsAllCaps(name)) return $"HELLO {name}!";
            return $"Hello, { name }.";
        }

        private static string GreetArray(string[] names)
        {
            if (names.Length == 1) return GreetOne(names[0]);
            if (names.Length == 2) return GreetTwo(names[0], names[1]);
            return GreetMultiple(names);
        }

        private static string GreetTwo(string name1, string name2)
        {
            var conjunction = " and ";
            if (IsAllCaps(name1) && IsAllCaps(name2)) conjunction = " AND ";
            return GreetOne(name1 + conjunction + name2);
        }

        private static string GreetMultiple(string[] names)
        {
            string greeting = "Hello";
            for (int i = 0; i < names.Length; i++)
            {
                bool isLast = i == names.Length - 1;
                if (isLast) greeting += ", and ";
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