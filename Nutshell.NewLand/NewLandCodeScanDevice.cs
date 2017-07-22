using System.Diagnostics;
using Nutshell.Automation.CodeScan.Subjects;
using Nutshell.Data.Models;
using Nutshell.NewLand.Models;

namespace Nutshell.NewLand
{
        public class NewLandCodeScanDevice : CodeScannerDevice
        {
                public NewLandCodeScanDevice()
                {
                        SerialBus.Parent = this;
                        SerialBus.BarcodeReceiveSuccessed += (obj, args) =>
                        {
                                Barcode = args.Barcode;
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
