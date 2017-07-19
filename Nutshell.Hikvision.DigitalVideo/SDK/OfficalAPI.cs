// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-07-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-04-20
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        public static class OfficalAPI
        {
                public delegate void EXCEPYIONCALLBACK(uint dwType, int lUserID, int lHandle, IntPtr pUser);

                public delegate void REALDATACALLBACK(
                        Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser);

                public const int SERIALNO_LEN = 48; //序列号长度

                public const int NET_DVR_SYSHEAD = 1; //系统头数据
                public const int NET_DVR_STREAMDATA = 2; //视频流数据（包括复合流和音视频分开的视频流数据）
                public const int STREAME_REALTIME = 0;
                public const int STREAM_ID_LEN = 32;

                #region 播放库错误码

                public const uint PLAYM4_NOERROR = 0;//no error
                public const uint PLAYM4_ORDER_ERROR = 2; //The order of the function to be called is error.
                public const uint PLAYM4_BUF_OVER = 11; //buffer is overflow

                #endregion

                /*********************************************************
                                Function:	NET_DVR_Init
                                Desc:		创建SDK, 调用其他SDK函数的前提.
                                Input:	
                                Output:	
                                Return:	TRUE表示成功, FALSE表示失败.
                                **********************************************************/

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_Init();

                /*********************************************************
                                Function:	NET_DVR_Cleanup
                                Desc:		释放SDK资源, 在结束之前最后调用
                                Input:	
                                Output:	
                                Return:	TRUE表示成功, FALSE表示失败
                                **********************************************************/

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_Cleanup();


                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_RebootDVR(int userId);


                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes);

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_SetReconnect(uint dwInterval, int bEnableRecon);

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_SetRecvTimeOut(uint nRecvTimeOut = 5000);

                //最小3000毫秒

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_SetPlayerBufNumber(Int32 lRealHandle, uint dwBufNum);


                /*********************************************************
                                Function:	NET_DVR_Login_V30
                                Desc:		
                                Input:	sDVRIP [in] 设备IP地址 
                                        wServerPort [in] 设备端口号 
                                        sUserName [in] 登录的用户名 
                                        sPassword [in] 用户密码 
                                Output:	lpDeviceInfo [out] 设备信息 
                                Return:	-1表示失败, 其他值表示返回的用户ID值
                                **********************************************************/

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern Int32 NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName,
                        string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);

                /*********************************************************
                                Function:	NET_DVR_Logout_V30
                                Desc:		用户注册设备.
                                Input:	lUserID [in] 用户ID号
                                Output:	
                                Return:	TRUE表示成功, FALSE表示失败
                                **********************************************************/

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_Logout_V30(Int32 lUserID);

                /*********************************************************
		Function:	REALDATACALLBACK
		Desc:		预览回调
		Input:	lRealHandle 当前的预览句柄 
				dwDataType 数据类型
				pBuffer 存放数据的缓冲区指针 
				dwBufSize 缓冲区大小 
				pUser 用户数据 
		Output:	
		Return:	void
		**********************************************************/

                /*********************************************************
                                Function:	NET_DVR_RealPlay_V40
                                Desc:		实时预览.X64平台
                                Input:	lUserID [in] NET_DVR_Login()或NET_DVR_Login_V30()的返回值 
                                        lpClientInfo [in] 预览参数 
                                        cbRealDataCallBack [in] 码流数据回调函数 
                                        pUser [in] 用户数据 
                                        bBlocked [in] 请求码流过程是否阻塞：0－否；1－是 
                                Output:	
                                Return:	1表示失败, 其他值作为NET_DVR_StopRealPlay等函数的句柄参数
                                **********************************************************/
                //[DllImport(@"Hikvision\X64\HCNetSDK.dll")]
                //public static extern int NET_DVR_RealPlay_V40(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo,
                //        REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser,
                //        UInt32 bBlocked);

                /// <summary>
                ///         实时预览.X86平台
                /// </summary>
                /// <param name="iUserId">NET_DVR_Login()或NET_DVR_Login_V30()的返回值</param>
                /// <param name="lpPreviewInfo">预览参数</param>
                /// <param name="fRealDataCallBackV30">码流数据回调函数</param>
                /// <param name="pUser">用户数据</param>
                /// <returns>1表示失败, 其他值作为NET_DVR_StopRealPlay等函数的句柄参数</returns>
                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern int NET_DVR_RealPlay_V40(int iUserId, ref NET_DVR_PREVIEWINFO lpPreviewInfo,
                        REALDATACALLBACK fRealDataCallBackV30, IntPtr pUser);

                /*********************************************************
		Function:	NET_DVR_StopRealPlay
		Desc:		停止预览.
		Input:	lRealHandle [in] 预览句柄, NET_DVR_RealPlay或者NET_DVR_RealPlay_V30的返回值 
		Output:	
		Return:	
		**********************************************************/

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_StopRealPlay(int iRealHandle);

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_Logout(int iUserID);


                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_SetExceptionCallBack_V30(uint nMessage, IntPtr hWnd,
                        EXCEPYIONCALLBACK fExceptionCallBack,
                        IntPtr pUser);

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_TestDVRAlive(int userId);

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern uint NET_DVR_GetLastError();


                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_SetStreamOpenMode(int nPort, uint nMode);

                public delegate void DECCBFUN(int nPort, IntPtr pBuf, int nSize, ref FRAME_INFO pFrameInfo, int nReserved1, int nReserved2);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_SetDecCallBack(int nPort, DECCBFUN DecCBFun);


                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_SetDisplayBuf(int nPort, uint nNum);


                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_SetOverlayMode(int nPort, int bOverlay, uint colorKey);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_GetPort(ref int nPort);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_FreePort(int nPort);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_OpenStream(int nPort, ref byte pFileHeadBuf, uint nSize,
                        uint nBufPoolSize);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_Play(int nPort, IntPtr hWnd);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_Stop(int nPort);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_InputData(int nPort, ref byte pBuf, uint nSize);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_CloseStream(int nPort);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_GetBMP(int nPort, ref byte pBitmap, uint nBufSize, ref uint pBmpSize);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern bool PlayM4_GetBMP(int nPort, IntPtr pBitmap, uint nBufSize, ref uint pBmpSize);

                [DllImport(@"Hikvision\X86\PlayCtrl.dll")]
                public static extern uint PlayM4_GetLastError(int nPort);

                #region 参数配置

                

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_GetDVRConfig(int userId, DVRConfigType dvrConfigType, int channel,
                        IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned);

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_SetDVRConfig(int userId, DVRConfigType dvrConfigType, int channel,
                        IntPtr lpInBuffer, uint dwInBufferSize);

                #endregion

                #region 云台控制

                [DllImport(@"Hikvision\X86\HCNetSDK.dll")]
                public static extern bool NET_DVR_PTZControl(Int32 lRealHandle, uint dwPTZCommand, uint dwStop);

                #endregion

                public struct NET_DVR_CLIENTINFO
                {
                        public IntPtr hPlayWnd; //播放窗口的句柄,为NULL表示不播放图象
                        public Int32 lChannel; //通道号

                        public Int32 lLinkMode;
                        //最高位(31)为0表示主码流, 为1表示子码流, 0－30位表示码流连接方式: 0：TCP方式,1：UDP方式,2：多播方式,3 - RTP方式, 4-音视频分开(TCP)

                        public string sMultiCastIP; //多播组地址
                }

                //预览V40接口

                public struct NET_DVR_DEVICEINFO_V30
                {
                        public byte byAlarmInPortNum; //报警输入个数
                        public byte byAlarmOutPortNum; //报警输出个数
                        public byte byAudioChanNum; //语音通道数
                        public byte byChanNum; //模拟通道个数
                        public byte byDVRType; //设备类型, 1:DVR 2:ATM DVR 3:DVS ...
                        public byte byDiskNum; //硬盘个数
                        public byte byIPChanNum; //最大数字通道个数  

                        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)] 
                        public byte[] byRes1; //保留

                        public byte byStartChan; //起始通道号,例如DVS-1,DVR - 1

                        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)] 
                        public byte[] sSerialNumber; //序列号
                }

                [StructLayout(LayoutKind.Sequential)]
                public struct NET_DVR_PREVIEWINFO
                {
                        public Int32 lChannel; //通道号
                        public uint dwStreamType; // 码流类型, 0-主码流, 1-子码流, 2-码流3, 3-码流4 等以此类推
                        public uint dwLinkMode; // 0：TCP方式,1：UDP方式,2：多播方式,3 - RTP方式, 4-RTP/RTSP,5-RSTP/HTTP 
                        public IntPtr hPlayWnd; //播放窗口的句柄,为NULL表示不播放图象
                        public bool bBlocked; //0-非阻塞取流, 1-阻塞取流, 如果阻塞SDK内部connect失败将会有5s的超时才能够返回,不适合于轮询取流操作.
                        public bool bPassbackRecord; //0-不启用录像回传,1启用录像回传
                        public byte byPreviewMode; //预览模式, 0-正常预览, 1-延迟预览

                        [MarshalAs(UnmanagedType.ByValArray, SizeConst = STREAM_ID_LEN, ArraySubType = UnmanagedType.I1)
                        ] public byte[] byStreamID; //流ID, lChannel为0xffffffff时启用此参数

                        public byte byProtoType; //应用层取流协议, 0-私有协议, 1-RTSP协议

                        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 222, ArraySubType = UnmanagedType.I1)] public
                                byte[] byRes;
                }
        }
}