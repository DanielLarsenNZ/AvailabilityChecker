using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvailabilityTester
{
    public class Functions
    {
        private static readonly HttpClient _http = new HttpClient();
        private readonly TelemetryClient _telemetry;
        private readonly IConfiguration _config;

        public Functions(TelemetryConfiguration telemetryConfiguration, IConfiguration config)
        {
            _telemetry = new TelemetryClient(telemetryConfiguration);
            _config = config;
        }

        public async Task CheckAvailability([TimerTrigger("0 */1 * * * *")] TimerInfo timer, ILogger logger)
        {
            logger.LogInformation("CheckAvailability");

            string name = _config["AvailabilityTestName"];
            string url = _config["AvailabilityCheckUrl"];

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(name))
            {
                logger.LogInformation("AppSetting \"AvailabilityCheckUrl\" is not set. Nothing to check.");
                return;
            }

            logger.LogInformation($"Getting {url}");

            var startTime = DateTimeOffset.Now;
            var response = await _http.GetAsync(url);
            var finishTime = DateTimeOffset.Now;
            var duration = DateTimeOffset.Now.Subtract(startTime);

            _telemetry.TrackAvailability(name, finishTime, duration, _config["AvailabilityTestRunLocation"], response.IsSuccessStatusCode, response.ReasonPhrase);
            logger.LogInformation($"{name}, {finishTime}, {duration}, {_config["AvailabilityTestRunLocation"]}, {response.IsSuccessStatusCode}, {response.ReasonPhrase}");
        }
    }
}
