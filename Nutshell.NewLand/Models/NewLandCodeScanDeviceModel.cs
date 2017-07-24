using System.Xml.Serialization;
using Nutshell.Automation.BarcodeRecognition.Subjects.Models;
using Nutshell.SerialPorts.Models;

namespace Nutshell.NewLand.Models
{
        [XmlType]
        public class NewLandCodeScanDeviceModel : BarcodeRecognizerDeviceModel
        {
                [XmlElement]
                public SerialPortBusModel SerialPortBusModel { get;  set; }

        }
}
