using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictonaryXML.Domain.Entities
{
    public class Word
    {
        public string MainWord { get; set; }
        public string TranslationWord { get; set; }
        public int PartOfSpeech { get; set; }
        public int Gender { get; set; }
        public string Description { get; set; }

        public Word() { }

        public Word(string mainWord,
                    string translationWord,
                    int partOfSpeech,
                    int gender,
                    string description)
        {
            MainWord = mainWord;
            TranslationWord = translationWord;
            PartOfSpeech = partOfSpeech;
            Gender = gender;
            Description = description;
        }
    }
}
