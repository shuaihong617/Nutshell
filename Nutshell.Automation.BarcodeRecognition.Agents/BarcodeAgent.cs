using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Extensions;

namespace Nutshell.Automation.BarcodeRecognition.Agents
{
        public class BarcodeAgent : IdentityObject
        {
                public BarcodeAgent(string id)
                        :base(id)
                {
                        
                }

                private string _barcode = string.Empty;

                [MustNotEqualNull]
                public string Barcode
                {
                        get { return _barcode; }
                        protected set
                        {
                                if (_barcode == value)
                                {
                                        return;
                                }

                                _barcode = value;
                                OnPropertyValueChanged();

                                OnBarcodeChanged(new BarcodeEventArgs(_barcode));
                        }
                }

                #region 方法

                public virtual void Reset()
                {
                        Barcode = string.Empty;
                }

                #endregion


                #region 事件

                public event EventHandler<BarcodeEventArgs> BarcodeChanged;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnBarcodeChanged(BarcodeEventArgs e)
                        => e.Raise(this, ref BarcodeChanged);

                #endregion

        }
}
