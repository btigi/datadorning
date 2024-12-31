namespace WeatherApi.Model.Weather
{
    internal class WeatherResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast Forecast { get; set; }
    }

    internal class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string Tz_Id { get; set; }
        public int Localtime_Epoch { get; set; }
        public string LocalTime { get; set; }
    }

    internal class Current
    {
        public int Last_Updated_Epoch { get; set; }
        public string Last_Updated { get; set; }
        public float Temp_c { get; set; }
        public float Temp_f { get; set; }
        public int Is_Day { get; set; }
        public Condition Condition { get; set; }
        public float Wind_mph { get; set; }
        public float Wind_kph { get; set; }
        public int Wind_Degree { get; set; }
        public string Wind_Dir { get; set; }
        public float Pressure_mb { get; set; }
        public float Pressure_in { get; set; }
        public float Precip_mm { get; set; }
        public float Precip_in { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public float Feelslike_c { get; set; }
        public float Feelslike_f { get; set; }
        public float Windchill_c { get; set; }
        public float Windchill_f { get; set; }
        public float Heatindex_c { get; set; }
        public float Heatindex_f { get; set; }
        public float Dewpoint_c { get; set; }
        public float Dewpoint_f { get; set; }
        public float Vis_km { get; set; }
        public float Vis_miles { get; set; }
        public float UV { get; set; }
        public float Gust_mph { get; set; }
        public float Gust_kph { get; set; }
    }

    internal class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
    }

    internal class Forecast
    {
        public Forecastday[] Forecastday { get; set; }
    }

    internal class Forecastday
    {
        public string Date { get; set; }
        public int Date_Epoch { get; set; }
        public Day Day { get; set; }
        public Astro Astro { get; set; }
        public Hour[] Hour { get; set; }
    }

    internal class Day
    {
        public float Maxtemp_c { get; set; }
        public float Maxtemp_f { get; set; }
        public float Mintemp_c { get; set; }
        public float Mintemp_f { get; set; }
        public float Avgtemp_c { get; set; }
        public float Avgtemp_f { get; set; }
        public float Maxwind_mph { get; set; }
        public float Maxwind_kph { get; set; }
        public float Totalprecip_mm { get; set; }
        public float Totalprecip_in { get; set; }
        public float Totalsnow_cm { get; set; }
        public float Avgvis_km { get; set; }
        public float Avgvis_miles { get; set; }
        public int Avghumidity { get; set; }
        public int Daily_Will_It_Rain { get; set; }
        public int Daily_Chance_Of_Rain { get; set; }
        public int Daily_Will_It_Snow { get; set; }
        public int Daily_Chance_Of_Snow { get; set; }
        public Condition Condition { get; set; }
        public float UV { get; set; }
    }

    internal class Astro
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public string Moonset { get; set; }
        public string Moon_phase { get; set; }
        public int Moon_illumination { get; set; }
        public int Is_moon_up { get; set; }
        public int Is_sun_up { get; set; }
    }

    internal class Hour
    {
        public int Time_epoch { get; set; }
        public string Time { get; set; }
        public float Temp_c { get; set; }
        public float Temp_f { get; set; }
        public int Is_day { get; set; }
        public Condition Condition { get; set; }
        public float Wind_mph { get; set; }
        public float Wind_kph { get; set; }
        public int Wind_degree { get; set; }
        public string Wind_dir { get; set; }
        public float Pressure_mb { get; set; }
        public float Pressure_in { get; set; }
        public float Precip_mm { get; set; }
        public float Precip_in { get; set; }
        public float Snow_cm { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public float Feelslike_c { get; set; }
        public float Feelslike_f { get; set; }
        public float Windchill_c { get; set; }
        public float Windchill_f { get; set; }
        public float Heatindex_c { get; set; }
        public float Heatindex_f { get; set; }
        public float Dewpoint_c { get; set; }
        public float Dewpoint_f { get; set; }
        public int Will_it_rain { get; set; }
        public int Chance_of_rain { get; set; }
        public int Will_it_snow { get; set; }
        public int Chance_of_snow { get; set; }
        public float Vis_km { get; set; }
        public float Vis_miles { get; set; }
        public float Gust_mph { get; set; }
        public float Gust_kph { get; set; }
        public float UV { get; set; }
    }
}