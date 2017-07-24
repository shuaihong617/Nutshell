using Nutshell.Aspects.Locations.Propertys;

namespace Nutshell.Fyying
{
        public class Fyying6400IOBoardDevice : FyyingIOBoardDevice
        {
                #region 常量

                public const int Fyying6400StandardInputChannelsCount = 16;

                public const int Fyying6400StandardOutputChannelsCount = 16;

                #endregion

                protected override sealed bool StartConnectCore()
                {
                        if (!base.StartConnectCore())
                        {
                                return false;
                        }

                        return Fyying6400StandardInputChannelsCount == StandardInputChannelsCount
                                && Fyying6400StandardOutputChannelsCount == StandardOutputChannelsCount;
                }
        }
}
