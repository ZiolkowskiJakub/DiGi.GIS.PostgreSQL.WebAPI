using DiGi.Analytical.Building.HVAC.Classes;
using DiGi.Analytical.Building.HVAC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("gis/[controller]")]
    public class HeatTransferCoefficientController : DiGi.WebAPI.Classes.WebAPIController
    {
        private static readonly RegulatedHeatTransferCoefficientsManager regulatedHeatTransferCoefficientsManager = Analytical.Building.HVAC.Create.RegulatedHeatTransferCoefficientsManager();

        public HeatTransferCoefficientController()
        {
        }

        [HttpGet("regulatedheattransfercoefficientsbyyear")]
        public async Task<IActionResult> GetRegulatedHeatTransferCoefficientsByYearAsync([FromQuery(Name = "year")] short year, CancellationToken cancellationToken = default)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(HeatTransferCoefficientController), nameof(GetRegulatedHeatTransferCoefficientsByYearAsync));

            Serilog.Modify.Log("Year provided: {Year}", year);

            if (regulatedHeatTransferCoefficientsManager is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "RegulatedHeatTransferCoefficientsManager is null");
                return BadRequest();
            }

            IRegulatedHeatTransferCoefficients? regulatedHeatTransferCoefficients = regulatedHeatTransferCoefficientsManager.GetRegulatedHeatTransferCoefficients(new DateTime(year, 1, 1));

            if (regulatedHeatTransferCoefficients is null)
            {
                Serilog.Modify.Log("No RegulatedHeatTransferCoefficients found for provided year");
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(regulatedHeatTransferCoefficients) ?? string.Empty, "application/json");
        }
    }
}