public class Item {
    private double Price;
    private String Name;
    public double getPrice() { return Price; }
    public String getName() { return Name; }
    public Item(String name, double price){
        Name = name;
        Price = price;
    }
}
