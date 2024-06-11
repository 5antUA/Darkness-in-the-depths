using UnityEngine;


// Вішати скріпт на базовий об'єкт гравця
public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform _startShooter;            // точка початку променя

    private float _hitDistance;                                  // дальність променя
    private SavedData.InputData _inputData;                      // дані про клавіші


    #region MONOBEHAVIOUR
    private void Start()
    {
        _inputData = new SavedData.InputData();
        _inputData = _inputData.Load();
        _hitDistance = 2f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_inputData.Interact))
        {
            Interact();
        }
    }
    #endregion


    #region Interacting
    // Логіка взаємодії з предметами
    private void Interact()
    {
        SimpleDoor door = GetObject();

        if (door != null)
        {
            if(door.isOpen)
                door.Close();
            else if(!door.isOpen)
                door.Open();
        }
    }

    // Пошук дверей за допомогою променя
    private SimpleDoor GetObject()
    {
        RaycastHit hit = GetComponentInChildren<ThrowRay>().GetHit(_hitDistance);

        if (hit.collider != null)
            return hit.collider.GetComponentInChildren<SimpleDoor>();
        else
            return null;
    }
    #endregion
}