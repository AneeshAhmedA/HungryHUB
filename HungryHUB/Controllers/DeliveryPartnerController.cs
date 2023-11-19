using AutoMapper;
using HungryHUB.DTO;
using HungryHUB.Entity;
using HungryHUB.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HungryHUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryPartnerController : ControllerBase
    {
        private readonly IDeliveryPartnerService _deliveryPartnerService;
        private readonly IMapper _mapper;

        public DeliveryPartnerController(IDeliveryPartnerService deliveryPartnerService, IMapper mapper)
        {
            _deliveryPartnerService = deliveryPartnerService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeliveryPartnerDTO>> GetAllDeliveryPartners()
        {
            var deliveryPartners = _deliveryPartnerService.GetAllDeliveryPartners();
            var deliveryPartnerDTOs = _mapper.Map<List<DeliveryPartnerDTO>>(deliveryPartners);
            return StatusCode(200, deliveryPartnerDTOs);
        }

        [HttpGet("{deliveryPartnerId}")]
        public ActionResult<DeliveryPartnerDTO> GetDeliveryPartnerById(int deliveryPartnerId)
        {
            var deliveryPartner = _deliveryPartnerService.GetDeliveryPartnerById(deliveryPartnerId);

            if (deliveryPartner == null)
            {
                return StatusCode(404); // Not Found
            }

            var deliveryPartnerDTO = _mapper.Map<DeliveryPartnerDTO>(deliveryPartner);
            return StatusCode(200, deliveryPartnerDTO);
        }

        [HttpPost]
        public ActionResult CreateDeliveryPartner([FromBody] DeliveryPartnerDTO deliveryPartnerDTO)
        {
            try
            {
                var deliveryPartner = _mapper.Map<DeliveryPartner>(deliveryPartnerDTO);
                _deliveryPartnerService.CreateDeliveryPartner(deliveryPartner);
                return StatusCode(200); // 200 OK for success
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{deliveryPartnerId}")]
        public ActionResult UpdateDeliveryPartner(int deliveryPartnerId, [FromBody] DeliveryPartnerDTO deliveryPartnerDTO)
        {
            try
            {
                var existingDeliveryPartner = _deliveryPartnerService.GetDeliveryPartnerById(deliveryPartnerId);

                if (existingDeliveryPartner == null)
                {
                    return StatusCode(404); // Not Found
                }

                var updatedDeliveryPartner = _mapper.Map<DeliveryPartner>(deliveryPartnerDTO);
                _deliveryPartnerService.UpdateDeliveryPartner(deliveryPartnerId, updatedDeliveryPartner);

                return StatusCode(200); // 200 OK for success
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{deliveryPartnerId}")]
        public ActionResult DeleteDeliveryPartner(int deliveryPartnerId)
        {
            var existingDeliveryPartner = _deliveryPartnerService.GetDeliveryPartnerById(deliveryPartnerId);

            if (existingDeliveryPartner == null)
            {
                return StatusCode(404); // Not Found
            }

            _deliveryPartnerService.DeleteDeliveryPartner(deliveryPartnerId);

            return StatusCode(200); // 200 OK for success
        }
    }
}
