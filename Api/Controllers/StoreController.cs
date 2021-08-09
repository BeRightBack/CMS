using Api.Repository;
using AutoMapper;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StoreController> _logger;
        private readonly IMapper _mapper;

        public StoreController(IUnitOfWork unitOfWork, ILogger<StoreController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            try
            {
                var stores = await _unitOfWork.Stores.GetAll();
                var results = _mapper.Map<IList<StoreDTO>>(stores);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetStores)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetStore(int id)
        {
            try
            {
                var store = await _unitOfWork.Stores.Get(q => q.Id==id,new List<string> {"Products"});
                var result = _mapper.Map<StoreDTO>(store);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetStore)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

    }
}
