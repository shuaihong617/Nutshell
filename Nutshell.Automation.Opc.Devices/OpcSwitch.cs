namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        ///         开关元器件
        /// </summary>
        public abstract class OpcSwitch : OpcDevice<bool>
        {
                protected OpcSwitch(IdentityObject parent, string id, OpcItem source)
                        : base(parent,id, source)
                {
                }

                public void Open()
                {
                        OpcPoint.RemoteWrite(true);
                }

                public void Close()
                {
                        OpcPoint.RemoteWrite(false);
                }
        }
}
