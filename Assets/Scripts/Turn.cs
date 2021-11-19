using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{

    Text myText;

    [SerializeField]
    List<Color> colors;

    private void Start()
    { 
        GameManager.instance.message += SetText;
    }

    public void SetText(Player player)
    {
        myText = GetComponent<Text>();
        myText.text = player.ToString() + "'S TURN";
        myText.color = colors[(int)player];
    }
}
