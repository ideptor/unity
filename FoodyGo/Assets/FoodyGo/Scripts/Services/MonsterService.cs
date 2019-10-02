using packt.FoodyGO.Mapping;
using packt.FoodyGO.Services;
using UnityEngine;
using UnityEngine.UI;

namespace packt.FoodyGo.Services
{
    public class MonsterService : MonoBehaviour
    {

        public GPSLocationService gpsLocationService;
        public Text distanceText;

        private double lastTimestamp;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(gpsLocationService != null && 
                gpsLocationService.IsServiceStarted &&
                gpsLocationService.PlayerTimestamp > lastTimestamp)
            {
                lastTimestamp = gpsLocationService.PlayerTimestamp;
                var s = MathG.Distance(
                    gpsLocationService.Longitude,
                    gpsLocationService.Latitude,
                    gpsLocationService.mapCenter.Longitude,
                    gpsLocationService.mapCenter.Latitude
                    );

                Debug.Log("Play distance from map tile center = " + s);
                if(distanceText != null)
                {
                    distanceText.text = string.Format("L:({0}, {1})\nD:{2}",
                        gpsLocationService.Longitude.ToString("F3"),
                        gpsLocationService.Latitude.ToString("F3"),
                        s.ToString("F8"));
                }

            }
        }
    }

}
