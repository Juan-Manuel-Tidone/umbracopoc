using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace UmbracoSample.Helpers
{
    public sealed class TypeHelper
    {

        private static volatile TypeHelper _instance;
        private static object _lock = new object();
        private Dictionary<string, Type> _mappedTypes = new Dictionary<string, Type>();

        public TypeHelper() { }

        public static TypeHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TypeHelper();
                        }
                    }
                }

                return _instance;
            }
        }

        public object GetGeneratedContentModel(IPublishedContent content)
        {
            if (content != null)
            {
                if (this._mappedTypes.Keys.Contains(content.ContentType.Alias))
                {
                    return Activator.CreateInstance(this._mappedTypes.Where(t => t.Key == content.ContentType.Alias).FirstOrDefault().Value, new object[] { content });
                }
                else
                {
                    foreach (Type item in GetTypesInNamespace(Assembly.GetExecutingAssembly(), "AM.Models"))
                    {
                        FieldInfo field = item.GetField("ModelTypeAlias");

                        if (field != null)
                        {
                            if (content.ContentType.Alias == field.GetValue(null).ToString())
                            {
                                this._mappedTypes.Add(content.ContentType.Alias, item);

                                return Activator.CreateInstance(item, new object[] { content });
                            }
                        }
                    }
                }
            }

            return null;
        }

        #region Private

        private IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal));
        }

        #endregion
    }
}