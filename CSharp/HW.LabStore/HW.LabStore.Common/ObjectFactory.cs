using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW.LabStore.Common
{
    public class ObjectFactory
    {
        private static IDictionary<string,object> objectContainer = new Dictionary<string, object>();
        private static ObjectFactory instanceFactory;
        private string defaultXmlPath = string.Empty;
        private static object lockHelp = new object();

        private ObjectFactory(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = defaultXmlPath;
            }
        }

        public static ObjectFactory Instance(string filePath)
        {
            if (instanceFactory == null)
            {
                lock (lockHelp)
                {
                    instanceFactory = instanceFactory ?? new ObjectFactory(filePath);
                }
            }
            return instanceFactory;
        }

        private static void LoadObject(string filePath)
        {
            var root = XElement.Load(filePath);
            var objs = from obj in root.Elements("object") select obj;

            // no parameter contructor
            objectContainer = objs.Where(obj => obj.Element("contructor-arg") == null).ToDictionary(
                k => k.Attribute("id").Value,
                v =>
                {
                    string typeName = v.Attribute("type").Value;
                    Type type = Type.GetType(typeName);
                    return Activator.CreateInstance(type);
                });

            // has parameter contructor
            var hasContrustor = objs.Where(obj => obj.Element("contructor-arg") != null);
            foreach (XElement item in hasContrustor)
            {
                string id = item.Attribute("id").Value;
                string typeName = item.Attribute("type").Value;
                Type type = Type.GetType(typeName);

                var args = from property in type.GetConstructors()[0].GetParameters()
                    join e1 in item.Elements("contructor-arg")
                    on property.Name equals e1.Attribute("name").Value
                    select Convert.ChangeType(e1.Attribute("value").Value, property.ParameterType);

                object obj = Activator.CreateInstance(type, args.ToArray());
                objectContainer.Add(id, obj);
            }
        }

        private void LoadProperty(string filePath)
        {
            XElement root = XElement.Load(filePath);
            var objects = from obj in root.Elements("object") select obj;

            foreach (var item in objectContainer)
            {
                var conditions = objects.Where(e => e.Attribute("id").Value == item.Key).Elements("property");
                foreach (var el in conditions)
                {
                    Type type = item.Value.GetType();
                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        if (el.Attribute("value") != null)
                        {
                            property.SetValue(item.Value, Convert.ChangeType(el.Attribute("value").Value, property.PropertyType), null);
                        }
                        else if (el.Attribute("ref") != null)
                        {
                            object refObject = null;
                            if (objectContainer.ContainsKey(el.Attribute("ref").Value))
                            {
                                refObject = objectContainer[el.Attribute("ref").Value];
                            }
                            property.SetValue(item.Value, refObject, null);
                        }
                    }
                }
            }
        }

        public object GetObject(string name)
        {
            object result = null;
            objectContainer.TryGetValue(name, out result);
            return result;
        }
    }
}
