namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        /// 电磁阀
        /// </summary>
        public class OpcSolenoid:OpcSwitch
        {
                public OpcSolenoid(IdentityObject parent, string id, OpcItem opcItem)
                        : base(parent, id, opcItem)
                {
                }
        }
}
