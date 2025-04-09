using System;

namespace LAB10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab Assignment 10 - C# Console Applications");

            // Menu to select different activities
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nSelect an activity to run:");
                Console.WriteLine("1. Basic Calculator (Activity 2)");
                Console.WriteLine("2. Loops and Functions (Activity 3)");
                Console.WriteLine("3. Student Management (Activity 4)");
                Console.WriteLine("4. Exception Handling Calculator (Activity 5)");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BasicCalculator.Run();
                        break;
                    case "2":
                        LoopsAndFunctions.Run();
                        break;
                    case "3":
                        StudentManagement.Run();
                        break;
                    case "4":
                        ExceptionHandlingCalculator.Run();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    // Activity 2: Basic Calculator
    class BasicCalculator
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Basic Calculator ---");

            // User input for two numbers
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // Perform arithmetic operations
            double sum = num1 + num2;
            double difference = num1 - num2;
            double product = num1 * num2;
            double quotient = num1 / num2;

            // Display results
            Console.WriteLine($"Addition: {num1} + {num2} = {sum}");
            Console.WriteLine($"Subtraction: {num1} - {num2} = {difference}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {product}");
            Console.WriteLine($"Division: {num1} / {num2} = {quotient}");

            // Check if sum is even or odd
            if (sum % 2 == 0)
                Console.WriteLine($"The sum ({sum}) is even.");
            else
                Console.WriteLine($"The sum ({sum}) is odd.");
        }
    }

    // Activity 3: Loops and Functions
    class LoopsAndFunctions
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Loops and Functions ---");

            // For loop to print numbers 1 to 10
            Console.WriteLine("Numbers from 1 to 10:");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            // While loop for user input
            string userInput = "";
            Console.WriteLine("\nEnter text (type 'exit' to quit):");
            while (userInput.ToLower() != "exit")
            {
                userInput = Console.ReadLine();
                if (userInput.ToLower() != "exit")
                    Console.WriteLine($"You entered: {userInput}");
            }

            // Factorial function
            Console.Write("\nEnter a number to calculate its factorial: ");
            int number = Convert.ToInt32(Console.ReadLine());
            long factorial = CalculateFactorial(number);
            Console.WriteLine($"Factorial of {number} is: {factorial}");
        }

        // Function to calculate factorial
        private static long CalculateFactorial(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * CalculateFactorial(n - 1);
        }
    }

    // Activity 4: Object-Oriented Programming
    class StudentManagement
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Student Management ---");

            // Create a Student object
            Console.WriteLine("\nCreating a regular student:");
            Student student = new Student("Vamsi", "hfgvjbk", 85);
            DisplayStudentDetails(student);

            // Create a StudentIITGN object
            Console.WriteLine("\nCreating an IITGN student:");
            StudentIITGN iitgnStudent = new StudentIITGN("sriram", "gvbnm", 92, "Hostel E");
            DisplayIITGNStudentDetails(iitgnStudent);
        }

        private static void DisplayStudentDetails(Student student)
        {
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"ID: {student.ID}");
            Console.WriteLine($"Marks: {student.Marks}");
            Console.WriteLine($"Grade: {student.GetGrade()}");
        }

        private static void DisplayIITGNStudentDetails(StudentIITGN student)
        {
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"ID: {student.ID}");
            Console.WriteLine($"Marks: {student.Marks}");
            Console.WriteLine($"Grade: {student.GetGrade()}");
            Console.WriteLine($"Hostel: {student.Hostel_Name_IITGN}");
        }
    }

    // Student class
    class Student
    {
        // Properties
        public string Name { get; set; }
        public string ID { get; set; }
        public int Marks { get; set; }

        // Constructor
        public Student(string name, string id, int marks)
        {
            Name = name;
            ID = id;
            Marks = marks;
        }

        // Method to get grade
        public string GetGrade()
        {
            if (Marks >= 90)
                return "A";
            else if (Marks >= 80)
                return "B";
            else if (Marks >= 70)
                return "C";
            else if (Marks >= 60)
                return "D";
            else
                return "F";
        }
    }

    // StudentIITGN subclass
    class StudentIITGN : Student
    {
        // Additional property
        public string Hostel_Name_IITGN { get; set; }

        // Constructor
        public StudentIITGN(string name, string id, int marks, string hostelName)
            : base(name, id, marks)
        {
            Hostel_Name_IITGN = hostelName;
        }
    }

    // Activity 5: Exception Handling
    class ExceptionHandlingCalculator
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Exception Handling Calculator ---");

            try
            {
                // User input for two numbers
                Console.Write("Enter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                // Perform arithmetic operations with exception handling
                double sum = num1 + num2;
                double difference = num1 - num2;
                double product = num1 * num2;

                // Division with exception handling
                double quotient;
                try
                {
                    // Check for division by zero
                    if (num2 == 0)
                        throw new DivideByZeroException();

                    quotient = num1 / num2;
                    Console.WriteLine($"Division: {num1} / {num2} = {quotient}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Cannot divide by zero!");
                }

                // Display results
                Console.WriteLine($"Addition: {num1} + {num2} = {sum}");
                Console.WriteLine($"Subtraction: {num1} - {num2} = {difference}");
                Console.WriteLine($"Multiplication: {num1} * {num2} = {product}");

                // Check if sum is even or odd
                if (sum % 2 == 0)
                    Console.WriteLine($"The sum ({sum}) is even.");
                else
                    Console.WriteLine($"The sum ({sum}) is odd.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
