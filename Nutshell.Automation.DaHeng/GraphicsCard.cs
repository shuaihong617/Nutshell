using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Nutshell.Automation.DaHeng.Models;
using Nutshell.Automation.DaHeng.Sdk;
using Nutshell.Data.Models;
using Nutshell.Storaging;

namespace Nutshell.Automation.DaHeng
{
	public class GraphicsCard: StorableObject
        {
                public GraphicsCard()
                        :this(1)
                {
                }

                public GraphicsCard(int index)
	        {
	                Index = index;

	                Buffer = Marshal.AllocHGlobal(FrameSize);
	        }

	        #region 常量

	        public const int Width = 768;

	        public const int Height = 576;

	        private const int FrameSize = Width*Height;

	        #endregion


                private IntPtr _cardHandle;

	        private IntPtr _staticMemoryHandle;

	        private IntPtr _staticMemoryPointer;

	        public IntPtr Buffer { get; private set; }

                public int Index { get; private set; }

	        public override void Load(IIdentityModel model)
	        {
                        base.Load(model);

                        var subModel = model as GraphicsCardModel;
                        Trace.Assert(subModel != null);

	                Index = subModel.Index;
	        }

	        public void StartConnect()
	        {
                        ErrorCode errorCode = OfficalApi.BeginCard(Index, ref _cardHandle);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                throw new InvalidOperationException("打开采集卡失败");
                        }

                        errorCode = OfficalApi.SetVideoStandard(_cardHandle, VideoStandardMode.Pal);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                throw new InvalidOperationException("设置采集卡视频制式失败");
                        }

                        errorCode = OfficalApi.SetVideoFormat(_cardHandle, VideoFormat.Limited8Bit);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                throw new InvalidOperationException("设置采集卡视频格式失败");
                        }

                        errorCode = OfficalApi.SetInputWindow(_cardHandle, 0, 0, Width, Height);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                throw new InvalidOperationException("设置采集卡输入窗口失败");
                        }

                        errorCode = OfficalApi.SetOutputWindow(_cardHandle, 0, 0, Width, Height);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                throw new InvalidOperationException("设置采集卡输出窗口失败");
                        }
                }

                /// <summary>
                /// 开始同步采集
                /// </summary>
                public void StartCaptureSync()
	        {
	                
	        }

                /// <summary>
                /// 停止同步采集
                /// </summary>
                public void StopCaptureSync()
	        {
	                
	        }


                /// <summary>
                /// 采集一帧
                /// </summary>
                public unsafe bool CaptureOneFrame()
	        {
                        //采集图像
                        ErrorCode errorCode = OfficalApi.SnapShot(_cardHandle,0,0,true,1);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                return false;
                                //throw gcnew InvalidOperationException("采集卡采集图像失败");
                        }

                        errorCode = OfficalApi.StaticMemLock(0,
                                FrameSize,
                                ref _staticMemoryHandle,
                                ref _staticMemoryPointer);

                        if (errorCode != ErrorCode.CG_OK)
                        {
                                return false;
                                //throw gcnew InvalidOperationException("采集卡锁定图像失败");
                        }

                        //传输到缓冲区
                        var sourcePtr = (byte*) _staticMemoryPointer.ToPointer();
                        var targetPtr = (byte*)Buffer.ToPointer();

                        for (int i = 0; i < FrameSize; i++)
                        {
                                *targetPtr++ = *sourcePtr++;
                        }

                        errorCode = OfficalApi.StaticMemUnlock(_staticMemoryHandle);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                return false;
                                //throw gcnew InvalidOperationException("采集卡解锁图像失败");
                        }

                        return true;
                }

	        public void StopConnect()
	        {
                        OfficalApi.EndCard(_cardHandle);
                }


                public void SetVideoSource(int index)
	        {
	                VideoSource videoSource = new VideoSource
	                {
	                        Index = index,
	                        Type = VideoSourceType.CompositeVideo
	                };

	                ErrorCode errorCode = OfficalApi.SetVideoSource(_cardHandle, videoSource);

                        if (errorCode != ErrorCode.CG_OK)
                        {
                                throw new InvalidOperationException("采集卡设置视频源失败");
                        }
                }

                //void UpdateSnapingFrameNumber();

                //void TransformSnapShotData(byte* imageBuffer);

                public void SetBrightness(int brightness)
	        {
                        OfficalApi.AdjustVideo(_cardHandle, VideoAdjustMode.Brightness, (byte)brightness);
                }

                public void SetContrast(int constrast)
	        {
                        OfficalApi.AdjustVideo(_cardHandle, VideoAdjustMode.Contrast, (byte)constrast);
                }
        }
}
