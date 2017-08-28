using System;
using System.Diagnostics;
using Nutshell.Automation.BarcodeRecognition.Subjects;
using Nutshell.Data.Models;
using Nutshell.NewLand.Models;

namespace Nutshell.NewLand
{
        public class NewLandBarcodeRecognizerDevice : BarcodeRecognizerDevice
        {
	        public NewLandBarcodeRecognizerDevice()
		        : this(String.Empty)
	        {
		        
	        }

		public NewLandBarcodeRecognizerDevice(string id="")
			:base(id)
                {
                        SerialBus.Parent = this;
                        SerialBus.BarcodeReceiveSuccessed += (obj, args) =>
                        {
                                WriteBarcode(args.Barcode);
                        };
                }
                public NewLandSerialBus SerialBus { get; } = new NewLandSerialBus();

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as NewLandCodeScanDeviceModel;
                        Trace.Assert(subModel != null);

                        SerialBus.Load(subModel.SerialPortBusModel);
                }

                protected override bool StartConnectCore()
                {
                        return base.StartConnectCore() && SerialBus.Start();
                }

                protected override bool StopConnectCore()
                {
                        SerialBus.Stop();
                        return base.StopConnectCore();
                }
        }
}
