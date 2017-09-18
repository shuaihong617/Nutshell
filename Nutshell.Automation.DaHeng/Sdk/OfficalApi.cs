// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-09-09
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-09-09
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Nutshell.Automation.DaHeng.Sdk
{
        /// <summary>
        /// 大恒官方API
        /// </summary>
        public class OfficalApi
	{
                /// <summary>
                /// 开始指定图像卡操作，初始化图像卡，获得其设备句柄，分配相应的资源
                /// </summary>
                /// <param name="device">图像卡的逻辑序号</param>
                /// <param name="handle">指向图像卡设备句柄</param>
                /// <returns>调用成功，返回 CG_OK，否则返回错误代码</returns>
                [DllImport("CGVideo.dll", EntryPoint = "BeginCGCard")]
		public static extern ErrorCode BeginCard(int device, ref IntPtr handle);

                /// <summary>
                /// Ends the card.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll", EntryPoint = "EndCGCard")]
		public static extern ErrorCode EndCard(IntPtr handle);

                /// <summary>
                /// Captures the specified handle.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="bEnable">if set to <c>true</c> [b enable].</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll")]
		public static extern ErrorCode Capture(IntPtr handle, bool bEnable);

                /// <summary>
                /// Captures the shot.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll")]
		public static extern ErrorCode CaptureShot(IntPtr handle);

                /// <summary>
                /// Sets the input window.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="nStartX">The n start x.</param>
                /// <param name="nStartY">The n start y.</param>
                /// <param name="nWidth">Width of the n.</param>
                /// <param name="nHeight">Height of the n.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll", EntryPoint = "CGSetInputWindow")]
		public static extern ErrorCode SetInputWindow(IntPtr handle, int nStartX, int nStartY, int nWidth, int nHeight);

                /// <summary>
                /// Sets the output window.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="nStartX">The n start x.</param>
                /// <param name="nStartY">The n start y.</param>
                /// <param name="nWidth">Width of the n.</param>
                /// <param name="nHeight">Height of the n.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll", EntryPoint = "CGSetOutputWindow")]
		public static extern ErrorCode SetOutputWindow(IntPtr handle, int nStartX, int nStartY, int nWidth, int nHeight);

                /// <summary>
                /// Sets the video format.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="format">The format.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll", EntryPoint = "CGSetVideoFormat")]
		public static extern ErrorCode SetVideoFormat(IntPtr handle, VideoFormat format);

                /// <summary>
                /// Sets the video standard.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="mode">The mode.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll",EntryPoint = "CGSetVideoStandard")]
		public static extern ErrorCode SetVideoStandard(IntPtr handle, VideoStandardMode mode);


                /// <summary>
                /// Sets the scan mode.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="mode">The mode.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll",EntryPoint = "CGSetScanMode")]
		public static extern ErrorCode SetScanMode(IntPtr handle, VideoScanMode mode);

                /// <summary>
                /// Sets the video source.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="source">The source.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll", EntryPoint = "CGSetVideoSource")]
		public static extern ErrorCode SetVideoSource(IntPtr handle, VideoSource source);

                /// <summary>
                /// Adjusts the video.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="param">The parameter.</param>
                /// <param name="value">The value.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll",EntryPoint = "CGAdjustVideo")]
		public static extern ErrorCode AdjustVideo(IntPtr handle, VideoAdjustMode param, byte value);


                [DllImport("CGVideo.dll", EntryPoint = "CGEnableVideoMirror")]
                public static extern ErrorCode SetVideoMirror(IntPtr handle, MirrorType mirrorType, bool enable);

                /// <summary>
                /// Statics the memory lock.
                /// </summary>
                /// <param name="dwStartOffset">The dw start offset.</param>
                /// <param name="dwLength">Length of the dw.</param>
                /// <param name="pHandle">The p handle.</param>
                /// <param name="ppLineAddr">The pp line addr.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll",EntryPoint = "CGStaticMemLock")]
		public static extern ErrorCode StaticMemLock(int dwStartOffset, int dwLength, ref IntPtr pHandle, ref IntPtr ppLineAddr);

                /// <summary>
                /// Statics the memory unlock.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll",EntryPoint = "CGStaticMemUnlock")]
		public static extern ErrorCode StaticMemUnlock(IntPtr handle);


                /// <summary>
                /// Snaps the shot.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="dwMemOffset">The dw memory offset.</param>
                /// <param name="wIntervSyncs">The w interv syncs.</param>
                /// <param name="bInterline">if set to <c>true</c> [b interline].</param>
                /// <param name="wSum">The w sum.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll",EntryPoint = "CGSnapShot")]
		public static extern ErrorCode CaptureSync(IntPtr handle, int dwMemOffset, short wIntervSyncs, bool bInterline, short wSum);

                /// <summary>
                /// Starts the snap.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="dwMemOffset">if set to <c>true</c> [dw memory offset].</param>
                /// <param name="bInterline">if set to <c>true</c> [b interline].</param>
                /// <param name="sum">The w sum.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll", EntryPoint = "CGStartSnap")]
		public static extern ErrorCode StartCaptureAsync(IntPtr handle, int dwMemOffset, bool bInterline, short sum);

                /// <summary>
                /// Gets the snapping number.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="number">The p number.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll", EntryPoint = "CGGetSnappingNumber")]
		public static extern ErrorCode GetSnappingNumber(IntPtr handle, ref  int number);

                /// <summary>
                /// Stops the snap.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll", EntryPoint = "CGStopSnap")]
		public static extern ErrorCode StopCaptureAsync(IntPtr handle);


                /// <summary>
                /// Gets the type of the card.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="type">The type.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll")]
		public static extern ErrorCode GetCardType(IntPtr handle, ref CardType type);

                /// <summary>
                /// Gets the card total.
                /// </summary>
                /// <param name="pNumber">The p number.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll")]
		public static extern ErrorCode GetCardTotal(ref int pNumber);


                /************************ 400Util *************************************/

                /// <summary>
                /// Gets the board information.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="type">The type.</param>
                /// <param name="pInfo">The p information.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll")]
		public static extern ErrorCode GetBoardInfo(IntPtr handle, BoardInfoType type, string pInfo);


                /************************ 410Util *************************************/

                /// <summary>
                /// Reads the SCM parameter.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="pBuffer">The p buffer.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll")]
		public static extern ErrorCode ReadSCMParam(IntPtr handle, IntPtr pBuffer);

                /// <summary>
                /// Writes the SCM parameter.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="pBuffer">The p buffer.</param>
                /// <param name="byEntries">The by entries.</param>
                /// <returns>ErrorCode.</returns>
                [DllImport("CGVideo.dll")]
		public static extern ErrorCode WriteSCMParam(IntPtr handle, IntPtr pBuffer, byte byEntries);
	}
}
