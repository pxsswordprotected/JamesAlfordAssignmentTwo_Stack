using System;

class Program { 

        private static int[] stack = new int[100]; //og stack
        private static int stackPointer = -1;

        private static int[] processedStackElements = new int[100]; //array to store elements after processing the stack
        private static int processedStackPointer = -1;


    static void Main()
    {
        //part 1: stack operations
        ProcessStackOperations();

        //part 2: print remaining stack
        PrintRemainingStack();

        //part 3: search srray function to search for things
        SearchArray();

        //part 4: print arrays
        PrintArrays();

        Console.WriteLine("hi");
    }

    static void ProcessStackOperations()
    {
        string input;

        do
        {
            input = Console.ReadLine();
            if (input != "(stack end)")
            {
                ProcessStackOperation(input);
            }
        } while (input != "(stack end)");
    }

    static void ProcessStackOperation(string input)
    {
        if (input.StartsWith("push")) //if txt file says to push
        {
            string[] parts = input.Split(' ');

            if (parts.Length >= 2 && int.TryParse(parts[1], out int value))
            {
                if (stackPointer < stack.Length - 1)
                {
                    stack[++stackPointer] = value;
                    Console.WriteLine($"Pushed {value}");
                }
                else
                {
                    Console.WriteLine("stack ixx full");
                }
            }
            else
            {
                Console.WriteLine($"invalid format of push: {input}");
            }
        }
        else if (input.Equals("pop"))
        {
            if (stackPointer >= 0)
            {
                int poppedValue = stack[stackPointer--];
                processedStackElements[++processedStackPointer] = poppedValue;  //store the popped value in the processedStackElements array
                
                Console.WriteLine($"Popped {poppedValue}");
            }
            else
            {
                Console.WriteLine("stack is empty");
            }
        }
        else
        {
            Console.WriteLine($"Invalid input, can't process: {input}");
        }
    }

    static void PrintRemainingStack()
    {
        Console.Write("Stack after processing: ");
        for (int i = 0; i <= stackPointer; i++) //easy for loo to go through stack
        {
            Console.Write($"{stack[i]}, ");
        }
        Console.WriteLine();
    }

    static void SearchArray()
    {
        string input;
        while ((input = Console.ReadLine()) != "(find end)") //while text does not equal to the end of find 
        {
            if (input.StartsWith("find")) //if the input starts with find from txt file
            {
                if (int.TryParse(input.Split(' ')[1], out int valueToFind))
                {
                    int position = CustomLinearSearch(stack, valueToFind);
                    if (position != -1)
                    {
                        Console.WriteLine($"Searching list for item {valueToFind}, found it in array position {position}."); //following directions for format of output
                    }
                    else
                    {
                        Console.WriteLine($"Searching list for item {valueToFind}, could not find it.");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid format: {input}"); //if txt file is invalid
                }
            }
            else
            {
                Console.WriteLine($"Invalid input, can't process: {input}"); //if the txt file is invalid
            }
        }
    }
    static int CustomLinearSearch(int[] array, int value) //function to search the array used above 
    {
        for (int i = 0; i <= processedStackPointer-1; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }
        return -1;
    }

    static void PrintArrays()
    {
        Console.Write("Unsorted Array: "); //printing the unsorted array using for loop
        for (int i = 0; i <= processedStackPointer-1; i++)
        {
            Console.Write($"{stack[i]}   ");
        }
        Console.WriteLine();

        int[] newStack = new int[processedStackPointer];
        for (int i = 0; i <= processedStackPointer-1;i++)
        { 
            newStack[i] = stack[i]; 
        }

        Array.Sort(newStack); //sorting the array using function

        Console.Write("Sorted Array: "); //print the sorted array using for loop
        for (int i = 0; i <= processedStackPointer-1; i++)
        {
            Console.Write($"{newStack[i]}   ");
        }
        Console.WriteLine();
    }



}
