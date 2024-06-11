using UnityEngine;
using UnityEngine.UI;


public class CheckContinueButton : MonoBehaviour
{
    private Button _thisButton;                                 // кнопка, яку потрібно перевірити на неактивність
    private SavedData.CharacterData _characterData;             // ігрові дані про 

    private void Awake()
    {
        _thisButton = this.GetComponent<Button>();
        _characterData = new SavedData.CharacterData();
        _characterData = _characterData.Load();

        if (_characterData.isContinueGame)
            _thisButton.interactable = true;
    }
}
