using Nutshell.Automation.DaHeng.Sdk;
using Nutshell.Components;

namespace Nutshell.Automation.DaHeng
{
        public class DaHengRuntime:Runtime
        {
                public DaHengRuntime(string id) 
                        : base(id)
                {
                }

                public int GetCardsCount()
                {
                        int total = 0;

                        var errorcode = OfficalApi.GetCardTotal(ref total);
                        if (errorcode != ErrorCode.CG_OK)
                        {
                                throw new DaHengException(errorcode);
                        }

                        return total;
                }
        }
}