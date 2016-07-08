/***************************************************************************************************
* 
* 版权信息：版权所有 (c) 2015, 杭州海康威视数字技术股份有限公司, 保留所有权利
* 
* 文件名称：CameraParams.h
* 摘    要：相机参数定义
*
* 当前版本：1.0.0.0
* 作    者：陈祖文
* 日    期：2015-02-03
* 备    注：新建
* 修改：    1. 增加了MV_USB3_DEVICE_INFO结构体定义
           2. 修改了MV_CC_DEVICE_INFO结构体定义，在该结构体中增加MV_USB3_DEVICE_INFO

***************************************************************************************************/
#ifndef _MV_CAMERA_PARAMS_H_
#define _MV_CAMERA_PARAMS_H_

#include "PixelType.h"

// 设备类型定义
#define MV_UNKNOW_DEVICE        0x00000000          // 未知设备类型，保留意义
#define MV_GIGE_DEVICE          0x00000001          // GigE设备
#define MV_1394_DEVICE          0x00000002          // 1394-a/b 设备
#define MV_USB_DEVICE           0x00000004          // USB3.0 设备
#define MV_CAMERALINK_DEVICE    0x00000008          // CameraLink设备

typedef struct _MV_GIGE_DEVICE_INFO_
{
    unsigned int        nIpCfgOption;        
    unsigned int        nIpCfgCurrent;       //IP configuration:bit31-static bit30-dhcp bit29-lla          
    unsigned int        nCurrentIp;          //curtent ip          
    unsigned int        nCurrentSubNetMask;  //curtent subnet mask             
    unsigned int        nDefultGateWay;      //current gateway
    unsigned char       chManufacturerName[32];
    unsigned char       chModelName[32];
    unsigned char       chDeviceVersion[32];
    unsigned char       chManufacturerSpecificInfo[48];
    unsigned char       chSerialNumber[16];
    unsigned char       chUserDefinedName[16];      

    unsigned int        nNetExport;         // 网口IP地址

    unsigned int        nReserved[4];

}MV_GIGE_DEVICE_INFO;

#define INFO_MAX_BUFFER_SIZE 64
typedef struct _MV_USB3_DEVICE_INFO_
{
    unsigned char           CrtlInEndPoint;                        //控制输入端点
    unsigned char           CrtlOutEndPoint;                       //控制输出端点
    unsigned char           StreamEndPoint;                        //流端点
    unsigned char           EventEndPoint;                         //事件端点
    unsigned short          idVendor;                              //供应商ID号
    unsigned short          idProduct;                             //产品ID号
    unsigned int            nDeviceNumber;                         //设备序列号
    unsigned char           chDeviceGUID[INFO_MAX_BUFFER_SIZE];    //设备GUID号
    unsigned char           chVendorName[INFO_MAX_BUFFER_SIZE];    //供应商名字
    unsigned char           chModelName[INFO_MAX_BUFFER_SIZE];     //型号名字
    unsigned char           chFamilyName[INFO_MAX_BUFFER_SIZE];    //家族名字
    unsigned char           chDeviceVersion[INFO_MAX_BUFFER_SIZE];  //设备版本号
    unsigned char           chManufacturerName[INFO_MAX_BUFFER_SIZE]; //制造商名字
    unsigned char           chSerialNumber[INFO_MAX_BUFFER_SIZE];      //序列号
    unsigned char           chUserDefinedName[INFO_MAX_BUFFER_SIZE];  //用户自定义名字
    unsigned int            nReserved[4];                             //保留字节
}MV_USB3_DEVICE_INFO;

// 设备信息
typedef struct _MV_CC_DEVICE_INFO_
{
    // common info 
    unsigned short      nMajorVer;
    unsigned short      nMinorVer;
    unsigned int        nMacAddrHigh;               // MAC 地址
    unsigned int        nMacAddrLow;

    unsigned int        nTLayerType;                // 设备传输层协议类型，e.g. MV_GIGE_DEVICE

    unsigned int        nReserved[4];

    union
    {
        MV_GIGE_DEVICE_INFO stGigEInfo;
        MV_USB3_DEVICE_INFO stUsb3VInfo; 
        // more ...
    }SpecialInfo;

}MV_CC_DEVICE_INFO;

// 网络传输的相关信息
typedef struct _MV_NETTRANS_INFO_
{
    __int64         nReviceDataSize;    // 已接收数据大小  [统计StartGrabbing和StopGrabbing之间的数据量]
    int             nThrowFrameCount;   // 丢帧数量
    unsigned int    nReserved[5];

}MV_NETTRANS_INFO;


// 最多支持的传输层实例个数
#define MV_MAX_TLS_NUM          8
// 最大支持的设备个数
#define MV_MAX_DEVICE_NUM      256

// 设备信息列表
typedef struct _MV_CC_DEVICE_INFO_LIST_
{
    unsigned int            nDeviceNum;                         // 在线设备数量
    MV_CC_DEVICE_INFO*      pDeviceInfo[MV_MAX_DEVICE_NUM];     // 支持最多256个设备

}MV_CC_DEVICE_INFO_LIST;


// 输出帧的信息
typedef struct _MV_FRAME_OUT_INFO_
{
    unsigned short      nWidth;             // 图像宽
    unsigned short      nHeight;            // 图像高
    MvGvspPixelType     enPixelType;        // 像素格式

    /*以下字段暂不支持*/
    unsigned int        nFrameNum;          // 帧号
    unsigned int        nDevTimeStampHigh;  // 时间戳高32位
    unsigned int        nDevTimeStampLow;   // 时间戳低32位
    unsigned int        nReserved0;         // 保留，8字节对齐
    __int64             nHostTimeStamp;     // 主机生成的时间戳

    unsigned int        nReserved[4];       // 保留
}MV_FRAME_OUT_INFO;


// 采集模式
typedef enum _MV_CAM_ACQUISITION_MODE_
{
    MV_ACQ_MODE_SINGLE      = 0,            // 单帧模式
    MV_ACQ_MODE_MUTLI       = 1,            // 多帧模式
    MV_ACQ_MODE_CONTINUOUS  = 2,            // 持续采集模式

}MV_CAM_ACQUISITION_MODE;

// 增益模式
typedef enum _MV_CAM_GAIN_MODE_
{
    MV_GAIN_MODE_OFF        = 0,            // 关闭
    MV_GAIN_MODE_ONCE       = 1,            // 一次
    MV_GAIN_MODE_CONTINUOUS = 2,            // 连续

}MV_CAM_GAIN_MODE;

// 自动曝光模式
typedef enum _MV_CAM_EXPOSURE_AUTO_MODE_
{
    MV_EXPOSURE_AUTO_MODE_OFF        = 0,            // 关闭
    MV_EXPOSURE_AUTO_MODE_ONCE       = 1,            // 一次
    MV_EXPOSURE_AUTO_MODE_CONTINUOUS = 2,            // 连续

}MV_CAM_EXPOSURE_AUTO_MODE;

typedef enum _MV_CAM_TRIGGER_MODE_
{
    MV_TRIGGER_MODE_OFF         = 0,            // 关闭
    MV_TRIGGER_MODE_ON          = 1,            // 打开

}MV_CAM_TRIGGER_MODE;

typedef enum _MV_CAM_GAMMA_SELECTOR_
{
    MV_GAMMA_SELECTOR_USER      = 1,
    MV_GAMMA_SELECTOR_SRGB      = 2,

}MV_CAM_GAMMA_SELECTOR;

typedef enum _MV_CAM_BALANCEWHITE_AUTO_
{
    MV_BALANCEWHITE_AUTO_OFF            = 0,
    MV_BALANCEWHITE_AUTO_ONCE           = 1,
    MV_BALANCEWHITE_AUTO_CONTINUOUS     = 2,            // 连续

}MV_CAM_BALANCEWHITE_AUTO;

typedef enum _MV_CAM_TRIGGER_SOURCE_
{
    MV_TRIGGER_SOURCE_LINE0             = 0,
    MV_TRIGGER_SOURCE_LINE1             = 1,
    MV_TRIGGER_SOURCE_LINE2             = 2,
    MV_TRIGGER_SOURCE_LINE3             = 3,
    MV_TRIGGER_SOURCE_COUNTER0          = 4,

    MV_TRIGGER_SOURCE_SOFTWARE          = 7,

}MV_CAM_TRIGGER_SOURCE;


// GigEVision IP Configuration
#define MV_IP_CFG_STATIC        0x01000000
#define MV_IP_CFG_DHCP          0x02000000
#define MV_IP_CFG_LLA           0x04000000

// GigEVision Net Transfer Mode
#define MV_NET_TRANS_DRIVER     0x00000001
#define MV_NET_TRANS_SOCKET     0x00000002


// 信息类型
#define MV_MATCH_TYPE_NET_DETECT             0x00000001      // 网络流量和丢包信息
#define MV_MATCH_TYPE_USB_DETECT             0x00000002      // host接收到来自U3V设备的字节总数


// 某个节点对应的子节点个数最大值
#define MV_MAX_XML_NODE_NUM_C       128

// 节点名称字符串最大长度
#define MV_MAX_XML_NODE_STRLEN_C    64

//节点String值最大长度
#define MV_MAX_XML_STRVALUE_STRLEN_C 64

// 节点描述字段最大长度
#define MV_MAX_XML_DISC_STRLEN_C    512

// 最多的单元数
#define MV_MAX_XML_ENTRY_NUM        10

// 父节点个数上限
#define MV_MAX_XML_PARENTS_NUM      8

//每个已经实现单元的名称长度
#define MV_MAX_XML_SYMBOLIC_STRLEN_C 64

#define MV_MAX_XML_SYMBOLIC_NUM      64

// 全匹配的一种信息结构体
typedef struct _MV_ALL_MATCH_INFO_
{
    unsigned int    nType;          // 需要输出的信息类型，e.g. MV_MATCH_TYPE_NET_DETECT
    void*           pInfo;          // 输出的信息缓存，由调用者分配
    unsigned int    nInfoSize;      // 信息缓存的大小

}MV_ALL_MATCH_INFO;

//  网络流量和丢包信息反馈结构体，对应类型为 MV_MATCH_TYPE_NET_DETECT
typedef struct _MV_MATCH_INFO_NET_DETECT_
{
    __int64         nReviceDataSize;    // 已接收数据大小  [统计StartGrabbing和StopGrabbing之间的数据量]
    __int64         nLostPacketCount;   // 丢失的包数量
    unsigned int    nLostFrameCount;    // 丢帧数量
    unsigned int    nReserved[5];          // 保留
}MV_MATCH_INFO_NET_DETECT;

// host收到从u3v设备端的总字节数，对应类型为 MV_MATCH_TYPE_USB_DETECT
typedef struct _MV_MATCH_INFO_USB_DETECT_
{
    __int64         nReviceDataSize;      // 已接收数据大小    [统计OpenDevicce和CloseDevice之间的数据量]
    unsigned int    nReserved[4];         // 保留
}MV_MATCH_INFO_USB_DETECT;

typedef struct _MV_IMAGE_BASIC_INFO_
{
    // width
    unsigned short      nWidthValue;
    unsigned short      nWidthMin;
    unsigned int        nWidthMax;
    unsigned int        nWidthInc;

    // height
    unsigned int        nHeightValue;
    unsigned int        nHeightMin;
    unsigned int        nHeightMax;
    unsigned int        nHeightInc;

    // framerate
    float               fFrameRateValue;
    float               fFrameRateMin;
    float               fFrameRateMax;

    // 像素格式
    unsigned int        enPixelType;                // 当前的像素格式
    unsigned int        nSupportedPixelFmtNum;      // 支持的像素格式种类
    unsigned int        enPixelList[MV_MAX_XML_SYMBOLIC_NUM];
    unsigned int        nReserved[8];

}MV_IMAGE_BASIC_INFO;

//  异常消息类型
#define MV_EXCEPTION_DEV_DISCONNECT     0x00008001      // 设备断开连接
#define MV_EXCEPTION_VERSION_CHECK      0x00008002      // SDK与驱动版本不匹配


// 设备的访问模式
#define MV_ACCESS_Exclusive                                         1
#define MV_ACCESS_ExclusiveWithSwitch                               2
#define MV_ACCESS_Control                                           3
#define MV_ACCESS_ControlWithSwitch                                 4
#define MV_ACCESS_ControlSwitchEnable                               5
#define MV_ACCESS_ControlSwitchEnableWithKey                        6
#define MV_ACCESS_Monitor                                           7


/************************************************************************/
/* 封装了GenICam的C接口相关参数定义                                     */
/************************************************************************/

// 每个节点对应的接口类型
enum MV_XML_InterfaceType
{
    IFT_IValue,         //!> IValue interface
    IFT_IBase,          //!> IBase interface
    IFT_IInteger,       //!> IInteger interface
    IFT_IBoolean,       //!> IBoolean interface
    IFT_ICommand,       //!> ICommand interface
    IFT_IFloat,         //!> IFloat interface
    IFT_IString,        //!> IString interface
    IFT_IRegister,      //!> IRegister interface
    IFT_ICategory,      //!> ICategory interface
    IFT_IEnumeration,   //!> IEnumeration interface
    IFT_IEnumEntry,     //!> IEnumEntry interface
    IFT_IPort,          //!> IPort interface
};

// 节点的访问模式
enum MV_XML_AccessMode
{
    AM_NI,          //!< Not implemented
    AM_NA,          //!< Not available
    AM_WO,          //!< Write Only
    AM_RO,          //!< Read Only
    AM_RW,          //!< Read and Write
    AM_Undefined,   //!< Object is not yet initialized
    AM_CycleDetect, //!< used internally for AccessMode cycle detection

};

enum MV_XML_Visibility
{
    V_Beginner      = 0,    //!< Always visible
    V_Expert        = 1,    //!< Visible for experts or Gurus
    V_Guru          = 2,    //!< Visible for Gurus
    V_Invisible     = 3,    //!< Not Visible
    V_Undefined     = 99    //!< Object is not yet initialized
};




//

// 单个节点基本属性
typedef struct _MV_XML_NODE_FEATURE_
{
    MV_XML_InterfaceType    enType;                             // 节点类型
    MV_XML_Visibility       enVisivility;                       //是否可见
    char                    strDescription[MV_MAX_XML_DISC_STRLEN_C];//节点描述
    char                    strDisplayName[MV_MAX_XML_NODE_STRLEN_C];//显示名称
    char                    strName[MV_MAX_XML_NODE_STRLEN_C];  // 节点名
    char                    strToolTip[MV_MAX_XML_DISC_STRLEN_C];  //提示

    unsigned int            nReserved[4];
}MV_XML_NODE_FEATURE;

// 节点列表
typedef struct _MV_XML_NODES_LIST_
{
    unsigned int            nNodeNum;       // 节点个数
    MV_XML_NODE_FEATURE     stNodes[MV_MAX_XML_NODE_NUM_C];
}MV_XML_NODES_LIST;



typedef struct _MV_XML_FEATURE_Value_
{
    MV_XML_InterfaceType    enType;                             // 节点类型
    char                    strDescription[MV_MAX_XML_DISC_STRLEN_C];//节点描述
    char                    strDisplayName[MV_MAX_XML_NODE_STRLEN_C];//显示名称
    char                    strName[MV_MAX_XML_NODE_STRLEN_C];  // 节点名
    char                    strToolTip[MV_MAX_XML_DISC_STRLEN_C];  //提示
    unsigned int            nReserved[4];
}MV_XML_FEATURE_Value;

typedef struct _MV_XML_FEATURE_Base_
{
    MV_XML_AccessMode   enAccessMode;       // 访问模式
}MV_XML_FEATURE_Base;

typedef struct _MV_XML_FEATURE_Integer_
{
    char                strName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDisplayName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDescription[MV_MAX_XML_DISC_STRLEN_C];
    char                strToolTip[MV_MAX_XML_DISC_STRLEN_C];

    MV_XML_Visibility   enVisivility;                       //是否可见
    MV_XML_AccessMode   enAccessMode;       // 访问模式
    int                 bIsLocked;          // 是否锁定。0-否；1-是
    __int64             nValue;             // 当前值
    __int64             nMinValue;          // 最小值
    __int64             nMaxValue;          // 最大值
    __int64             nIncrement;         // 增量

    unsigned int        nReserved[4];

}MV_XML_FEATURE_Integer;

typedef struct _MV_XML_FEATURE_Boolean_
{
    char                strName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDisplayName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDescription[MV_MAX_XML_DISC_STRLEN_C];
    char                strToolTip[MV_MAX_XML_DISC_STRLEN_C];

    MV_XML_Visibility   enVisivility;                       //是否可见
    MV_XML_AccessMode   enAccessMode;       // 访问模式
    int                 bIsLocked;          // 是否锁定。0-否；1-是
    bool                bValue;             // 当前值

    unsigned int        nReserved[4];
}MV_XML_FEATURE_Boolean;

typedef struct _MV_XML_FEATURE_Command_
{
    char                strName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDisplayName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDescription[MV_MAX_XML_DISC_STRLEN_C];
    char                strToolTip[MV_MAX_XML_DISC_STRLEN_C];

    MV_XML_Visibility   enVisivility;                       //是否可见
    MV_XML_AccessMode   enAccessMode;       // 访问模式
    int                 bIsLocked;          // 是否锁定。0-否；1-是

    unsigned int        nReserved[4];
}MV_XML_FEATURE_Command;

typedef struct _MV_XML_FEATURE_Float_
{
    char                strName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDisplayName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDescription[MV_MAX_XML_DISC_STRLEN_C];
    char                strToolTip[MV_MAX_XML_DISC_STRLEN_C];

    MV_XML_Visibility       enVisivility;                       //是否可见
    MV_XML_AccessMode   enAccessMode;       // 访问模式
    int                 bIsLocked;          // 是否锁定。0-否；1-是
    double              dfValue;             // 当前值
    double              dfMinValue;          // 最小值
    double              dfMaxValue;          // 最大值
    double              dfIncrement;         // 增量

    unsigned int        nReserved[4];
}MV_XML_FEATURE_Float;

typedef struct _MV_XML_FEATURE_String_
{
    char                strName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDisplayName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDescription[MV_MAX_XML_DISC_STRLEN_C];
    char                strToolTip[MV_MAX_XML_DISC_STRLEN_C];

    MV_XML_Visibility       enVisivility;                       //是否可见
    MV_XML_AccessMode   enAccessMode;       // 访问模式
    int                 bIsLocked;          // 是否锁定。0-否；1-是
    char                strValue[MV_MAX_XML_STRVALUE_STRLEN_C];// 当前值

    unsigned int        nReserved[4];
}MV_XML_FEATURE_String;

typedef struct _MV_XML_FEATURE_Register_
{
    char                strName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDisplayName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDescription[MV_MAX_XML_DISC_STRLEN_C];
    char                strToolTip[MV_MAX_XML_DISC_STRLEN_C];

    MV_XML_Visibility       enVisivility;                       //是否可见
    MV_XML_AccessMode   enAccessMode;       // 访问模式
    int                 bIsLocked;          // 是否锁定。0-否；1-是
    __int64             nAddrValue;             // 当前值

    unsigned int        nReserved[4];
}MV_XML_FEATURE_Register;

typedef struct _MV_XML_FEATURE_Category_
{
    char                    strDescription[MV_MAX_XML_DISC_STRLEN_C];//节点描述
    char                    strDisplayName[MV_MAX_XML_NODE_STRLEN_C];//显示名称
    char                    strName[MV_MAX_XML_NODE_STRLEN_C];  // 节点名
    char                    strToolTip[MV_MAX_XML_DISC_STRLEN_C];  //提示

    MV_XML_Visibility       enVisivility;                       //是否可见

    unsigned int            nReserved[4];
}MV_XML_FEATURE_Category;

typedef struct _MV_XML_FEATURE_EnumEntry_
{
    char                strName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDisplayName[MV_MAX_XML_NODE_STRLEN_C];
    char                strDescription[MV_MAX_XML_DISC_STRLEN_C];
    char                strToolTip[MV_MAX_XML_DISC_STRLEN_C];
    int                 bIsImplemented;
    int                 nParentsNum;
    MV_XML_NODE_FEATURE stParentsList[MV_MAX_XML_PARENTS_NUM];

    MV_XML_Visibility       enVisivility;                       //是否可见
    __int64             nValue;             // 当前值
    MV_XML_AccessMode   enAccessMode;       // 访问模式
    int                 bIsLocked;          // 是否锁定。0-否；1-是
    int                 nReserved[8];

}MV_XML_FEATURE_EnumEntry;


typedef struct _MV_XML_FEATURE_Enumeration_
{
    MV_XML_Visibility       enVisivility;                       //是否可见
    char                    strDescription[MV_MAX_XML_DISC_STRLEN_C];//节点描述
    char                    strDisplayName[MV_MAX_XML_NODE_STRLEN_C];//显示名称
    char                    strName[MV_MAX_XML_NODE_STRLEN_C];  // 节点名
    char                    strToolTip[MV_MAX_XML_DISC_STRLEN_C];  //提示

    int                 nSymbolicNum;          // Symbolic数
    char                strCurrentSymbolic[MV_MAX_XML_SYMBOLIC_STRLEN_C];          // 当前Symbolic索引
    char                strSymbolic[MV_MAX_XML_SYMBOLIC_NUM][MV_MAX_XML_SYMBOLIC_STRLEN_C];
    MV_XML_AccessMode   enAccessMode;       // 访问模式
    int                 bIsLocked;          // 是否锁定。0-否；1-是
    __int64             nValue;             // 当前值

    unsigned int        nReserved[4];
}MV_XML_FEATURE_Enumeration;


typedef struct _MV_XML_FEATURE_Port_
{
    MV_XML_Visibility       enVisivility;                       //是否可见
    char                    strDescription[MV_MAX_XML_DISC_STRLEN_C];//节点描述
    char                    strDisplayName[MV_MAX_XML_NODE_STRLEN_C];//显示名称
    char                    strName[MV_MAX_XML_NODE_STRLEN_C];  // 节点名
    char                    strToolTip[MV_MAX_XML_DISC_STRLEN_C];  //提示

    MV_XML_AccessMode       enAccessMode;       // 访问模式
    int                     bIsLocked;          // 是否锁定。0-否；1-是

    unsigned int            nReserved[4];
}MV_XML_FEATURE_Port;



typedef struct _MV_XML_CAMERA_FEATURE_
{
    MV_XML_InterfaceType    enType;
    union
    {
        MV_XML_FEATURE_Integer      stIntegerFeature;
        MV_XML_FEATURE_Float        stFloatFeature;
        MV_XML_FEATURE_Enumeration  stEnumerationFeature;
        MV_XML_FEATURE_String       stStringFeature;
    }SpecialFeature;

}MV_XML_CAMERA_FEATURE;


typedef struct _MVCC_ENUMVALUE_T
{
    unsigned int    nCurValue;      // 当前值
    unsigned int    nSupportedNum;  // 数据的有效数据个数
    unsigned int    nSupportValue[MV_MAX_XML_SYMBOLIC_NUM];

    unsigned int    nReserved[4];
}MVCC_ENUMVALUE;

typedef struct _MVCC_INTVALUE_T
{
    unsigned int    nCurValue;      // 当前值
    unsigned int    nMax;
    unsigned int    nMin;
    unsigned int    nInc;

    unsigned int    nReserved[4];
}MVCC_INTVALUE;

typedef struct _MVCC_FLOATVALUE_T
{
    float           fCurValue;      // 当前值
    float           fMax;
    float           fMin;

    unsigned int    nReserved[4];
}MVCC_FLOATVALUE;

typedef struct _MVCC_STRINGVALUE_T
{
    char   chCurValue[256];      // 当前值

    unsigned int    nReserved[4];
}MVCC_STRINGVALUE;

#endif /* _MV_CAMERA_PARAMS_H_ */
