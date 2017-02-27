using System.Collections.Generic;
using System.Globalization;
using Frapid.Configuration;
using Frapid.i18n;

namespace Frapid.Calendar
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
			ResourceDirectory = PathMapper.MapPath("/Areas/Frapid.Calendar/i18n");
		}

		/// <summary>
		///Invalid model data.
		/// </summary>
		public static string InvalidModelData => I18NResource.GetString(ResourceDirectory, "InvalidModelData");

		/// <summary>
		///Please enter a category name.
		/// </summary>
		public static string PleaseEnterCategoryName => I18NResource.GetString(ResourceDirectory, "PleaseEnterCategoryName");

		/// <summary>
		///Please select a category color.
		/// </summary>
		public static string PleaseSelectCategoryColor => I18NResource.GetString(ResourceDirectory, "PleaseSelectCategoryColor");

		/// <summary>
		///Please select a category to edit.
		/// </summary>
		public static string PleaseSelectCategoryToEdit => I18NResource.GetString(ResourceDirectory, "PleaseSelectCategoryToEdit");

		/// <summary>
		///Add Category
		/// </summary>
		public static string AddCategory => I18NResource.GetString(ResourceDirectory, "AddCategory");

		/// <summary>
		///Add Event
		/// </summary>
		public static string AddEvent => I18NResource.GetString(ResourceDirectory, "AddEvent");

		/// <summary>
		///Save Order
		/// </summary>
		public static string SaveOrder => I18NResource.GetString(ResourceDirectory, "SaveOrder");

		/// <summary>
		///Edit the First Selected Category
		/// </summary>
		public static string EditFirstSelectedCategory => I18NResource.GetString(ResourceDirectory, "EditFirstSelectedCategory");

		/// <summary>
		///Edit
		/// </summary>
		public static string Edit => I18NResource.GetString(ResourceDirectory, "Edit");

		/// <summary>
		///Delete the First Selected Category
		/// </summary>
		public static string DeleteFirstSelectedCategory => I18NResource.GetString(ResourceDirectory, "DeleteFirstSelectedCategory");

		/// <summary>
		///Delete
		/// </summary>
		public static string Delete => I18NResource.GetString(ResourceDirectory, "Delete");

		/// <summary>
		///Enter Category Name
		/// </summary>
		public static string EnterCategoryName => I18NResource.GetString(ResourceDirectory, "EnterCategoryName");

		/// <summary>
		///Save
		/// </summary>
		public static string Save => I18NResource.GetString(ResourceDirectory, "Save");

		/// <summary>
		///Close
		/// </summary>
		public static string Close => I18NResource.GetString(ResourceDirectory, "Close");

		/// <summary>
		///Dinner with Kathey tonight at York & Albany
		/// </summary>
		public static string NaturalLanguageDemoText => I18NResource.GetString(ResourceDirectory, "NaturalLanguageDemoText");

		/// <summary>
		///Integrations
		/// </summary>
		public static string Integrations => I18NResource.GetString(ResourceDirectory, "Integrations");

		/// <summary>
		///Enter Event Title
		/// </summary>
		public static string EnterEventTitle => I18NResource.GetString(ResourceDirectory, "EnterEventTitle");

		/// <summary>
		///Select Category
		/// </summary>
		public static string SelectCategory => I18NResource.GetString(ResourceDirectory, "SelectCategory");

		/// <summary>
		///Enter Location
		/// </summary>
		public static string EnterLocation => I18NResource.GetString(ResourceDirectory, "EnterLocation");

		/// <summary>
		///Starts At
		/// </summary>
		public static string StartsAt => I18NResource.GetString(ResourceDirectory, "StartsAt");

		/// <summary>
		///Ends On
		/// </summary>
		public static string EndsOn => I18NResource.GetString(ResourceDirectory, "EndsOn");

		/// <summary>
		///All day
		/// </summary>
		public static string AllDay => I18NResource.GetString(ResourceDirectory, "AllDay");

		/// <summary>
		///Options
		/// </summary>
		public static string Options => I18NResource.GetString(ResourceDirectory, "Options");

		/// <summary>
		///Private
		/// </summary>
		public static string Private => I18NResource.GetString(ResourceDirectory, "Private");

		/// <summary>
		///More
		/// </summary>
		public static string More => I18NResource.GetString(ResourceDirectory, "More");

		/// <summary>
		///Repeat Every
		/// </summary>
		public static string RepeatEvery => I18NResource.GetString(ResourceDirectory, "RepeatEvery");

		/// <summary>
		///Don't Repeat
		/// </summary>
		public static string DontRepeat => I18NResource.GetString(ResourceDirectory, "DontRepeat");

		/// <summary>
		///Day(s)
		/// </summary>
		public static string Days => I18NResource.GetString(ResourceDirectory, "Days");

		/// <summary>
		///Week(s)
		/// </summary>
		public static string Weeks => I18NResource.GetString(ResourceDirectory, "Weeks");

		/// <summary>
		///Month(s), On a Chosen Date
		/// </summary>
		public static string MonthsOnChosenDate => I18NResource.GetString(ResourceDirectory, "MonthsOnChosenDate");

		/// <summary>
		///Month(s), On a Chosen Day
		/// </summary>
		public static string MonthsOnChosenDay => I18NResource.GetString(ResourceDirectory, "MonthsOnChosenDay");

		/// <summary>
		///On
		/// </summary>
		public static string On => I18NResource.GetString(ResourceDirectory, "On");

		/// <summary>
		///Monday
		/// </summary>
		public static string Monday => I18NResource.GetString(ResourceDirectory, "Monday");

		/// <summary>
		///Tuesday
		/// </summary>
		public static string Tuesday => I18NResource.GetString(ResourceDirectory, "Tuesday");

		/// <summary>
		///Wednesday
		/// </summary>
		public static string Wednesday => I18NResource.GetString(ResourceDirectory, "Wednesday");

		/// <summary>
		///Thursday
		/// </summary>
		public static string Thursday => I18NResource.GetString(ResourceDirectory, "Thursday");

		/// <summary>
		///Friday
		/// </summary>
		public static string Friday => I18NResource.GetString(ResourceDirectory, "Friday");

		/// <summary>
		///Saturday
		/// </summary>
		public static string Saturday => I18NResource.GetString(ResourceDirectory, "Saturday");

		/// <summary>
		///Sunday
		/// </summary>
		public static string Sunday => I18NResource.GetString(ResourceDirectory, "Sunday");

		/// <summary>
		///Which Day of Month?
		/// </summary>
		public static string WhichDayOfMonth => I18NResource.GetString(ResourceDirectory, "WhichDayOfMonth");

		/// <summary>
		///On the
		/// </summary>
		public static string OnThe => I18NResource.GetString(ResourceDirectory, "OnThe");

		/// <summary>
		///First
		/// </summary>
		public static string First => I18NResource.GetString(ResourceDirectory, "First");

		/// <summary>
		///Second
		/// </summary>
		public static string Second => I18NResource.GetString(ResourceDirectory, "Second");

		/// <summary>
		///Third
		/// </summary>
		public static string Third => I18NResource.GetString(ResourceDirectory, "Third");

		/// <summary>
		///Last
		/// </summary>
		public static string Last => I18NResource.GetString(ResourceDirectory, "Last");

		/// <summary>
		///Until
		/// </summary>
		public static string Until => I18NResource.GetString(ResourceDirectory, "Until");

		/// <summary>
		///Stop Recurrence When the Date Is
		/// </summary>
		public static string StopRecurrenceWhenDateIs => I18NResource.GetString(ResourceDirectory, "StopRecurrenceWhenDateIs");

		/// <summary>
		///Remind Me
		/// </summary>
		public static string RemindMe => I18NResource.GetString(ResourceDirectory, "RemindMe");

		/// <summary>
		///None
		/// </summary>
		public static string None => I18NResource.GetString(ResourceDirectory, "None");

		/// <summary>
		///5 Minutes Before
		/// </summary>
		public static string Remind5MinutesBefore => I18NResource.GetString(ResourceDirectory, "Remind5MinutesBefore");

		/// <summary>
		///10 Minutes Before
		/// </summary>
		public static string Remind10MinutesBefore => I18NResource.GetString(ResourceDirectory, "Remind10MinutesBefore");

		/// <summary>
		///15 Minutes Before
		/// </summary>
		public static string Remind15MinutesBefore => I18NResource.GetString(ResourceDirectory, "Remind15MinutesBefore");

		/// <summary>
		///30 Minutes Before
		/// </summary>
		public static string Remind30MinutesBefore => I18NResource.GetString(ResourceDirectory, "Remind30MinutesBefore");

		/// <summary>
		///1 Hour Before
		/// </summary>
		public static string Remind1HourBefore => I18NResource.GetString(ResourceDirectory, "Remind1HourBefore");

		/// <summary>
		///2 Hours Before
		/// </summary>
		public static string Remind2HoursBefore => I18NResource.GetString(ResourceDirectory, "Remind2HoursBefore");

		/// <summary>
		///1 Day Before
		/// </summary>
		public static string Remind1DayBefore => I18NResource.GetString(ResourceDirectory, "Remind1DayBefore");

		/// <summary>
		///2 Days Before
		/// </summary>
		public static string Remind2DaysBefore => I18NResource.GetString(ResourceDirectory, "Remind2DaysBefore");

		/// <summary>
		///Select Reminder Type(s)
		/// </summary>
		public static string SelectReminderTypes => I18NResource.GetString(ResourceDirectory, "SelectReminderTypes");

		/// <summary>
		///Note
		/// </summary>
		public static string Note => I18NResource.GetString(ResourceDirectory, "Note");

		/// <summary>
		///Url
		/// </summary>
		public static string Url => I18NResource.GetString(ResourceDirectory, "Url");

		/// <summary>
		///Enter Note
		/// </summary>
		public static string EnterNote => I18NResource.GetString(ResourceDirectory, "EnterNote");

		/// <summary>
		///Enter Url
		/// </summary>
		public static string EnterUrl => I18NResource.GetString(ResourceDirectory, "EnterUrl");

		/// <summary>
		///OK
		/// </summary>
		public static string Ok => I18NResource.GetString(ResourceDirectory, "Ok");

		/// <summary>
		///Today
		/// </summary>
		public static string Today => I18NResource.GetString(ResourceDirectory, "Today");

		/// <summary>
		///Day
		/// </summary>
		public static string Day => I18NResource.GetString(ResourceDirectory, "Day");

		/// <summary>
		///Week
		/// </summary>
		public static string Week => I18NResource.GetString(ResourceDirectory, "Week");

		/// <summary>
		///Month
		/// </summary>
		public static string Month => I18NResource.GetString(ResourceDirectory, "Month");

		/// <summary>
		///Agendas
		/// </summary>
		public static string Agendas => I18NResource.GetString(ResourceDirectory, "Agendas");

		/// <summary>
		///Search ...
		/// </summary>
		public static string Search => I18NResource.GetString(ResourceDirectory, "Search");

		/// <summary>
		///Close This Tooltip
		/// </summary>
		public static string CloseThisTooltip => I18NResource.GetString(ResourceDirectory, "CloseThisTooltip");

		/// <summary>
		///Remind me <span class="reminder minutes"></span> minutes before.
		/// </summary>
		public static string RemindMeNMinutesBefore => I18NResource.GetString(ResourceDirectory, "RemindMeNMinutesBefore");

		/// <summary>
		///Edit This Event
		/// </summary>
		public static string EditThisEvent => I18NResource.GetString(ResourceDirectory, "EditThisEvent");

		/// <summary>
		///Delete This Event
		/// </summary>
		public static string DeleteThisEvent => I18NResource.GetString(ResourceDirectory, "DeleteThisEvent");

		/// <summary>
		///Events & Schedules
		/// </summary>
		public static string EventsAndSchedules => I18NResource.GetString(ResourceDirectory, "EventsAndSchedules");

		/// <summary>
		///Search Category
		/// </summary>
		public static string SearchCategory => I18NResource.GetString(ResourceDirectory, "SearchCategory");

		/// <summary>
		///Location
		/// </summary>
		public static string Location => I18NResource.GetString(ResourceDirectory, "Location");

		/// <summary>
		///Email Notification
		/// </summary>
		public static string EmailNotification => I18NResource.GetString(ResourceDirectory, "EmailNotification");

		/// <summary>
		///In App Notification
		/// </summary>
		public static string InAppNotification => I18NResource.GetString(ResourceDirectory, "InAppNotification");

		/// <summary>
		///Calendar Event Reminder: {0} at {1}
		/// </summary>
		public static string CalendarNotificationEmailSubject => I18NResource.GetString(ResourceDirectory, "CalendarNotificationEmailSubject");

		/// <summary>
		///Cannot add a null instance of calendar event
		/// </summary>
		public static string CannotAddNullCalendarEvent => I18NResource.GetString(ResourceDirectory, "CannotAddNullCalendarEvent");

		/// <summary>
		///Access is denied!
		/// </summary>
		public static string AccessIsDenied => I18NResource.GetString(ResourceDirectory, "AccessIsDenied");

		/// <summary>
		///Cannot delete this item because there are events under this category.
		/// </summary>
		public static string CannotDeleteBecauseEventsUnderCategory => I18NResource.GetString(ResourceDirectory, "CannotDeleteBecauseEventsUnderCategory");

		/// <summary>
		///SMS Notification
		/// </summary>
		public static string SmsNotification => I18NResource.GetString(ResourceDirectory, "SmsNotification");

	}
}
