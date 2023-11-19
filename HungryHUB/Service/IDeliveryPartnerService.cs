using HungryHUB.Entity;
using System.Collections.Generic;

namespace HungryHUB.Service
{
    public interface IDeliveryPartnerService
    {
        List<DeliveryPartner> GetAllDeliveryPartners();
        DeliveryPartner GetDeliveryPartnerById(int deliveryPartnerId);
        void CreateDeliveryPartner(DeliveryPartner deliveryPartner);
        void UpdateDeliveryPartner(int deliveryPartnerId, DeliveryPartner updatedDeliveryPartner);
        void DeleteDeliveryPartner(int deliveryPartnerId);
    }
}
