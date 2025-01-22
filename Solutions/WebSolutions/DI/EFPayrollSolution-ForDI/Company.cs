namespace EFPayroll;

public class Company : Payable
{
    public Company()
    { }

    public Company(string name, string taxId)
    {
        Name = name;
        TaxId = taxId;
        Address = "";
    }

    public override string Name { get; set; } = string.Empty;
    public string TaxId { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public virtual ICollection<Payable> Resources {get;set;} = new HashSet<Payable>();
    public void Hire(Payable emp)
    {
        Resources.Add(emp);
    }
    public override double Pay() => Resources.Sum(r => r.Pay());
}
