//using DiGi.Core.Interfaces;
//using DiGi.GIS.Classes;
//using DiGi.PostgreSQL.PartitionReference.Classes;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Text.Json.Nodes;
//using System.Threading.Tasks;

//namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
//{
//    [ApiController]
//    [Route("gis/[controller]")]
//    public class OrtoDatasController : DiGi.WebAPI.Classes.WebAPIController
//    {
//        private readonly PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter;

//        public OrtoDatasController(PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter)
//        {
//            this.ortoDatasPostgreSQLConverter = ortoDatasPostgreSQLConverter;
//        }

//        [HttpGet("item")]
//        public async Task<IActionResult> GetAsync([FromQuery(Name = "reference")] string? reference)
//        {
//            if (ortoDatasPostgreSQLConverter is null)
//            {
//                return StatusCode(500);
//            }

//            if (string.IsNullOrWhiteSpace(reference))
//            {
//                return BadRequest();
//            }

//            if (Create.PartitionReference(GIS.Create.GISModelAreal2DReference(reference)) is not PartitionReference partitionReference)
//            {
//                return BadRequest();
//            }

//            OrtoDatas? ortoDatas = await ortoDatasPostgreSQLConverter.GetSerializableObjectAsync<OrtoDatas>(partitionReference);

//            return Content(Core.Convert.ToSystem_String(ortoDatas as ISerializableObject) ?? string.Empty, "application/json");
//        }

//        [HttpPost("items")]
//        public async Task<IActionResult> GetAsync([FromBody] List<string>? references)
//        {
//            if (ortoDatasPostgreSQLConverter is null)
//            {
//                return StatusCode(500);
//            }

//            if (references == null || references.Count == 0)
//            {
//                return BadRequest();
//            }

//            HashSet<PartitionReference> partitionReferences = [];
//            foreach (string reference in references)
//            {
//                if (Create.PartitionReference(GIS.Create.GISModelAreal2DReference(reference)) is not PartitionReference partitionReference)
//                {
//                    continue;
//                }

//                partitionReferences.Add(partitionReference);
//            }

//            List<OrtoDatas>? ortoDatasList = await ortoDatasPostgreSQLConverter.GetSerializableObjectsAsync<OrtoDatas>(partitionReferences);

//            return Content(Core.Convert.ToSystem_String(ortoDatasList) ?? string.Empty, "application/json");
//        }

//        [HttpPost("update")]
//        public async Task<IActionResult> UpdateAsync([FromBody] JsonObject? jsonObject, [FromQuery(Name = "reference")] string? reference)
//        {
//            if (ortoDatasPostgreSQLConverter is null)
//            {
//                return StatusCode(500);
//            }

//            if (jsonObject is null)
//            {
//                return BadRequest();
//            }

//            if (string.IsNullOrEmpty(reference))
//            {
//                return BadRequest();
//            }

//            GISModelAreal2DReference? gISModelAreal2DReference = GIS.Create.GISModelAreal2DReference(reference);
//            if (gISModelAreal2DReference is null)
//            {
//                return BadRequest();
//            }

//            string? name = gISModelAreal2DReference.Areal2DReference ?? gISModelAreal2DReference.GISModelReference;
//            if (string.IsNullOrWhiteSpace(name))
//            {
//                return BadRequest();
//            }

//            OrtoDatas? ortoDatas = Core.Create.SerializableObject<OrtoDatas>(jsonObject);
//            if (ortoDatas is null)
//            {
//                return BadRequest();
//            }

//            ortoDatasPostgreSQLConverter.SetName(ortoDatas, name);

//            PartitionReference? partitionReference = await ortoDatasPostgreSQLConverter.UpdateAsync(ortoDatas);

//            return Ok(Create.GISModelAreal2DReference(partitionReference)?.ToString());
//        }
//    }
//}