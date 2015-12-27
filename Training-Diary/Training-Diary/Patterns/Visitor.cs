using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Diary
{
   public class Visitor:StrengthExercise
    {
         public StExercises VisitEx(string amount,StExercises m)
        {
            foreach (var a in m)
            {
                if (a.IsChecked == true)
                {
                    a.Amount = amount;
                    a.ExPassNumber = a.GetPassNumber(amount);
                }
            }
            return m;
        }
    }
}
