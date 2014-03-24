public class ReportPrinterImpl implements ReportPrinter {
    private String data;
    private String document;
    private DocumentFormatter documentFormatter;
    public ReportPrinterImpl(String _data)
    {
        data = _data;
        documentFormatter = new DocumentFormatter();
    }
    public String GetData()
    {
        return data;
    }
    public void PrintReport()
    {
        System.out.println(documentFormatter.FormatDocument(data));
    }
}
