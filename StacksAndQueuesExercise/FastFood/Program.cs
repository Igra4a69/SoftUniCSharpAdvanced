namespace FastFood;

class Program
{
    static void Main(string[] args)
    {
        int foodQuantity = int.Parse(Console.ReadLine());
        Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

        int maxOrder = orders.Count > 0 ? orders.Max() : 0;
        Console.WriteLine(maxOrder);

        while (orders.Count > 0)
        {
            int currentOrder = orders.Peek();

            if (foodQuantity >= currentOrder)
            {
                foodQuantity -= currentOrder;
                orders.Dequeue();
            }
            else
            {
                break;
            }
        }

        if (orders.Count == 0)
        {
            Console.WriteLine("Orders complete");
        }
        else
        {
            Console.Write("Orders left: ");
            Console.WriteLine(string.Join(" ", orders));
        }
    }
}