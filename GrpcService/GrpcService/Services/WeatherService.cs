using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class WeatherService : Weather.WeatherBase
    {
        public WeatherService()
        {
        }

        private static readonly List<WeatherForecast> Data = new() { 
            new WeatherForecast { Summary = "Cold"}
        };

        public override Task<StatusResponse> SaveForecast(WeatherForecast request, ServerCallContext cobtext)
        { 
            if (string.IsNullOrEmpty(request.Summary))
            {
                return Task.FromResult(new StatusResponse { Success = false });
            }
            Data.Add(request);
            return Task.FromResult(new StatusResponse { Success = true });
        }

        public override Task<WeatherForecast> GetForecast(Empty request, ServerCallContext context)
        {
            
            var result = Data.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (result is null)
                return Task.FromResult(new WeatherForecast { });

            return Task.FromResult(result);
        }




    }
}