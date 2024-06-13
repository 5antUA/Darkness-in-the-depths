using SavedData;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharacterButtons : MonoBehaviour
{
    [SerializeField] private GameObject BlackImage;              // ������������ ������ �����
    [SerializeField] private GameObject ConfirmScreenUI;         // UI ������� (������������ 䳿)

    private string CharacterName;                                // ��'� ���������
    private CharacterData CharacterData;                         // ����� ��� ��� ���������
    private PlayerPositionData PlayerData;                       // ����� ��� ��� ������
    private NotesData NotesData;                                 // ����� ��� ��� �������
    private RostykEnums.Characters character;                    // ������� ��������


    void Start()
    {
        CharacterData = new CharacterData();
        PlayerData = new PlayerPositionData();
        NotesData = new NotesData();
    }


    // ������ ������ ��������� ��������
    public void SetCharacterValentinButton()
    {
        character = RostykEnums.Characters.Valentin;
        CharacterName = "��������";
    }

    // ������ ������ ��������� ���������
    public void SetCharacterKovalButton()
    {
        character = RostykEnums.Characters.Kovalev;
        CharacterName = "���������";
    }

    // ������ ������ ��������� ������ ��������
    public void SetCharacterRomarioButton()
    {
        character = RostykEnums.Characters.Romario;
        CharacterName = "������ ��������";
    }

    // ������ ������ ��������� ̳���� �����
    public void SetCharacterPaniniButton()
    {
        character = RostykEnums.Characters.Panini;
        CharacterName = "̳���� �����";
    }

    // ������ ������ ���������
    public void ApplyCharacterButton()
    {
        ConfirmScreenUI.SetActive(true);
        ConfirmScreenUI.GetComponentInChildren<Text>().text =
            $"�� ����� ������ ������ ��������� {CharacterName}?";
    }

    // ������ "���" � ����������� ������ ���������
    public void ApplyCharacterButtonYes()
    {
        ConfirmScreenUI.SetActive(false);
        BlackImage.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(LoadGame());
        CharacterData.isContinueGame = false;
        CharacterData.Character = character;
        CharacterData.Save();
        PlayerData.Save();
        NotesData.Save();
    }

    // ������ "ͳ" � ����������� ������ ���������
    public void ApplyCharacterButtonNo()
    {
        ConfirmScreenUI.SetActive(false);
    }

    // ���������� ������� ������� ������ ��������
    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LoadScene");
    }
}
