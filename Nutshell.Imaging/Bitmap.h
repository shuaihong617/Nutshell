// Nutshell.Imaging.h

#pragma once

using namespace System;
using namespace Nutshell::Data;

namespace Nutshell
{
	namespace Imaging
	{

		public ref class Bitmap :IdentityObject
		{
		public:
			Bitmap(IdentityObject^ parent, String^ id, int width, int height, PixelFormat format);
		private:
			
			int _width;
			int _height;
			PixelFormat _format;
			IntPtr _buffer;

			DateTime _timeStamp;
		public:
			property int Width
			{
				int get()
				{
					return _width;
				}
			}

			property int Height
			{
				int get()
				{
					return _height;
				}
			}

			property PixelFormat Format
			{
				PixelFormat get()
				{
					return _format;
				}
			}

		};
	}
}