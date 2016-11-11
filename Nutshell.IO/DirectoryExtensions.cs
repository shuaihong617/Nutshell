using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.IO
{
        public static class DirectoryExtensions
        {
                public static void MustDirectoryHasExist(this string path)
                {
                        if (!Directory.Exists(path))
                        {
                                throw new InvalidOperationException("目录 " + path + " 不存在");
                        }
                }
        }
}
