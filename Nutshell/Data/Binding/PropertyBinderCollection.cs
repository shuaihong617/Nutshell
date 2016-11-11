using System.Collections.Generic;

namespace Nutshell.Data.Binding
{
        public class PropertyBinderCollection<T> : Dictionary<T, PropertyBinder>
        {
                public void Add(T key, object Itance, string propertyName, object converter)
                {
                        Add(key, new PropertyBinder(Itance, propertyName, converter));
                }
        }
}
