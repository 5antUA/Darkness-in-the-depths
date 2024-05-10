using System.IO;


namespace SavedData
{
    [System.Serializable]
    public class InterfaceData
    {
        private const string KEY = "InterfaceData";

        public bool isLightTheme;

        public InterfaceData()
        {
            isLightTheme = false;
        }


        #region Management
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        public InterfaceData Load()
        {
            try
            {
                var data = StorageService.Load<InterfaceData>(KEY);
                return data;
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