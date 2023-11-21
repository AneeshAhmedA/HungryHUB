
using HungryHUB.Entity;

namespace HungryHUB.Service
{
    public interface IWalletService
    {
        void CreateWallet(Wallet wallet);
        void UpdateWallet(string walletId, Wallet updatedWallet);
        void DeleteWallet(string walletId);
        Wallet GetWalletById(string walletId);
        List<Wallet> GetAllWallets();
        List<Wallet> GetWalletsByUser(string userId);
    }
}