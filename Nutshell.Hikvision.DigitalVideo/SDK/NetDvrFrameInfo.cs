namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        public struct NetDvrFrameInfo
        {
                public int Width;
                public int Height;
                public int Stamp;
                public FrameDataFormat FrameDataFormat;
                public int FrameRate;
                public uint FrameNum;

                public void Init()
                {
                        Width = 0;
                        Height = 0;
                        Stamp = 0;
                        FrameDataFormat = 0;
                        FrameRate = 0;
                        FrameNum = 0;
                }

                public override string ToString()
                {
                        return $"帧信息： 宽{Width,10:d} 高{Height,10:d} 帧戳{Stamp,10:d} 类型{FrameDataFormat,10:d} 帧率{FrameRate,10:d} 编号{FrameNum,10:d}";
                }
        }
}
