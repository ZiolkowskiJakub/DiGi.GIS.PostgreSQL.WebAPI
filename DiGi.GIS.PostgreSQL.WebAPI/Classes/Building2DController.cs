using DiGi.GIS.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("api/gis/[controller]")]
    public class Building2DController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.GISModelPostgreSQLConverter gISModelPostgreSQLConverter;

        public Building2DController(PostgreSQL.Classes.GISModelPostgreSQLConverter gISModelPostgreSQLConverter)
        {
            this.gISModelPostgreSQLConverter = gISModelPostgreSQLConverter;
        }

        [HttpGet("item")]
        public async Task<IActionResult> GetAsync([FromQuery(Name = "reference")] string? reference)
        {
            if (string.IsNullOrWhiteSpace(reference))
            {
                return BadRequest();
            }

            return Content(Core.Convert.ToSystem_String(new Building2D(Guid.NewGuid(), reference, null, 1, GIS.Enums.BuildingPhase.occupied, GIS.Enums.BuildingGeneralFunction.agricultural_production_service_utility_buildings, [GIS.Enums.BuildingSpecificFunction.single_family_building])) ?? string.Empty, "application/json");
        }

        [HttpPost("items")]
        public async Task<IActionResult> GetAsync([FromBody] List<string>? references)
        {
            if (references == null || references.Count == 0)
            {
                return BadRequest();
            }

            List<Building2D> buildings = [];

            foreach (string reference in references)
            {
                buildings.Add(new Building2D(Guid.NewGuid(), reference, null, 1, GIS.Enums.BuildingPhase.occupied, GIS.Enums.BuildingGeneralFunction.agricultural_production_service_utility_buildings, [GIS.Enums.BuildingSpecificFunction.single_family_building]));
            }

            return Content(Core.Convert.ToSystem_String(buildings) ?? string.Empty, "application/json");
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] JsonObject? jsonObject, [FromQuery(Name = "reference")] string? reference)
        {
            if (jsonObject is null || string.IsNullOrWhiteSpace(reference))
            {
                return BadRequest();
            }



            return Ok();
        }
    }
}