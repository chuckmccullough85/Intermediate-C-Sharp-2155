
namespace EFPayroll;

public abstract class Payable
{
    public int Id { get; set; }
    public virtual string Name { get; set;} = "No Name";
    public abstract double Pay();
}
