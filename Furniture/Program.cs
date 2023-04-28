
class Furniture
{
    public int Height { get; set; }
    public int Width { get; set; }
    public string Color { get; set; }
    public int Qty { get; set; }
    public double Price { get; set; }

    public void Accept()
    {
        Console.WriteLine("Enter furniture details:");
        Console.Write("Height: ");
        Height = Convert.ToInt32(Console.ReadLine());
        Console.Write("Width: ");
        Width = Convert.ToInt32(Console.ReadLine());
        Console.Write("Color: ");
        Color = Console.ReadLine();
        Console.Write("Quantity: ");
        Qty = Convert.ToInt32(Console.ReadLine());
        Console.Write("Price: ");
        Price = Convert.ToInt32(Console.ReadLine());
    }

    public void Show()
    {
        Console.WriteLine("Furniture details:");
        Console.WriteLine("Height: {0}", Height);
        Console.WriteLine("Width: {0}", Width);
        Console.WriteLine("Color: {0}", Color);
        Console.WriteLine("Quantity: {0}", Qty);
        Console.WriteLine("Price: {0}", Price);
    }
}

class BookShelf : Furniture
{
    public int NoOfShelves { get; set; }

    public new void Accept()
    {
        base.Accept();
        Console.Write("Number of shelves: ");
        NoOfShelves = Convert.ToInt32(Console.ReadLine());
    }
    public new void Show()
    {
        base.Show();
        Console.WriteLine("Number of shelves: {0}", NoOfShelves);
    }
}

class DiningTable : Furniture
{
    public int NoOfLegs { get; set; }

    public new void Accept()
    {
        base.Accept();
        Console.Write("Number of legs: ");
        NoOfLegs = Convert.ToInt32(Console.ReadLine());
    }

    public new void Show()
    {
        base.Show();
        Console.WriteLine("Number of legs: {0}", NoOfLegs);
    }
}
class Program
{
    static int AddToStock(Furniture[] stock)
    {
        Console.WriteLine("Enter furniture details for 5 items:");

        for (int i = 0; i < stock.Length; i++)
        {
            Console.WriteLine("Item {0}:", i + 1);

            while (true)
            {
                Console.Write("BookShelf or DiningTable (B/D): ");
                string type = Console.ReadLine();

                if (type == "B")
                {
                    stock[i] = new BookShelf();
                    break;
                }
                else if (type == "D")
                {
                    stock[i] = new DiningTable();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid type. Please try again.");
                }
            }
            stock[i].Accept();
        }
        return stock.Length;
    }

    static double TotalStockValue(Furniture[] stock)
    {
        double total = 0;

        foreach (Furniture item in stock)
        {
            total = item.Price * item.Qty;
        }
        return total;
    }

    static void ShowStockDetails(Furniture[] stock)
    {
        foreach (Furniture item in stock)
        {
            item.Show();
            Console.WriteLine();
        }
    }
static void Main(string[] args)
{
    Furniture[] stock = new Furniture[5];
    int count = AddToStock(stock);
    Console.WriteLine("\nAccepted {0} items.\n", count);
    ShowStockDetails(stock);
    double totalValue = TotalStockValue(stock);
    Console.WriteLine("\nTotalCost of Accepted Stock: {0}Rs", totalValue);
}
}
