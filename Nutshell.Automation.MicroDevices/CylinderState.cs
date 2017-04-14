namespace Nutshell.Automation.MicroDevices
{
        /// <summary>
        ///         气缸状态
        /// </summary>
        public enum CylinderState:byte
        {
		未定义 = 0,
                关闭完成 = 1,
                正在开启,
                开启完成,
                正在关闭,
        }
}