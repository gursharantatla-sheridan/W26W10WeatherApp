namespace W26W10WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGetWeatherBtnClicked(object sender, EventArgs e)
        {
            var location = await Geolocation.Default.GetLocationAsync();
            var latitude = location!.Latitude;
            var longitude = location.Longitude;

            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&appid=adee4d9d26685357054efd2f06359807";

            var myWeather = await WeatherProxy.GetWeatherAsync(url);

            CityLbl.Text = myWeather!.name;
            TemperatureLbl.Text = myWeather.main.temp.ToString("F0") + " \u00B0C";
            ConditionsLbl.Text = myWeather.weather[0].description.ToUpper();

            string iconUrl = $"https://openweathermap.org/payload/api/media/file/{myWeather.weather[0].icon}.png";
            WeatherImg.Source = ImageSource.FromUri(new Uri(iconUrl));
        }
    }
}
