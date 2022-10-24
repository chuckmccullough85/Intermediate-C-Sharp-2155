
using Deconstructor;

Employee e = new("Hank", "Hill", 200, DateTime.Today);

e.Pay();
e.Pay();

var (n, s, y) = e;
Console.WriteLine($"{n}'s salary is {s:c} and has made {y:c} so far");

var (f, l, _, _, hired) = e;
Console.WriteLine($"{f} {l} was hired on {hired}");





