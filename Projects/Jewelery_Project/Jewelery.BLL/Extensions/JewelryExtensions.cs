using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jewelery.BLL.Extensions
{
  public static class JewelryExtensions
    {
        public static T MapTO<T>(this object source)
        {
            Type target = typeof(T);

            Type sourceType = source.GetType();

            T result = Activator.CreateInstance<T>();

            PropertyInfo[] targetProp = target.GetProperties();

            PropertyInfo[] sourceProp = sourceType.GetProperties();

            foreach (PropertyInfo item in sourceProp)
            {
                PropertyInfo tp = targetProp.FirstOrDefault(x => x.Name.ToLower() == item.Name.ToLower());

                if (tp != null)
                {
                    object data = item.GetValue(source);

                    tp.SetValue(result, data);
                }
            }

            return result;
        }


    }
}
