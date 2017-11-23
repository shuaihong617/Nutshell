namespace Nutshell.Hikvision.SmartVision.Sdk
{
        public struct FrameOutInformation
        {
                public ushort nWidth;             // 图像宽
                public ushort nHeight;            // 图像高
                MvScPixelType enPixelType;        // 像素或图片格式

                public uint nTriggerIndex;      // 触发序号（仅在电平触发时有效）
                public uint nFrameNum;          // 帧号
                public uint nFrameLen;          // 当前帧数据大小
                public uint nTimeStampHigh;     // 时间戳高32位
                public uint nTimeStampLow;      // 时间戳低32位

                public uint nResultType;        // 输出的消息类型

                public uchar chResult[MV_SC_MAX_RESULT_SIZE];    // 根据消息类型对应不同的结构体

                public uint nFrameLenForCutout; // 抠面单后的图片数据大小

                public uint bFlaseTrigger;       // 是否误触发
                public uint nFocusScore;       //  聚焦得分

                public uint nReserved[5];       // 保留 
        }
}