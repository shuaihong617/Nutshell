/***************************************************************************************************
* 
* 版权信息：版权所有 (c) 2015, 杭州海康威视数字技术股份有限公司, 保留所有权利
* 
* 文件名称：MvGigEDevice.h
* 摘    要：GigE设备控制类，继承设备基类的方法
*
* 当前版本：1.0.0.0
* 作    者：陈祖文
* 日    期：2015-02-03
* 备    注：新建
***************************************************************************************************/
#ifndef __MV_GIGE_DEVICE_H__
#define __MV_GIGE_DEVICE_H__

#include "MvDeviceBase.h"

namespace MvCamCtrl
{
    class CMvGigEDevice : public IMvDevice
    {
    public:

        // 打开设备
        virtual int     Open(unsigned int nAccessMode = MV_ACCESS_Exclusive, unsigned short nSwitchoverKey = 0);


        // 关闭设备
        virtual int     Close();


        // 判断设备的状态，仅当返回false时，可打开设备
        virtual bool    IsOpen();


        // 开启抓图
        virtual int     StartGrabbing();


        // 停止抓图
        virtual int     StopGrabbing();


        // 获取设备信息
        virtual int     GetDeviceInfo(MV_CC_DEVICE_INFO&);


        /** @fn     GetGenICamXML(unsigned char* pData, unsigned int nDataSize, unsigned int* pnDataLen)
         *  @brief  获取设备的XML文件
         *  @param  pData           [IN][OUT]   - 待拷入的缓存地址
                    nDataSize       [IN]        - 缓存大小
                    pnDataLen       [OUT]       - xml 文件数据长度
         *  
         *  @return 成功，返回MV_OK；失败，返回错误码
         *  @note   当pData为NULL或nDataSize比实际的xml文件小时，不拷贝数据，由pnDataLen返回xml文件大小；
         *          当pData为有效缓存地址，且缓存足够大时，拷贝完整数据，并由pnDataLen返回xml文件大小。
         */
        virtual int     GetGenICamXML(unsigned char* pData, unsigned int nDataSize, unsigned int* pnDataLen);


        /** @fn     GetOneFrame(unsigned char * pData , unsigned int nDataSize, MV_FRAME_OUT_INFO* pFrameInfo)
         *  @brief  获取一帧图像数据
         *  @param  pData           [IN][OUT]   - 数据指针
                    nDataLen        [IN]        - 数据长度
                    pFrameInfo      [OUT]       - 输出的帧信息
         *  
         *  @return 成功，返回MV_OK；失败，返回错误码
         */
        virtual int     GetOneFrame(unsigned char * pData , unsigned int nDataSize, MV_FRAME_OUT_INFO* pFrameInfo);


        // 获取GenICam使用的传输层代理类
        virtual TlProxy     GetTlProxy();


        virtual ~CMvGigEDevice( void );


        CMvGigEDevice( const MV_CC_DEVICE_INFO* pInfo );


        // 获取网络信息
        virtual int     GetNetTransInfo(MV_NETTRANS_INFO* pstInfo);


        // 强制IP
        virtual int     ForceIp(unsigned int nIP);


        // 配置IP方式
        virtual int     SetIpConfig(unsigned int nType);


        // 获取各种类型的信息
        virtual int     GetAllMatchInfo(MV_ALL_MATCH_INFO* pstInfo);
        // add new interface here...

        // 注册消息异常回调
        virtual int     RegisterExceptionCallBack(void(__stdcall* cbException)(unsigned int nMsgType, void* pUser),
                                                    void* pUser);


        virtual int     SetSingleShot(void(__stdcall* cbSingleShot)(unsigned char* pData , unsigned int nDataLen, 
                                                                    MV_FRAME_OUT_INFO* pFrameInfo, void* pUser), 
                                        void* pUser);

        // 设置设备采集模式
        virtual int     SetAcquisitionMode(MV_CAM_ACQUISITION_MODE enMode);


        // 设备本地升级
        virtual int     LocalUpgrade(const void *pFilePathName);

        // 获取当前升级进度
        virtual int     GetUpgradeProcess(unsigned int* pnProcess);

        virtual int     GetOptimalPacketSize();

        // 显示一帧图像
        virtual int     Display(void* hWnd);

        virtual int     SetNetTransMode(unsigned int nType);

        virtual int     ReadMemory(void *pBuffer, __int64 nAddress, __int64 nLength);

        virtual int     WriteMemory(const void *pBuffer, __int64 nAddress, __int64 nLength);

        // 返回值 0驱动不正常，1驱动正常工作
        virtual int     IsDriverWorking();

        // 0：不丢弃；1：丢弃
        virtual int     SetThrowAbnormalImage(int bThrow);


    private:
        CDevRefs*       m_pRefs;
    };


}

#endif /* __MV_GIGE_DEVICE_H__ */
