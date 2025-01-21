namespace TaskTwo;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        var continueLoop = true;

        do
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("----------------Main Menu----------------");
            Console.WriteLine("P - Print Numbers");
            Console.WriteLine("A - Add a Number");
            Console.WriteLine("M - Display the mean of the number");
            Console.WriteLine("N - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("S - Sort the list");
            Console.WriteLine("F - Find a number");
            Console.WriteLine("C - Clear the whole list");
            Console.WriteLine("Q - Quit");

            Console.Write("Please enter your choice: ");
            var choice = Convert.ToChar(Console.ReadLine());

            var lowerCaseChoice = char.ToLower(choice);

            switch (lowerCaseChoice)
            {
                case 'p':
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else
                    {
                        Console.Write("[ ");
                        for (var i = 0; i < numbers.Count; i++)
                        {
                            Console.Write($"{numbers[i]} ");
                        }

                        Console.WriteLine("]");
                    }

                    break;
                case 'a':
                    Console.Write("Please enter the number: ");
                    var number = Convert.ToInt32(Console.ReadLine());
                    var isNumberAlreadyInTheList = false;

                    for (var i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == number)
                        {
                            isNumberAlreadyInTheList = true;
                            break;
                        }
                    }

                    if (isNumberAlreadyInTheList)
                    {
                        Console.WriteLine($"{number} already exists in the list!");
                    }
                    else
                    {
                        numbers.Add(number);
                        Console.WriteLine($"{number} was added successfully!");
                    }

                    break;
                case 'm':
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else
                    {
                        var sum = 0;

                        for (var i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }

                        var avg = sum / numbers.Count;

                        Console.WriteLine($"Mean: {avg}");
                    }

                    break;
                case 'n':
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else
                    {
                        var smallestNumber = numbers[0];

                        for (var i = 1; i < numbers.Count; i++)
                        {
                            if (numbers[i] < smallestNumber)
                            {
                                smallestNumber = numbers[i];
                            }
                        }

                        Console.WriteLine($"Smallest Number: {smallestNumber}");
                    }

                    break;
                case 'l':
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else
                    {
                        var largestNumber = numbers[0];

                        for (var i = 1; i < numbers.Count; i++)
                        {
                            if (numbers[i] > largestNumber)
                            {
                                largestNumber = numbers[i];
                            }
                        }

                        Console.WriteLine($"Largest Number: {largestNumber}");
                    }

                    break;
                case 's':
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else if (numbers.Count == 1)
                    {
                        Console.WriteLine("The list has one number only!");
                    }
                    else
                    {
                        Console.WriteLine("How do you want to sort the list?");
                        Console.WriteLine("A - Ascending");
                        Console.WriteLine("D - Descending");

                        Console.Write("Please enter your choice: ");
                        var sortingChoice = Convert.ToChar(Console.ReadLine());
                        var lowerCaseSortingChoice = char.ToLower(sortingChoice);

                        switch (lowerCaseSortingChoice)
                        {
                            case 'a':
                                bool swapped;

                                do
                                {
                                    swapped = false;
                                    for (int i = 0; i < numbers.Count - 1; i++)
                                    {
                                        if (numbers[i] > numbers[i + 1])
                                        {
                                            // Swap elements
                                            int temp = numbers[i];
                                            numbers[i] = numbers[i + 1];
                                            numbers[i + 1] = temp;
                                            swapped = true;
                                        }
                                    }
                                } while (swapped);

                                Console.WriteLine("The list is sorted!");

                                Console.Write("[ ");
                                for (var i = 0; i < numbers.Count; i++)
                                {
                                    Console.Write($"{numbers[i]} ");
                                }

                                Console.WriteLine("]");

                                break;
                            case 'd':
                                bool descendingSortSwapped;

                                do
                                {
                                    descendingSortSwapped = false;
                                    for (int i = 0; i < numbers.Count - 1; i++)
                                    {
                                        if (numbers[i] < numbers[i + 1])
                                        {
                                            // Swap elements
                                            int temp = numbers[i];
                                            numbers[i] = numbers[i + 1];
                                            numbers[i + 1] = temp;
                                            descendingSortSwapped = true;
                                        }
                                    }
                                } while (descendingSortSwapped);

                                Console.WriteLine("The list is sorted!");

                                Console.Write("[ ");
                                for (var i = 0; i < numbers.Count; i++)
                                {
                                    Console.Write($"{numbers[i]} ");
                                }

                                Console.WriteLine("]");

                                break;
                            default:
                                Console.WriteLine("Invalid Choice!");
                                break;
                        }
                    }

                    break;
                case 'f':
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else
                    {
                        Console.Write("Please enter the number: ");
                        var numberToFind = Convert.ToInt32(Console.ReadLine());
                        var numberIndex = -1;

                        for (var i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] == numberToFind)
                            {
                                numberIndex = i;
                                break;
                            }
                        }

                        if (numberIndex == -1)
                        {
                            Console.WriteLine($"{numberToFind} is not in the list!");
                        }
                        else
                        {
                            Console.WriteLine($"{numberToFind} is in the list at position {numberIndex + 1}");
                        }
                    }

                    break;
                case 'c':
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else
                    {
                        numbers.Clear();
                        Console.WriteLine("The list was cleared successfully!");
                    }

                    break;
                case 'q':
                    Console.WriteLine("Thank you for using the program!");
                    Console.WriteLine("Have a nice day!");
                    continueLoop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        } while (continueLoop);
    }
}