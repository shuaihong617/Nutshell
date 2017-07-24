using System;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Extensions;

namespace Nutshell.Automation.IOBoard
{
        public abstract class Channel : IdentityObject
        {
                protected Channel(int index)
                        :base("通道" + index)
                {
                        Index = index;
                }

                #region 字段

                private int _value;

                #endregion


                public int Index { get; }

                [NotifyPropertyValueChanged]
                public int Value
                {
                        get { return _value; }
                        protected set
                        {
                                if (value == _value)
                                {
                                        return;
                                }
                                _value = value;
                                OnPropertyValueChanged();

                                OnValueChanged(new ChannelValueEventArgs(Index, Value));
                        }
                }

                public abstract int Read();

                public override string ToString()
                {
                        return $"{Id},值:{Value}";
                }

                #region 事件

                public event EventHandler<ChannelValueEventArgs> ValueChanged;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnValueChanged(ChannelValueEventArgs e)
                        => e.Raise(this, ref ValueChanged);

                #endregion
        }
}
