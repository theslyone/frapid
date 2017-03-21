using System;
using System.Web;
using Frapid.Framework.Extensions;
using Frapid.i18n;

namespace Frapid.Reports.Helpers
{
    public static class FormattingHelper
    {
        public static string GetFormattedValue(object value)
        {
            string cellValue = value.ToString();

            if (value is DateTime)
            {
                var date = value.To<DateTime>();
                cellValue = date.ToString("o");
            }

            if (value is DateTimeOffset)
            {
                var date = value.To<DateTimeOffset>();
                cellValue = date.ToString("o");
            }

            if (value is decimal || value is double || value is float)
            {
                decimal amount = value.To<decimal>();

                cellValue =
                    amount.ToString("C", CultureManager.GetCurrentUiCulture())
                        .Replace(CultureManager.GetCurrentUiCulture().NumberFormat.CurrencySymbol, "");
            }

            return HttpUtility.HtmlEncode(cellValue);
        }
    }
}