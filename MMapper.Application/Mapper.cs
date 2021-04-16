using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MMapper.Application
{
    public static class Mapper
    {
        public static t Map<t>(object source)
        {
            var sourceProperties = source.GetType().GetProperties();
            var targetType = typeof(t);
            var targetProperties = targetType.GetProperties();
            object targetObject = null;
            foreach (PropertyInfo prop in sourceProperties)
            {
                if (targetProperties.Any(x => x.Name == prop.Name))
                {
                    if (targetObject == null)
                    {
                        targetObject = Activator.CreateInstance(targetType);
                    }

                    var sourceValue = prop.GetValue(source);
                    targetObject.GetType().GetProperty(prop.Name).SetValue(targetObject, sourceValue);

                }
            }

            return (t)targetObject;
        }

        public static IList<t> Map<t>(IEnumerable<object> sources)
        {
            var targetObjects = new List<t>();
            foreach(var source in sources)
            {
                var targetObject = Map<t>(source);
                if(targetObject != null)
                {
                    targetObjects.Add(targetObject);
                }
            }

            return targetObjects;
        }
    }
}
