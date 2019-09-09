using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Xml;

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
                string strResult = System.Text.Encoding.UTF8.GetString(results);
                string weatherInfo = createWeatherInfoString(strResult);

                WeatherText.text = weatherInfo;
            }
        }
    }

    string createWeatherInfoString(string xmlResult) {
        string weatherInfo = "";

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlResult);


        // time stamp
        XmlNodeList list = xmlDocument.GetElementsByTagName("tm");
        if(list.Count > 0) {
            XmlNode timestamp = list.Item(0);
            string strTimestamp = timestamp.InnerText;
            strTimestamp = strTimestamp.Substring(0,4) + "." + strTimestamp.Substring(4,2) + "." + strTimestamp.Substring(6,2);
            Debug.Log(strTimestamp);
            
            weatherInfo += strTimestamp + "\n";
        }
        else {
            weatherInfo += "No timestamp info\n";
        }


        // temperature
        list = xmlDocument.GetElementsByTagName("temp");
        if(list.Count > 0) {
            XmlNode firstTemperature = list.Item(0);

            Debug.Log(firstTemperature.InnerText);
            weatherInfo += firstTemperature.InnerText+"ºC\n";
        } else {
            weatherInfo += "No temperature info\n";
        }

        // skyCondition
        list = xmlDocument.GetElementsByTagName("wfEn");
        if(list.Count > 0) {
            XmlNode skyCondition = list.Item(0);

            Debug.Log(skyCondition.InnerText);
            weatherInfo += skyCondition.InnerText+"\n";
        } else {
            weatherInfo += "No SkyCondition info\n";
        }


        return weatherInfo;
    }

    /*
http://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=1165066000

   

<?xml version="1.0" encoding="UTF-8" ?>
<rss version="2.0">
<channel>
<title>기상청 동네예보 웹서비스 - 서울특별시 서초구 내곡동 도표예보</title>
<link>http://www.kma.go.kr/weather/main.jsp</link>
<description>동네예보 웹서비스</description>
<language>ko</language>
<generator>동네예보</generator>
<pubDate>2019년 09월 09일 (월)요일 11:00</pubDate>
 <item>
<author>기상청</author>
<category>서울특별시 서초구 내곡동</category>
<title>동네예보(도표) : 서울특별시 서초구 내곡동 [X=61,Y=124]</title><link>http://www.kma.go.kr/weather/forecast/timeseries.jsp?searchType=INTEREST&amp;dongCode=1165066000</link>
<guid>http://www.kma.go.kr/weather/forecast/timeseries.jsp?searchType=INTEREST&amp;dongCode=1165066000</guid>
<description>
 <header>
  <tm>201909091100</tm>
  <ts>3</ts>
  <x>61</x>
  <y>124</y>
 </header>
 <body>
  <data seq="0">
   <hour>15</hour>
   <day>0</day>
   <temp>27.0</temp>
   <tmx>28.0</tmx>
   <tmn>-999.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>60</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.2000000000000002</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>75</reh>
   <r06>2.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="1">
   <hour>18</hour>
   <day>0</day>
   <temp>26.0</temp>
   <tmx>28.0</tmx>
   <tmn>-999.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>60</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.9</ws>
   <wd>1</wd>
   <wdKor>북동</wdKor>
   <wdEn>NE</wdEn>
   <reh>80</reh>
   <r06>2.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="2">
   <hour>21</hour>
   <day>0</day>
   <temp>24.0</temp>
   <tmx>28.0</tmx>
   <tmn>-999.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>70</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.7000000000000001</ws>
   <wd>1</wd>
   <wdKor>북동</wdKor>
   <wdEn>NE</wdEn>
   <reh>95</reh>
   <r06>7.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="3">
   <hour>24</hour>
   <day>0</day>
   <temp>24.0</temp>
   <tmx>28.0</tmx>
   <tmn>-999.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>70</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.7000000000000001</ws>
   <wd>1</wd>
   <wdKor>북동</wdKor>
   <wdEn>NE</wdEn>
   <reh>95</reh>
   <r06>7.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="4">
   <hour>3</hour>
   <day>1</day>
   <temp>24.0</temp>
   <tmx>28.0</tmx>
   <tmn>23.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>70</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.6000000000000001</ws>
   <wd>1</wd>
   <wdKor>북동</wdKor>
   <wdEn>NE</wdEn>
   <reh>95</reh>
   <r06>10.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="5">
   <hour>6</hour>
   <day>1</day>
   <temp>24.0</temp>
   <tmx>28.0</tmx>
   <tmn>23.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>80</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.8</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>95</reh>
   <r06>10.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="6">
   <hour>9</hour>
   <day>1</day>
   <temp>25.0</temp>
   <tmx>28.0</tmx>
   <tmn>23.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>60</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.2000000000000002</ws>
   <wd>3</wd>
   <wdKor>남동</wdKor>
   <wdEn>SE</wdEn>
   <reh>90</reh>
   <r06>5.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="7">
   <hour>12</hour>
   <day>1</day>
   <temp>27.0</temp>
   <tmx>28.0</tmx>
   <tmn>23.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>60</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.5</ws>
   <wd>3</wd>
   <wdKor>남동</wdKor>
   <wdEn>SE</wdEn>
   <reh>85</reh>
   <r06>5.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="8">
   <hour>15</hour>
   <day>1</day>
   <temp>26.0</temp>
   <tmx>28.0</tmx>
   <tmn>23.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>70</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.4000000000000001</ws>
   <wd>4</wd>
   <wdKor>남</wdKor>
   <wdEn>S</wdEn>
   <reh>85</reh>
   <r06>15.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="9">
   <hour>18</hour>
   <day>1</day>
   <temp>26.0</temp>
   <tmx>28.0</tmx>
   <tmn>23.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>60</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.9</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>90</reh>
   <r06>15.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="10">
   <hour>21</hour>
   <day>1</day>
   <temp>24.0</temp>
   <tmx>28.0</tmx>
   <tmn>23.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>60</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.8</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>90</reh>
   <r06>3.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="11">
   <hour>24</hour>
   <day>1</day>
   <temp>24.0</temp>
   <tmx>28.0</tmx>
   <tmn>23.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>60</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.7000000000000001</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>95</reh>
   <r06>3.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="12">
   <hour>3</hour>
   <day>2</day>
   <temp>23.0</temp>
   <tmx>29.0</tmx>
   <tmn>22.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>70</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.8</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>95</reh>
   <r06>6.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="13">
   <hour>6</hour>
   <day>2</day>
   <temp>23.0</temp>
   <tmx>29.0</tmx>
   <tmn>22.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>70</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>0.8</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>95</reh>
   <r06>6.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="14">
   <hour>9</hour>
   <day>2</day>
   <temp>25.0</temp>
   <tmx>29.0</tmx>
   <tmn>22.0</tmn>
   <sky>4</sky>
   <pty>1</pty>
   <wfKor>비</wfKor>
   <wfEn>Rain</wfEn>
   <pop>60</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.2000000000000002</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>85</reh>
   <r06>4.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="15">
   <hour>12</hour>
   <day>2</day>
   <temp>26.0</temp>
   <tmx>29.0</tmx>
   <tmn>22.0</tmn>
   <sky>4</sky>
   <pty>0</pty>
   <wfKor>흐림</wfKor>
   <wfEn>Cloudy</wfEn>
   <pop>30</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.6</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>75</reh>
   <r06>4.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="16">
   <hour>15</hour>
   <day>2</day>
   <temp>27.0</temp>
   <tmx>29.0</tmx>
   <tmn>22.0</tmn>
   <sky>4</sky>
   <pty>0</pty>
   <wfKor>흐림</wfKor>
   <wfEn>Cloudy</wfEn>
   <pop>30</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.8</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>75</reh>
   <r06>0.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="17">
   <hour>18</hour>
   <day>2</day>
   <temp>26.0</temp>
   <tmx>29.0</tmx>
   <tmn>22.0</tmn>
   <sky>3</sky>
   <pty>0</pty>
   <wfKor>구름 많음</wfKor>
   <wfEn>Mostly Cloudy</wfEn>
   <pop>20</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.4000000000000001</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>80</reh>
   <r06>0.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="18">
   <hour>21</hour>
   <day>2</day>
   <temp>24.0</temp>
   <tmx>29.0</tmx>
   <tmn>22.0</tmn>
   <sky>4</sky>
   <pty>0</pty>
   <wfKor>흐림</wfKor>
   <wfEn>Cloudy</wfEn>
   <pop>30</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.3</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>80</reh>
   <r06>0.0</r06>
   <s06>0.0</s06>
  </data>
  <data seq="19">
   <hour>24</hour>
   <day>2</day>
   <temp>22.0</temp>
   <tmx>29.0</tmx>
   <tmn>22.0</tmn>
   <sky>4</sky>
   <pty>0</pty>
   <wfKor>흐림</wfKor>
   <wfEn>Cloudy</wfEn>
   <pop>30</pop>
   <r12>0.0</r12>
   <s12>0.0</s12>
   <ws>1.1</ws>
   <wd>2</wd>
   <wdKor>동</wdKor>
   <wdEn>E</wdEn>
   <reh>85</reh>
   <r06>0.0</r06>
   <s06>0.0</s06>
  </data>
 </body>
</description>
</item>
</channel>
</rss>

     */
}

