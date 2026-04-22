class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException
        // This will throw a NullReferenceException
        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");

        // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
        // TODO: Implement this part three.

        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();

        fruitManager.AddItem(new Fruit { Name = "Durian" });
        fruitManager.AddItem(new Fruit { Name = "Rambutan" });
        fruitManager.AddItem(new Fruit { Name = "Mango" });

        fruitManager.PrintAllItems();

        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
    }
}

public interface IntItemManager  // interface for ItemManager
{
    void AddItem(string item);
    void RemoveItem(string item);
    void PrintAllItems();
    void ClearAllItems();
}
public class ItemManager: IntItemManager
{
    private List<string> items = new List<string>();  // initialize the list

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Part Two: Implement the RemoveItem method
    // TODO: Implement this method
    public void RemoveItem(string item)
    {
        if (items.Count == 0)  // check if the item list is empty or not
        {
            Console.WriteLine("The item list is empty. No product removed.");
            return;
        }

        bool removed = items.Remove(item); 

        if (removed == false)  // check if the item exists in the item list or not
        {
            Console.WriteLine("Item not found. No product removed.");
        }
        else
        {
            Console.WriteLine(item + " has been removed");
        }
    }

    public void ClearAllItems()
    {
        items = [];
    }
}

public class ItemManager<T>
{
    private List<T> items = new List<T>();  // initialize the list

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        items = [];
    }
}

public class Fruit
{
    public required string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
