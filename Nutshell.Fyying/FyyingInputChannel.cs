using System;
using System.Diagnostics;
using Nutshell.Automation.IOBoard;
using Nutshell.Fyying.SDK;

namespace Nutshell.Fyying
{
        public class FyyingInputChannel : InputChannel
        {
                public FyyingInputChannel(int index)
                        : base(index)
                {
                }

                public override int Read()
                {
                        var handle = ((FyyingIOBoardDevice) Parent).Handle;
                        Debug.Assert(handle != IntPtr.Zero);

                        Value = OfficalAPI.FY6400_DI_Bit(handle, Index);
                        return Value;
                }
        }
}
