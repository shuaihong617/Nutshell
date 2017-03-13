namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        ///         开关元器件
        /// </summary>
        public abstract class OpcSwitch : OpcDevice<bool>
        {
                protected OpcSwitch(string id, OpcItem source)
                        : base(id, source)
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