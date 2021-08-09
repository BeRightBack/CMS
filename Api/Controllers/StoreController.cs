using Api.Data;
using Api.Models;
using Api.Repository;
using AutoMapper;
using Dto;
using Microsoft.AspNetCore.Authorization;
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
        // Can be used to override global caching on a particular endpoint at any point. 
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        //[HttpCacheValidation(MustRevalidate = false)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStores([FromQuery] RequestParams requestParams)
        {
            var stores = await _unitOfWork.Stores.GetPagedList(requestParams);
            var results = _mapper.Map<IList<StoreDTO>>(stores);
            return Ok(results);
            
        }

        [HttpGet("{id:int}", Name = "GetStore")]
        //[ResponseCache(CacheProfileName = "120SecondsDuration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStore(int id)
        {
            var store = await _unitOfWork.Stores.Get(q => q.Id == id, new List<string> { "Products" });
            var result = _mapper.Map<StoreDTO>(store);
            return Ok(result);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreDTO storeDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateStore)}");
                return BadRequest(ModelState);
            }

            var store = _mapper.Map<Store>(storeDTO);
            await _unitOfWork.Stores.Insert(store);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetStore", new { id = store.Id }, store);

        }

        [Authorize]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStore(int id, [FromBody] UpdateStoreDTO storeDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateStore)}");
                return BadRequest(ModelState);
            }

            var store = await _unitOfWork.Stores.Get(q => q.Id == id);
            if (store == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateStore)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(storeDTO, store);
            _unitOfWork.Stores.Update(store);
            await _unitOfWork.Save();

            return NoContent();

        }

        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStore(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStore)}");
                return BadRequest();
            }

            var store = await _unitOfWork.Stores.Get(q => q.Id == id);
            if (store == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStore)}");
                return BadRequest("Submitted data is invalid");
            }

            await _unitOfWork.Stores.Delete(id);
            await _unitOfWork.Save();

            return NoContent();

        }

    }
}
