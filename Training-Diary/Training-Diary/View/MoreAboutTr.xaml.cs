using System.Windows;
using System.Windows.Controls;

namespace Training_Diary
{
    /// <summary>
    /// Логика взаимодействия для MoreAboutTr.xaml
    /// </summary>
    public partial class MoreAboutTr : UserControl
    {
        public UserTraining SelectedTr { get; set; }
    
        public MoreAboutTr()
        {
            InitializeComponent();
        }
       

        private void StartTr(object sender, RoutedEventArgs e)
        {

            TrStart wind = new TrStart(SelectedTr);
            wind.Show();
        }
    }
}
