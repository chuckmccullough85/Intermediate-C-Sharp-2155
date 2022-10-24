
using LinqApi;

Console.WriteLine("Welcom to the Movie Database");

var mdb = new MovieDb();
//var m = mdb.Movies.Where(m => m.Cast.Contains("Anthony Hopkins"));
var q = from m in mdb.Movies
        select m;
Console.WriteLine(q.First().Title);
foreach (var c in q.First().Cast)
    Console.WriteLine($"\t{c}");

//m = mdb.Movies.Where(m => m.Cast.Contains("Anthony Hopkins")).OrderBy(m => m.Year);
q = from m in mdb.Movies
    where m.Cast.Contains("Anthony Hopkins")
    orderby m.Year
    select m;

Console.WriteLine($"First movie in {q.First().Year} was {q.First().Title} starring:");
foreach(var c in q.First().Cast) Console.WriteLine($"\t{c}");

Console.WriteLine($"Last movie in {q.Last().Year} was {q.Last().Title} starring:");
foreach (var c in q.Last().Cast) Console.WriteLine($"\t{c}");

//var jnj = mdb.Movies
//    .Where(m => m.Cast.Contains("John Wayne") && m.Cast.Contains("James Stewart"))
//    .OrderBy(m => m.Year)
//    .Select(m => (m.Year, m.Title));
var jnj = from m in mdb.Movies
          where m.Cast.Contains("John Wayne") && m.Cast.Contains("James Stewart")
          orderby m.Year
          select new { Year = m.Year, Title = m.Title };

Console.WriteLine("Movies with Stewart & Wayne");
foreach (var t in jnj) Console.WriteLine($"{t.Year} {t.Title}");

Console.WriteLine("G movies");
//var gmov = mdb.Movies.Where (m=>m.Rated == "G")
//    .OrderBy(m=>(m.Year, m.Title))
//    .Select(m=> (m.Year, m.Title, star: m.Cast.FirstOrDefault()));
var gmov = from m in mdb.Movies
           where m.Rated == "G"
           orderby (m.Year, m.Title)
           select new {Year = m.Year, Title = m.Title, Star = m.Cast.FirstOrDefault() };
foreach(var t in gmov) Console.WriteLine($"{t.Year} {t.Title} \t starring {t.Star}");
    
