import java.util.Comparator;

public class OrderingByPrice implements Comparator<Item> {
    public int compare(Item a, Item b){
        return (int)(a.getPrice() - b.getPrice());
    }
}
