using ExercicioEnumCompo.Entities;
using ExercicioEnumCompo.Entities.Enums;
using System.Globalization;
using System;

namespace ExercicioEnumCompo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name:");
            string clientName = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status:");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, email, birthDate); // Instanciei a classe Client
            Order order = new Order(DateTime.Now, status, client); // Instanciei a classe Order e passei client(classe Client) nos parametros

            Console.WriteLine("How many items to this order?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter {i} item data:");
                Console.WriteLine("Product name:");
                string productName = Console.ReadLine();
                Console.WriteLine("Product price:");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price); // Instanciei a classe Product

                Console.WriteLine("Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product); // Instanciei a classe OrderItem e instanciei por parâmetro a classe Product com o parâmetro product
                order.AddItem(orderItem); // Adicionei itens da classe OrderItem(orderItem) no pedido (order)

            }

            Console.WriteLine("ORDER SUMMARY:");
            Console.Write("Order moment:");
            Console.WriteLine(order);


        }
    }
}
