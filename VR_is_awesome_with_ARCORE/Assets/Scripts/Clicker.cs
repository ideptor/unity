using System.Collections;
using UnityEngine;

//public class Clicker : MonoBehaviour
public class Clicker
{

    public bool clicked()
    {
#if (UNITY_ANDROID || UNITY_IPHONE)
        //return Cardboard.SDK.CardBoardTriggered;
#else
        //return Input.anyKeyDown;
#endif
        return Input.anyKeyDown;
    }
}
