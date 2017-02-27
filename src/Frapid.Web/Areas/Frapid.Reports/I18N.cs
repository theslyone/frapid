using System.Collections.Generic;
using System.Globalization;
using Frapid.Configuration;
using Frapid.i18n;

namespace Frapid.Reports
{
	public sealed class Localize : ILocalize
	{
		public Dictionary<string, string> GetResources(CultureInfo culture)
		{
			string resourceDirectory = I18N.ResourceDirectory;
			return I18NResource.GetResources(resourceDirectory, culture);
		}
	}

	public static class I18N
	{
		public static string ResourceDirectory { get; }

		static I18N()
		{
			ResourceDirectory = PathMapper.MapPath("/Areas/Frapid.Reports/i18n");
		}

		/// <summary>
		///Frapid Report
		/// </summary>
		public static string FrapidReport => I18NResource.GetString(ResourceDirectory, "FrapidReport");

		/// <summary>
		///Print This Report
		/// </summary>
		public static string PrintThisReport => I18NResource.GetString(ResourceDirectory, "PrintThisReport");

		/// <summary>
		///Email This Report
		/// </summary>
		public static string EmailThisReport => I18NResource.GetString(ResourceDirectory, "EmailThisReport");

		/// <summary>
		///Download PDF
		/// </summary>
		public static string DownloadPdf => I18NResource.GetString(ResourceDirectory, "DownloadPdf");

		/// <summary>
		///Download Excel
		/// </summary>
		public static string DownloadExcel => I18NResource.GetString(ResourceDirectory, "DownloadExcel");

		/// <summary>
		///Download Word
		/// </summary>
		public static string DownloadWord => I18NResource.GetString(ResourceDirectory, "DownloadWord");

		/// <summary>
		///Download XML
		/// </summary>
		public static string DownloadXml => I18NResource.GetString(ResourceDirectory, "DownloadXml");

		/// <summary>
		///Download Text
		/// </summary>
		public static string DownloadText => I18NResource.GetString(ResourceDirectory, "DownloadText");

		/// <summary>
		///Zoom In
		/// </summary>
		public static string ZoomIn => I18NResource.GetString(ResourceDirectory, "ZoomIn");

		/// <summary>
		///Zoom Out
		/// </summary>
		public static string ZoomOut => I18NResource.GetString(ResourceDirectory, "ZoomOut");

		/// <summary>
		///Reload
		/// </summary>
		public static string Reload => I18NResource.GetString(ResourceDirectory, "Reload");

		/// <summary>
		///Send Email
		/// </summary>
		public static string SendEmail => I18NResource.GetString(ResourceDirectory, "SendEmail");

		/// <summary>
		///Send To
		/// </summary>
		public static string SendTo => I18NResource.GetString(ResourceDirectory, "SendTo");

		/// <summary>
		///Subject
		/// </summary>
		public static string Subject => I18NResource.GetString(ResourceDirectory, "Subject");

		/// <summary>
		///Message
		/// </summary>
		public static string Message => I18NResource.GetString(ResourceDirectory, "Message");

		/// <summary>
		///Please find the attached document.
		/// </summary>
		public static string PleaseFindAttachedDocument => I18NResource.GetString(ResourceDirectory, "PleaseFindAttachedDocument");

		/// <summary>
		///Attachments
		/// </summary>
		public static string Attachments => I18NResource.GetString(ResourceDirectory, "Attachments");

		/// <summary>
		///Send
		/// </summary>
		public static string Send => I18NResource.GetString(ResourceDirectory, "Send");

		/// <summary>
		///Close
		/// </summary>
		public static string Close => I18NResource.GetString(ResourceDirectory, "Close");

		/// <summary>
		///Show
		/// </summary>
		public static string Show => I18NResource.GetString(ResourceDirectory, "Show");

		/// <summary>
		///No email processor defined.
		/// </summary>
		public static string NoEmailProcessorDefined => I18NResource.GetString(ResourceDirectory, "NoEmailProcessorDefined");

	}
}
