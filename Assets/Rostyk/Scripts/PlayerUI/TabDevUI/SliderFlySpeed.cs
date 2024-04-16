using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ¬≈ÿ¿“‹ — –»œ“ Õ¿ Œ¡⁄≈ “ TabDevUI/SliderFlySpeed
public class SliderFlySpeed : MonoBehaviour
{
    [SerializeField] private Text Value;
    private Slider Slider;
    private Player MyPlayer;

    private void Start()
    {
        MyPlayer = this.GetComponentInParent<Player>();
        Slider = this.GetComponent<Slider>();

        Slider.value = MyPlayer.FlySpeed;
        Value.text = Slider.value.ToString();
    }

    public void ChangeValue()
    {
        Value.text = ((int)Slider.value).ToString();
        MyPlayer.FlySpeed = Slider.value;
    }
}
