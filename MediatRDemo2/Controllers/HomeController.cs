using MediatR;
using Microsoft.AspNetCore.Mvc;
using Data.Cars.Commands;
using Data.Cars.Queries;
using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatRDemo2.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<Car>> Index()
        {
            return _mediator.Send(new GetAllCarsQuery());
        }

        [HttpPost]
        [Route("create")]
        public Task<string> Create([FromBody] CreateCarCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
