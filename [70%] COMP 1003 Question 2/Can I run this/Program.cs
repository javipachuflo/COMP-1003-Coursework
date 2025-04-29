namespace Can_I_run_this
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // (i)
            Dictionary<string, int> employees = new Dictionary<string, int>();

            // (ii)
            employees.Add("Homer", 20000);
            employees.Add("Monty", 500000);

            // (iii)
            employees.Remove("Homer");

            // (iv)
            if (employees.TryGetValue("Carl", out int Carl_pay))
            {
                employees["Carl"] = Carl_pay - 1000;
            }
            else
            {
                employees.Add("Carl", -1000);
            }

            // (v)
            foreach (var key in employees.Keys)
            {
                employees[key] = (int)(employees[key] * 1.01);
                Console.WriteLine(employees[key]);

            }

        }
    }
}
