namespace Nutshell.Windows
{
        /// <summary>
        /// 光栅操作代码
        /// </summary>
        public enum RasterOperationCode
        {
                BLACKNESS = 0x42,
                DSTINVERT = 0x550009,
                MERGECOPY = 0xC000CA,
                MERGEPAINT = 0xBB0226,
                NOTSRCCOPY = 0x330008,
                NOTSRCERASE = 0x1100A6,
                PATCOPY = 0xF00021,
                PATINVERT = 0x5A0049,
                PATPAINT = 0xFB0A09,
                SRCAND = 0x8800C6,
                SRCCOPY = 0xCC0020,
                SRCERASE = 0x440328,
                SRCINVERT = 0x660046,
                SRCPAINT = 0xEE0086,
                WHITENESS = 0xFF0062,
        }
}
