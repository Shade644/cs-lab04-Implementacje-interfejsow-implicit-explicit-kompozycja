using System;
using ver1;
using Zadanie2;

namespace zadanie
{
    class Program
    {
        static void Main()
        {
            var xerox = new MultiFunctionalDevice();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);

            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);

            xerox.ScanPrintFax();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.ScanCounter);
            System.Console.WriteLine(xerox.PrintCounter);
            

        }
    }
}
