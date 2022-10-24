using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinqApi
{
    public record Movie (string Title, int Year, string Rated, string Genre, string[] Cast );
    public class MovieDb
    {
        public MovieDb(string path = "MoviesJson.txt")
        {
            var movies = new List<Movie>();
            Movies = movies; 
            using var rdr = new StreamReader(path);
            string? line;
            while ((line = rdr.ReadLine()) != null) 
            {
                var m = JsonSerializer.Deserialize<Movie>(line);
                if (m != null) movies.Add(m);
            }
        }
        public IEnumerable<Movie> Movies { get; init; }
    }
}
