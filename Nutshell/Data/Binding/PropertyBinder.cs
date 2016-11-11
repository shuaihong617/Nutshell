using System.Reflection;

namespace Nutshell.Data.Binding
{
        public class PropertyBinder
        {
                public PropertyBinder(object instance, string propertyName, object converter)
                {
                        Instance = instance;
                        PropertyName = propertyName;

                        PropertyInfo = Instance.GetType().GetRuntimeProperty(PropertyName);

                        Converter = converter;
                }

                public object Instance { get; private set; }

                public string PropertyName { get; private set; }

                public PropertyInfo PropertyInfo { get; private set; }

                public object Converter { get; private set; }

                public void Update(string source)
                {
                        dynamic c = Converter;
                        PropertyInfo.SetValue(Instance, c.Convert(source));
                }
        }
}
