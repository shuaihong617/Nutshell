using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Data.Models;

namespace Nutshell.Automation
{
        public abstract class ControllableDevice : Device
        {
                protected ControllableDevice(IdentityObject parent, string id = "可控设备")
                        : base(parent, id)
                {
                        RunMode = RunMode.普通;
                }

                #region 属性

                public RunMode RunMode { get; private set; }

                #endregion

                public override void Load([AssignableFrom(typeof(IDeviceModel))] IDataModel model)
                {
                        base.Load(model);

                        var deviceModel = model as IDeviceModel;
                        RunMode = deviceModel.RunMode;
                }
        }
}
