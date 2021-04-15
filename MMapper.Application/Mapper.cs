using System;
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
            var targetObject = (t)Activator.CreateInstance(targetType);
            foreach(PropertyInfo prop in sourceProperties)
            {
                if (targetProperties.Any(x => x.Name == prop.Name))
                {
                    var sourceValue = prop.GetValue(source);
                    targetObject.GetType().GetProperty(prop.Name).SetValue(targetObject, sourceValue);
                }
            }
            
            return targetObject;
        }
    }
}
