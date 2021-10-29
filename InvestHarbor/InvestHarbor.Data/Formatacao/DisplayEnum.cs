using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InvestHarbor.Data.Formatacao
{
    public static class DisplayEnum
    {
        public static string GetDisplayNameEnum(System.Enum enumValue)
        {
            if (enumValue == null)
            {
                return null;
            }
            var displayName = enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()?
                           .Name;

            return displayName ?? enumValue.ToString();
        }
    }
}
