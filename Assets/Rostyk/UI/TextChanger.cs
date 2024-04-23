using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    private Text text;
    private Button button;

    void Start()
    {
        text = this.GetComponent<Text>();
        button = this.GetComponent<Button>();
    }

    private void OnMouseEnter()
    {
        text.color = Color.red;
    }

    private void OnMouseExit()
    {
        text.color = Color.black;
    }
}
