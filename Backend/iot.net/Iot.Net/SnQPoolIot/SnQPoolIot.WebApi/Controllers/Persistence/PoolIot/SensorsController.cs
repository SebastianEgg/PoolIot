//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Persistence.PoolIot
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.PoolIot.ISensor;
    using TModel = Transfer.Models.Persistence.PoolIot.Sensor;
    [ApiController]
    [Route("Controller")]
    public partial class SensorsController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
