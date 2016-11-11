using System.Diagnostics;

namespace Nutshell.Windows
{
        public class CpuPerformance
        {
                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly CpuPerformance Itance = new CpuPerformance();

                #endregion

                /// <summary>
                /// 所有处理器工作时间处理器
                /// </summary>
                private PerformanceCounter _totalProcessorTimePerformanceCounter;

                /// <summary>
                /// 获取所有处理器工作时间计数，即CPU使用率
                /// </summary>
                /// <remarks>
                /// 返回值为百分比形式
                /// </remarks>
                public float TotalProcessorTime
                {
                        get
                        {
                                if (_totalProcessorTimePerformanceCounter == null)
                                {
                                        _totalProcessorTimePerformanceCounter = new PerformanceCounter("Processor", "% Processor Time","_Total");
                                }
                                return _totalProcessorTimePerformanceCounter.NextValue();
                        }
                }
        }
}
