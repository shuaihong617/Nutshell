namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        public enum DVRConfigType:uint
        {

                //压缩参数 (NET_DVR_COMPRESSIONCFG_V30结构)
                NET_DVR_GET_COMPRESSCFG_V30 = 1040,
                NET_DVR_SET_COMPRESSCFG_V30 = 1041,

                NET_DVR_GET_CCDPARAMCFG = 1067, //IPC获取CCD参数配置
                NET_DVR_SET_CCDPARAMCFG = 1068, //IPC设置CCD参数配置
        }
}
