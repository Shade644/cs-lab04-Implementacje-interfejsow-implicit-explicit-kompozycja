using System;
using System.Collections.Generic;
using System.Text;
using ver1;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        

        public void Print(in IDocument document)
        {
            if(GetState() == IDevice.State.on)
            {
                Console.WriteLine($"{DateTime.Now:dd.MM.yyyy HH:mm:ss} Print: {document.GetFileName()}");
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