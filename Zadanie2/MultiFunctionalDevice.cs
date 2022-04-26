using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ver1;
using Zadanie1;


namespace Zadanie2
{
    class MultiFunctionalDevice : Copier, IFax
    {
        public int FaxCounter { get; set;}

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
    }
}
