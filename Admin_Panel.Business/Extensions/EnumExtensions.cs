﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;

namespace Admin_Panel.Bussines.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumName(this Enum myEnum)
        {
            var enumDisplayName = myEnum.GetType()
                .GetMember(myEnum.ToString())
                .FirstOrDefault();

            if (enumDisplayName != null)
                return enumDisplayName.GetCustomAttribute<DisplayAttribute>().GetName();

            return "";
        }
    }
}