using UnityEngine;
using UnityEngine.UI;


// ����, ���� ������ ����������� ����� ��� ��������� ������
public class PointerClick : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;      // AudioSource ��� ����������� �����
    [SerializeField] private AudioClip _AudioClip;          // AudioClip �����
    [SerializeField] private Button Button;                 // ������, ��� ������������ �� ���������


    // ������� ��� ����������� �����
    public void AudioPlay()
    {
        if (Button.interactable)
            _AudioSource.PlayOneShot(_AudioClip);
    }
}
