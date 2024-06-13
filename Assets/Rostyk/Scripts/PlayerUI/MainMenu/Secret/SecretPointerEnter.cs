using UnityEngine;
using UnityEngine.UI;


// 
public class SecretPointerEnter : MonoBehaviour
{
    public void Enter()
    {
        this.GetComponent<Text>().text = "seCr3t._'";
    }

    public void Exit()
    {
        this.GetComponent<Text>().text = "Secret...";
    }
}
