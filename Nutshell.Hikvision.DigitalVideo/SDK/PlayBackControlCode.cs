

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
	public enum PlayBackControlCode : uint
	{
		NET_DVR_PLAYSTART = 1, //开始播放
		NET_DVR_PLAYSTOP = 2, //停止播放
		NET_DVR_PLAYPAUSE = 3, //暂停播放
		NET_DVR_PLAYRESTART = 4, //恢复播放
		NET_DVR_PLAYFAST = 5, //快放
		NET_DVR_PLAYSLOW = 6, //慢放
		NET_DVR_PLAYNORMAL = 7, //正常速度
		NET_DVR_PLAYFRAME = 8, //单帧放
		NET_DVR_PLAYSTARTAUDIO = 9, //打开声音
		NET_DVR_PLAYSTOPAUDIO = 10, //关闭声音
		NET_DVR_PLAYAUDIOVOLUME = 11, //调节音量
		NET_DVR_PLAYSETPOS = 12, //改变文件回放的进度
		NET_DVR_PLAYGETPOS = 13, //获取文件回放的进度
		NET_DVR_PLAYGETTIME = 14, //获取当前已经播放的时间(按文件回放的时候有效)
		NET_DVR_PLAYGETFRAME = 15, //获取当前已经播放的帧数(按文件回放的时候有效)
		NET_DVR_GETTOTALFRAMES = 16, //获取当前播放文件总的帧数(按文件回放的时候有效)
		NET_DVR_GETTOTALTIME = 17, //获取当前播放文件总的时间(按文件回放的时候有效)
		NET_DVR_THROWBFRAME = 20, //丢B帧
		NET_DVR_SETSPEED = 24, //设置码流速度
		NET_DVR_KEEPALIVE = 25, //保持与设备的心跳(如果回调阻塞，建议2秒发送一次)
		NET_DVR_PLAYSETTIME = 26, //按绝对时间定位
		NET_DVR_PLAYGETTOTALLEN = 27, //获取按时间回放对应时间段内的所有文件的总长度
		NET_DVR_PLAY_FORWARD = 29, //倒放切换为正放
		NET_DVR_PLAY_REVERSE = 30, //正放切换为倒放
		NET_DVR_SET_TRANS_TYPE = 32, //设置转封装类型
		NET_DVR_PLAY_CONVERT = 33 //正放切换为倒放
	}
}
