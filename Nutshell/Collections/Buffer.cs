using System;

namespace Nutshell.Collections
{
        public abstract class Buffer<T>:IdentityObject,IBuffer<T>
        {
                protected Buffer(IdentityObject parent, string id)
                        :base(parent, id)
                {
                        
                }

                public abstract void Enqueue(T t);

                public abstract T Dequeue();

                public abstract void Clear();

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                protected event EventHandler<ValueEventArgs<T>> Enqueued;

                /// <summary>
                ///         引发 <see cref="E:Enqueued" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="ValueEventArgs{T}" /> instance containing the event data.</param>
                protected virtual void OnEnqueued(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref Enqueued);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                protected event EventHandler<ValueEventArgs<T>> Dequeued;

                /// <summary>
                ///         引发 <see cref="E:Dequeued" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="ValueEventArgs{T}" /> instance containing the event data.</param>
                protected virtual void OnDequeued(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref Dequeued);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                protected event EventHandler<EventArgs> Cleared;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnCleared(EventArgs e)
                {
                        e.Raise(this, ref Cleared);
                }

                #endregion

        }
}
