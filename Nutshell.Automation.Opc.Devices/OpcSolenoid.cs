namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        /// 电磁阀
        /// </summary>
        public class OpcSolenoid:OpcSwitch
        {
                public OpcSolenoid(string id, OpcItem opcItem)
                        : base( id, opcItem)
                {
                }
        }
}
