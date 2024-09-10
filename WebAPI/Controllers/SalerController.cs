using Application.UseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class SalerController : ControllerBase
        {
            private readonly AddSaleBySaler _addSaleBySalerUseCase;
            private readonly UpdateQuantityBySaler _updateQuantityBySalerUseCase;

            public SalerController(
                AddSaleBySaler addSaleBySalerUseCase,
                UpdateQuantityBySaler updateQuantityBySalerUseCase)
            {
                _addSaleBySalerUseCase = addSaleBySalerUseCase;
                _updateQuantityBySalerUseCase = updateQuantityBySalerUseCase;
            }

            [HttpPost("AddSale")]
            public async Task<IActionResult> AddSale([FromBody] SalerStock request)
            {
                try
                {
                    await _addSaleBySalerUseCase.Execute(request.SalerId, request.BeerId, request.Quantity);
                    return Ok("Sale added successfully.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut("UpdateStock")]
            public async Task<IActionResult> UpdateStock([FromBody] SalerStock request)
            {
                try
                {
                    await _updateQuantityBySalerUseCase.Execute(request.SalerId, request.BeerId, request.Quantity);
                    return Ok("Quantity updated successfully.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
