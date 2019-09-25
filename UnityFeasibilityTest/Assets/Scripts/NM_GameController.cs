using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NM_GameController : MonoBehaviour
{

    public Text HPText;


    // Update is called once per frame
    void Update()
    {
        var player = FindObjectOfType<Player>();
        if(HPText != null && player != null)
        {
            HPText.text = "HP: " + player.hp.ToString();
        }
            

    }
}
