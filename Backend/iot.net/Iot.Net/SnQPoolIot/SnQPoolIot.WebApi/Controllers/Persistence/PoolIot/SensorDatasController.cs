//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Persistence.PoolIot
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.PoolIot.ISensorData;
    using TModel = Transfer.Models.Persistence.PoolIot.SensorData;
    [ApiController]
    [Route("Controller")]
    public partial class SensorDatasController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
