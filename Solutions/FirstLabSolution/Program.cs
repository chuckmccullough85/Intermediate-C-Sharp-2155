
Employee e = new("Hank", "Hill", 200, DateTime.Today);

e.Pay();
e.Pay();

Console.WriteLine("{0} has made {1:c} so far this year",
    e.FirstName, e.YtdGrossPay);




