using System;
using ver3;
using Zadanie3;

namespace Zadanie3
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        protected IPrinter _printer;
        protected IScanner _scanner;

        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public new int Counter { get; set; }


        public void Print(in IDocument doc)
        {
            if (GetState() == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss} Print: {doc.GetFileName()}");
                PrintCounter++;
            }
        }

        public void Scan(out IDocument doc, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            doc = null;

            if (GetState() == IDevice.State.on)
            {
                switch (formatType)
                {
                    case IDocument.FormatType.PDF:
                        doc = new PDFDocument($"PDFScan{ScanCounter}.pdf");
                        break;

                    case IDocument.FormatType.JPG:
                        doc = new ImageDocument($"ImageScan{ScanCounter}.jpg");
                        break;

                    case IDocument.FormatType.TXT:
                        doc = new TextDocument($"TextScan{ScanCounter}.txt");
                        break;
                }

                Console.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss} Scan: {doc.GetFileName()}");
                ScanCounter++;
            }
        }
        public new void PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                Counter++;
                base.PowerOn();
            }
        }
        public void Copierr()
        {
            if (GetState() == IDevice.State.on)
            {
                Scan(out IDocument doc);
                Print(in doc);
            }
        }
        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.on)
            {
                Scan(out IDocument doc);
                Print(in doc);
            }
        }
    }

   
}

