using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Windows;

namespace Training_Diary
{
        public static class DialogService
        {
            public static async Task<MessageDialogResult> ShowMessage(string message)
            {
                var metroWindow = (Application.Current.MainWindow as MetroWindow);
                return await metroWindow.ShowMessageAsync(Application.Current.MainWindow.Title,
                    message, MessageDialogStyle.Affirmative, metroWindow.MetroDialogOptions);
            }
        }

}
