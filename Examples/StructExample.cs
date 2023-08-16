
namespace Examples
{
    public struct Status
    {
        public int Code;
        public string Message;
    }


    public class StructExample
    {
        public static void Func(Status status)
        {
            status.Code = 400;
        }
public static void SE()
{
    Status status = new Status();
    status.Code = 200;
    status.Message = "OK";
    Func(status);

    System.Console.WriteLine("Status Code: {0}", status.Code);
    System.Console.WriteLine("Status Message: {0}", status.Message);
}
    }
}