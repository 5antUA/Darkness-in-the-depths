using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ������ ������ �� ������ TabDevUI/Sliders
public class TabDevSliders : MonoBehaviour
{
    private Player MyPlayer;                                    // ������ this.Player
    [SerializeField] private Slider SliderFlySpeed;             // ������� ��� ����� �������� ������
    [SerializeField] private Slider SliderWalkSpeed;            // ������� ��� ����� �������� ������
    [SerializeField] private Slider SliderJumpForce;            // ������� ��� ����� ���� ������


    private void Start()
    {
        MyPlayer = this.GetComponentInParent<Player>();

        SliderFlySpeed.value = MyPlayer.FlySpeed;
        SliderWalkSpeed.value = MyPlayer.WalkSpeed;
        SliderJumpForce.value = MyPlayer.JumpForce;
    }

    // ����� �������� ������
    public void ChangeFlySpeed()
    {
        MyPlayer.FlySpeed = SliderFlySpeed.value;
    }

    // ����� �������� ������
    public void ChangeWalkSpeed()
    {
        MyPlayer.WalkSpeed = SliderWalkSpeed.value;
    }

    // ����� ���� ������
    public void ChangeJumpForce()
    {
        MyPlayer.JumpForce = SliderJumpForce.value;
    }
}
