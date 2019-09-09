using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WebRequestController_Weather : MonoBehaviour
{

    public Text WeatherText;

    // Start is called before the first frame update
    void Start()
    {
        if(WeatherText == null) {
            Debug.Log("WeatherText is null");
            return;
        }

        WeatherText.text = "Loading Weather info";
        StartCoroutine("WebRequest");

    }

    // Update is called once per frame
    void Update()
    {
        //"http://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=1165066000"
    }

    IEnumerator WebRequest()  {

        UnityWebRequest request = new UnityWebRequest();
        using (request = UnityWebRequest.Get("http://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=1165066000"))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                byte[] results = request.downloadHandler.data;
                string weatherInfo = System.Text.Encoding.UTF8.GetString(results);
                WeatherText.text = weatherInfo;
            }
        }
    }
}

