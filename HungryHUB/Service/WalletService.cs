using HungryHUB.Database;
using HungryHUB.Entity;
namespace HungryHUB.Service
{
    public class WalletService : IWalletService
    {
        private readonly MyContext _context;

        public WalletService(MyContext context)
        {
            _context = context;
        }

        public void CreateWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
        }

        public void UpdateWallet(string walletId, Wallet updatedWallet)
        {
            var existingWallet = _context.Wallets.Find(walletId);

            if (existingWallet != null)
            {
                existingWallet.Balance = updatedWallet.Balance;
                existingWallet.LastUpdated = DateTime.Now;

                _context.SaveChanges();
            }
        }

        public void DeleteWallet(string walletId)
        {
            var wallet = _context.Wallets.Find(walletId);

            if (wallet != null)
            {
                _context.Wallets.Remove(wallet);
                _context.SaveChanges();
            }
        }

        public Wallet GetWalletById(string walletId)
        {
            return _context.Wallets.Find(walletId);
        }

        public List<Wallet> GetAllWallets()
        {
            return _context.Wallets.ToList();
        }

        public List<Wallet> GetWalletsByUser(string userId)
        {
            return _context.Wallets
                .Where(w => w.UserId == userId)
                .ToList();
        }
    }
}