using System;
using System.Net.NetworkInformation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GPRTU.Models;
using GPRTU.Services;
using Microsoft.Maui.Networking;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;


namespace GPRTU.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public Command RefreshCommand { get; }
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        private string _origin;
        public string Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                OnPropertyChanged();
            }
        }

        private string _destination;
        public string Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                OnPropertyChanged();
            }
        }

        private double _routeDuration;
        public double RouteDuration
        {
            get { return _routeDuration; }
            set
            {
                _routeDuration = value;
                OnPropertyChanged();
            }
        }

        private double _routeDistance;
        public double RouteDistance
        {
            get { return _routeDistance; }
            set
            {
                _routeDistance = value;
                OnPropertyChanged();
            }
        }

        private double _routeFare;
        public double RouteFare
        {
            get { return _routeFare; }
            set
            {
                _routeFare = value;
                OnPropertyChanged();
            }
        }

        private bool _showRouteDetails;
        public bool ShowRouteDetails
        {
            get { return _showRouteDetails; }
            set
            {
                _showRouteDetails = value;
                OnPropertyChanged();
            }
        }


        public static Map map;
        public Command GetRouteCommand { get; }
        public Command DestinationSearch { get; }
        private RouteServices services;
        private Destination dr;
        private readonly IGeolocation geolocation1;

        public MainPageViewModel(IGeolocation geolocation1, IConnectivity connectivity)
		{
            map = new Map();
           // ShowRouteDetails = false;
            this.geolocation1 = geolocation1;
            GetLocation();
            services = new RouteServices();
            dr = new Destination();

            LocationSheet bottom = new();

            // LoadDestinations();

             bottom.DismissAsync();

            RefreshCommand = new Command(async () => await RefreshAsync());

            GetRouteCommand = new Command(async () => await LoadRouteAsync(Origin, Destination));
            DestinationSearch = new Command(async () => await LoadDestinationAsync());
            // LoadDestinations();
            this.connectivity = connectivity;
        }
        async Task RefreshAsync()
        {
            await GetLocation();
        }

        async Task GetLocation()
        {
            if (IsRefreshing)
                return;
            try
            {
                IsRefreshing = true;
                var geolocation = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(20));
                var location = await Geolocation.GetLocationAsync(geolocation);

                Pin pin = new()
                {
                    Address = Origin,
                    Location = location,
                    Type = PinType.Place,
                    Label = "Origin",
                };

                map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(10)));

                map.Pins.Add(pin);
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                var placemark = placemarks?.FirstOrDefault();
                Origin = string.Format($"{placemark.FeatureName}, {placemark.SubAdminArea}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert($"Data Error", ex.ToString(), "OK");
                IsRefreshing = false;
            }
            IsRefreshing = false;
        }
        private async Task LoadDestinationAsync()
        {
            LocationSheet bottom = new LocationSheet();

            // LoadDestinations();

            await bottom.ShowAsync();
            
        }
        private async Task LoadRouteAsync(string origin, string destination)
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No Internet Access", "", "OK", "Retry");
                return;
            }
            if (origin == null)
            {
                await Application.Current.MainPage.DisplayAlert("Location Services Error", "Origin must be not empty", "OK");
                return;
            }
            else if (destination == null)
            {
                await Application.Current.MainPage.DisplayAlert("Location Services Error", "Destination must be not empty", "OK");
                return;
            }
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (GetLocation == null)
            {
                location = await geolocation1.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High,
                    Timeout = TimeSpan.FromSeconds(10),
                    RequestFullAccuracy = true,

                });
            }
            if (location == null)
            {
                await Shell.Current.DisplayAlert("Location Error", "Location service unavailable!!!! Please Try Again Later!!", "OK", "Retry");
                return;
            }
            IsRefreshing = true;
            List<Route> routes = new List<Route>();
            List<LatLong> locations = new List<LatLong>();

            dr = await services.GetDirectionResponseAsync(origin, destination);
            if (dr != null)
            {
                ShowRouteDetails = false;
                routes = dr.Routes.ToList();


                //route duration to minutes
                RouteDuration = Math.Round((Double)routes[0].Duration / 60, 0);


                //route duration to miles
                RouteDistance = Math.Round((Double)routes[0].Distance / 1609, 1);

                // route distance and duration to fare
               /* RouteFare = Math.Round((Double)RouteDistance * 1.25, 2);

                if (RouteFare <= 6)
                {
                    RouteFare = 6;
                }
               */
                locations = DecodepolylinePoint(routes[0].Geometry.ToString());

                var firstPinLocation = locations[0];
                var lastPinLocation = locations[locations.Count - 1];

                Pin OriginPin = new Pin
                {
                    Label = "Origin",
                    Address = Origin,
                    Type = PinType.Place,
                    Location = new Location(firstPinLocation.Lat, firstPinLocation.Long)
                };
                map.Pins.Add(OriginPin);

                Pin DestinatioPin = new Pin
                {
                    Label = "Destination",
                    Address = Destination,
                    Type = PinType.Place,
                    Location = new Location(lastPinLocation.Lat, lastPinLocation.Long)
                };
                map.Pins.Add(DestinatioPin);

                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(firstPinLocation.Lat, firstPinLocation.Long), Distance.FromMiles(10)));

                Polyline polyline = new()
                {
                    StrokeColor = Colors.Blue,
                    StrokeWidth = 12,
                   
                };
                foreach(var loca in locations)
                {
                    polyline.Geopath.Add(new Location(loca.Lat, loca.Long));
                };

                // Add the Polyline to the map's MapElements collection
                map.MapElements.Add(polyline);

                IsRefreshing = false;

                ShowRouteDetails = true;

            }
        }

        private List<LatLong> DecodepolylinePoint(string encodedPoints)
        {
            if (encodedPoints == null || encodedPoints == "")
                return null;
            List<LatLong> poly = new List<LatLong>();
            char[] polylinechars = encodedPoints.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            try
            {
                while (index < polylinechars.Length)
                {
                    // calculate next latitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length)
                        break;

                    currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                    //calculate next longitude
                    sum = 0;
                    shifter = 0;
                    do
                    {
                        next5bits = (int)polylinechars[index++] - 63;
                        sum |= (next5bits & 31) << shifter;
                        shifter += 5;
                    } while (next5bits >= 32 && index < polylinechars.Length);

                    if (index >= polylinechars.Length && next5bits >= 32)
                        break;

                    currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                    LatLong p = new LatLong();
                    p.Lat = Convert.ToDouble(currentLat) / 100000.0;
                    p.Long = Convert.ToDouble(currentLng) / 100000.0;
                    poly.Add(p);
                }

            }
            catch(Exception ex)
            {
                // await Shell.Current.DisplayAlert("Routing Error", $"{ex}", "OK", "Retry");
                Console.WriteLine($"ex");
            }
            return poly;

        }
        

    }
}

