using System;
using System.Windows;
using System.Collections.ObjectModel;
using MahApps.Metro;

namespace Training_Diary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public TrainingShow list = new TrainingShow();
        protected ObservableCollection<UserTraining> tr;
        public MoreAboutTr usercontrol = new MoreAboutTr();
       
        public ObservableCollection<UserTraining> allUsTr { get; set; }
       
        public UserTraining userTr { get; set; }
        public MainWindow()
        {
            if (DateTime.Now.Hour >= 21 || (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 9))
            {
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                // now set the Steel accent and dark theme when now is night
                ThemeManager.ChangeAppStyle(Application.Current,
                                            ThemeManager.GetAccent("Steel"),
                                            ThemeManager.GetAppTheme("BaseDark"));
            }
            InitializeComponent();
            stackforuser.Children.Add(usercontrol);
            allUsTr = new ObservableCollection<UserTraining>();
            this.Resources.Add("ExList", list);
            this.Resources.Add("UsTr", allUsTr);
            this.Resources.Add("TrName", userTr);
        }

        private async void AddNewTraining(object sender, RoutedEventArgs e)
        {
            if (NameOfNewTr.Text != "")
            {
                userTr = new UserTraining();
                foreach (var a in list)
                {
                    a.Adding(userTr);
                }
                userTr.Name = NameOfNewTr.Text;
                allUsTr.Add(userTr);
                await DialogService.ShowMessage("Тренировка добавлена!");
            }
        }

        private void MoreInformationAboutEx(object sender, RoutedEventArgs e)
        {
            this.DataContext = ShowAllExercises.SelectedItem;
        }

        private void GetInfoAboutTr(object sender, RoutedEventArgs e)
        {
            var m = (AllUserTrainings.SelectedItem) as UserTraining;
            usercontrol.SelectedTr = m;
            usercontrol.DataContext = m;          
        }

        private void MenuItemEventClick(object sender, RoutedEventArgs e)
        {
            Visitor v = new Visitor();
            if (Datagrid.SelectedItem != null)
            {
                var t = (Datagrid.SelectedItem) as StrengthExercise;
                list.Strength = v.VisitEx(t.Amount, list.Strength);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            MySerialization s = new MySerialization();
            s.Serialize(allUsTr);
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            MySerialization s = new MySerialization();
            foreach (var a in s.DeSerialize())
            {
                allUsTr.Add(a);
            }
        }
    }
   
}
