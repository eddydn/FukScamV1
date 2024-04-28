using System.ComponentModel;
using System.Reflection;

namespace FukScamV1.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string name = value.ToString();
            Type type = value.GetType();
            MemberInfo[] memberInfo = type.GetMember(name);

            if (memberInfo.Length > 0)
            {
                DescriptionAttribute? attr = memberInfo[0].GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }

            return name;
        }
    }
}

