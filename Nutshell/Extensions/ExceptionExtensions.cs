using Nutshell.Aspects.Locations.Contracts;
using System;
using System.Text;

namespace Nutshell.Extensions
{
        public static class ExceptionExtensions
        {
                /// <summary>
                ///         格式化异常消息
                /// </summary>
                /// <param name="exception">异常对象</param>
                /// <param name="isHideStackTrace">是否隐藏异常规模信息</param>
                /// <returns>格式化后的异常信息字符串</returns>
                public static string FormatMessage([MustNotEqualNull] this Exception exception, bool isHideStackTrace = false)
                {
                        var sb = new StringBuilder();
                        var count = 0;
                        var appString = string.Empty;
                        while (exception != null)
                        {
                                if (count > 0)
                                {
                                        appString += "  ";
                                }
                                sb.AppendLine($"{appString}异常消息：{exception.Message}");
                                sb.AppendLine($"{appString}异常类型：{exception.GetType().FullName}");
                                sb.AppendLine($"{appString}异常方法：{exception.TargetSite?.Name}");
                                sb.AppendLine($"{appString}异常源：{exception.Source}");
                                if (!isHideStackTrace && exception.StackTrace != null)
                                {
                                        sb.AppendLine($"{appString}异常堆栈：{exception.StackTrace}");
                                }
                                if (exception.InnerException != null)
                                {
                                        sb.AppendLine($"{appString}内部异常：");
                                        count++;
                                }
                                exception = exception.InnerException;
                        }
                        return sb.ToString();
                }

                /// <summary>
                ///         对某对象执行指定功能与后续功能，并处理异常情况
                /// </summary>
                /// <typeparam name="T">对象类型</typeparam>
                /// <param name="source">值</param>
                /// <param name="action">要对值执行的主功能代码</param>
                /// <param name="failureAction">catch中的功能代码</param>
                /// <param name="successAction">主功能代码成功后执行的功能代码</param>
                /// <returns>主功能代码是否顺利执行</returns>
                public static bool TryCatch<T>(this T source, Action<T> action, Action<Exception> failureAction,
                        Action<T> successAction) where T : class
                {
                        bool result;
                        try
                        {
                                action(source);
                                successAction(source);
                                result = true;
                        }
                        catch (Exception obj)
                        {
                                failureAction(obj);
                                result = false;
                        }
                        return result;
                }

                /// <summary>
                ///         对某对象执行指定功能，并处理异常情况
                /// </summary>
                /// <typeparam name="T">对象类型</typeparam>
                /// <param name="source">值</param>
                /// <param name="action">要对值执行的主功能代码</param>
                /// <param name="failureAction">catch中的功能代码</param>
                /// <returns>主功能代码是否顺利执行</returns>
                public static bool TryCatch<T>(this T source, Action<T> action, Action<Exception> failureAction) where T : class
                {
                        return source.TryCatch(action,
                                failureAction,
                                obj => { });
                }

                /// <summary>
                ///         对某对象执行指定功能，并处理异常情况与返回值
                /// </summary>
                /// <typeparam name="T">对象类型</typeparam>
                /// <typeparam name="TResult">返回值类型</typeparam>
                /// <param name="source">值</param>
                /// <param name="func">要对值执行的主功能代码</param>
                /// <param name="failureAction">catch中的功能代码</param>
                /// <param name="successAction">主功能代码成功后执行的功能代码</param>
                /// <returns>功能代码的返回值，如果出现异常，则返回对象类型的默认值</returns>
                public static TResult TryCatch<T, TResult>(this T source, Func<T, TResult> func, Action<Exception> failureAction,
                        Action<T> successAction)
                        where T : class
                {
                        TResult result;
                        try
                        {
                                var u = func(source);
                                successAction(source);
                                result = u;
                        }
                        catch (Exception obj)
                        {
                                failureAction(obj);
                                result = default(TResult);
                        }
                        return result;
                }

                /// <summary>
                ///         对某对象执行指定功能，并处理异常情况与返回值
                /// </summary>
                /// <typeparam name="T">对象类型</typeparam>
                /// <typeparam name="TResult">返回值类型</typeparam>
                /// <param name="source">值</param>
                /// <param name="func">要对值执行的主功能代码</param>
                /// <param name="failureAction">catch中的功能代码</param>
                /// <returns>功能代码的返回值，如果出现异常，则返回对象类型的默认值</returns>
                public static TResult TryCatch<T, TResult>(this T source, Func<T, TResult> func, Action<Exception> failureAction)
                        where T : class
                {
                        return source.TryCatch(func,
                                failureAction,
                                obj => { });
                }
        }
}