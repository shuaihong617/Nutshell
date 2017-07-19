using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Hikvision.DigitalVideo.SDK;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        public struct NET_DVR_CAMERAPARAMCFG
        {
                public uint dwSize;
                public NET_DVR_VIDEOEFFECT struVideoEffect;/*亮度、对比度、饱和度、锐度、色调配置*/
                public NET_DVR_GAIN struGain;/*自动增益*/
                public NET_DVR_WHITEBALANCE struWhiteBalance;/*白平衡*/
                public NET_DVR_EXPOSURE struExposure; /*曝光控制*/
                public NET_DVR_GAMMACORRECT struGammaCorrect;/*Gamma校正*/
                public NET_DVR_WDR struWdr;/*宽动态*/
                public NET_DVR_DAYNIGHT struDayNight;/*日夜转换*/
                public NET_DVR_BACKLIGHT struBackLight;/*背光补偿*/
                public NET_DVR_NOISEREMOVE struNoiseRemove;/*数字降噪*/
                public byte byPowerLineFrequencyMode; /*0-50HZ; 1-60HZ*/
                public byte byIrisMode; /*0 自动光圈 1手动光圈*/
                public byte byMirror;  /* 镜像：0 off，1- leftright，2- updown，3-center */
                public byte byDigitalZoom;  /*数字缩放:0 dsibale  1 enable*/
                public byte byDeadPixelDetect;   /*坏点检测,0 dsibale  1 enable*/
                public byte byBlackPwl;/*黑电平补偿 ,  0-255*/
                public byte byEptzGate;// EPTZ开关变量:0-不启用电子云台，1-启用电子云台
                public byte byLocalOutputGate;//本地输出开关变量0-本地输出关闭1-本地BNC输出打开 2-HDMI输出关闭  
                //20-HDMI_720P50输出开
                //21-HDMI_720P60输出开
                //22-HDMI_1080I60输出开
                //23-HDMI_1080I50输出开
                //24-HDMI_1080P24输出开
                //25-HDMI_1080P25输出开
                //26-HDMI_1080P30输出开
                //27-HDMI_1080P50输出开
                //28-HDMI_1080P60输出开
                //40-SDI_720P50,
                //41-SDI_720P60,
                //42-SDI_1080I50,
                //43-SDI_1080I60,
                //44-SDI_1080P24,
                //45-SDI_1080P25,
                //46-SDI_1080P30,
                //47-SDI_1080P50,
                //48-SDI_1080P60
                public byte byCoderOutputMode;//编码器fpga输出模式0直通3像素搬家
                public byte byLineCoding; //是否开启行编码：0-否，1-是
                public byte byDimmerMode; //调光模式：0-半自动，1-自动
                public byte byPaletteMode; //调色板：0-白热，1-黑热，2-调色板2，…，8-调色板8
                public byte byEnhancedMode; //增强方式（探测物体周边）：0-不增强，1-1，2-2，3-3，4-4
                public byte byDynamicContrastEN;    //动态对比度增强 0-1
                public byte byDynamicContrast;    //动态对比度 0-100
                public byte byJPEGQuality;    //JPEG图像质量 0-100
                public NET_DVR_CMOSMODECFG struCmosModeCfg;//CMOS模式下前端参数配置，镜头模式从能力集获取
                public byte byFilterSwitch; //滤波开关：0-不启用，1-启用
                public byte byFocusSpeed; //镜头调焦速度：0-10
                public byte byAutoCompensationInterval; //定时自动快门补偿：1-120，单位：分钟
                public byte bySceneMode;  //场景模式：0-室外，1-室内，2-默认，3-弱光
        }
}
