using System.Collections;
using UnityEngine;


// клас, який плавно масштабує об'єкти
public class SmoothScaling : MonoBehaviour
{
    public Vector3 StartScale;          // початковий масштаб
    public Vector3 EndScale;            // кінцевий масштаб
    public float ScalingTime;           // час для масштабування

    private Transform _transform;       // трансформ масштабованого об'єкту


    private void Awake()
    {
        _transform = this.transform;
        _transform.localScale = StartScale;
    }

    private void OnEnable()
    {
        StartCoroutine(ResizeCoroutine(ScalingTime * 0.1f, EndScale));
    }

    private void OnDisable()
    {
        this.transform.localScale = StartScale;
    }


    // асинхронна функція, яка масштабує об'єкт
    private IEnumerator ResizeCoroutine(float time, Vector3 target)
    {
        float Timer = 0;
        Vector3 Base = _transform.localScale;
        while (Timer < time)
        {
            _transform.localScale = Vector3.Lerp(Base, target, Timer / time);
            yield return null;
            Timer += Time.deltaTime;
        }
        _transform.localScale = target;
    }
}
