namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, 
        AllowMultiple = true, Inherited =false)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string authorName)
        {
            Name = authorName;
            Department = "";
        }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
