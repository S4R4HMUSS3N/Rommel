using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class repo : IStageOpdrachtenRepository
    {
        public IEnumerable<StageOpdracht> getByTag()
        {
            throw new NotImplementedException(); //hier is het stuk waar je je databank aanspreekt -> het filteren op Tag
        }
    }
}
