using CoffeeLovers.APIModels;
using CoffeeLovers.APIModels.Owner;
using CoffeeLovers.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CoffeeLovers.IBusinessLogic
{
    public interface ICoffeeService
    {
        Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByName(string cofeeName);

        Task<(HttpStatusCode statusCode, CoffeeDto coffeeDto)> GetCoffeeByDisplayId(string coffeeDisplayid);

        Task<(HttpStatusCode statusCode, IEnumerable<CoffeeDto> coffeeDtos)> GetAllCoffees(bool includeCofeeOwners);

        Task<(HttpStatusCode statusCode, string coffeeId)> CreateCoffee(AddCoffeeDto cofeeToAdd);

        Task<HttpStatusCode> UpdateCoffee(string coffeeDisplayid, List<PatchDto> patchDtos);

        Task<HttpStatusCode> DeleteCoffee(string coffeeDisplayid);
    }


   
}
