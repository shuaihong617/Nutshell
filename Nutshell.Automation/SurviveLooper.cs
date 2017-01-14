using System.Threading;
using Nutshell.Components;

namespace Nutshell.Automation
{
        public class SurviveLooper : Looper
        {
                public SurviveLooper(IIdentityObject parent)
                        : base(parent, "Opc服务器在线工作者", ThreadPriority.Normal, 3000)
                {
                }               

                protected sealed  override IResult RepeatWork()
                {
                        return IsSurvive();
                }

                /// <summary>
                /// 在线测试
                /// </summary>
                /// <returns>设备在线返回True，否则返回False</returns>
                protected virtual IResult IsSurvive()
                {
                        return Result.Successed;
                }
        }
}
