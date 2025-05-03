using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

class ProductManager
{
    class Product
    {
        public UInt32 ProductNumber { get; set; }
        public double? ProductPrice { get; set; }
        public string? ProductName { get; set; }
        public int? ProductAmount { get; set; }


    }
    static List<Product> list = new List<Product>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Product Manager");
            Console.WriteLine("1. Stock Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Test Product Purchase");
            Console.WriteLine("4. View Product");
            Console.WriteLine("5. Exit");
            Console.WriteLine("What would you like to do? (select 1-5)");

            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    StockProduct();
                    break;
                case "2":
                    RemoveProduct();
                    break;
                case "3":
                    PurchaseProduct();
                    break;
                case "4":
                    ViewProduct();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please select an option 1-5.");
                    break;
            }

        }
    }

    static void StockProduct()
    {
        System.Console.WriteLine("Input Product Number");
        UInt32 productNumber = Convert.ToUInt32(Console.ReadLine());
        bool productExists = CheckIfProductExists(productNumber);
        if (productExists)
        {
            Console.WriteLine("How much would you like to restock");
            int restockAmount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                list[i].ProductAmount = list[i].ProductAmount + restockAmount;
            }
            return;
        }
        Console.WriteLine("Input product name: ");
        string? newName = Console.ReadLine();

        Console.WriteLine("Input product price: ");
        string? newPrice = Console.ReadLine();

        Console.WriteLine("Input product amount: ");
        string? newAmount = Console.ReadLine();

        if (string.IsNullOrEmpty(newName))
        {
            Console.WriteLine("Product cant be empty.");
            return;
        }
        if (string.IsNullOrEmpty(newPrice))
        {
            Console.WriteLine("Price cannot be empty.");
            return;
        }
        if (string.IsNullOrEmpty(newAmount))
        {
            Console.WriteLine("Please input a correct amount.");
            return;
        }
        else
        {
            Product newPro = new Product();
            newPro.ProductNumber = productNumber;
            newPro.ProductName = newName;
            newPro.ProductPrice = Convert.ToDouble(newPrice);
            newPro.ProductAmount = Convert.ToInt32(newAmount);

            list.Add(newPro);
            Console.WriteLine("Product successfully added.");
        }
    }

    static bool CheckIfProductExists(UInt32 productNumber)
    {
        bool productExists = false;
        for (int i = 0; i <= list.Count - 1; i++)
        {
            if (list[i].ProductNumber == productNumber)
            {
                productExists = true;
                break;
            }
        }
        return productExists;
    }

    static void RemoveProduct()
    {

        if (list.Count == 0)
        {
            Console.WriteLine("No product available to remove.");
            return;
        }
        else
        {
            Console.WriteLine("Here are your products.");
            for (int i = 0; i < list.Count; i++)

            {
                string prod = $"[{i}]{list[i].ProductName}";
                Console.WriteLine(prod);
            }
        }
        Console.WriteLine("Which product would you like to remove?:");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int remove))
        {
            Console.WriteLine("Invalid input. Please enter a valid product number.");
            return;
        }
        {
            if (remove > list.Count)
            {
                Console.WriteLine("Please enter a valid product number");
                return;
            }
            else
            {
                list.RemoveAt(remove);
            }
        }

    }

    static void PurchaseProduct()
    {
        if (list.Count == 0)
        {
            Console.WriteLine("No products available to purchase.");
            return;
        }
        else
        {
            Console.WriteLine("Here are your products.");
            for (int i = 0; i < list.Count; i++)
            {
                string prod = $"{list[i].ProductNumber}...{list[i].ProductName}...Price: ${list[i].ProductPrice}...Amount: {list[i].ProductAmount}";
                Console.WriteLine(prod);
            }
        }
        Console.WriteLine("Which product would you like to purchase?");
        UInt32 productNumber = Convert.ToUInt32(Console.ReadLine());
        if (productNumber <= 0)
        {
            Console.WriteLine("Invalid purchase.");
            return;
        }

        bool productExists = CheckIfProductExists(productNumber);
        if (productExists == false)
        {
            Console.WriteLine("Sorry that product doesnt exist");
            return;
        }
        Console.WriteLine("How many would you like to purchase?");
        int itemAmount = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i <= list.Count - 1; i++)
            if (list[i].ProductNumber == productNumber && list[i].ProductAmount >= itemAmount)
            {
                list[i].ProductAmount = list[i].ProductAmount - itemAmount;
                Console.WriteLine("Product successfully purchased");
                return;
            }
            else
            {
                Console.WriteLine("There is not enough product");
            }
    }

    static void ViewProduct()
    {
        if (list.Count == 0)
        {
            Console.WriteLine("You have no products.");
        }
        else
        {
            Console.WriteLine("Products: ");
            for (int i = 0; i < list.Count; i++)
            {
                string prod = $"{list[i].ProductNumber}...{list[i].ProductName}...Price: ${list[i].ProductPrice}...Amount: {list[i].ProductAmount}";
                Console.WriteLine(prod);
            }
        }
    }
}