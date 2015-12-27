using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Training_Diary
{
    [Serializable]
    public abstract class KardioExercise : IExercise,INotifyPropertyChanged,IChainCheck
    {
        public string ExName { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
        protected string _duration;
        public string Duration
        {
            get { return _duration; }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    _duration = value;
                }
                else
                {
                    DialogService.ShowMessage("Неверный формат числа!");
                    _duration = "0";

                }
                OnPropertyChanged("Duration");

            }
        }
        protected string _durationinfact;
        public string DurationInFact
        {
            get { return _durationinfact; }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    _durationinfact = value;
                }
                else
                {
                    DialogService.ShowMessage("Неверный формат числа!");
                    _durationinfact = "0";

                }
                OnPropertyChanged("DurationInFacr");
            }
        }

        public bool Done
        {
            get; set;
        }

        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string t)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(t));
        }

        public void Check()
        {
            if (Duration == DurationInFact) this.Done = true;
        }
    }
    [Serializable]
    public class KardExercises : ObservableCollection<KardioExercise>,IExCollectionType,IChainCheck
    {
        public bool Done
        {
            get; set;
        }

        public void Adding(UserTraining tr)
        {
            foreach(var a in this)
            {
                if (a.IsChecked == true)
                {
                    tr.UsKardio.Add(a);
                }
            }
        }

        public void Check()
        {
            foreach(var a in this)
            {
                a.Check();
            }
            if (this.All(x => x.Done == true)) this.Done = true;
        }
        public int GetTrData(Excel.Worksheet workSheet, int i)
        {

            workSheet.Cells[i, 1] = "Name";
            workSheet.Cells[i, 2] = "Time";
            i++;
            foreach (var a in this)
            {
                workSheet.Cells[i, 1] = a.ExName;
                workSheet.Cells[i, 2] = a.Duration;
                i++;
            }
            return i;
        }
    }
}
