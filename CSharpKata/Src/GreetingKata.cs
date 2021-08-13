using Castle.Core.Internal;

namespace CSharpKata.Src
{
    public static class GreetingKata
    {
        public static string Greet(string name)
        {
            if (name == null) name = "my friend";
            else if (IsAllUpperCase(name)) return $"HELLO {name}!";
            return $"Hello, { name }.";
        }

        public static string Greet(string[] names)
        {
            if (names.IsNullOrEmpty()) return Greet((string)null);
            else if (names.Length == 1) return Greet(names[0]);
            else if (names.Length == 2) return Greet(names[0] + " and " + names[1]);
            else return GreetMultiple(names);
        }

        private static string GreetMultiple(string[] names)
        {
            string greeting = "Hello";
            for (int i = 0; i < names.Length; i++)
            {
                if (i == 0) greeting += " ";
                else if (i == names.Length - 1) greeting += ", and ";
                else greeting += ", ";
                greeting += names[i];
            }
            return greeting;
        }

        private static bool IsAllUpperCase(string name) =>
            name.ToCharArray().All(character => char.IsUpper(character));
    }
}