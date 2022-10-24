
using LinqApi;

Console.WriteLine("Welcom to the Movie Database");

var mdb = new MovieDb();

Console.WriteLine($"Our movie database has {mdb.Movies.Count()} movies");
