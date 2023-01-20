using System;

class Program
{
    public static void Main(string[] args)
    {

        StockItem Milk = new StockItem("1 Gallon of Milk", 3.60F, 15);
        StockItem Bread = new StockItem("1 Loaf of Bread", 1.98F, 30);

        while (true)
        {
            UserMenu(Milk, Bread);
            Console.WriteLine("\n");
        }
    }

    public static void UserMenu(StockItem Milk, StockItem Bread)
    {
        Console.WriteLine("1. Sold One Milk\n2. Sold One Bread\n3. Change price of Milk\n4. Change price of Bread\n5. Add Milk to Inventory\n6. Add Bread to Inventory\n7. See Inventory\n8. Quit");
        int choice = Convert.ToInt16(Console.ReadLine());
        switch (choice)
        {
            default:
                System.Environment.Exit(1);
                break;
            case 1:
                if (Milk.getStock() == 0)
                    Console.WriteLine("None to sell!");
                else
                {
                    Milk.lowerStock();
                    Console.WriteLine("Sold a Milk, there is " + (Milk.getStock()).ToString() + " left");
                }
                break;
            case 2:
                if (Bread.getStock() == 0)
                    Console.WriteLine("None to sell!");
                else
                {
                    Bread.lowerStock();
                    Console.WriteLine("Sold a Bread, there is " + (Bread.getStock()).ToString() + " left");
                }
                break;
            case 3:
                Console.WriteLine("New Price?");
                float a = (float)Convert.ToDouble(Console.ReadLine());
                if (a < 0)
                {
                    Console.WriteLine("Invalad Price");
                    break;
                }
                Milk.setPrice(a);
                Console.WriteLine("New price of milk is " + Milk.getPrice().ToString());
                break;
            case 4:
                Console.WriteLine("New Price?");
                a = (float)Convert.ToDouble(Console.ReadLine());
                if (a < 0)
                {
                    Console.WriteLine("Invalad Price");
                    break;
                }
                Bread.setPrice(a);
                Console.WriteLine("New price of bread is " + Bread.getPrice().ToString());
                break;
            case 5:
                Console.WriteLine("How many to add to inventory?");
                Milk.raiseStock(Convert.ToInt16(Console.ReadLine()));
                Console.WriteLine("New stock of milk is " + Milk.getStock().ToString());
                break;
            case 6:
                Console.WriteLine("How many to add to inventory?");
                Bread.raiseStock(Convert.ToInt16(Console.ReadLine()));
                Console.WriteLine("New stock of bread is " + Bread.getStock().ToString());
                break;
            case 7:
                Console.WriteLine("Milk: " + Milk.ToString() + "\nBread: " + Bread.ToString());

                break;
            case 8:
                System.Environment.Exit(1);
                break;
        }
    }
}


class StockItem
{
    private String description = "";
    private static int count = 0;
    private int id;
    private float price;
    private int quantity;

    public StockItem()
    {
        id = count;
        count++;
    }

    public StockItem(String description, float price, int quantity)
    {
        id = count;
        count++;
        this.description = description;
        this.price = price;
        this.quantity = quantity;

    }

    public override string ToString()
    {
        return ("Item #" + id + " is " + description + " and has the price " + price + ". " + quantity + " in stock.");
    }

    public String getDescription()
    {
        return (description);
    }
    public int getID()
    {
        return (id);
    }
    public float getPrice()
    {
        return (price);
    }
    public int getStock()
    {
        return (quantity);
    }

    public void setPrice(float price)
    {
        if (price > 0)
            this.price = price;
        else
            throw new Exception("Invalid Price");

    }

    public void setStock(int quantity)
    {
        if (quantity > 0)
            this.quantity = quantity;
        else
            throw new Exception("Invalid Quantity");

    }

    public void raiseStock(int quantity)
    {
        this.quantity = quantity + this.quantity;
    }

    public void lowerStock()
    {
        if (quantity > 0)
            quantity--;
        else
            throw new Exception("Invalid Quantity");

    }

}