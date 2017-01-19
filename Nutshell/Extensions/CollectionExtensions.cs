// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-03-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-03-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nutshell
{
        /// <summary>
        ///         集合扩展方法
        /// </summary>
        public static class CollectionExtensions
        {
                /// <summary>
                ///         Automatics the observable collection.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="collection">The lt.</param>
                /// <param name="observableCollection">The ot.</param>
                /// <returns></returns>
                public static ObservableCollection<T> ToObservableCollection<T>(this ICollection<T> collection,
                        ObservableCollection<T> observableCollection)
                {
                        collection.NotNull();
                        observableCollection.NotNull();

                        observableCollection.Clear();
                        foreach (T t in collection)
                        {
                                observableCollection.Add(t);
                        }

                        return observableCollection;
                }

                /// <summary>
                ///         Automatics the observable collection.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="collection">The lt.</param>
                /// <returns></returns>
                public static ObservableCollection<T> ToObservableCollection<T>(this ICollection<T> collection)
                {
                        collection.NotNull();

                        var observableCollection = new ObservableCollection<T>();

                        foreach (T t in collection)
                        {
                                observableCollection.Add(t);
                        }

                        return observableCollection;
                }

                /// <summary>
                ///         Each of the collection item run action--function
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="collection">The lt.</param>
                /// <param name="action">The action.</param>
                public static void Each<T>(this ICollection<T> collection, Action<T> action)
                {
                        collection.NotNull();
                        action.NotNull();

                        foreach (T t in collection)
                        {
                                action(t);
                        }
                }
        }
}