using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Diary
{
    public interface IChainCheck
    {
        bool Done { get; set; }
        void Check();
    }
}
