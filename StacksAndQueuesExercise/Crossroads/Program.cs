namespace Crossroads;

class Program
{
    static void Main(string[] args)
    {
                int greenLightDuration = int.Parse(Console.ReadLine());
        int freeWindowDuration = int.Parse(Console.ReadLine());

        Queue<string> carsQueue = new Queue<string>();
        int totalCarsPassed = 0;

        string input;
        bool crashHappened = false;

        while ((input = Console.ReadLine()) != "END")
        {
            if (input == "green")
            {
                int currentGreen = greenLightDuration;

                while (carsQueue.Count > 0 && currentGreen > 0)
                {
                    string currentCar = carsQueue.Peek();
                    int carLength = currentCar.Length;

                    if (carLength <= currentGreen)
                    {

                        currentGreen -= carLength;
                        carsQueue.Dequeue();
                        totalCarsPassed++;
                    }
                    else
                    {
                        int remainingTime = currentGreen + freeWindowDuration;

                        if (carLength <= remainingTime)
                        {
                            carsQueue.Dequeue();
                            totalCarsPassed++;
                            currentGreen = 0; 
                        }
                        else
                        {
                            int hitIndex = remainingTime;
                            char hitChar = currentCar[hitIndex];

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {hitChar}.");
                            crashHappened = true;
                            break;
                        }
                    }
                }

                if (crashHappened)
                    break;
            }
            else
            {
                carsQueue.Enqueue(input);
            }
        }

        if (!crashHappened)
        {
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}