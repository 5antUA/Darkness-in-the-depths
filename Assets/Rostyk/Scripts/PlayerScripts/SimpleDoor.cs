using UnityEngine;


public class SimpleDoor : MonoBehaviour
{
    private Animator anim;                  // ������� ��� ��������� ��������� ������
    public float distance;                  // ��������� �����䳿 � �������
    public bool isOpen { get; set; }        // ���������� ��� ��������, �� ���� ������

    void Start()
    {
        anim = GetComponent<Animator>();    // ��������� ��������� �� ��������� Animator
        isOpen = false;                     // ����������� ����� ������ �� ������
    }

    // ����� ��� �������� ������
    public void Open()
    {
        anim.SetBool("isOpen", true);       // ������������ ��������� �������� ��� �������� ������
        isOpen = true;                      // ��������� ����� ������ �� ������
    }

    // ����� ��� �������� ������
    public void Close()
    {
        anim.SetBool("isOpen", false);      // ������������ ��������� �������� ��� �������� ������
        isOpen = false;                     // ��������� ����� ������ �� ������
    }
}
