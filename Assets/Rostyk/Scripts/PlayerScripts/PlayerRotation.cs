using UnityEngine;


// ВЕШАТЬ СКРИП НА КАМЕРУ ИГРОКА
public class PlayerRotation : MonoBehaviour
{
    public float _sensitive = 5;                            // to normal - 5.0f in inspector
    private float rotationX;                                // ? ? ?

    [SerializeField] private Transform playerBody;          // трансформ базового объекта игрока
    private Player Player;

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


    // Функция для вращения камеры
    private void Rotate()
    {
        float rotX = Input.GetAxis("Mouse X") * _sensitive;
        float rotY = Input.GetAxis("Mouse Y") * _sensitive;

        rotationX -= rotY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * rotX);
    }
}
