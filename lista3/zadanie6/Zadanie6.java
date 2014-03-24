public class Zadanie6 {
    public static void main(String[] args) {
	DocumentFormatter df = new ConcreteDocumentFormatter();
        ReportPrinter rp = new ReportPrinterImpl("TEST", df);
        rp.PrintReport();
    }
}
