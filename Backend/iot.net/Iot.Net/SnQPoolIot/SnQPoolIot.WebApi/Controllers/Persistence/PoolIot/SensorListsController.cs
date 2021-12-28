//@GeneratedCode
namespace SnQPoolIot.WebApi.Controllers.Persistence.PoolIot
{
    using Microsoft.AspNetCore.Mvc;
    using TContract = Contracts.Persistence.PoolIot.ISensorList;
    using TModel = Transfer.Models.Persistence.PoolIot.SensorList;
    [ApiController]
    [Route("Controller")]
    public partial class SensorListsController : WebApi.Controllers.GenericController<TContract, TModel>
    {
    }
}
