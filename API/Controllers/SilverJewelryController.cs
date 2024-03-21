using API.DTO;
using API.ViewModel;
using AutoMapper;
using BusinessObjects.Models;
using DAO.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace API.Controllers
{
    public class SilverJewelryController : ODataController
    {
        private readonly ISilverJewelryRepo _silverJewelryRepo;
        private readonly IMapper _mapper;
        public SilverJewelryController(ISilverJewelryRepo silverJewelryRepo, IMapper mapper)
        {
            _silverJewelryRepo = silverJewelryRepo;
            _mapper = mapper;
        }
        [EnableQuery]

        public ActionResult<IQueryable<SilverJewelry>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<SilverJewelryDTO>>(_silverJewelryRepo.GetAll()));
        }

        [HttpGet("odata/SilverJewelry/{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetByID([FromRoute] string id)
        {
            try
            {
                var sil = await _silverJewelryRepo.GetByID(id);
                if (sil != null)
                {
                    return Ok(sil);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [EnableQuery]
        public async Task<IActionResult> PostSilverJewelry([FromBody] SilverJewelryCreate sil)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newSil = _mapper.Map<SilverJewelry>(sil);
                await _silverJewelryRepo.Create(newSil);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
