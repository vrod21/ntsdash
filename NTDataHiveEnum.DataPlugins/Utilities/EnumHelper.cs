using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NTDataHiveEnum.DataPlugins.Utilities
{
    public class EnumHelper
    {
        public static List<DropDownListItem> ConvertEnumToDropDownSource<T>() 
        {
            List<DropDownListItem> ret = new List<DropDownListItem>();
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            for (int i = 0; i < Enum.GetNames(typeof(T)).Length; i++)
            {
                DropDownListItem ddlItem = new DropDownListItem();

                ddlItem.Text = Enum.GetNames(typeof(T))[i];
                ddlItem.Value = values[i].ToString();

                ret.Add(ddlItem);
            }
            return ret;
        }
    }
}
