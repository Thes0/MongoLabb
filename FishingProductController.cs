using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MONGOLABB3.DAO;
using MONGOLABB3.UI;


namespace MONGOLABB3
{
    internal class FishingProductController
    {
        IUI io;
        IProduct pDAO;

        public FishingProductController(IUI io, IProduct pDAO)
        {
            this.io = io;
            this.pDAO = pDAO;
        }
        public void start()
        {
            int i = 1;
            bool menu = true;
            while (menu)
            {

                io.Print("HEJ OCH VÄLKOMMEN TILL BASSES FISKE SHOP! \n 1. Create new item \n 2. View all \n 3. Update \n 4. Delete \n 5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //create
                        io.Clear();
                        FishingProductModel product = new FishingProductModel();
                        io.Print("Skriv namn på vad du vill lägga till");
                        product.Name = io.GetInput();
                        io.Print("Vad kostar produkten?");
                        product.Price = decimal.Parse(io.GetInput());
                        io.Print("Hur många finns de i lager?");
                        product.Inventory = int.Parse(io.GetInput());
                        io.Print("Beskriv produkten");
                        product.Description = io.GetInput();
                        pDAO.Create(product);
                    break;
                        
                    case "2":
                        //View
                        io.Clear();
                        foreach (var prod in pDAO.ReadAll())
                        {
                            io.Print($"Name: {prod.Name}\n Description: {prod.Description}\n Price: {prod.Price.ToString()}\n Inventory: {prod.Inventory.ToString()}");
                        }
                    break;

                    case "3":
                        i = 1;
                        io.Clear();
                        foreach (var prod in pDAO.ReadAll())
                        {
                            io.Print($"{i}Name: {prod.Name}\n Description: {prod.Description}\n Price: {prod.Price.ToString()}\n Inventory: {prod.Inventory.ToString()}");
                            i++;
                        }
                        int val = int.Parse(io.GetInput());
                        FishingProductModel godis = pDAO.ReadAll()[val-1];
                        
                        FishingProductModel updatedproduct = new FishingProductModel();
                        io.Print("Skriv nytt namn");
                        updatedproduct.Name = io.GetInput();
                        io.Print("Skriv nya priset");
                        updatedproduct.Price = decimal.Parse(io.GetInput());
                        io.Print("Hur många i lager?");
                        updatedproduct.Inventory = int.Parse(io.GetInput());
                        io.Print("Beskriv produkten");
                        updatedproduct.Description = io.GetInput();
                        pDAO.Update(godis, updatedproduct);
                        break;

                    case "4":
                        i = 1;
                        io.Clear();
                        foreach (var prod in pDAO.ReadAll())
                        {
                            io.Print($"{i}Name: {prod.Name}\n Description: {prod.Description}\n Price: {prod.Price.ToString()}\n Inventory: {prod.Inventory.ToString()}");
                            i++;
                        }
                        int v = int.Parse(io.GetInput());
                        FishingProductModel delete = pDAO.ReadAll()[v - 1];
                        pDAO.Delete(delete);
                        break;
                    case "5":
                        Environment.Exit(0);
                    break;                    
                }
            }
        }
    }
}
