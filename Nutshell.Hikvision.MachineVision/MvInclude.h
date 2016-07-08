/***************************************************************************************************
* 
* 版权信息：版权所有 (c) 2015, 杭州海康威视数字技术股份有限公司, 保留所有权利
* 
* 文件名称：MvInclude.h
* 摘    要：头文件包含，类型定义等
*
* 当前版本：1.0.0.0
* 作    者：陈祖文
* 日    期：2015-02-03
* 备    注：新建
***************************************************************************************************/
#ifndef _MV_INCLUDE_H_
#define _MV_INCLUDE_H_

#include "CameraParams.h"

/**
 *  @brief  动态库导入导出定义
 */
#ifndef MV_CAMCTRL_API

    #ifdef WIN32
        #if defined(MV_CAMCTRL_EXPORTS)
            #define MV_CAMCTRL_API __declspec(dllexport)
        #else
            #define MV_CAMCTRL_API __declspec(dllimport)
        #endif
    #else
        #ifndef __stdcall
            #define __stdcall
        #endif

        #ifndef MV_CAMCTRL_API
            #define  MV_CAMCTRL_API
        #endif
    #endif

#endif


namespace MvCamCtrl
{

    typedef  void       ITransportLayer;
    typedef  void*      TlProxy;
    class               MvCamera;
    class               CTlRefs;
    class               CDevRefs;


}

#endif /* _MV_INCLUDE_H_ */
