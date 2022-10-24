using System.Reflection;

namespace Reflection
{
    public class AuthorDocumenter
    {
        public AuthorDocumenter(string assemblyPath)
        {
            AssemblyPath = assemblyPath;
        }

        public string AssemblyPath { get; set; }

        public void Scan()
        {
            var assembly = Assembly.GetExecutingAssembly();
            //System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(AssemblyPath);
            var types = assembly.GetTypes()
                .Where(t => t.IsDefined(typeof(AuthorAttribute)))
                .OrderBy(t=>t.Name);
            foreach (var t in types)
            {
                var attrs = t.GetCustomAttributes<AuthorAttribute>(true);
                foreach (var attr in attrs)
                {
                    Console.WriteLine($"{t.Name} was written by {attr.Name} from {attr.Department}");
                }
            }
        }
    }
}
