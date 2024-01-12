using System;
using GPRTU.Models;
using Newtonsoft.Json;

namespace GPRTU.Services
{
	public class RouteServices
	{
        private readonly string baseRouteUrl = "https://router.project-osrm.org/route/v1/driving/";

        private HttpClient _httpClient;
        public RouteServices()
        {
            _httpClient = new HttpClient();
        }
        public async Task<Destination> GetDirectionResponseAsync(string origin, string destination)
        {
            var originLocations = await Geocoding.GetLocationsAsync(origin);
            var originLocation = originLocations?.FirstOrDefault();

            var destinationLocations = await Geocoding.GetLocationsAsync(destination);
            var destinationLocation = destinationLocations?.FirstOrDefault();

            if (originLocation == null || destinationLocation == null)
            {
                return null;
            }

            if (originLocation != null & destinationLocation != null)
            {
                string url = string.Format(baseRouteUrl) + $"{originLocation.Longitude},{originLocation.Latitude};" +
                    $"{destinationLocation.Longitude},{destinationLocation.Latitude}?overview=full&geometries=polyline&steps=false";

                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<Destination>(json);

                    return results;
                }
            }
            else
            {
                return null;
            }
            return null;
        }

    }
}

