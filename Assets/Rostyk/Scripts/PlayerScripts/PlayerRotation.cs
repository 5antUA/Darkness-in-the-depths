using UnityEngine;


// ВЕШАТЬ СКРИП НА КАМЕРУ ИГРОКА
public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform playerBody;          // трансформ базового об`єкта гравця

    public float Sensitive = 5;                             // чутливість миші

    private float rotationX;                                // поворот по X
    private Player Player;                                  // скрипт гравця


    #region MONOBEHAVIOUR
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player = this.GetComponentInParent<Player>();
    }

    private void Update()
    {
        if (Player.IsDead)
            return;

        Rotate();
    }
    #endregion


    // Функція для повороту камери та гравця
    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * Sensitive;
        float rotY = Input.GetAxis("Mouse Y") * Sensitive;
        rotationX -= rotY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * rotX);
    }
}
