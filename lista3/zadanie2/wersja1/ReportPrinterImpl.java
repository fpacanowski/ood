public class ReportPrinterImpl implements ReportPrinter {
    private String data;
    private String document;
    public ReportPrinterImpl(String _data)
    {
        data = _data;
    }
    public String GetData()
    {
        return data;
    }
    public void FormatDocument()
    {
        document = "Report data: " + data;
    }
    public void PrintReport()
    {
        FormatDocument();
        System.out.println(document);
    }
}
