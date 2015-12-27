using System;

namespace Training_Diary
{
    [Serializable]
    class Legs:StrengthExercise
    {
        public Legs()
        {
            ExName = "Ноги";
            Description = "Поднимите ноги"; 
        }
    }
    [Serializable]
    class Back : StrengthExercise
    {
        public Back()
        {
            ExName = "Спина";
            Description = "Сделайте подъем корпусa из положения лежа на животе";
        }
    }
    [Serializable]
    class Press:StrengthExercise
    {
        public Press()
        {
            ExName = "Пресс";
            Description = "Одновременно поднимите корпус и ноги в вертикальное положение";
        }
    }
    [Serializable]
    class RunningTrack : KardioExercise
    {
        public RunningTrack()
        {
            ExName = "Беговая дорожка";
            Description = "Побежали";
        }
    }
    [Serializable]
    class VeloTrack : KardioExercise
    {
        public VeloTrack()
        {
            ExName = "Велотренажер";
            Description = "Поехали";
        }
    }
    [Serializable]
    class Squats : StrengthExercise
    {
        public Squats()
        {
            ExName = "Приседания";
            Description = "Ноги на ширине плечь, приседания";
        }
    }
}
