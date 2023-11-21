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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                var order = _mapper.Map<Order>(orderDTO);
                _orderService.CreateOrder(order);
                return StatusCode(200, order.OrderId); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(string orderId)
        {
            var order = _orderService.GetOrderById(orderId);

            if (order == null)
            {
                return NotFound();
            }

            var orderDTO = _mapper.Map<OrderDTO>(order);
            return StatusCode(200, orderDTO);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var orders = _orderService.GetAllOrders();
                var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);
                return StatusCode(200, orderDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{orderId}")]
        public IActionResult UpdateOrder(string orderId, [FromBody] OrderDTO updatedOrderDTO)
        {
            try
            {
                var updatedOrder = _mapper.Map<Order>(updatedOrderDTO);
                _orderService.UpdateOrder(orderId, updatedOrder);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(string orderId)
        {
            _orderService.DeleteOrder(orderId);
            return NoContent();
        }
    }
}
