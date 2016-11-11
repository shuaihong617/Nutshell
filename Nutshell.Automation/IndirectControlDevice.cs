namespace Nutshell.Automation
{
        public abstract class IndirectControlDevice:ControllableDevice
        {
                protected IndirectControlDevice(IdentityObject parent, string id = "间接控制设备")
                        : base(parent, id)
                {
                }
        }
}
