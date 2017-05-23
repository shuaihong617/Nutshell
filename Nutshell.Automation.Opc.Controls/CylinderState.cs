namespace Nutshell.Automation.Opc.Controls
{
        /// <summary>
        ///         气缸状态
        /// </summary>
        public enum CylinderState:byte
        {
                关闭完成 = 1,
                正在开启,
                开启完成,
                正在关闭,
        }
}