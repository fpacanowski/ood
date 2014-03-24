public class Zadanie3a {
    public static void main(String[] args) {
        CashRegister cr = new CashRegister();
        Item[] items = {new Item("foo", 5), new Item("bar", 10)};
        cr.PrintBill( items );
    }
}
