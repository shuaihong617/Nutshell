using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Nutshell.Automation.DaHeng.Models;
using Nutshell.Automation.DaHeng.Sdk;
using Nutshell.Data.Models;
using Nutshell.Storaging;

namespace Nutshell.Automation.DaHeng
{
	public unsafe class GraphicsCard: StorableObject
        {
                public GraphicsCard()
                        :this(1)
                {
                }

                public GraphicsCard(int index)
	        {
	                Index = index;

	                CaptureFrameBuffer = Marshal.AllocHGlobal(FrameBufferSize);

                        EvenFieldBuffer = Marshal.AllocHGlobal(FieldBufferSize);
                        OddFieldBuffer = Marshal.AllocHGlobal(FieldBufferSize);
	        }

	        #region 常量

	        public const int Width = 768;

	        public const int Height = 576;

	        public const int FrameBufferSize = Width*Height;

                public const int FieldBufferSize = Width * Height /2;

	        private const int AsyncFramesCount = 8;

                #endregion


                private IntPtr _cardHandle;

	        private IntPtr _staticMemoryHandle;

	        private IntPtr _staticMemoryPointer;

	        public IntPtr CaptureFrameBuffer { get; private set; }

                public IntPtr EvenFieldBuffer { get; private set; }
                public IntPtr OddFieldBuffer { get; private set; }

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
                public void StartCaptureAsync()
                {
                        OfficalApi.StartCaptureAsync(_cardHandle, 0, true, AsyncFramesCount);
                }

                /// <summary>
                /// 停止同步采集
                /// </summary>
                public void StopCaptureAsync()
                {
                        OfficalApi.StopCaptureAsync(_cardHandle);
                }

	        public bool CaptureOneFrameAsync()
	        {
	                int fieldNumber = -1;
	                var errorCode = OfficalApi.GetSnappingNumber(_cardHandle,ref fieldNumber);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                return false;
                                //throw gcnew InvalidOperationException("采集卡采集图像失败");
                        }

	                if (fieldNumber < 0)
	                {
	                        return false;
	                }

	                int frameNumber = fieldNumber/2 -1;
	                if (frameNumber == -1)
	                {
	                        frameNumber = AsyncFramesCount - 1;
	                }

                        //Trace.WriteLine(DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss:fff") + "     " + frameNumber);

                        errorCode = OfficalApi.StaticMemLock(frameNumber * FrameBufferSize,
                                FrameBufferSize,
                                ref _staticMemoryHandle,
                                ref _staticMemoryPointer);

                        if (errorCode != ErrorCode.CG_OK)
                        {
                                return false;
                                //throw gcnew InvalidOperationException("采集卡锁定图像失败");
                        }

                        //传输到缓冲区
                        var sourcePtr = (byte*)_staticMemoryPointer.ToPointer();
                        var targetPtr = (byte*)CaptureFrameBuffer.ToPointer();

                        for (int i = 0; i < FrameBufferSize; i++)
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


                /// <summary>
                /// 采集一帧
                /// </summary>
                public bool CaptureOneFrameSync()
	        {
                        //采集图像
                        ErrorCode errorCode = OfficalApi.CaptureSync(_cardHandle,0,0,true,1);
                        if (errorCode != ErrorCode.CG_OK)
                        {
                                return false;
                                //throw gcnew InvalidOperationException("采集卡采集图像失败");
                        }

                        errorCode = OfficalApi.StaticMemLock(0,
                                FrameBufferSize,
                                ref _staticMemoryHandle,
                                ref _staticMemoryPointer);

                        if (errorCode != ErrorCode.CG_OK)
                        {
                                return false;
                                //throw gcnew InvalidOperationException("采集卡锁定图像失败");
                        }

                        //传输到缓冲区
                        var sourcePtr = (byte*) _staticMemoryPointer.ToPointer();
                        var targetPtr = (byte*)CaptureFrameBuffer.ToPointer();

                        for (int i = 0; i < FrameBufferSize; i++)
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

	        protected void UpdateEvenFieldBuffer()
	        {
                        byte* sourcePtr = (byte*)CaptureFrameBuffer.ToPointer();
                        byte* targetPtr = (byte*)EvenFieldBuffer.ToPointer();

                        for (int y = 0; y < Height / 2; y++)
                        {
                                for (int x = 0; x < Width; x++)
                                {
                                        *targetPtr++ = *sourcePtr++;
                                }
                                sourcePtr += Width;
                        }
                }

                protected void UpdateOddFieldBuffer()
                {
                        byte* sourcePtr = (byte*)CaptureFrameBuffer.ToPointer() + Width;
                        byte* targetPtr = (byte*)OddFieldBuffer.ToPointer();

                        for (int y = 0; y < Height / 2; y++)
                        {
                                for (int x = 0; x < Width; x++)
                                {
                                        *targetPtr++ = *sourcePtr++;
                                }
                                sourcePtr += Width;
                        }
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

	        public void SetVideoMirror(MirrorType mirrorType, bool enable)
	        {
	                Debug.Assert(_cardHandle != IntPtr.Zero);
	                OfficalApi.SetVideoMirror(_cardHandle, mirrorType, enable);
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
