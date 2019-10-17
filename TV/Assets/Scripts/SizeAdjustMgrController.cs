using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAdjustMgrController : MonoBehaviour
{
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AdjustCubeSize(int size)
    {
        switch (size)
        {

            case 65:
                cube.localScale = new Vector3(1.3947f, 0.1000001f, 0.7845f);
                break;
            case 80:
                cube.localScale = new Vector3(1.8596f, 0.1000001f, 1.046f);
                break;
            case 100:
                cube.localScale = new Vector3(2.196002f, 0.1000001f, 1.251f);
                break;
            default:    // 65in
                cube.localScale = new Vector3(1.3947f, 0.1000001f, 0.7845f);
                break;

        }
    }

    public void OnClick65in()
    {
        AdjustCubeSize(65);
    }
    public void OnClick80in()
    {
        AdjustCubeSize(80);
    }
    public void OnClick100in()
    {
        AdjustCubeSize(100);
    }
    public void OnClicked()
    {
        Debug.Log("clicked");
    }
}
