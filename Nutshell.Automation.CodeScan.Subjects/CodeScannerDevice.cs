using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Extensions;

namespace Nutshell.Automation.CodeScan.Subjects
{
        public class CodeScannerDevice: ConnectableDevice
        {
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

                                OnBarcodeChanged(new BarcodeChangedEventArgs(_barcode));
                        }
                }

                #region 事件

                public event EventHandler<BarcodeChangedEventArgs> BarcodeChanged;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnBarcodeChanged(BarcodeChangedEventArgs e)
                        => e.Raise(this, ref BarcodeChanged);

                #endregion
        }
}
