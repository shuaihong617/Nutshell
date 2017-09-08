using System;
using System.ComponentModel;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Extensions;

namespace Nutshell.Automation.Agents
{
        public class Locator : IdentityObject
        {
                public Locator(string id = "", int standardTriggeredCount = 1)
                        : base(id)
                {
                        StandardTriggeredCount = standardTriggeredCount;
                }

                private int _practiceTriggeredCount;
                private bool _isEffective;

                [NotifyPropertyValueChanged]
                public int StandardTriggeredCount { get; }

                public int PracticeTriggeredCount
                {
                        get { return _practiceTriggeredCount; }
                        private set
                        {
                                if (value == _practiceTriggeredCount)
                                {
                                        return;
                                }
                                _practiceTriggeredCount = value;
                                OnPropertyValueChanged();
                                OnTriggered(EventArgs.Empty);

                                IsEffective = PracticeTriggeredCount == StandardTriggeredCount;
                        }
                }

                public bool IsEffective
                {
                        get { return _isEffective; }
                        private set
                        {
                                if (value == _isEffective)
                                {
                                         return;
                                }
                                _isEffective = value;
                                OnPropertyValueChanged();
                                OnEffectiveChanged(new ValueEventArgs<bool>(_isEffective));
                        }
                }

                public void Triggering()
                {
                        PracticeTriggeredCount++;
                }

                public void Reset()
                {
                        PracticeTriggeredCount = 0;
                }

                #region 事件

                /// <summary>
                ///         当全局标识改变时发生
                /// </summary>
                [Description("全局标识改变事件")]
                public event EventHandler<EventArgs> Triggered;

                /// <summary>
                ///         引发全局标识改变事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs" />实例</param>
                protected virtual void OnTriggered(EventArgs e)
                {
                        e.Raise(this, ref Triggered);
                }

                /// <summary>
                ///         当全局标识改变时发生
                /// </summary>
                [Description("全局标识改变事件")]
                public event EventHandler<ValueEventArgs<bool>> EffectiveChanged;

                /// <summary>
                ///         引发全局标识改变事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs" />实例</param>
                protected virtual void OnEffectiveChanged(ValueEventArgs<bool> e)
                {
                        e.Raise(this, ref EffectiveChanged);
                }

                #endregion
        }
}
