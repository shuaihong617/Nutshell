using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        //视频参数配置
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_VIDEOEFFECT
        {
                public byte byBrightnessLevel; /*0-100*/
                public byte byContrastLevel; /*0-100*/
                public byte bySharpnessLevel; /*0-100*/
                public byte bySaturationLevel; /*0-100*/
                public byte byHueLevel; /*0-100,（保留）*/
                public byte byEnableFunc; //使能，按位表示，bit0-SMART IR(防过曝)，bit1-低照度,bit2-强光抑制使能，0-否，1-是
                public byte byLightInhibitLevel; //强光抑制等级，[1-3]表示等级
                public byte byGrayLevel; //灰度值域，0-[0-255]，1-[16-235]
        }

}
