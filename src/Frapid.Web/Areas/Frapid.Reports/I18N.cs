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
		///Address
		/// </summary>
		public static string Address => I18NResource.GetString(ResourceDirectory, "Address");

		/// <summary>
		///Alias
		/// </summary>
		public static string Alias => I18NResource.GetString(ResourceDirectory, "Alias");

		/// <summary>
		///Audit Ts
		/// </summary>
		public static string AuditTs => I18NResource.GetString(ResourceDirectory, "AuditTs");

		/// <summary>
		///Audit User Id
		/// </summary>
		public static string AuditUserId => I18NResource.GetString(ResourceDirectory, "AuditUserId");

		/// <summary>
		///Author Id
		/// </summary>
		public static string AuthorId => I18NResource.GetString(ResourceDirectory, "AuthorId");

		/// <summary>
		///Author Name
		/// </summary>
		public static string AuthorName => I18NResource.GetString(ResourceDirectory, "AuthorName");

		/// <summary>
		///Blog Category Id
		/// </summary>
		public static string BlogCategoryId => I18NResource.GetString(ResourceDirectory, "BlogCategoryId");

		/// <summary>
		///Blog Category Name
		/// </summary>
		public static string BlogCategoryName => I18NResource.GetString(ResourceDirectory, "BlogCategoryName");

		/// <summary>
		///Blog Description
		/// </summary>
		public static string BlogDescription => I18NResource.GetString(ResourceDirectory, "BlogDescription");

		/// <summary>
		///Blog Id
		/// </summary>
		public static string BlogId => I18NResource.GetString(ResourceDirectory, "BlogId");

		/// <summary>
		///Blog Title
		/// </summary>
		public static string BlogTitle => I18NResource.GetString(ResourceDirectory, "BlogTitle");

		/// <summary>
		///Browser
		/// </summary>
		public static string Browser => I18NResource.GetString(ResourceDirectory, "Browser");

		/// <summary>
		///Category Alias
		/// </summary>
		public static string CategoryAlias => I18NResource.GetString(ResourceDirectory, "CategoryAlias");

		/// <summary>
		///Category Id
		/// </summary>
		public static string CategoryId => I18NResource.GetString(ResourceDirectory, "CategoryId");

		/// <summary>
		///Category Name
		/// </summary>
		public static string CategoryName => I18NResource.GetString(ResourceDirectory, "CategoryName");

		/// <summary>
		///City
		/// </summary>
		public static string City => I18NResource.GetString(ResourceDirectory, "City");

		/// <summary>
		///Configuration Id
		/// </summary>
		public static string ConfigurationId => I18NResource.GetString(ResourceDirectory, "ConfigurationId");

		/// <summary>
		///Confirmed
		/// </summary>
		public static string Confirmed => I18NResource.GetString(ResourceDirectory, "Confirmed");

		/// <summary>
		///Confirmed On
		/// </summary>
		public static string ConfirmedOn => I18NResource.GetString(ResourceDirectory, "ConfirmedOn");

		/// <summary>
		///Contact Id
		/// </summary>
		public static string ContactId => I18NResource.GetString(ResourceDirectory, "ContactId");

		/// <summary>
		///Content Alias
		/// </summary>
		public static string ContentAlias => I18NResource.GetString(ResourceDirectory, "ContentAlias");

		/// <summary>
		///Content Id
		/// </summary>
		public static string ContentId => I18NResource.GetString(ResourceDirectory, "ContentId");

		/// <summary>
		///Contents
		/// </summary>
		public static string Contents => I18NResource.GetString(ResourceDirectory, "Contents");

		/// <summary>
		///Country
		/// </summary>
		public static string Country => I18NResource.GetString(ResourceDirectory, "Country");

		/// <summary>
		///Created On
		/// </summary>
		public static string CreatedOn => I18NResource.GetString(ResourceDirectory, "CreatedOn");

		/// <summary>
		///Deleted
		/// </summary>
		public static string Deleted => I18NResource.GetString(ResourceDirectory, "Deleted");

		/// <summary>
		///Description
		/// </summary>
		public static string Description => I18NResource.GetString(ResourceDirectory, "Description");

		/// <summary>
		///Details
		/// </summary>
		public static string Details => I18NResource.GetString(ResourceDirectory, "Details");

		/// <summary>
		///Display Contact Form
		/// </summary>
		public static string DisplayContactForm => I18NResource.GetString(ResourceDirectory, "DisplayContactForm");

		/// <summary>
		///Display Email
		/// </summary>
		public static string DisplayEmail => I18NResource.GetString(ResourceDirectory, "DisplayEmail");

		/// <summary>
		///Domain Name
		/// </summary>
		public static string DomainName => I18NResource.GetString(ResourceDirectory, "DomainName");

		/// <summary>
		///Email
		/// </summary>
		public static string Email => I18NResource.GetString(ResourceDirectory, "Email");

		/// <summary>
		///Email Subscription Id
		/// </summary>
		public static string EmailSubscriptionId => I18NResource.GetString(ResourceDirectory, "EmailSubscriptionId");

		/// <summary>
		///First Name
		/// </summary>
		public static string FirstName => I18NResource.GetString(ResourceDirectory, "FirstName");

		/// <summary>
		///Hits
		/// </summary>
		public static string Hits => I18NResource.GetString(ResourceDirectory, "Hits");

		/// <summary>
		///Ip Address
		/// </summary>
		public static string IpAddress => I18NResource.GetString(ResourceDirectory, "IpAddress");

		/// <summary>
		///Is Blog
		/// </summary>
		public static string IsBlog => I18NResource.GetString(ResourceDirectory, "IsBlog");

		/// <summary>
		///Is Default
		/// </summary>
		public static string IsDefault => I18NResource.GetString(ResourceDirectory, "IsDefault");

		/// <summary>
		///Is Draft
		/// </summary>
		public static string IsDraft => I18NResource.GetString(ResourceDirectory, "IsDraft");

		/// <summary>
		///Is Homepage
		/// </summary>
		public static string IsHomepage => I18NResource.GetString(ResourceDirectory, "IsHomepage");

		/// <summary>
		///Last Edited On
		/// </summary>
		public static string LastEditedOn => I18NResource.GetString(ResourceDirectory, "LastEditedOn");

		/// <summary>
		///Last Editor Id
		/// </summary>
		public static string LastEditorId => I18NResource.GetString(ResourceDirectory, "LastEditorId");

		/// <summary>
		///Last Name
		/// </summary>
		public static string LastName => I18NResource.GetString(ResourceDirectory, "LastName");

		/// <summary>
		///Markdown
		/// </summary>
		public static string Markdown => I18NResource.GetString(ResourceDirectory, "Markdown");

		/// <summary>
		///Menu Id
		/// </summary>
		public static string MenuId => I18NResource.GetString(ResourceDirectory, "MenuId");

		/// <summary>
		///Menu Item Id
		/// </summary>
		public static string MenuItemId => I18NResource.GetString(ResourceDirectory, "MenuItemId");

		/// <summary>
		///Menu Name
		/// </summary>
		public static string MenuName => I18NResource.GetString(ResourceDirectory, "MenuName");

		/// <summary>
		///Name
		/// </summary>
		public static string Name => I18NResource.GetString(ResourceDirectory, "Name");

		/// <summary>
		///Parent Menu Item Id
		/// </summary>
		public static string ParentMenuItemId => I18NResource.GetString(ResourceDirectory, "ParentMenuItemId");

		/// <summary>
		///Position
		/// </summary>
		public static string Position => I18NResource.GetString(ResourceDirectory, "Position");

		/// <summary>
		///Postal Code
		/// </summary>
		public static string PostalCode => I18NResource.GetString(ResourceDirectory, "PostalCode");

		/// <summary>
		///Publish On
		/// </summary>
		public static string PublishOn => I18NResource.GetString(ResourceDirectory, "PublishOn");

		/// <summary>
		///Recipients
		/// </summary>
		public static string Recipients => I18NResource.GetString(ResourceDirectory, "Recipients");

		/// <summary>
<<<<<<< HEAD
		///Seo Description
		/// </summary>
		public static string SeoDescription => I18NResource.GetString(ResourceDirectory, "SeoDescription");

		/// <summary>
		///Sort
		/// </summary>
		public static string Sort => I18NResource.GetString(ResourceDirectory, "Sort");
=======
		///Last Editor Id
		/// </summary>
		public static string LastEditorId => I18NResource.GetString(ResourceDirectory, "LastEditorId");

		/// <summary>
		///State
		/// </summary>
		public static string State => I18NResource.GetString(ResourceDirectory, "State");
>>>>>>> a64747d65c2151b27997e174ef78cea71963bdee

		/// <summary>
		///Blog Id
		/// </summary>
		public static string BlogId => I18NResource.GetString(ResourceDirectory, "BlogId");

		/// <summary>
<<<<<<< HEAD
		///Status
=======
		///Blog Category Id
		/// </summary>
		public static string BlogCategoryId => I18NResource.GetString(ResourceDirectory, "BlogCategoryId");

		/// <summary>
		///Content Id
		/// </summary>
		public static string ContentId => I18NResource.GetString(ResourceDirectory, "ContentId");

		/// <summary>
		///Website Name
>>>>>>> a64747d65c2151b27997e174ef78cea71963bdee
		/// </summary>
		public static string Status => I18NResource.GetString(ResourceDirectory, "Status");

		/// <summary>
<<<<<<< HEAD
		///Subscribed On
=======
		///Is Default
		/// </summary>
		public static string IsDefault => I18NResource.GetString(ResourceDirectory, "IsDefault");

		/// <summary>
		///Is Homepage
>>>>>>> a64747d65c2151b27997e174ef78cea71963bdee
		/// </summary>
		public static string SubscribedOn => I18NResource.GetString(ResourceDirectory, "SubscribedOn");

		/// <summary>
		///Subscription Type
		/// </summary>
		public static string SubscriptionType => I18NResource.GetString(ResourceDirectory, "SubscriptionType");

		/// <summary>
<<<<<<< HEAD
		///Tag
=======
		///Blog Title
>>>>>>> a64747d65c2151b27997e174ef78cea71963bdee
		/// </summary>
		public static string Tag => I18NResource.GetString(ResourceDirectory, "Tag");

		/// <summary>
		///Tag Id
		/// </summary>
		public static string TagId => I18NResource.GetString(ResourceDirectory, "TagId");

		/// <summary>
		///Tags
		/// </summary>
		public static string Tags => I18NResource.GetString(ResourceDirectory, "Tags");

		/// <summary>
		///Target
		/// </summary>
		public static string Target => I18NResource.GetString(ResourceDirectory, "Target");

		/// <summary>
		///Telephone
		/// </summary>
		public static string Telephone => I18NResource.GetString(ResourceDirectory, "Telephone");

		/// <summary>
		///Title
		/// </summary>
		public static string Title => I18NResource.GetString(ResourceDirectory, "Title");

		/// <summary>
		///Unsubscribed
		/// </summary>
		public static string Unsubscribed => I18NResource.GetString(ResourceDirectory, "Unsubscribed");

		/// <summary>
		///Unsubscribed On
		/// </summary>
		public static string UnsubscribedOn => I18NResource.GetString(ResourceDirectory, "UnsubscribedOn");

		/// <summary>
		///Url
		/// </summary>
		public static string Url => I18NResource.GetString(ResourceDirectory, "Url");

		/// <summary>
		///Website Category Id
		/// </summary>
		public static string WebsiteCategoryId => I18NResource.GetString(ResourceDirectory, "WebsiteCategoryId");

		/// <summary>
		///Website Category Name
		/// </summary>
		public static string WebsiteCategoryName => I18NResource.GetString(ResourceDirectory, "WebsiteCategoryName");

		/// <summary>
		///Website Name
		/// </summary>
		public static string WebsiteName => I18NResource.GetString(ResourceDirectory, "WebsiteName");

		/// <summary>
		///Attachments
		/// </summary>
		public static string Attachments => I18NResource.GetString(ResourceDirectory, "Attachments");

		/// <summary>
		///Close
		/// </summary>
		public static string Close => I18NResource.GetString(ResourceDirectory, "Close");

		/// <summary>
		///Download Excel
		/// </summary>
		public static string DownloadExcel => I18NResource.GetString(ResourceDirectory, "DownloadExcel");

		/// <summary>
		///Download PDF
		/// </summary>
		public static string DownloadPdf => I18NResource.GetString(ResourceDirectory, "DownloadPdf");

		/// <summary>
		///Download Text
		/// </summary>
		public static string DownloadText => I18NResource.GetString(ResourceDirectory, "DownloadText");

		/// <summary>
		///Download Word
		/// </summary>
		public static string DownloadWord => I18NResource.GetString(ResourceDirectory, "DownloadWord");

		/// <summary>
		///Download XML
		/// </summary>
		public static string DownloadXml => I18NResource.GetString(ResourceDirectory, "DownloadXml");

		/// <summary>
		///Email This Report
		/// </summary>
		public static string EmailThisReport => I18NResource.GetString(ResourceDirectory, "EmailThisReport");

		/// <summary>
		///Frapid Report
		/// </summary>
		public static string FrapidReport => I18NResource.GetString(ResourceDirectory, "FrapidReport");

		/// <summary>
		///Message
		/// </summary>
		public static string Message => I18NResource.GetString(ResourceDirectory, "Message");

		/// <summary>
		///No email processor defined.
		/// </summary>
		public static string NoEmailProcessorDefined => I18NResource.GetString(ResourceDirectory, "NoEmailProcessorDefined");

		/// <summary>
		///Please find the attached document.
		/// </summary>
		public static string PleaseFindAttachedDocument => I18NResource.GetString(ResourceDirectory, "PleaseFindAttachedDocument");

		/// <summary>
		///Print This Report
		/// </summary>
		public static string PrintThisReport => I18NResource.GetString(ResourceDirectory, "PrintThisReport");

		/// <summary>
		///Reload
		/// </summary>
		public static string Reload => I18NResource.GetString(ResourceDirectory, "Reload");

		/// <summary>
		///Send
		/// </summary>
		public static string Send => I18NResource.GetString(ResourceDirectory, "Send");

		/// <summary>
		///Send Email
		/// </summary>
		public static string SendEmail => I18NResource.GetString(ResourceDirectory, "SendEmail");

		/// <summary>
		///Send To
		/// </summary>
		public static string SendTo => I18NResource.GetString(ResourceDirectory, "SendTo");

		/// <summary>
		///Show
		/// </summary>
		public static string Show => I18NResource.GetString(ResourceDirectory, "Show");

		/// <summary>
		///Subject
		/// </summary>
		public static string Subject => I18NResource.GetString(ResourceDirectory, "Subject");

		/// <summary>
		///Zoom In
		/// </summary>
		public static string ZoomIn => I18NResource.GetString(ResourceDirectory, "ZoomIn");

		/// <summary>
		///Zoom Out
		/// </summary>
		public static string ZoomOut => I18NResource.GetString(ResourceDirectory, "ZoomOut");

	}
}
