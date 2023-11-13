// See https://aka.ms/new-console-template for more information
using System;

namespace Tutorials
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    //class Product
    //{
    //    public int ProductId { get; set; }
    //    public string? ProductName { get; set; } 
    //    public double Price { get; set; }
    //    public string? Category { get; set; }
    //}

    //class Customer
    //{
    //    public int CustomerId { get; set; }
    //    public string? Name { get; set; }
    //    public string? Email { get; set; }
    //}

    //class Order
    //{
    //    public int OrderId { get; set; }
    //    public Customer? Customer { get; set; }
    //    public List<Product> OrderedProducts { get; } = new List<Product>();
    //    public double TotalAmount { get; private set; }

    //    public void AddProduct(Product product)
    //    {
    //        OrderedProducts.Add(product);
    //    }

    //    public void CalculateTotalAmount()
    //    {
    //        TotalAmount = 0;
    //        foreach (var product in OrderedProducts)
    //        {
    //            TotalAmount += product.Price;
    //        }
    //    }

    //    public void DisplayOrderDetails()
    //    {

    //        Console.WriteLine($"Order ID: {OrderId}");
    //        if (Customer != null)
    //        {
    //            Console.WriteLine($"Customer: {Customer.Name}");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Customer: No customer assigned");
    //        }
    //        Console.WriteLine("Ordered Products:");
    //        foreach (var product in OrderedProducts)
    //        {
    //            Console.WriteLine($"{product.ProductName} - ${product.Price}");
    //        }
    //        Console.WriteLine($"Total Amount: ${TotalAmount}");
    //    }

    //    static void Main()
    //    {
    //        var order = new Order
    //        {
    //            OrderId = 1,
    //            Customer = new Customer
    //            {
    //                CustomerId = 1,
    //                Name = "John Doe",
    //                Email = "john.doe@example.com"
    //            }
    //        };

    //        order.AddProduct(new Product { ProductId = 1, ProductName = "Widget", Price = 10.0, Category = "Electronics" });
    //        order.AddProduct(new Product { ProductId = 2, ProductName = "Gadget", Price = 15.0, Category = "Electronics" });

    //        order.CalculateTotalAmount();
    //        order.DisplayOrderDetails();
    //    }
    //}



    /*Create a class Student with properties for Name and RollNumber.
    Implement a dictionary that stores student information where the RollNumber is the key and the Student object is the value.
    Write a method to add students to the dictionary and another method to retrieve a student's information by their roll number.*/

    class Student
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public double GPA { get; set; }
    }

    class StudentDatabase
    {
        private Dictionary<int, Student> _studentDictionary;

        public StudentDatabase()
        {
            _studentDictionary = new Dictionary<int, Student>();
        }

        public void AddStudent(Student student)
        {
            _studentDictionary.Add(student.RollNumber, student);
        }

        public Student GetStudentByRollNumber(int rollNumber)
        {
            if (_studentDictionary.ContainsKey(rollNumber))
            {
                return _studentDictionary[rollNumber];
            }
            return default;
        }

        public double CalculateAverageGPA()
        {
            double totalGPA = 0;
            foreach (var student in _studentDictionary.Values)
            {
                totalGPA += student.GPA;
            }
            return totalGPA / _studentDictionary.Count;
        }


        public class Exercise
        {
            
            public static void Main()
            {
                int[] array = { 1, 2, 3, 4, 5, };
                List<int> list = new List<int>();
                foreach (var item in array)
                {
                    list.Add(item);
                }
            }
        }    
    }



}
