using System.IO;


namespace SavedData
{
    [System.Serializable]
    public class WeaponData
    {
        private const string KEY = "WeaponData";
        public bool[] Weapons;

        public WeaponData()
        {
            Weapons = new bool[3];
            Weapons[0] = true;
        }


        #region Management
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        public WeaponData Load()
        {
            try
            {
                var newData = StorageService.Load<WeaponData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save();
                return this;
            }
        }
        #endregion
    }
}