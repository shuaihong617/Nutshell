namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        ///         传感器
        /// </summary>
        public class OpcSensor<T> : OpcDevice<T> where T : struct
        {
                public OpcSensor(string id, OpcItem opcItem)
                        : base( id, opcItem)
                {
                }
        }
}
