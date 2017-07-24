using System;

namespace Nutshell.Automation.BarcodeRecognition
{
        public class BarcodeEventArgs : EventArgs
        {
	        public BarcodeEventArgs(string barcode)
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
