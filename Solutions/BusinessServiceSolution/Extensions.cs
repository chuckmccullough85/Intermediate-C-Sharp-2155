using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace ExtensionMethods
{
    public static class Extensions
    {
        public static bool IsValid (this string text, string expression)
        {
            if (!expression.StartsWith('^')) expression = "^" + expression;
            if (!expression.EndsWith('$')) expression += "$";
            return Regex.IsMatch(text, expression);
        }
        public static void Validate<E>(this string text, string expression, string error="invalid") 
            where E : Exception, new()
        {
            if (!text.IsValid(expression)) throw new E();
        }
        public static void Validate(this string text, string expression, string error = "invalid") => 
            Validate<ArgumentException>(text, expression, error);
    }
}
