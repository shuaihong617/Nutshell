// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-03-03
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-03-03
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 错误代码
        /// </summary>
        public enum ErrorCode:uint
        {
                 MV_OK                 =  0x00000000,  // 成功，无错误

                //通用错误码定义:范围0x80000000-0x800000FF
                 MV_E_HANDLE           =  0x80000000 , // 错误或无效的句柄
                 MV_E_SUPPORT          =  0x80000001 , // 不支持的功能
                 MV_E_BUFOVER          =  0x80000002 , // 缓存已满
                 MV_E_CALLORDER        =  0x80000003 , // 函数调用顺序错误
                 MV_E_PARAMETER        =  0x80000004 , // 错误的参数
                 MV_E_RESOURCE         =  0x80000006 , // 资源申请失败
                 MV_E_NODATA           =  0x80000007 , // 无数据
                 MV_E_PRECONDITION     =  0x80000008 , // 前置条件有误，或运行环境已发生变化
                 MV_E_VERSION          =  0x80000009 , // 版本不匹配
                 MV_E_NOENOUGH_BUF     =  0x8000000A , // 传入的内存空间不足
                 MV_E_UNKNOW           =  0x800000FF , // 未知的错误

                // GenICam系列错误:范围0x80000100-0x800001FF
                 MV_E_GC_GENERIC        = 0x80000100 , // 通用错误
                 MV_E_GC_ARGUMENT       = 0x80000101 , // 参数非法
                 MV_E_GC_RANGE          = 0x80000102 , // 值超出范围
                 MV_E_GC_PROPERTY       = 0x80000103 , // 属性
                 MV_E_GC_RUNTIME        = 0x80000104 , // 运行环境有问题
                 MV_E_GC_LOGICAL        = 0x80000105 , // 逻辑错误
                 MV_E_GC_ACCESS         = 0x80000106 , // 访问权限有误
                 MV_E_GC_TIMEOUT        = 0x80000107 , // 超时
                 MV_E_GC_DYNAMICCAST    = 0x80000108 , // 转换异常
                 MV_E_GC_UNKNOW         = 0x800001FF , // GenICam未知错误

                //GigE_STATUS对应的错误码:范围0x80000200-0x800002FF
                 MV_E_NOT_IMPLEMENTED  =  0x80000200 , // 命令不被设备支持
                 MV_E_INVALID_ADDRESS  =  0x80000201 , // 访问的目标地址不存在
                 MV_E_WRITE_PROTECT    =  0x80000202 , // 目标地址不可写
                 MV_E_ACCESS_DENIED    =  0x80000203 , // 访问无权限
                 MV_E_BUSY             =  0x80000204 , // 设备忙，或网络断开
                 MV_E_PACKET           =  0x80000205 , // 网络包数据错误
                 MV_E_NETER            =  0x80000206 , // 网络相关错误
        }
}
