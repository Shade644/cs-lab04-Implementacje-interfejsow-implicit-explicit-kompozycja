using System;
using Zadanie3;
using ver3;


    namespace Zadanie33
    {
        internal class MultiFunctionalDevice : Copier, IFax
        {
            public int FaxCounter { get; set; }
        public int Counter2 { get; set; }

        public void Fax(in IDocument doc)
            {
                if (state == IDevice.State.on)
                {
                    DateTime date = DateTime.Now;
                    FaxCounter++;
                    Console.WriteLine($"{date} Fax: {doc.GetFileName()}");
                }
            }
        public new void PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                Counter2++;
                base.PowerOn();
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

            public void Send(in IDocument document)
            {
                throw new NotImplementedException();
            }
        }
    }


