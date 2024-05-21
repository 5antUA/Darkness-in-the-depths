using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavedData
{
    [System.Serializable]
    public class CharacterData
    {
        private const string KEY = "CharacterData";

        public bool[] character;


        public CharacterData()
        {
            character = new bool[3];
            character[0] = true;
        }

        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        public CharacterData Load()
        {
            try
            {
                var newData = StorageService.Load<CharacterData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save();
                return this;
            }
        }
    }
}
