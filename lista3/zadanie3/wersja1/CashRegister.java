public class CashRegister
{
    private TaxCalculator taxCalc = new TaxCalculator();

    private double CalculatePrice( Item[] Items ) {
        double _price = 0;
        for ( Item item : Items ) {
            _price += item.getPrice() + taxCalc.CalculateTax( item.getPrice() );
        }
        return _price;
    }

    public void PrintBill( Item[] Items ) {
        for ( Item item : Items )
            System.out.printf( "towar %s : cena %f + podatek %f\n", item.getName(), item.getPrice(),
                                                                    taxCalc.CalculateTax( item.getPrice() ) );
        System.out.printf( "razem: %f\n", CalculatePrice(Items));
}
}
