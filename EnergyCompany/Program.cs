using EnergyCompany.Controllers;
using EnergyCompany.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyCompany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEndpointService service = new EndpointService();
            EndpointController controller = new EndpointController(service);

            bool showOptions = true;

            while (showOptions)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("--  Endpoint Manager  --");
                Console.WriteLine("------------------------");
                Console.WriteLine("1- Insert a new endpoint");
                Console.WriteLine("2- Edit an existing endpoint");
                Console.WriteLine("3- Delete an existing endpoint");
                Console.WriteLine("4- List all endpoints");
                Console.WriteLine("5- Find an endpoint by Serial Number");
                Console.WriteLine("6- Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        controller.InsertEndpoint();
                        break;
                    case "2":
                        controller.EditEndpoint();
                        break;
                    case "3":
                        controller.DeleteEndpoint();
                        break;
                    case "4":
                        controller.ListAllEndpoints();
                        break;
                    case "5":
                        controller.FindEndpoint();
                        break;
                    case "6":
                        Console.WriteLine("Are you sure you want to exit? (y/n)");
                        string confirm = Console.ReadLine();
                        if (confirm.ToLower().First() == 'y')
                            showOptions = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.\n");
                        break;
                }
            }
        }
    }
}
