// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-01-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-02-12
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell
{
	/// <summary>
	/// 表示操作的结果.
	/// </summary>
	public class Result:IResult
        {
		/// <summary>
		/// 初始化<see cref="Result"/>的新实例.
		/// </summary>
		/// <param name="isSuccessed">操作是否成功.</param>
		public Result(bool isSuccessed)
                {
                        IsSuccessed = isSuccessed;

                }

		/// <summary>
		/// 操作成功.
		/// </summary>
		public static readonly Result Successed = new Result(true);

		/// <summary>
		/// 操作失败.
		/// </summary>
		public static readonly Result Failed = new Result(false);

		/// <summary>
		/// 获取操作成功或失败
		/// </summary>
		/// <value>操作成功返回True,否则返回False.</value>
		public bool IsSuccessed { get; private set; }
        }
}