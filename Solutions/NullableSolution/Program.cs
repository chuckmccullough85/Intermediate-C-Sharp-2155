
using Deconstructor;

Employee e = new("Hank", "Hill", 200, DateTime.Today);
e.MiddleName = "Rutherford";
ShowEmp(e);

e.Pay();
e.Pay();

var (n, s, y) = e;
Console.WriteLine($"{n}'s salary is {s:c} and has made {y:c} so far");

var (f, l, _, _, hired) = e;
Console.WriteLine($"{f} {l} was hired on {hired}");



void ShowEmp (Employee? e)
{
    string m1 = e?.MiddleName ?? "";
    string m2 = e?.MiddleName is null ? "" : e.MiddleName;
    string m3 = e?.MiddleName!;
}   

