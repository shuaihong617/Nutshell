﻿namespace Nutshell.Fyying
{
        public class Fyying6400IOBoardDevice : FyyingIOBoardDevice
        {
                #region 字段

                public const int StandardInputChannelsCount = 16;

                public const int StandardOutputChannelsCount = 16;

                #endregion

                protected override sealed bool StartConnectCore()
                {
                        if (!base.StartConnectCore())
                        {
                                return false;
                        }

                        return InputChannelsCount == StandardInputChannelsCount
                                && OutputChannelsCount == StandardOutputChannelsCount;
                }
        }
}
