using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarRing.Core.Helpers
{
    public enum TipoCampoEdit
    {
        DatePicker,
        Picker

    }
    public static class LayoutHelper
    {
        public static StackLayout CreateField(String labelText, TipoCampoEdit tipoCampo, Boolean labelTop = true, List<String> dsPicker = null, Boolean labelInPlaceholder = false)
        {
            StackLayout stack = new StackLayout() { Orientation = labelTop ? StackOrientation.Vertical : StackOrientation.Horizontal };
            if (!labelInPlaceholder)
            {
                Label lbl = new Label() { Text = labelText };
                stack.Children.Add(lbl);
            }
            switch (tipoCampo)
            {
                case TipoCampoEdit.DatePicker:
                    DatePicker dtpicker = new DatePicker();
                    stack.Children.Add(dtpicker);
                    break;
                case TipoCampoEdit.Picker:
                    Picker picker = new Picker() { HorizontalOptions = LayoutOptions.CenterAndExpand };
                    foreach (var item in dsPicker)
                    {
                        picker.Items.Add(item);
                    }
                    stack.Children.Add(picker);
                    if (labelInPlaceholder)
                        picker.Title = labelText;
                    break;
                default:
                    throw new NotImplementedException();

            }
            return stack;
        }
    }
}
