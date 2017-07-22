using System;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Extensions;
using Nutshell.Fyying.SDK;

namespace Nutshell.Fyying
{
        public class Channel : IdentityObject
        {
                public Channel(int index)
                        :base(index + "通道")
                {
                        Index = index;
                        Value = Zero;
                }

                #region 常量

                public const int One = 1;

                public const int Zero = 0;

                #endregion

                #region 字段

                private int _value;

                private IntPtr _handle;

                #endregion


                public int Index { get; }

                [NotifyPropertyValueChanged]
                public int Value
                {
                        get { return _value; }
                        private set
                        {
                                if (value == _value)
                                {
                                        return;
                                }
                                _value = value;
                                OnPropertyValueChanged();

                                OnValueChanged(new ChannelValueChangedEventArgs(Index, Value == One));

                                //this.Info(ToString());
                        }
                }

                public void BindToBoardDevice(FyyingIOBoardDevice board)
                {
                        _handle = board.Handle;
                }

                public void Read()
                {
                        Value = OfficalAPI.FY6400_DI_Bit(_handle, Index);
                }

                public void Write(int data)
                {
                        OfficalAPI.FY6400_DO_Bit(_handle, data, Index);
                }

                public override string ToString()
                {
                        return $"{Id}:{Value}";
                }

                #region 事件

                public event EventHandler<ChannelValueChangedEventArgs> ValueChanged;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnValueChanged(ChannelValueChangedEventArgs e)
                        => e.Raise(this, ref ValueChanged);

                #endregion
        }
}
