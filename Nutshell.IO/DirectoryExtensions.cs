using System;
using System.IO;

namespace Nutshell.IO
{
        public static class DirectoryExtensions
        {
                public static void MustExistDirectory(this string path)
                {
                        if (!Directory.Exists(path))
                        {
                                throw new InvalidOperationException("目录 " + path + " 不存在");
                        }
                }
        }
}