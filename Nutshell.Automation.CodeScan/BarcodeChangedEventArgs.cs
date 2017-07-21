using System;

namespace Nutshell.Automation.CodeScan
{
        public class BarcodeChangedEventArgs : EventArgs
        {
	        public BarcodeChangedEventArgs(string barcode)
	        {
		        Barcode = barcode;
	        }

                public string Barcode { get; set; }

                public override string ToString()
                {
                        return Barcode;
                }
        }
}
