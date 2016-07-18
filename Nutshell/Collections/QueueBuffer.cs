using System;
using System.Collections.Concurrent;

namespace Nutshell.Collections
{
        public class QueueBuffer<T>:Buffer<T>
        {
                public QueueBuffer(IdentityObject parent, string id = "")
                        :base(parent, id)
                {
                        
                }

                private readonly ConcurrentQueue<T> _buffer = new ConcurrentQueue<T>();

                public override void Enqueue(T t)
                {
                        _buffer.Enqueue(t);
                }

                public override T Dequeue()
                {
                        T t;
                        _buffer.TryDequeue(out t);
                        return t;
                }
                
                public override void Clear()
                {
                        throw new NotSupportedException();
                }

               
        }
}
