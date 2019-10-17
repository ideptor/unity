using UnityEngine;
using UnityEngine.UI;


public class App : MonoBehaviour
{
    private Heart _heart;

    private void Start()
    {
        _heart = new Heart(_image);
    }

    [SerializeField] public Image _image;
    // Update is called once per frame
    void Update()
    {

               
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _heart.Replenish(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _heart.Deplete(1);
        }
    }

}
