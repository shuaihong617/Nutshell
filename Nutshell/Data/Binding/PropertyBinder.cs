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

                public object Instance { get; }

                public string PropertyName { get; }

                public PropertyInfo PropertyInfo { get; }

                public object Converter { get; }

                public void Update(string source)
                {
                        dynamic c = Converter;
                        PropertyInfo.SetValue(Instance, c.Convert(source));
                }
        }
}
