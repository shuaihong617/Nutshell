using System;
using Nutshell.Automation.DaHeng.Sdk;

namespace Nutshell.Automation.DaHeng
{
        public class DaHengException:Exception
        {
                public DaHengException(ErrorCode errorCode)
                {
                        ErrorCode = errorCode;
                }

                public ErrorCode ErrorCode { get; private set; }
        }
}