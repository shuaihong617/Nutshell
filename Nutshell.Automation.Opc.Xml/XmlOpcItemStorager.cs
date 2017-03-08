namespace Nutshell.Automation.Opc.Xml
{
        public class XmlOpcItemStorager
        {
                protected XmlOpcItemStorager()
                {

                }

                #region 属性

                //单例
                public static readonly XmlOpcItemStorager Instance = new XmlOpcItemStorager();

                #endregion


                public void Load([MustFileExist]string fileName)
                {

                }

                public void Save(string fileName)
                {

                }


        }
}