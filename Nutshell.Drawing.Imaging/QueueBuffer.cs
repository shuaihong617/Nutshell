// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-08-01
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Collections.Concurrent;
using Nutshell.Collections;

namespace Nutshell.Drawing.Imaging
{
        /// <summary>
        /// 队列缓冲区
        /// </summary>
        /// <typeparam name="T">缓冲数据类型</typeparam>
        public class BitmapBuffer:IdentityObject
        {

                /// <summary>
                /// 初始化<see cref="QueueBuffer{T}"/>的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public BitmapBuffer(IdentityObject parent, string id = "")
                        :base(parent, id)
                {
                        _buffer = new QueueBuffer<Bitmap>(this);
                }

                private readonly QueueBuffer<Bitmap> _buffer;

                public Bitmap EnterRead()
                {
                        throw new Exception();
                }

                public void ExitRead(Bitmap bitmap)
                {
                        _buffer.Enqueue(bitmap);
                }


                public Bitmap EnterWrite()
                {
                        return _buffer.Dequeue();
                }

                public void ExitWrite(Bitmap bitmap)
                {
                        bitmap.UpdateTimeStamp();
                        _buffer.Enqueue(bitmap);
                }

                
        }
}
