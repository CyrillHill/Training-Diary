using System.Windows;
namespace Training_Diary
{
    /// <summary>
    /// Логика взаимодействия для TrStart.xaml
    /// </summary>
    public partial class TrStart 
    {
       public UserTraining tr { get; set; }
        public TrStart(UserTraining t)
        {
            tr = t;
            this.DataContext = t;
            InitializeComponent();
        }

        private void EndTrClick(object sender, RoutedEventArgs e)
        {
            tr.Check();
        }
        private void ExcelAddNew(object sender, RoutedEventArgs e)
        {
            Facade f = new Facade(tr);
            f.DoIt();
        }
    }
}
