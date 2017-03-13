using System;
using System.IO;

namespace Nutshell.IO
{
        public static class FileExtensions
        {
                public static void MustFileHasExist(this string path)
                {
                        if (!File.Exists(path))
                        {
                                throw new InvalidOperationException("文件 " + path + " 不存在");
                        }
                }
        }
}