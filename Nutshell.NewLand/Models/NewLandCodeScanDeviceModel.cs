using System.Xml.Serialization;
using Nutshell.Automation.CodeScan.Subjects;
using Nutshell.Automation.CodeScan.Subjects.Models;
using Nutshell.SerialPorts.Models;

namespace Nutshell.NewLand.Models
{
        [XmlType]
        public class NewLandCodeScanDeviceModel : CodeScannerDeviceModel
        {
                [XmlElement]
                public SerialPortBusModel SerialPortBusModel { get;  set; }

        }
}
