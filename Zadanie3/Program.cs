using System;
using Zadanie3;
using Zadanie33;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            var xerox = new Copier();
            var printer = new Printer();
            var scanner = new Scanner();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);

            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);
            xerox.PowerOff();
           // Console.WriteLine("xxxxxxxxxxxxx");
            var xerox2 = new MultiFunctionalDevice();
            xerox2.PowerOn();
            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);
            xerox2.PowerOff();

            printer.PowerOn();
            printer.PowerOff();
            scanner.PowerOn();
            scanner.PowerOff();


        }
    }
}
