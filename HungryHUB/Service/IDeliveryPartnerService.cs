// IDeliveryPartnerService.cs
using HungryHUB.Entity;
using System.Collections.Generic;

namespace HungryHUB.Service
{
    public interface IDeliveryPartnerService
    {
        List<DeliveryPartner> GetAllDeliveryPartners();
        DeliveryPartner GetDeliveryPartnerById(string deliveryPartnerId);
        void CreateDeliveryPartner(DeliveryPartner deliveryPartner);
        void UpdateDeliveryPartner(string deliveryPartnerId, DeliveryPartner updatedDeliveryPartner);
        void DeleteDeliveryPartner(string deliveryPartnerId);
    }
}
