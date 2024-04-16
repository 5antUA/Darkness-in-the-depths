using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ TabDevUI/Sliders
public class TabDevSliders : MonoBehaviour
{
    private Player MyPlayer;                                    // скрипт this.Player
    [SerializeField] private Slider SliderFlySpeed;             // слайдер для смены скорости полета
    [SerializeField] private Slider SliderWalkSpeed;            // слайдер для смены скорости ходьбы
    [SerializeField] private Slider SliderJumpForce;            // слайдер для смены силы прыжка


    private void Start()
    {
        MyPlayer = this.GetComponentInParent<Player>();

        SliderFlySpeed.value = MyPlayer.FlySpeed;
        SliderWalkSpeed.value = MyPlayer.WalkSpeed;
        SliderJumpForce.value = MyPlayer.JumpForce;
    }

    // Смена скорости полета
    public void ChangeFlySpeed()
    {
        MyPlayer.FlySpeed = SliderFlySpeed.value;
    }

    // Смена скорости ходьбы
    public void ChangeWalkSpeed()
    {
        MyPlayer.WalkSpeed = SliderWalkSpeed.value;
    }

    // Смена силы прыжка
    public void ChangeJumpForce()
    {
        MyPlayer.JumpForce = SliderJumpForce.value;
    }
}
