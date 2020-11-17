using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryXML.Domain.Entities
{
    [Serializable]
    public class Words
    {
        public List<Word> WordsList = new List<Word>();
    }
}
