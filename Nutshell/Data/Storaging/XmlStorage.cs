using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Nutshell.Data.Models;
using Nutshell.Data.Serializing;

namespace Nutshell.Data.Storaging
{
        public class XmlStorage
        {
                public XmlStorage(string filePath)
                {
                        filePath.MustNotNullOrEmpty();
                        FilePath = filePath;
                }

                #region 属性

                private static readonly XmlSerializerNamespaces XmlSerializerNamespaces = new XmlSerializerNamespaces(
                        new[] {new XmlQualifiedName(string.Empty, string.Empty)});

                private static readonly Dictionary<Type, XmlSerializer> XmlSerializers =
                        new Dictionary<Type, XmlSerializer>();

                public static XmlSerializer GetSerializer(Type type)
                {
                        if (!XmlSerializers.ContainsKey(type))
                        {
                                XmlSerializers.Add(type, new XmlSerializer(type));
                        }
                        return XmlSerializers[type];
                }

                public string FilePath { get; set; }

                #endregion

                public T Load<T>() where T : class, IStorableModel
                {
                        return Load<T>(FilePath);
                }

                public static T Load<T>(string path) where T : class, IStorableModel
                {
                        path.MustFileHasExist();

                        using (var stream = File.OpenRead(path))
                        {
                                return MSSerializers.GetMSSerializer(typeof (T)).Deserialize<T>(stream);
                        }
                }

                public void Save<T>(T t) where T : class, IStorableModel
                {
                        using (var stream = File.Create(FilePath))
                        {
                                var type = t.GetType();
                                var serializer = new XmlSerializer(type);
                                serializer.Serialize(stream, type, XmlSerializerNamespaces);
                                stream.Close();
                        }
                }

                public static void Save<T>(T t, string filePath) where T : class, IStorableModel
                {
                        using (var stream = File.Create(filePath))
                        {
                                var type = t.GetType();
                                var serializer = new XmlSerializer(type);
                                serializer.Serialize(stream, t, XmlSerializerNamespaces);
                                stream.Close();
                        }
                }
        }
}