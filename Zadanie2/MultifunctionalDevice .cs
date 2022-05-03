using System;
using System.Collections.Generic;
using System.Text;
using ver2;

namespace Zadanie2
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
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
        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.on)
            {
                Scan(out IDocument doc);
                Print(in doc);
            }
        }
    }
        namespace Zadanie22 { 

        class MultiFunctionalDevice : Copier, IFax
    {
        public int FaxCounter { get; set; }

        public void Fax(in IDocument doc)
        {
            if (state == IDevice.State.on)
            {
                DateTime date = DateTime.Now;
                FaxCounter++;
                Console.WriteLine($"{date} Fax: {doc.GetFileName()}");
            }
        }

        public void ScanPrintFax()
        {
            if (state == IDevice.State.on)
            {
                Scan(out IDocument doc, IDocument.FormatType.JPG);
                Print(doc);
                Fax(doc);
            }
        }

            public void Send(in IDocument doc)
            {
                throw new NotImplementedException();
            }
        }
    }
    }
