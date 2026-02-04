using DiGi.Core.Interfaces;
using DiGi.GIS.Classes;
using DiGi.PostgreSQL.PartitionReference.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("api/gis/[controller]")]
    public class OrtoDatasController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter;

        public OrtoDatasController(PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter)
        {
            this.ortoDatasPostgreSQLConverter = ortoDatasPostgreSQLConverter;
        }

        [HttpGet("item")]
        public async Task<IActionResult> GetAsync([FromQuery(Name = "reference")] string? reference)
        {
            if (string.IsNullOrWhiteSpace(reference))
            {
                return BadRequest();
            }

            return Content(Core.Convert.ToSystem_String((ISerializableObject)new OrtoDatas(reference, [])) ?? string.Empty, "application/json");
        }

        [HttpPost("items")]
        public async Task<IActionResult> GetAsync([FromBody] List<string>? references)
        {
            if (references == null || references.Count == 0)
            {
                return BadRequest();
            }

            List<OrtoDatas> ortoDatas = [];

            foreach (string reference in references)
            {
                ortoDatas.Add(new OrtoDatas(reference, []));
            }

            return Content(Core.Convert.ToSystem_String(ortoDatas) ?? string.Empty, "application/json");
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] JsonObject? jsonObject, [FromQuery(Name = "reference")] string? reference)
        {
            if(ortoDatasPostgreSQLConverter is null)
            {
                return StatusCode(500);
            }

            if (jsonObject is null)
            {
                return BadRequest();
            }

            if(string.IsNullOrEmpty(reference))
            {
                return BadRequest();
            }

            OrtoDatas? ortoDatas = Core.Create.SerializableObject<OrtoDatas>(jsonObject);
            if(ortoDatas is null)
            {
                return BadRequest();
            }

            ortoDatasPostgreSQLConverter.SetName(ortoDatas, reference);

            PartitionReference? partitionReference = await ortoDatasPostgreSQLConverter.UpdateAsync(ortoDatas);
            
            string? json = Core.Convert.ToSystem_String(partitionReference);

            return Ok(json);
        }
    }
}