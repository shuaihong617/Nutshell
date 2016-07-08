namespace Nutshell.Collections
{
        public interface  IBuffer<T>
        {
                void Enqueue(T t);

                T Dequeue();

                void Clear();
        }
}
