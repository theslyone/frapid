using System.Collections.Generic;
using System.Globalization;
using Frapid.Configuration;
using Frapid.i18n;

namespace Frapid.i18n
{
	public sealed class Localize : ILocalize
	{
		public Dictionary<string, string> GetResources(CultureInfo culture)
		{
			string resourceDirectory = Resources.ResourceDirectory;
			return I18NResource.GetResources(resourceDirectory, culture);
		}
	}

	public static class Resources
	{
		public static string ResourceDirectory { get; }

		static Resources()
		{
			ResourceDirectory = PathMapper.MapPath("i18n");
		}

		/// <summary>
		///Sign In
		/// </summary>
		public static string SignIn => I18NResource.GetString(ResourceDirectory, "SignIn");

		/// <summary>
		///Username
		/// </summary>
		public static string Username => I18NResource.GetString(ResourceDirectory, "Username");

		/// <summary>
		///Password
		/// </summary>
		public static string Password => I18NResource.GetString(ResourceDirectory, "Password");

		/// <summary>
		///Return to Website
		/// </summary>
		public static string ReturnToWebsite => I18NResource.GetString(ResourceDirectory, "ReturnToWebsite");

		/// <summary>
		///Or
		/// </summary>
		public static string Or => I18NResource.GetString(ResourceDirectory, "Or");

		/// <summary>
		///Add
		/// </summary>
		public static string Add => I18NResource.GetString(ResourceDirectory, "Add");

		/// <summary>
		///Save
		/// </summary>
		public static string Save => I18NResource.GetString(ResourceDirectory, "Save");

		/// <summary>
		///Actions
		/// </summary>
		public static string Actions => I18NResource.GetString(ResourceDirectory, "Actions");

		/// <summary>
		///Edit
		/// </summary>
		public static string Edit => I18NResource.GetString(ResourceDirectory, "Edit");

		/// <summary>
		///Delete
		/// </summary>
		public static string Delete => I18NResource.GetString(ResourceDirectory, "Delete");

		/// <summary>
		///Update
		/// </summary>
		public static string Update => I18NResource.GetString(ResourceDirectory, "Update");

		/// <summary>
		///Select
		/// </summary>
		public static string Select => I18NResource.GetString(ResourceDirectory, "Select");

		/// <summary>
		///Approve
		/// </summary>
		public static string Approve => I18NResource.GetString(ResourceDirectory, "Approve");

		/// <summary>
		///Reject
		/// </summary>
		public static string Reject => I18NResource.GetString(ResourceDirectory, "Reject");

		/// <summary>
		///Close
		/// </summary>
		public static string Close => I18NResource.GetString(ResourceDirectory, "Close");

		/// <summary>
		///Return to View
		/// </summary>
		public static string ReturnToView => I18NResource.GetString(ResourceDirectory, "ReturnToView");

		/// <summary>
		///Create Duplicate
		/// </summary>
		public static string CreateDuplicate => I18NResource.GetString(ResourceDirectory, "CreateDuplicate");

		/// <summary>
		///None
		/// </summary>
		public static string None => I18NResource.GetString(ResourceDirectory, "None");

		/// <summary>
		///First
		/// </summary>
		public static string First => I18NResource.GetString(ResourceDirectory, "First");

		/// <summary>
		///Previous
		/// </summary>
		public static string Previous => I18NResource.GetString(ResourceDirectory, "Previous");

		/// <summary>
		///Next
		/// </summary>
		public static string Next => I18NResource.GetString(ResourceDirectory, "Next");

		/// <summary>
		///Last
		/// </summary>
		public static string Last => I18NResource.GetString(ResourceDirectory, "Last");

		/// <summary>
		///Loading
		/// </summary>
		public static string Loading => I18NResource.GetString(ResourceDirectory, "Loading");

		/// <summary>
		///Create a Flag
		/// </summary>
		public static string CreateAFlag => I18NResource.GetString(ResourceDirectory, "CreateAFlag");

		/// <summary>
		///Create New
		/// </summary>
		public static string CreateNew => I18NResource.GetString(ResourceDirectory, "CreateNew");

		/// <summary>
		///Verification
		/// </summary>
		public static string Verification => I18NResource.GetString(ResourceDirectory, "Verification");

		/// <summary>
		///Reason
		/// </summary>
		public static string Reason => I18NResource.GetString(ResourceDirectory, "Reason");

		/// <summary>
		///Add a Kanban List
		/// </summary>
		public static string AddAKanbanList => I18NResource.GetString(ResourceDirectory, "AddAKanbanList");

		/// <summary>
		///KanbanId
		/// </summary>
		public static string KanbanId => I18NResource.GetString(ResourceDirectory, "KanbanId");

		/// <summary>
		///KanbanName
		/// </summary>
		public static string KanbanName => I18NResource.GetString(ResourceDirectory, "KanbanName");

		/// <summary>
		///Description
		/// </summary>
		public static string Description => I18NResource.GetString(ResourceDirectory, "Description");

		/// <summary>
		///Cancel
		/// </summary>
		public static string Cancel => I18NResource.GetString(ResourceDirectory, "Cancel");

		/// <summary>
		///OK
		/// </summary>
		public static string OK => I18NResource.GetString(ResourceDirectory, "OK");

		/// <summary>
		///Add New
		/// </summary>
		public static string AddNew => I18NResource.GetString(ResourceDirectory, "AddNew");

		/// <summary>
		///Flag
		/// </summary>
		public static string Flag => I18NResource.GetString(ResourceDirectory, "Flag");

		/// <summary>
		///Filter
		/// </summary>
		public static string Filter => I18NResource.GetString(ResourceDirectory, "Filter");

		/// <summary>
		///Export
		/// </summary>
		public static string Export => I18NResource.GetString(ResourceDirectory, "Export");

		/// <summary>
		///Export This Document
		/// </summary>
		public static string ExportThisDocument => I18NResource.GetString(ResourceDirectory, "ExportThisDocument");

		/// <summary>
		///Export to Doc
		/// </summary>
		public static string ExportToDoc => I18NResource.GetString(ResourceDirectory, "ExportToDoc");

		/// <summary>
		///Export to Excel
		/// </summary>
		public static string ExportToExcel => I18NResource.GetString(ResourceDirectory, "ExportToExcel");

		/// <summary>
		///Export to PDF
		/// </summary>
		public static string ExportToPDF => I18NResource.GetString(ResourceDirectory, "ExportToPDF");

		/// <summary>
		///Print
		/// </summary>
		public static string Print => I18NResource.GetString(ResourceDirectory, "Print");

		/// <summary>
		///Select a Column
		/// </summary>
		public static string SelectAColumn => I18NResource.GetString(ResourceDirectory, "SelectAColumn");

		/// <summary>
		///Filter Condition
		/// </summary>
		public static string FilterCondition => I18NResource.GetString(ResourceDirectory, "FilterCondition");

		/// <summary>
		///Value
		/// </summary>
		public static string Value => I18NResource.GetString(ResourceDirectory, "Value");

		/// <summary>
		///And
		/// </summary>
		public static string And => I18NResource.GetString(ResourceDirectory, "And");

		/// <summary>
		///Column Name
		/// </summary>
		public static string ColumnName => I18NResource.GetString(ResourceDirectory, "ColumnName");

		/// <summary>
		///Condition
		/// </summary>
		public static string Condition => I18NResource.GetString(ResourceDirectory, "Condition");

		/// <summary>
		///Save This Filter
		/// </summary>
		public static string SaveThisFilter => I18NResource.GetString(ResourceDirectory, "SaveThisFilter");

		/// <summary>
		///Filter Name
		/// </summary>
		public static string FilterName => I18NResource.GetString(ResourceDirectory, "FilterName");

		/// <summary>
		///Manage Filters
		/// </summary>
		public static string ManageFilters => I18NResource.GetString(ResourceDirectory, "ManageFilters");

		/// <summary>
		///Remove As Default
		/// </summary>
		public static string RemoveAsDefault => I18NResource.GetString(ResourceDirectory, "RemoveAsDefault");

		/// <summary>
		///Make As Default
		/// </summary>
		public static string MakeAsDefault => I18NResource.GetString(ResourceDirectory, "MakeAsDefault");

		/// <summary>
		///Data Import
		/// </summary>
		public static string DataImport => I18NResource.GetString(ResourceDirectory, "DataImport");

		/// <summary>
		///Export Data
		/// </summary>
		public static string ExportData => I18NResource.GetString(ResourceDirectory, "ExportData");

		/// <summary>
		///Import Data
		/// </summary>
		public static string ImportData => I18NResource.GetString(ResourceDirectory, "ImportData");

		/// <summary>
		///Yes
		/// </summary>
		public static string Yes => I18NResource.GetString(ResourceDirectory, "Yes");

		/// <summary>
		///No
		/// </summary>
		public static string No => I18NResource.GetString(ResourceDirectory, "No");

		/// <summary>
		///View
		/// </summary>
		public static string View => I18NResource.GetString(ResourceDirectory, "View");

		/// <summary>
		///Rating
		/// </summary>
		public static string Rating => I18NResource.GetString(ResourceDirectory, "Rating");

		/// <summary>
		///Add New Checklist
		/// </summary>
		public static string AddNewChecklist => I18NResource.GetString(ResourceDirectory, "AddNewChecklist");

		/// <summary>
		///Edit This Checklist
		/// </summary>
		public static string EditThisChecklist => I18NResource.GetString(ResourceDirectory, "EditThisChecklist");

		/// <summary>
		///Delete This Checklist
		/// </summary>
		public static string DeleteThisChecklist => I18NResource.GetString(ResourceDirectory, "DeleteThisChecklist");

		/// <summary>
		///Verify
		/// </summary>
		public static string Verify => I18NResource.GetString(ResourceDirectory, "Verify");

		/// <summary>
		///Back
		/// </summary>
		public static string Back => I18NResource.GetString(ResourceDirectory, "Back");

		/// <summary>
		///Page {0}
		/// </summary>
		public static string PageN => I18NResource.GetString(ResourceDirectory, "PageN");

		/// <summary>
		///Select a Filter
		/// </summary>
		public static string SelectAFilter => I18NResource.GetString(ResourceDirectory, "SelectAFilter");

		/// <summary>
		///Custom Fields
		/// </summary>
		public static string CustomFields => I18NResource.GetString(ResourceDirectory, "CustomFields");

		/// <summary>
		///Untitled
		/// </summary>
		public static string Untitled => I18NResource.GetString(ResourceDirectory, "Untitled");

		/// <summary>
		///Your upload is of invalid file type "{0}". Please try again.
		/// </summary>
		public static string UploadInvalidTryAgain => I18NResource.GetString(ResourceDirectory, "UploadInvalidTryAgain");

		/// <summary>
		///Processing  your CSV file.
		/// </summary>
		public static string ProcessingYourCSVFile => I18NResource.GetString(ResourceDirectory, "ProcessingYourCSVFile");

		/// <summary>
		///Flag was saved.
		/// </summary>
		public static string FlagSaved => I18NResource.GetString(ResourceDirectory, "FlagSaved");

		/// <summary>
		///Successfully processed your file.
		/// </summary>
		public static string SuccessfullyProcessedYourFile => I18NResource.GetString(ResourceDirectory, "SuccessfullyProcessedYourFile");

		/// <summary>
		///Flag was removed.
		/// </summary>
		public static string FlagRemoved => I18NResource.GetString(ResourceDirectory, "FlagRemoved");

		/// <summary>
		///Requesting import. This may take several minutes to complete.
		/// </summary>
		public static string RequestingImport => I18NResource.GetString(ResourceDirectory, "RequestingImport");

		/// <summary>
		///No instance of form was found.
		/// </summary>
		public static string NoFormFound => I18NResource.GetString(ResourceDirectory, "NoFormFound");

		/// <summary>
		///Successfully imported {0} items.
		/// </summary>
		public static string ImportedNItems => I18NResource.GetString(ResourceDirectory, "ImportedNItems");

		/// <summary>
		///Rolling back changes.
		/// </summary>
		public static string RollingBackChanges => I18NResource.GetString(ResourceDirectory, "RollingBackChanges");

		/// <summary>
		///Invalid file extension.
		/// </summary>
		public static string InvalidFileExtension => I18NResource.GetString(ResourceDirectory, "InvalidFileExtension");

		/// <summary>
		///Are you sure?
		/// </summary>
		public static string AreYouSure => I18NResource.GetString(ResourceDirectory, "AreYouSure");

		/// <summary>
		///The column "{0}" does not exist or is invalid. Are you sure you want to continue?
		/// </summary>
		public static string ColumnInvalidAreYouSure => I18NResource.GetString(ResourceDirectory, "ColumnInvalidAreYouSure");

		/// <summary>
		///Task completed successfully. Return to view?
		/// </summary>
		public static string TaskCompletedSuccessfullyReturnToView => I18NResource.GetString(ResourceDirectory, "TaskCompletedSuccessfullyReturnToView");

		/// <summary>
		///{0} hour(s).
		/// </summary>
		public static string NHours => I18NResource.GetString(ResourceDirectory, "NHours");

		/// <summary>
		///{0} minute(s).
		/// </summary>
		public static string NMinutes => I18NResource.GetString(ResourceDirectory, "NMinutes");

		/// <summary>
		///Item duplicated.
		/// </summary>
		public static string ItemDuplicated => I18NResource.GetString(ResourceDirectory, "ItemDuplicated");

		/// <summary>
		///Task completed successfully.
		/// </summary>
		public static string TaskCompletedSuccessfully => I18NResource.GetString(ResourceDirectory, "TaskCompletedSuccessfully");

		/// <summary>
		///This field is required.
		/// </summary>
		public static string ThisFieldIsRequired => I18NResource.GetString(ResourceDirectory, "ThisFieldIsRequired");

		/// <summary>
		///Filter: {0}.
		/// </summary>
		public static string NamedFilter => I18NResource.GetString(ResourceDirectory, "NamedFilter");

		/// <summary>
		///The table was not found.
		/// </summary>
		public static string TableNotFound => I18NResource.GetString(ResourceDirectory, "TableNotFound");

		/// <summary>
		///Notifications
		/// </summary>
		public static string Notifications => I18NResource.GetString(ResourceDirectory, "Notifications");

		/// <summary>
		///Notifications
		/// </summary>
		public static string Notification => I18NResource.GetString(ResourceDirectory, "Notification");

		/// <summary>
		///Mark All as Read
		/// </summary>
		public static string MarkAllAsRead => I18NResource.GetString(ResourceDirectory, "MarkAllAsRead");

		/// <summary>
		///Cannot Save
		/// </summary>
		public static string CannotSave => I18NResource.GetString(ResourceDirectory, "CannotSave");

		/// <summary>
		///Form Invalid
		/// </summary>
		public static string FormInvalid => I18NResource.GetString(ResourceDirectory, "FormInvalid");

		/// <summary>
		///You don't have any notification.
		/// </summary>
		public static string YouDontHaveAnyNotification => I18NResource.GetString(ResourceDirectory, "YouDontHaveAnyNotification");

		/// <summary>
		///Select Language
		/// </summary>
		public static string SelectLanguage => I18NResource.GetString(ResourceDirectory, "SelectLanguage");

		/// <summary>
		///Search Results
		/// </summary>
		public static string SearchResults => I18NResource.GetString(ResourceDirectory, "SearchResults");

		/// <summary>
		///It's good to see you again, {0}!
		/// </summary>
		public static string GreetingGoodToSeeYouAgain => I18NResource.GetString(ResourceDirectory, "GreetingGoodToSeeYouAgain");

		/// <summary>
		///Nice to see you, {0}!
		/// </summary>
		public static string GreetingNiceToSeeYou => I18NResource.GetString(ResourceDirectory, "GreetingNiceToSeeYou");

		/// <summary>
		///How was your day, {0}?
		/// </summary>
		public static string GreetingHowWasYourDay => I18NResource.GetString(ResourceDirectory, "GreetingHowWasYourDay");

		/// <summary>
		///Welcome back {0}.
		/// </summary>
		public static string GreetingWelcomeBack => I18NResource.GetString(ResourceDirectory, "GreetingWelcomeBack");

		/// <summary>
		///Hi!
		/// </summary>
		public static string GreetingHi => I18NResource.GetString(ResourceDirectory, "GreetingHi");

		/// <summary>
		///There you are!
		/// </summary>
		public static string GreetingThereYouAre => I18NResource.GetString(ResourceDirectory, "GreetingThereYouAre");

		/// <summary>
		///We missed you!!!
		/// </summary>
		public static string GreetingWeMissedYou => I18NResource.GetString(ResourceDirectory, "GreetingWeMissedYou");

		/// <summary>
		///You're back with a bang!!!
		/// </summary>
		public static string GreetingYouAreBackWithABang => I18NResource.GetString(ResourceDirectory, "GreetingYouAreBackWithABang");

		/// <summary>
		///You're awesome. ;)
		/// </summary>
		public static string GreetingYouAreAwesome => I18NResource.GetString(ResourceDirectory, "GreetingYouAreAwesome");

		/// <summary>
		///Dashboard
		/// </summary>
		public static string Dashboard => I18NResource.GetString(ResourceDirectory, "Dashboard");

		/// <summary>
		///Show Notifications
		/// </summary>
		public static string ShowNotifications => I18NResource.GetString(ResourceDirectory, "ShowNotifications");

		/// <summary>
		///Say Hi
		/// </summary>
		public static string SayHi => I18NResource.GetString(ResourceDirectory, "SayHi");

		/// <summary>
		///Log Off
		/// </summary>
		public static string LogOff => I18NResource.GetString(ResourceDirectory, "LogOff");

		/// <summary>
		///Hope to see you soon.
		/// </summary>
		public static string HopeToSeeYouSoon => I18NResource.GetString(ResourceDirectory, "HopeToSeeYouSoon");

		/// <summary>
		///Sign Out
		/// </summary>
		public static string SignOut => I18NResource.GetString(ResourceDirectory, "SignOut");

		/// <summary>
		///Go Back
		/// </summary>
		public static string GoBack => I18NResource.GetString(ResourceDirectory, "GoBack");

		/// <summary>
		///Goodbye
		/// </summary>
		public static string Goodbye => I18NResource.GetString(ResourceDirectory, "Goodbye");

		/// <summary>
		///Installing frapid, please visit the site after a few minutes.
		/// </summary>
		public static string FrapidInstallationMessage => I18NResource.GetString(ResourceDirectory, "FrapidInstallationMessage");

		/// <summary>
		///Could not generate sitemap.
		/// </summary>
		public static string CouldNotGenerateSiteMap => I18NResource.GetString(ResourceDirectory, "CouldNotGenerateSiteMap");

		/// <summary>
		///Only a single file may be uploaded.
		/// </summary>
		public static string OnlyASingleFileMayBeUploaded => I18NResource.GetString(ResourceDirectory, "OnlyASingleFileMayBeUploaded");

		/// <summary>
		///No file was uploaded.
		/// </summary>
		public static string NoFileWasUploaded => I18NResource.GetString(ResourceDirectory, "NoFileWasUploaded");

		/// <summary>
		///Access is denied
		/// </summary>
		public static string AccessIsDenied => I18NResource.GetString(ResourceDirectory, "AccessIsDenied");

		/// <summary>
		///Access is denied. Deleting a website is not allowed.
		/// </summary>
		public static string DeletingWebsiteIsNotAllowed => I18NResource.GetString(ResourceDirectory, "DeletingWebsiteIsNotAllowed");

		/// <summary>
		///Cannot find a suitable directory to create a PostgreSQL DB Backup.
		/// </summary>
		public static string CannotFindPostgreSQLBackupDirectory => I18NResource.GetString(ResourceDirectory, "CannotFindPostgreSQLBackupDirectory");

		/// <summary>
		///Could not create backup.
		/// </summary>
		public static string CouldNotCreateBackup => I18NResource.GetString(ResourceDirectory, "CouldNotCreateBackup");

		/// <summary>
		///Go to Website
		/// </summary>
		public static string GoToWebsite => I18NResource.GetString(ResourceDirectory, "GoToWebsite");

		/// <summary>
		///Search ...
		/// </summary>
		public static string Search => I18NResource.GetString(ResourceDirectory, "Search");

		/// <summary>
		///CTRL + SHIFT + F
		/// </summary>
		public static string CtrlShiftF => I18NResource.GetString(ResourceDirectory, "CtrlShiftF");

		/// <summary>
		///Filters
		/// </summary>
		public static string Filters => I18NResource.GetString(ResourceDirectory, "Filters");

		/// <summary>
		///Show
		/// </summary>
		public static string Show => I18NResource.GetString(ResourceDirectory, "Show");

		/// <summary>
		///Grid View
		/// </summary>
		public static string GridView => I18NResource.GetString(ResourceDirectory, "GridView");

		/// <summary>
		///Kanban View
		/// </summary>
		public static string KanbanView => I18NResource.GetString(ResourceDirectory, "KanbanView");

		/// <summary>
		///Filter View
		/// </summary>
		public static string FilterView => I18NResource.GetString(ResourceDirectory, "FilterView");

		/// <summary>
		///Import
		/// </summary>
		public static string Import => I18NResource.GetString(ResourceDirectory, "Import");

		/// <summary>
		///Clear Filters
		/// </summary>
		public static string ClearFilters => I18NResource.GetString(ResourceDirectory, "ClearFilters");

	}
}
