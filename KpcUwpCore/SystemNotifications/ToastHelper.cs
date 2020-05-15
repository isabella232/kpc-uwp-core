/**
 * ToastHelper.cs
 *
 * Copyright (c) 2020 Kano Computing Ltd.
 * License: https://opensource.org/licenses/MIT
 */


using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;


namespace KanoComputing.SystemNotifications {

    public class ToastHelper {

        public static void ShowToast(string title, string message) {
            if (string.IsNullOrEmpty(title)) {
                title = "Notification Header";
            }
            if (string.IsNullOrEmpty(message)) {
                message = "Notification Message";
            }
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(title));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(message));

            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
