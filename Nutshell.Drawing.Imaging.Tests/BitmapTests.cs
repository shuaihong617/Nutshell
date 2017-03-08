using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nutshell.Drawing.Imaging.Tests
{
        [TestClass()]
        public unsafe class BitmapTests
        {
		[TestMethod()]
		public void SaveMono8Test()
		{
			var bitmap = new Bitmap(string.Empty, 480, 480, PixelFormat.Mono8);
			var ptr = (byte*)bitmap.Buffer.ToPointer();
			for (int x = 0; x < bitmap.Width; x++)
			{
				for (int y = 0; y < bitmap.Height; y++)
				{
					if (x < 160 && y < 160)
					{
						*ptr++ = 255;
					}
					else
					{
						*ptr++ = 0;
					}
				}
			}
			BitmapStorager.Save(bitmap, "SaveMono8Test.bmp");
		}

		[TestMethod()]
                public void SaveBgr24Test()
                {
                        var bitmap = new Bitmap(string.Empty, 640, 480, PixelFormat.Bgr24);
                        var ptr = (byte*)bitmap.Buffer.ToPointer();
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                                for (int y = 0; y < bitmap.Height; y++)
                                {
                                       *ptr++ = (byte)((x) % 0xff);
                                       *ptr++ = (byte)((x) % 0xff);
                                       *ptr++ = (byte)((x + y) % 0xff);
                                }
                        }
			BitmapStorager.Save(bitmap, "SaveBgr24Test.bmp");
                }

                [TestMethod()]
                public void SaveRgb24Test()
                {
                        var bitmap = new Bitmap(string.Empty, 640, 480, PixelFormat.Rgb24);
                        var ptr = (byte*)bitmap.Buffer.ToPointer();
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                                for (int y = 0; y < bitmap.Height; y++)
                                {
                                        *ptr++ = 255;
                                        *ptr++ = 0;
                                        *ptr++ = 0;
                                }
                        }
                        BitmapStorager.Save(bitmap,"SaveBgr24RedTest.bmp");


                        ptr = (byte*)bitmap.Buffer.ToPointer();
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                                for (int y = 0; y < bitmap.Height; y++)
                                {
                                        *ptr++ = 0;
                                        *ptr++ = 255;
                                        *ptr++ = 0;
                                }
                        }
			BitmapStorager.Save(bitmap, "SaveBgr24GreenTest.bmp");

                        ptr = (byte*)bitmap.Buffer.ToPointer();
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                                for (int y = 0; y < bitmap.Height; y++)
                                {
                                        *ptr++ = 0;
                                        *ptr++ = 0;
                                        *ptr++ = 255;
                                }
                        }
			BitmapStorager.Save(bitmap, "SaveBgr24BlueTest.bmp");
                }
        }
}
