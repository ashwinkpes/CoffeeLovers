using CoffeeLovers.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CoffeeLovers.APIModels.Coffee;

namespace CoffeeLovers.IBusinessLogic
{
    public interface ICoffeeService
    {
        Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByName(string coffeeName);

        Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByDisplayId(string coffeeDisplayId);

        Task<(HttpStatusCode statusCode, IEnumerable<CoffeeDto> coffeeDtos)> GetAllCoffees(bool includeCoffeeOwners);

        Task<(HttpStatusCode statusCode, string coffeeId)> CreateCoffee(AddCoffeeDto coffeeToAdd);

        Task<HttpStatusCode> UpdateCoffee(string coffeeDisplayId, List<PatchDto> patchDtos);

        Task<HttpStatusCode> DeleteCoffee(string coffeeDisplayId);
    }


   
}
