using System.Linq;

namespace Py.Core
{
    public interface IClonable { }

    public static partial class Extensions
    {
        /// <summary>
        /// Returns an object that is member-wise copy of the given instance.
        /// </summary>
        /// <typeparam name="T">is any type that implements IClonable interface.</typeparam>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static T Clone<T>(this T origin) where T : IClonable, new()
        {
            var result = new T();
            var propertyInfos = typeof(T).GetPublicDeclaredInstancePropertyInfos();
            foreach (var propertyInfo in propertyInfos)
                propertyInfo.SetValue(result, propertyInfo.GetValue(origin));
            return result;
        }

        public static T CopyPropertiesFrom<T>(this T target, T origin) where T : IClonable
        {
            var propertyInfos = typeof(T).GetPublicDeclaredInstancePropertyInfos();
            foreach (var propertyInfo in propertyInfos)
                propertyInfo.SetValue(target, propertyInfo.GetValue(origin));
            return target;
        }

        public static T CopyPropertiesTo<T>(this T origin, T target) where T : IClonable
        {
            var propertyInfos = typeof(T).GetPublicDeclaredInstancePropertyInfos();
            foreach (var propertyInfo in propertyInfos)
                propertyInfo.SetValue(target, propertyInfo.GetValue(origin));
            return origin;
        }

        public static T CopySimilarPropertiesFrom<T, U>(this T it, U origin) where T : IClonable
        {
            // We need to have two separate sets of PropInfos because they are unique to their types!
            var propertyInfosOfT = typeof(T).GetPublicInstancePropertyInfos();
            var propertyInfosOfU = typeof(U).GetPublicInstancePropertyInfos();
            foreach (var propertyInfo in propertyInfosOfT)
            {
                var correspondingPiOfU = propertyInfosOfU.SingleOrDefault(pi => pi.Name == propertyInfo.Name && pi.PropertyType == propertyInfo.PropertyType);
                if (correspondingPiOfU != null)
                {
                    var value = typeof(U).GetProperty(propertyInfo.Name).GetValue(origin);
                    propertyInfo.SetValue(it, value);
                }
            }
            return it;
        }
    }
}
