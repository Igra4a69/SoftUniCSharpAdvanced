namespace ParkingLot;

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> carsInParking = new HashSet<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }

            string[] parts = input.Split(", ");
            string direction = parts[0];
            string carNumber = parts[1];

            if (direction == "IN")
            {
                carsInParking.Add(carNumber);
            }
            else if (direction == "OUT")
            {
                carsInParking.Remove(carNumber);
            }
        }

        if (carsInParking.Count == 0)
        {
            Console.WriteLine("Parking Lot is Empty");
        }
        else
        {
            foreach (string car in carsInParking)
            {
                Console.WriteLine(car);
            }
        }
    }
}