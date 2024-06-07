using System.Collections;
using UnityEngine;

public class SmoothScaling : MonoBehaviour
{
    public Vector3 StartScale;
    public Vector3 EndScale;
    public float ScalingTime;

    private Transform _transform;


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
