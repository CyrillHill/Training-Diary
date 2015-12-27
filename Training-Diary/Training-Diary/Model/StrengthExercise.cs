using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Training_Diary
{
    
    public interface IExercise
    {
        string ExName { get; set; }
        string Description { get; set; }
        bool Done { get; set; }
        bool IsChecked { get; set; }
        
    }
    public interface IExCollectionType:IChainCheck
    {
        void Adding(UserTraining tr);
        int GetTrData(Excel.Worksheet workSheet,  int i);
    }
    [Serializable]
    public abstract class StrengthExercise:IExercise,INotifyPropertyChanged,IChainCheck
    {

        public string Description { get; set; }
        public bool IsChecked { get; set; }
        public int Reiterations { get; set; }
        public string _amount;
        public string Amount
        {
            get { return _amount; }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    _amount = value ;
                }
                else
                {
                    DialogService.ShowMessage("Неверный формат числа!");
                    _amount = "0";
                    
                }
                OnPropertyChanged("Amount");

            }
        }
        public ObservableCollection<PassNumber> ExPassNumber { get; set; }
        public string ExName
        {
             get; set;
        }

        public bool Done
        {
            get; set;
        }

        public StrengthExercise()
        {
            ExPassNumber = new ObservableCollection<PassNumber>();
        }
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged(string t)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(t));
        }
        public ObservableCollection<PassNumber> GetPassNumber(string t)
        {

            for (int i = 0; i < Convert.ToInt32(t); i++)
            {
                ExPassNumber.Add(new PassNumber() { PassNumberName = (i + 1).ToString() + "-й подход" });

            }
            return ExPassNumber;
        }

        public void Check()
        {
            foreach (var a in ExPassNumber)
            { a.Check(); }
            if (ExPassNumber.All(o => o.Done == true))
                this.Done = true;
        }
    }
    [Serializable]
    public class StExercises : ObservableCollection<StrengthExercise>,IExCollectionType,IChainCheck
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
                    if (!a.ExPassNumber.Any())
                    { a.ExPassNumber = a.GetPassNumber(a.Amount);
                    }
                    tr.UsStrength.Add(a);
                }
               
            }
        }

        public void Check()
        {
            foreach(var a in this)
            {
                a.Check();
            }
            if (this.All (x => x.Done == true)) this.Done = true;
        }
        public int GetTrData(Excel.Worksheet workSheet,  int i)

        {
           
            Excel.Range oRng;
            workSheet.Cells[i, 1] = "Name";
            workSheet.Cells[i, 2] = "PassNumber";
            workSheet.Cells[i, 3] = "Reiteration";
            workSheet.Cells[i, 4] = "Weight";
            i++;
            foreach (var a in this)
            {
                oRng = workSheet.Range[workSheet.Cells[i, 1], workSheet.Cells[(i + a.ExPassNumber.Count-1), 1]];
                oRng.Merge();
                oRng.Value = a.ExName;
                foreach (var b in a.ExPassNumber)
                {
                    workSheet.Cells[i, 2] = b.PassNumberName;
                    workSheet.Cells[i, 3] = b.Reiteration;
                    workSheet.Cells[i, 4] = b.Weight;
                    i++;
                }
            }
            return i;
        }
    }

    [Serializable]
    public class PassNumber : INotifyPropertyChanged,IChainCheck
    {
        public string PassNumberName { get; set; }
        protected string _reiterationinfact;
        public string ReiterationInFact
        {
            get { return _reiterationinfact; }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    _reiterationinfact = value;
                }
                else
                {
                    DialogService.ShowMessage("Неверный формат числа!");
                    _reiterationinfact = "0";

                }
                OnPropertyChanged("ReiterationInFact");

            }
        }

        private string _reiteration;
        public string Reiteration
        {
            get { return _reiteration; }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    _reiteration = value;
                }
                else
                {
                    DialogService.ShowMessage("Неверный формат числа!");
                    _reiteration = "0";

                }
                OnPropertyChanged("Reiteration");

            }
        }

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                int result;
                if (int.TryParse(value, out result))
                {
                    _weight = value;
                }
                else
                {
                    DialogService.ShowMessage("Неверный формат числа!");
                    _weight = "0";

                }
                OnPropertyChanged("Weight");

            }
        }

        public bool Done
        {
            get; set;
        }

        public void OnPropertyChanged(string t)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(t));
        }

        public void Check()
        {
            if (Reiteration == ReiterationInFact) Done = true;
        }
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

    }

}
