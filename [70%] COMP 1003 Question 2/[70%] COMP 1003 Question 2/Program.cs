namespace _70___COMP_1003_Question_2;

class Program
{
    static void Main(string[] args)
    {
        // (i)
        Map<string, int> employees = new Map<string, int>();

        // (ii)
        employees.Add("Homer", 20000);
        employees.Add("Monty", 500000);

        // (iii)
        employees.Remove("Homer");

        // (iv)
        int Carl_pay = employees.Get("Carl");
        employees.Add("Carl", Carl_pay - 1000);

        employees["Carl"] = employees["Carl"] - 1000;

        // (v)

    }
}
