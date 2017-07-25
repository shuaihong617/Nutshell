using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        //白平衡配置
        [StructLayout(LayoutKind.Sequential)]
        public struct NetDvrWhiteBalance
        {
                public byte byWhiteBalanceMode; /*0-手动白平衡（MWB）,1-自动白平衡1（AWB1）,2-自动白平衡2 (AWB2),3-自动控制改名为锁定白平衡(Locked WB)，
	                         4-室外(Indoor)，5-室内(Outdoor)6-日光灯(Fluorescent Lamp)，7-钠灯(Sodium Lamp)，
	                         8-自动跟踪(Auto-Track)9-一次白平衡(One Push)，10-室外自动(Auto-Outdoor)，
	                         11-钠灯自动 (Auto-Sodiumlight)，12-水银灯(Mercury Lamp)，13-自动白平衡(Auto)，
	                         14-白炽灯 (IncandescentLamp)，15-暖光灯(Warm Light Lamp)，16-自然光(Natural Light) */
                public byte byWhiteBalanceModeRGain; /*手动白平衡时有效，手动白平衡 R增益*/
                public byte byWhiteBalanceModeBGain; /*手动白平衡时有效，手动白平衡 B增益*/
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes;
        }
}
