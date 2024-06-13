using UnityEngine;


// ����, ���� ������ ����������� ����� ��� ��������� ������
public class PoinerClickStart : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;      // AudioSource ��� ����������� �����
    [SerializeField] private AudioClip _AudioClip;          // AudioClip �����


    // ������� ��� ����������� �����
    public void AudioPlay()
    {
        _AudioSource.PlayOneShot(_AudioClip);
    }
}
