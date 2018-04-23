﻿using AppTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTest { 

	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

       

        public async void GetWeatherButton_Clicker(object sender , EventArgs e)
        {
            Weather weather = await Services.WeatherService.GetWeather("93400") ;
            City.Text = weather.City;
            temperature.Text = weather.temperature;
            winds.Text = weather.wind;
        }

    }
}