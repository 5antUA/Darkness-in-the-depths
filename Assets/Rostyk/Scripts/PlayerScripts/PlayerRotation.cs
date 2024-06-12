using UnityEngine;


// ³���� ����� �� ������ ������
public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform playerBody;          // ��������� �������� ��'���� ������

    public float Sensitive = 5;                             // ��������� ����

    private float rotationX;                                // ������� �� X
    private Player Player;                                  // ������ ������


    #region MONOBEHAVIOUR
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;           // ���������� ������� � ����� ������
        Cursor.visible = false;                             // ������������ �������
        Player = this.GetComponentInParent<Player>();       // ��������� ��������� �� ������ ������
    }

    private void Update()
    {
        if (Player.IsDead)                                  // ��������, �� ������� �����
            return;

        Rotate();                                           // ������ ������� ��������
    }
    #endregion


    // ������� ��� �������� ������ �� ������
    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * Sensitive;  // ���������� �������� �� �� X
        float rotY = Input.GetAxis("Mouse Y") * Sensitive;  // ���������� �������� �� �� Y
        rotationX -= rotY;                                  // ���� �������� �������� �� �� X
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);      // ��������� �������� �� �� X
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // ��������� ������
        playerBody.Rotate(Vector3.up * rotX);               // ��������� ��� ������ �� �� Y
    }
}
