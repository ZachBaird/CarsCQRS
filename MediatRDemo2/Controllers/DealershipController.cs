using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Dealerships.Commands;
using Services.Dealerships.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRDemo2.Controllers
{
    [ApiController]
    [Route("api/dealerships")]
    public class DealershipController : Controller
    {
        private readonly IMediator _mediator;

        public DealershipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<Dealership>> Index()
        {
            return _mediator.Send(new GetAllDealershipsQuery());
        }

        [HttpGet]
        [Route("find")]
        public Task<Dealership> Find([FromQuery] GetDealershipQuery query)
        {
            return _mediator.Send(query);
        }

        [HttpPost]
        [Route("create")]
        public Task<string> Create([FromBody] CreateDealershipCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
