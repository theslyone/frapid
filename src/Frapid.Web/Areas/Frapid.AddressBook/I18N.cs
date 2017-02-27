using System.Collections.Generic;
using System.Globalization;
using Frapid.Configuration;
using Frapid.i18n;

namespace Frapid.AddressBook
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
			ResourceDirectory = PathMapper.MapPath("/Areas/Frapid.AddressBook/i18n");
		}

		/// <summary>
		///Select Type
		/// </summary>
		public static string SelectType => I18NResource.GetString(ResourceDirectory, "SelectType");

		/// <summary>
		///All Contacts
		/// </summary>
		public static string AllContacts => I18NResource.GetString(ResourceDirectory, "AllContacts");

		/// <summary>
		///Private Only
		/// </summary>
		public static string PrivateOnly => I18NResource.GetString(ResourceDirectory, "PrivateOnly");

		/// <summary>
		///Tags
		/// </summary>
		public static string Tags => I18NResource.GetString(ResourceDirectory, "Tags");

		/// <summary>
		///Add a New Contact
		/// </summary>
		public static string AddNewContact => I18NResource.GetString(ResourceDirectory, "AddNewContact");

		/// <summary>
		///Bulk Email
		/// </summary>
		public static string BulkEmail => I18NResource.GetString(ResourceDirectory, "BulkEmail");

		/// <summary>
		///Bulk SMS
		/// </summary>
		public static string BulkSms => I18NResource.GetString(ResourceDirectory, "BulkSms");

		/// <summary>
		///Find Duplicates
		/// </summary>
		public static string FindDuplicates => I18NResource.GetString(ResourceDirectory, "FindDuplicates");

		/// <summary>
		///Sync Now
		/// </summary>
		public static string SyncNow => I18NResource.GetString(ResourceDirectory, "SyncNow");

		/// <summary>
		///Import Contacts from a vCard File
		/// </summary>
		public static string ImportContactsFromVcard => I18NResource.GetString(ResourceDirectory, "ImportContactsFromVcard");

		/// <summary>
		///Export Contacts to a vCard File
		/// </summary>
		public static string ExportContactsToVcard => I18NResource.GetString(ResourceDirectory, "ExportContactsToVcard");

		/// <summary>
		///Delete Contact
		/// </summary>
		public static string DeleteContact => I18NResource.GetString(ResourceDirectory, "DeleteContact");

		/// <summary>
		///Search ...
		/// </summary>
		public static string Search => I18NResource.GetString(ResourceDirectory, "Search");

		/// <summary>
		///Prefix
		/// </summary>
		public static string Prefix => I18NResource.GetString(ResourceDirectory, "Prefix");

		/// <summary>
		///Suffix
		/// </summary>
		public static string Suffix => I18NResource.GetString(ResourceDirectory, "Suffix");

		/// <summary>
		///First Name
		/// </summary>
		public static string FirstName => I18NResource.GetString(ResourceDirectory, "FirstName");

		/// <summary>
		///Middle Name
		/// </summary>
		public static string MiddleName => I18NResource.GetString(ResourceDirectory, "MiddleName");

		/// <summary>
		///Last Name
		/// </summary>
		public static string LastName => I18NResource.GetString(ResourceDirectory, "LastName");

		/// <summary>
		///Email Address(es)
		/// </summary>
		public static string EmailAddresses => I18NResource.GetString(ResourceDirectory, "EmailAddresses");

		/// <summary>
		///Mobile Number(s)
		/// </summary>
		public static string MobileNumbers => I18NResource.GetString(ResourceDirectory, "MobileNumbers");

		/// <summary>
		///More
		/// </summary>
		public static string More => I18NResource.GetString(ResourceDirectory, "More");

		/// <summary>
		///Less
		/// </summary>
		public static string Less => I18NResource.GetString(ResourceDirectory, "Less");

		/// <summary>
		///Nick Name
		/// </summary>
		public static string NickName => I18NResource.GetString(ResourceDirectory, "NickName");

		/// <summary>
		///Gender
		/// </summary>
		public static string Gender => I18NResource.GetString(ResourceDirectory, "Gender");

		/// <summary>
		///Not Specified
		/// </summary>
		public static string NotSpecified => I18NResource.GetString(ResourceDirectory, "NotSpecified");

		/// <summary>
		///Female
		/// </summary>
		public static string Female => I18NResource.GetString(ResourceDirectory, "Female");

		/// <summary>
		///Male
		/// </summary>
		public static string Male => I18NResource.GetString(ResourceDirectory, "Male");

		/// <summary>
		///Not Applicable
		/// </summary>
		public static string NotApplicable => I18NResource.GetString(ResourceDirectory, "NotApplicable");

		/// <summary>
		///Other
		/// </summary>
		public static string Other => I18NResource.GetString(ResourceDirectory, "Other");

		/// <summary>
		///Telephone Number(s)
		/// </summary>
		public static string TelephoneNumbers => I18NResource.GetString(ResourceDirectory, "TelephoneNumbers");

		/// <summary>
		///Fax Number(s)
		/// </summary>
		public static string FaxNumbers => I18NResource.GetString(ResourceDirectory, "FaxNumbers");

		/// <summary>
		///Website
		/// </summary>
		public static string Website => I18NResource.GetString(ResourceDirectory, "Website");

		/// <summary>
		///Time Zone
		/// </summary>
		public static string TimeZone => I18NResource.GetString(ResourceDirectory, "TimeZone");

		/// <summary>
		///Language
		/// </summary>
		public static string Language => I18NResource.GetString(ResourceDirectory, "Language");

		/// <summary>
		///Title
		/// </summary>
		public static string Title => I18NResource.GetString(ResourceDirectory, "Title");

		/// <summary>
		///Role
		/// </summary>
		public static string Role => I18NResource.GetString(ResourceDirectory, "Role");

		/// <summary>
		///Organization
		/// </summary>
		public static string Organization => I18NResource.GetString(ResourceDirectory, "Organization");

		/// <summary>
		///Organizational Unit
		/// </summary>
		public static string OrganizationalUnit => I18NResource.GetString(ResourceDirectory, "OrganizationalUnit");

		/// <summary>
		///Contact Type
		/// </summary>
		public static string ContactType => I18NResource.GetString(ResourceDirectory, "ContactType");

		/// <summary>
		///Individual
		/// </summary>
		public static string Individual => I18NResource.GetString(ResourceDirectory, "Individual");

		/// <summary>
		///Group
		/// </summary>
		public static string Group => I18NResource.GetString(ResourceDirectory, "Group");

		/// <summary>
		///Location
		/// </summary>
		public static string Location => I18NResource.GetString(ResourceDirectory, "Location");

		/// <summary>
		///Linked User Id
		/// </summary>
		public static string LinkedUserId => I18NResource.GetString(ResourceDirectory, "LinkedUserId");

		/// <summary>
		///Birth Day
		/// </summary>
		public static string BirthDay => I18NResource.GetString(ResourceDirectory, "BirthDay");

		/// <summary>
		///Upload Avatar
		/// </summary>
		public static string UploadAvatar => I18NResource.GetString(ResourceDirectory, "UploadAvatar");

		/// <summary>
		///Upload
		/// </summary>
		public static string Upload => I18NResource.GetString(ResourceDirectory, "Upload");

		/// <summary>
		///Address Line 1
		/// </summary>
		public static string AddressLine1 => I18NResource.GetString(ResourceDirectory, "AddressLine1");

		/// <summary>
		///Address Line 2
		/// </summary>
		public static string AddressLine2 => I18NResource.GetString(ResourceDirectory, "AddressLine2");

		/// <summary>
		///Postal Code
		/// </summary>
		public static string PostalCode => I18NResource.GetString(ResourceDirectory, "PostalCode");

		/// <summary>
		///Street
		/// </summary>
		public static string Street => I18NResource.GetString(ResourceDirectory, "Street");

		/// <summary>
		///City
		/// </summary>
		public static string City => I18NResource.GetString(ResourceDirectory, "City");

		/// <summary>
		///State
		/// </summary>
		public static string State => I18NResource.GetString(ResourceDirectory, "State");

		/// <summary>
		///Country
		/// </summary>
		public static string Country => I18NResource.GetString(ResourceDirectory, "Country");

		/// <summary>
		///Note
		/// </summary>
		public static string Note => I18NResource.GetString(ResourceDirectory, "Note");

		/// <summary>
		///Do not share with other users
		/// </summary>
		public static string DoNotShareWithOtherUsers => I18NResource.GetString(ResourceDirectory, "DoNotShareWithOtherUsers");

		/// <summary>
		///Save
		/// </summary>
		public static string Save => I18NResource.GetString(ResourceDirectory, "Save");

		/// <summary>
		///Send Email
		/// </summary>
		public static string SendEmail => I18NResource.GetString(ResourceDirectory, "SendEmail");

		/// <summary>
		///Subject
		/// </summary>
		public static string Subject => I18NResource.GetString(ResourceDirectory, "Subject");

		/// <summary>
		///Enter Subject
		/// </summary>
		public static string EnterSubject => I18NResource.GetString(ResourceDirectory, "EnterSubject");

		/// <summary>
		///Message
		/// </summary>
		public static string Message => I18NResource.GetString(ResourceDirectory, "Message");

		/// <summary>
		///Enter Your Message
		/// </summary>
		public static string EnterYourMessage => I18NResource.GetString(ResourceDirectory, "EnterYourMessage");

		/// <summary>
		///Send
		/// </summary>
		public static string Send => I18NResource.GetString(ResourceDirectory, "Send");

		/// <summary>
		///Close
		/// </summary>
		public static string Close => I18NResource.GetString(ResourceDirectory, "Close");

		/// <summary>
		///Send Text Message
		/// </summary>
		public static string SendTextMessage => I18NResource.GetString(ResourceDirectory, "SendTextMessage");

		/// <summary>
		///Select
		/// </summary>
		public static string Select => I18NResource.GetString(ResourceDirectory, "Select");

		/// <summary>
		///Please select at least one contact.
		/// </summary>
		public static string PleaseSelectAtLeastOneContact => I18NResource.GetString(ResourceDirectory, "PleaseSelectAtLeastOneContact");

		/// <summary>
		///Please enter a subject.
		/// </summary>
		public static string PleaseEnterSubject => I18NResource.GetString(ResourceDirectory, "PleaseEnterSubject");

		/// <summary>
		///Please enter a message.
		/// </summary>
		public static string PleaseEnterMessage => I18NResource.GetString(ResourceDirectory, "PleaseEnterMessage");

		/// <summary>
		///Could not send the email. Please setup email provider or consult with your administrator.
		/// </summary>
		public static string CouldNotSendEmailSetupProvider => I18NResource.GetString(ResourceDirectory, "CouldNotSendEmailSetupProvider");

		/// <summary>
		///Could not send the text message. Please setup SMS gateway or consult with your administrator.
		/// </summary>
		public static string CouldNotSendSmsSetupProvider => I18NResource.GetString(ResourceDirectory, "CouldNotSendSmsSetupProvider");

	}
}
