using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.DaHeng.Sdk;
using Nutshell.Components;

namespace Nutshell.Automation.DaHeng
{
        public class DaHengRuntime:Runtime
        {
                private DaHengRuntime() 
                        : base("大恒采集卡运行环境")
                {
                }

                #region 字段

                /// <summary>
                ///         单例对象
                /// </summary>
                public static readonly DaHengRuntime Instance = new DaHengRuntime();

                #endregion

                [NotifyPropertyValueChanged]
                public int CardsCount { get; private set; }

                private int GetCardsCount()
                {
                        int total = 0;

                        var errorcode = OfficalApi.GetCardTotal(ref total);
                        if (errorcode != ErrorCode.CG_OK)
                        {
                                throw new DaHengException(errorcode);
                        }

                        return total;
                }

                protected override bool StartCore()
                {
                        CardsCount = GetCardsCount();
                        return true;
                }
        }
}