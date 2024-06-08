using System.IO;


namespace SavedData
{
    [System.Serializable]
    public class InterfaceData
    {
        private const string KEY = "InterfaceData";

        public bool isLightTheme;
        public bool isNegativeSensitivity;
        public float CameraSensitivity;
        public float PlayerFar;

        public InterfaceData()
        {
            isLightTheme = false;
            isNegativeSensitivity = false;
            CameraSensitivity = 5;
            PlayerFar = 100;
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