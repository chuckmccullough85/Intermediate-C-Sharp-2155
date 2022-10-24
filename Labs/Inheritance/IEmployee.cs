namespace EFPayroll
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        DateTime HireDate { get; init; }
        string LastName { get; set; }
        Employee.LocalTaxFunc? LocalTaxMethod { get; set; }
        double Salary { get; set; }
        int Tenure { get; }
        double YtdGrossPay { get; }

        event Employee.NotifyPay OnPay;

        double Pay();
    }
}