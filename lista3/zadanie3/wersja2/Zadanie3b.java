public class Zadanie3b {
    public static void main(String[] args) {
        TaxCalculator tc1 = new ConcreteTaxCalculator1();
        TaxCalculator tc2 = new ConcreteTaxCalculator2();
        OrderingByName comp1 = new OrderingByName();
        OrderingByPrice comp2 = new OrderingByPrice();
        PrintTestBill(new CashRegister(tc1, comp1));
        PrintTestBill(new CashRegister(tc2, comp1));
        PrintTestBill(new CashRegister(tc2, comp2));
    }
    private static void PrintTestBill(CashRegister cr){
        Item[] items = {new Item("foo", 5), new Item("bar", 10)};
        cr.PrintBill( items );
    }
}
