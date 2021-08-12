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
            var name = names[0] + " and " + names[1];
            return Greet(name);
        }

        private static bool IsAllUpperCase(string name)
        {
            return name.ToCharArray().All(character => char.IsUpper(character));
        }

    }
}