using System;

namespace Nutshell.Automation.Opc.Devices
{
        /// <summary>
        /// 自动复位电气按钮
        /// </summary>
        public class OpcAutoResetButton : OpcButton
        {
                public OpcAutoResetButton(string id, OpcItem opcItem)
                        : base(id, opcItem)
                {
                }

                protected override void OnPressed(EventArgs e)
                {
                        base.OnPressed(e);
                        Raise();
                }
        }
}