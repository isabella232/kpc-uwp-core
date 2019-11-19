using System;


namespace SystemNotifications {

    public sealed class ToastHelper {

        public static void ShowToast(string title, string message) {
            if (String.IsNullOrEmpty(title)) {
                title = "Notification Header";
            }
            if (String.IsNullOrEmpty(message)) {
                message = "Notification Message";
            }
            Windows.UI.Notifications.ToastTemplateType toastTemplate = Windows.UI.Notifications.ToastTemplateType.ToastText02;
            Windows.Data.Xml.Dom.XmlDocument toastXml = Windows.UI.Notifications.ToastNotificationManager.GetTemplateContent(toastTemplate);
            Windows.Data.Xml.Dom.XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(title));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(message));
            Windows.UI.Notifications.ToastNotification toast = new Windows.UI.Notifications.ToastNotification(toastXml);
            Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
