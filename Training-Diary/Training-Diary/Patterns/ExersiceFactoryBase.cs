namespace Training_Diary
{
    public abstract class ExerciseFactoryBase
    {
        public abstract IExercise CreateExercise();
    }
    public class LegsExerciseFactory : ExerciseFactoryBase
    {
        public override IExercise CreateExercise()
        {
            return new Legs();
            
        }
    }
    public class BackExerciseFactory : ExerciseFactoryBase
    {
        public override IExercise CreateExercise()
        {
            return new Back();
        }
    }
}