using FirstLab;

Console.WriteLine("First lab");

Employee emp = new("Hank", "Hill", 200, DateTime.Parse("2005-10-1"));

var net = emp.Pay();


Console.WriteLine(emp);

emp.Pay();
emp.Pay();

Console.WriteLine(emp.ToString());

