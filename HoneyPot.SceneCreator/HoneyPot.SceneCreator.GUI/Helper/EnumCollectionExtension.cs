using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace HoneyPot.SceneCreator.GUI.Helper
{

    //https://thecolorofcode.com/2018/01/24/wpf-simple-way-to-use-enums-as-combobox-items/
    public class EnumCollectionExtension : MarkupExtension
    {
        public Type EnumType { get; set; }

        public override object ProvideValue(IServiceProvider _)
        {
            if (EnumType != null)
            {
                return CreateEnumValueList(EnumType);
            }
            return default(object);
        }

        private List<object> CreateEnumValueList(Type enumType)
        {
            return Enum.GetNames(enumType)
                .Select(name => Enum.Parse(enumType, name))
                .ToList();
        }
    }
}
