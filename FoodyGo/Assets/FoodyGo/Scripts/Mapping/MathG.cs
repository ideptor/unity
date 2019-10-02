using System;

namespace packt.FoodyGO.Mapping
{
    public static class MathG
    {
        //public static float Distance(MapLocation mp1, MapLocation mp2)
        public static float Distance(double lon1, double lat1, double lon2, double lat2)
        {
            double R = 6371;        // 지구의 평균반경 km값

            // double로 변환하여 정확도를 높이고 반올림 오류를 피한다.
            /*
            double lat1 = mp1.Latitude;
            double lon1 = mp1.Longitude;

            double lat2 = mp2.Latitude;
            double lon2 = mp2.Longitude;
            */

            lat1 = deg2rad(lat1);
            lon1 = deg2rad(lon1);
            lat2 = deg2rad(lat2);
            lon2 = deg2rad(lon2);

            var dlat = (lat2 - lat1);
            var dlon = (lon2 - lon1);

            var a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) *
                Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = c * R;

            return (float)d * 1000;
        }

        public static double deg2rad(double deg)
        {
            var rad = deg * Math.PI / 180;
            // 라디안 = 각도 * 파이 / 180

            return rad;
        }
    }



}
