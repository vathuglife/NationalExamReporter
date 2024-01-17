using System.Windows;

namespace NationalExamReporter.Utils
{
    public class MessageBoxUtils
    {
        public static void ShowDefaultMessageBox(DefaultMessageBoxArguments defaultMessageBoxArguments)
        {
            string messageBoxText = defaultMessageBoxArguments.messageBoxText;
            string caption = defaultMessageBoxArguments.caption;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage messageBoxImage = defaultMessageBoxArguments.image;
            MessageBox.Show(messageBoxText, caption, button, messageBoxImage);
        }

        public static MessageBoxResult GetYesNoMessageBoxResult(DefaultMessageBoxArguments defaultMessageBoxArguments)
        {
            string messageBoxText = defaultMessageBoxArguments.messageBoxText;
            string caption = defaultMessageBoxArguments.caption;
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage messageBoxImage = defaultMessageBoxArguments.image;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, messageBoxImage);
            return result;
        }
    }

    public class DefaultMessageBoxArguments
    {
        public string messageBoxText;
        public string caption;
        public MessageBoxImage image;

        public DefaultMessageBoxArguments(string messageBoxText, string caption, MessageBoxButton button,
            MessageBoxImage image)
        {
            this.messageBoxText = messageBoxText;
            this.caption = caption;
            this.image = image;
        }
    }
}