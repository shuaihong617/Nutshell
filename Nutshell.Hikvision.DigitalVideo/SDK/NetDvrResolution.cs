namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        public enum NetDvrResolution:byte
        {
                //[Resolution(528,384)]
                DCIF =0,

                //[Resolution(640, 480)]
                VGA=16,

                //[Resolution(1280, 960)]
                XVGA=20,

                //[Resolution(1920, 1080)]
                P1080 =27,
                //[Resolution(1920, 1080)]
                I1080 =37,

                //[Resolution(2048, 1536)]
                P1536 = 30,
        }
}
