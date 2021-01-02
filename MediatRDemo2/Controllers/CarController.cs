using MediatR;
using Microsoft.AspNetCore.Mvc;
using Data.Cars.Commands;
using Data.Cars.Queries;
using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Cars.Queries;

namespace MediatRDemo2.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : Controller
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<Car>> Index()
        {
            return _mediator.Send(new GetAllCarsQuery());
        }

        [HttpGet]
        [Route("find")]
        public Task<Car> Find([FromQuery] GetCarQuery query)
        {
            return _mediator.Send(query);
        }

        [HttpPost]
        [Route("create")]
        public Task<string> Create([FromBody] CreateCarCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
