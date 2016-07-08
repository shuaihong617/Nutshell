/***************************************************************************************************
* 
* 版权信息：版权所有 (c) 2015, 杭州海康威视数字技术股份有限公司, 保留所有权利
* 
* 文件名称：MvErrorDefine.h
* 摘    要：错误码定义
*
* 当前版本：1.0.0.0
* 作    者：陈祖文
* 日    期：2015-01-28
* 备    注：新建
***************************************************************************************************/

#ifndef _MV_ERROR_DEFINE_H_
#define _MV_ERROR_DEFINE_H_

//正确码定义
#define MV_OK                   0x00000000  ///< 成功，无错误

//通用错误码定义:范围0x80000000-0x800000FF
#define MV_E_HANDLE             0x80000000  ///< 错误或无效的句柄
#define MV_E_SUPPORT            0x80000001  ///< 不支持的功能
#define MV_E_BUFOVER            0x80000002  ///< 缓存已满
#define MV_E_CALLORDER          0x80000003  ///< 函数调用顺序错误
#define MV_E_PARAMETER          0x80000004  ///< 错误的参数
#define MV_E_RESOURCE           0x80000006  ///< 资源申请失败
#define MV_E_NODATA             0x80000007  ///< 无数据
#define MV_E_PRECONDITION       0x80000008  ///< 前置条件有误，或运行环境已发生变化
#define MV_E_VERSION            0x80000009  ///< 版本不匹配
#define MV_E_NOENOUGH_BUF       0x8000000A  ///< 传入的内存空间不足
#define MV_E_UNKNOW             0x800000FF  ///< 未知的错误

// GenICam系列错误:范围0x80000100-0x800001FF
#define MV_E_GC_GENERIC         0x80000100  ///< 通用错误
#define MV_E_GC_ARGUMENT        0x80000101  ///< 参数非法
#define MV_E_GC_RANGE           0x80000102  ///< 值超出范围
#define MV_E_GC_PROPERTY        0x80000103  ///< 属性
#define MV_E_GC_RUNTIME         0x80000104  ///< 运行环境有问题
#define MV_E_GC_LOGICAL         0x80000105  ///< 逻辑错误
#define MV_E_GC_ACCESS          0x80000106  ///< 访问权限有误
#define MV_E_GC_TIMEOUT         0x80000107  ///< 超时
#define MV_E_GC_DYNAMICCAST     0x80000108  ///< 转换异常
#define MV_E_GC_UNKNOW          0x800001FF  ///< GenICam未知错误

//GigE_STATUS对应的错误码:范围0x80000200-0x800002FF
#define MV_E_NOT_IMPLEMENTED    0x80000200  ///< 命令不被设备支持
#define MV_E_INVALID_ADDRESS    0x80000201  ///< 访问的目标地址不存在
#define MV_E_WRITE_PROTECT      0x80000202  ///< 目标地址不可写
#define MV_E_ACCESS_DENIED      0x80000203  ///< 访问无权限
#define MV_E_BUSY               0x80000204  ///< 设备忙，或网络断开
#define MV_E_PACKET             0x80000205  ///< 网络包数据错误
#define MV_E_NETER              0x80000206  ///< 网络相关错误


//USB_STATUS对应的错误码:范围0x80000300-0x800003FF
#define MV_E_USB_READ           0x80000300      ///< 读usb出错
#define MV_E_USB_WRITE          0x80000301      ///< 写usb出错
#define MV_E_USB_DEVICE         0x80000302      ///< 设备异常
#define MV_E_USB_GENICAM        0x80000303      ///< GenICam相关错误
#define MV_E_USB_UNKNOW         0x800003FF      ///< USB未知的错误

//升级时对应的错误码:范围0x80000400-0x800004FF
#define MV_E_UPG_FILE_MISMATCH     0x80000400 ///< 升级固件不匹配
#define MV_E_UPG_LANGUSGE_MISMATCH 0x80000401 ///< 升级固件语言不匹配
#define MV_E_UPG_CONFLICT          0x80000402 ///< 升级冲突（设备已经在升级了再次请求升级即返回此错误）
#define MV_E_UPG_INNER_ERR         0x80000403 ///< 升级时相机内部出现错误
#define MV_E_UPG_UNKNOW            0x800004FF ///< 升级时未知错误





#endif //_MV_ERROR_DEFINE_H_
