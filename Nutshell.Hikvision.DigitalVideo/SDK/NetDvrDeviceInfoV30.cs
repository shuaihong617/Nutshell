using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        [StructLayout(LayoutKind.Sequential)]
        public struct NetDvrDeviceInfoV30
        {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = OfficalAPI.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
                public byte[] sSerialNumber;  //序列号
                public byte byAlarmInPortNum;                   //报警输入个数
                public byte byAlarmOutPortNum;                  //报警输出个数
                public byte byDiskNum;                              //硬盘个数
                public byte byDVRType;                              //设备类型, 1:DVR 2:ATM DVR 3:DVS ......
                public byte byChanNum;                              //模拟通道个数
                public byte byStartChan;                                //起始通道号,例如DVS-1,DVR - 1
                public byte byAudioChanNum;                //语音通道数
                public byte byIPChanNum;                                        //最大数字通道个数，低位  
                public byte byZeroChanNum;                      //零通道编码个数 //2010-01-16
                public byte byMainProto;                        //主码流传输协议类型 0-private, 1-rtsp,2-同时支持private和rtsp
                public byte bySubProto;                         //子码流传输协议类型0-private, 1-rtsp,2-同时支持private和rtsp
                public byte bySupport;        //能力，位与结果为0表示不支持，1表示支持，
                                              //bySupport & 0x1, 表示是否支持智能搜索
                                              //bySupport & 0x2, 表示是否支持备份
                                              //bySupport & 0x4, 表示是否支持压缩参数能力获取
                                              //bySupport & 0x8, 表示是否支持多网卡
                                              //bySupport & 0x10, 表示支持远程SADP
                                              //bySupport & 0x20, 表示支持Raid卡功能
                                              //bySupport & 0x40, 表示支持IPSAN 目录查找
                                              //bySupport & 0x80, 表示支持rtp over rtsp
                public byte bySupport1;        // 能力集扩充，位与结果为0表示不支持，1表示支持
                                               //bySupport1 & 0x1, 表示是否支持snmp v30
                                               //bySupport1 & 0x2, 支持区分回放和下载
                                               //bySupport1 & 0x4, 是否支持布防优先级	
                                               //bySupport1 & 0x8, 智能设备是否支持布防时间段扩展
                                               //bySupport1 & 0x10, 表示是否支持多磁盘数（超过33个）
                                               //bySupport1 & 0x20, 表示是否支持rtsp over http	
                                               //bySupport1 & 0x80, 表示是否支持车牌新报警信息2012-9-28, 且还表示是否支持NET_DVR_IPPARACFG_V40结构体
                public byte bySupport2; /*能力，位与结果为0表示不支持，非0表示支持							
							bySupport2 & 0x1, 表示解码器是否支持通过URL取流解码
							bySupport2 & 0x2,  表示支持FTPV40
							bySupport2 & 0x4,  表示支持ANR
							bySupport2 & 0x8,  表示支持CCD的通道参数配置
							bySupport2 & 0x10,  表示支持布防报警回传信息（仅支持抓拍机报警 新老报警结构）
							bySupport2 & 0x20,  表示是否支持单独获取设备状态子项
							bySupport2 & 0x40,  表示是否是码流加密设备*/
                public ushort wDevType;              //设备型号
                public byte bySupport3; //能力集扩展，位与结果为0表示不支持，1表示支持
                                        //bySupport3 & 0x1, 表示是否多码流
                                        // bySupport3 & 0x4 表示支持按组配置， 具体包含 通道图像参数、报警输入参数、IP报警输入、输出接入参数、
                                        // 用户参数、设备工作状态、JPEG抓图、定时和时间抓图、硬盘盘组管理 
                                        //bySupport3 & 0x8为1 表示支持使用TCP预览、UDP预览、多播预览中的"延时预览"字段来请求延时预览（后续都将使用这种方式请求延时预览）。而当bySupport3 & 0x8为0时，将使用 "私有延时预览"协议。
                                        //bySupport3 & 0x10 表示支持"获取报警主机主要状态（V40）"。
                                        //bySupport3 & 0x20 表示是否支持通过DDNS域名解析取流

                public byte byMultiStreamProto;//是否支持多码流,按位表示,0-不支持,1-支持,bit1-码流3,bit2-码流4,bit7-主码流，bit-8子码流
                public byte byStartDChan;               //起始数字通道号,0表示无效
                public byte byStartDTalkChan;   //起始数字对讲通道号，区别于模拟对讲通道号，0表示无效
                public byte byHighDChanNum;             //数字通道个数，高位
                public byte bySupport4;
                public byte byLanguageType;// 支持语种能力,按位表示,每一位0-不支持,1-支持  
                                           //  byLanguageType 等于0 表示 老设备
                                           //  byLanguageType & 0x1表示支持中文
                                           //  byLanguageType & 0x2表示支持英文
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes2;		//保留
        }
}
