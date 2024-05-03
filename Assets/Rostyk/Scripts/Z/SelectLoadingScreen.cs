using UnityEngine;
using UnityEngine.UI;

namespace Assets.Rostyk.Scripts.Z
{
    public class SelectLoadingScreen : MonoBehaviour
    {
        [SerializeField] private Texture[] LoadingScreens;
        private RawImage ThisImage;


        private void Awake()
        {
            ThisImage = this.GetComponent<RawImage>();
        }

        private void Start()
        {
            ThisImage.texture = RandomImage();
        }

        public Texture RandomImage()
        {
            int randIndex = Random.Range(0, LoadingScreens.Length);
            return LoadingScreens[randIndex];
        }
    }
}