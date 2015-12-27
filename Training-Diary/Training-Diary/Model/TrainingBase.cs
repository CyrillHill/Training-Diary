using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace Training_Diary
{
    public class TrainingShow : ObservableCollection<IExCollectionType>
    {
        public KardExercises Kardio { get; set; }
        public StExercises Strength { get; set; }
        public string Selected { get; set; }
        public TrainingShow()
        {
            Kardio = new KardExercises();
            Strength = new StExercises();
            this.Add(Kardio);
            this.Add(Strength);
            Strength.Add(new Legs());
            Strength.Add(new Back());
            Strength.Add(new Press());
            Kardio.Add(new VeloTrack());
            Kardio.Add(new RunningTrack());
        }  
    }
    [Serializable]
    public class UserTraining : IChainCheck
    {
        public bool Done { get; set; }
        public KardExercises UsKardio { get; set; }
        public StExercises UsStrength { get; set; }
        public ObservableCollection<IExCollectionType> Exercises { get; set; }
        public StrengthExercise SelectedExercise { get; set; }
        public UserTraining()
        {
            UsKardio = new KardExercises();
            UsStrength = new StExercises();
            Exercises = new ObservableCollection<IExCollectionType>();
            Exercises.Add(UsKardio);
            Exercises.Add(UsStrength);
        }

        public string Name { get; set; }

        public async void Check()
        {
            foreach (var a in Exercises) { a.Check(); }
            if (Exercises.All(x => x.Done == true))
            {
                this.Done = true;
                await DialogService.ShowMessage("Все выполнено!");
            }
            else await DialogService.ShowMessage("Доделайте упражнения!");
            
        }
    }

}
