using System;
using System.Diagnostics;
using Nutshell.Automation.IOBoard;
using Nutshell.Fyying.SDK;

namespace Nutshell.Fyying
{
        public class FyyingOutputChannel : OutputChannel
        {
                public FyyingOutputChannel(int index)
                        : base(index)
                {
                }

                public override int Read()
                {
                        var handle = ((FyyingIOBoardDevice)Parent).Handle;
                        Debug.Assert(handle != IntPtr.Zero);

                        Value = OfficalAPI.FY6400_RDO_Bit(handle, Index);

                        return Value;
                }

                public override void Write(int data)
                {
                        var handle = ((FyyingIOBoardDevice)Parent).Handle;
                        Debug.Assert(handle != IntPtr.Zero);

                        OfficalAPI.FY6400_DO_Bit(handle, data, Index);
                }
        }
}
