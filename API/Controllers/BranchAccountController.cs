using API.ViewModel;
using DAO.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchAccountController : ControllerBase
    {
        private readonly IBranchAccountRepo _branchAccountRepo;
        private readonly IJWTTokenService _jWTTokenService;
        public BranchAccountController(IBranchAccountRepo branchAccountRepo, IJWTTokenService jWTTokenService)
        {
            _branchAccountRepo = branchAccountRepo;
            _jWTTokenService = jWTTokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM account)
        {
            try
            {
                var check = await _branchAccountRepo.Login(account.Email!, account.Password!);
                if (check != null)
                {
                    var token = _jWTTokenService.CreateJWTToken(check);
                    return Ok(new
                    {
                        message = " Login Successfully",
                        data = check,
                        token = token
                    });
                }
                return NotFound(new
                {
                    message = " Login Fail",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
