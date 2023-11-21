using AutoMapper;
using HungryHUB.DTO;
using HungryHUB.Entity;
using HungryHUB.Service;
using Microsoft.AspNetCore.Mvc;

namespace HungryHUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;

        public WalletController(IWalletService walletService, IMapper mapper)
        {
            _walletService = walletService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateWallet([FromBody] WalletDTO walletDTO)
        {
            try
            {
                var wallet = _mapper.Map<Wallet>(walletDTO);
                _walletService.CreateWallet(wallet);
                return StatusCode(200, wallet.WalletId); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{walletId}")]
        public IActionResult GetWalletById(string walletId)
        {
            var wallet = _walletService.GetWalletById(walletId);

            if (wallet == null)
            {
                return NotFound();
            }

            var walletDTO = _mapper.Map<WalletDTO>(wallet);
            return StatusCode(200, walletDTO);
        }

        [HttpGet]
        public IActionResult GetAllWallets()
        {
            try
            {
                var wallets = _walletService.GetAllWallets();
                var walletDTOs = _mapper.Map<List<WalletDTO>>(wallets);
                return StatusCode(200, walletDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{walletId}")]
        public IActionResult UpdateWallet(string walletId, [FromBody] WalletDTO updatedWalletDTO)
        {
            try
            {
                var updatedWallet = _mapper.Map<Wallet>(updatedWalletDTO);
                _walletService.UpdateWallet(walletId, updatedWallet);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{walletId}")]
        public IActionResult DeleteWallet(string walletId)
        {
            _walletService.DeleteWallet(walletId);
            return NoContent(); 
        }
    }
}