using AppTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.Services
{
    class WeatherService
    {
        const string url = "http://api.openweathermap.org/data/2.5/weather";
        const string key = "be05a05af20309aa8fc00a3ff1f4ca01"; // clef api meteo
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string querystring = $"{url}?zip={zipCode},fr&appid={key}&units=metrics"; // requette http vers l'api 
            var result =  await DataServices.GetDataFromService(querystring).ConfigureAwait(false);//recupere les données de l'api
            if (result != null)
            {
                Weather weather = new Weather();
                weather.City = result["name"];
                weather.temperature = result["main"]["temp"] + " C";
                weather.wind = result["wind"]["speed"] + " km/h";
                weather.humididy = result["main"]["humidity"] + " %";
                weather.visibility = result["visibility"];


                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)result["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)result["sys"]["sunset"]);


                weather.sunset = sunset.ToString("HH:mm:ss") + " UTC";
                weather.sunrise = sunrise.ToString("HH:mm:ss") + " UTC";

                return weather;


            }
            else
                return null; 
        }
    }
}
