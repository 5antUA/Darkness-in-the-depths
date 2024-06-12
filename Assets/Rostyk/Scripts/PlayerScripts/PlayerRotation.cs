using UnityEngine;


// Вішати скріпт на камеру гравця
public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform playerBody;          // Трансформ базового об'єкта гравця

    public float Sensitive = 5;                             // Чутливість миші

    private float rotationX;                                // Поворот по X
    private Player Player;                                  // Скрипт гравця


    #region MONOBEHAVIOUR
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;           // Блокування курсора в центрі екрану
        Cursor.visible = false;                             // Приховування курсора
        Player = this.GetComponentInParent<Player>();       // Отримання посилання на скрипт гравця
    }

    private void Update()
    {
        if (Player.IsDead)                                  // Перевірка, чи гравець живий
            return;

        Rotate();                                           // Виклик функції повороту
    }
    #endregion


    // Функція для повороту камери та гравця
    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * Sensitive;  // Обчислення повороту по осі X
        float rotY = Input.GetAxis("Mouse Y") * Sensitive;  // Обчислення повороту по осі Y
        rotationX -= rotY;                                  // Зміна значення повороту по осі X
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);      // Обмеження повороту по осі X
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Обертання камери
        playerBody.Rotate(Vector3.up * rotX);               // Обертання тіла гравця по осі Y
    }
}
