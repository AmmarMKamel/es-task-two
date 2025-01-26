namespace UsingMethods;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        var continueLoop = true;

        do
        {
            DisplayMenu();

            var choice = ReadUserChoice();

            switch (choice)
            {
                case 'p':
                    PrintList(numbers);
                    break;
                case 'a':
                    Console.Write("Please enter the number: ");
                    var number = Convert.ToInt32(Console.ReadLine());
                    var isNumberAlreadyInTheList = CheckIfNumberIsInTheList(numbers, number);

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
                    var avg = ListAverage(numbers);

                    if (avg != null)
                        Console.WriteLine($"Mean: {avg}");
                    break;
                case 'n':
                    var smallestNumber = GetSmallestNumber(numbers);

                    if (smallestNumber != null)
                        Console.WriteLine($"Smallest Number: {smallestNumber}");

                    break;
                case 'l':
                    var largestNumber = GetLargestNumber(numbers);

                    if (largestNumber != null)
                        Console.WriteLine($"Largest Number: {largestNumber}");

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
                        var lowerCaseSortingChoice = GetSortingChoice();

                        var hasBeenSorted = SortList(numbers, lowerCaseSortingChoice);

                        if (!hasBeenSorted)
                        {
                            Console.WriteLine("Invalid Choice!");
                        }
                        else
                        {
                            Console.WriteLine("The list is sorted!");
                            PrintList(numbers);
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
                        var numberIndex = FindNumber(numbers, numberToFind);

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

    private static int FindNumber(List<int> numbers, int numberToFind)
    {
        var numberIndex = -1;

        for (var i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == numberToFind)
            {
                numberIndex = i;
                break;
            }
        }

        return numberIndex;
    }

    private static bool SortList(List<int> numbers, char sortingChoice)
    {
        bool swapped;

        if (sortingChoice == 'a')
        {
            do
            {
                swapped = false;
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            return true;
        }

        if (sortingChoice == 'd')
        {
            do
            {
                swapped = false;
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] < numbers[i + 1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            return true;
        }

        Console.WriteLine("Invalid Choice");
        return false;
    }

    private static char GetSortingChoice()
    {
        Console.WriteLine("How do you want to sort the list?");
        Console.WriteLine("A - Ascending");
        Console.WriteLine("D - Descending");

        Console.Write("Please enter your choice: ");
        var sortingChoice = Convert.ToChar(Console.ReadLine());
        var lowerCaseSortingChoice = char.ToLower(sortingChoice);
        return lowerCaseSortingChoice;
    }

    private static int? GetLargestNumber(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("The list is empty!");
            return null;
        }

        var largestNumber = numbers[0];

        for (var i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > largestNumber)
            {
                largestNumber = numbers[i];
            }
        }

        return largestNumber;
    }

    private static int? GetSmallestNumber(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("The list is empty!");
            return null;
        }

        var smallestNumber = numbers[0];

        for (var i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] < smallestNumber)
            {
                smallestNumber = numbers[i];
            }
        }

        return smallestNumber;
    }

    private static double? ListAverage(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("The list is empty!");
            return null;
        }

        var sum = 0;

        for (var i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }

        var avg = sum / numbers.Count;
        return avg;
    }

    private static bool CheckIfNumberIsInTheList(List<int> numbers, int number)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == number)
            {
                return true;
            }
        }

        return false;
    }

    private static void PrintList(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("The list is empty!");
            return;
        }

        Console.Write("[ ");
        for (var i = 0; i < numbers.Count; i++)
        {
            Console.Write($"{numbers[i]} ");
        }

        Console.WriteLine("]");
    }

    private static char ReadUserChoice()
    {
        Console.Write("Please enter your choice: ");
        var choice = Convert.ToChar(Console.ReadLine());

        var lowerCaseChoice = char.ToLower(choice);
        return lowerCaseChoice;
    }

    private static void DisplayMenu()
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
    }
}