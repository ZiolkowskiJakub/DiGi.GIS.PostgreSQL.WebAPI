//using DiGi.GIS.Classes;
//using DiGi.GIS.PostgreSQL.Classes;
//using DiGi.PostgreSQL.PartitionReference.Classes;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Compression;
//using System.Linq;
//using System.Net;
//using System.Text.Json.Nodes;
//using System.Threading.Tasks;

//namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
//{
//    [ApiController]
//    [Route("gis/[controller]")]
//    public class GISModelController : DiGi.WebAPI.Classes.WebAPIController
//    {
//        private readonly GISModelPostgreSQLConverter gISModelPostgreSQLConverter;

//        public GISModelController(GISModelPostgreSQLConverter gISModelPostgreSQLConverter)
//        {
//            this.gISModelPostgreSQLConverter = gISModelPostgreSQLConverter;
//        }

//        [HttpGet("item")]
//        public async Task<IActionResult> GetAsync([FromQuery(Name = "reference")] string? reference)
//        {
//            if (gISModelPostgreSQLConverter is null)
//            {
//                return StatusCode(500);
//            }

//            if (string.IsNullOrWhiteSpace(reference))
//            {
//                return BadRequest();
//            }

//            GISModel? gISModel = await gISModelPostgreSQLConverter.GetSerializableObjectAsync<GISModel>(Create.PartitionReference_GISModel(reference));

//            return Content(Core.Convert.ToSystem_String(gISModel) ?? string.Empty, "application/json");
//        }

//        [HttpPost("items")]
//        public async Task<IActionResult> GetAsync([FromBody] List<string>? references)
//        {
//            if (gISModelPostgreSQLConverter is null)
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
//                if (Create.PartitionReference_GISModel(reference) is not PartitionReference partitionReference)
//                {
//                    continue;
//                }

//                partitionReferences.Add(partitionReference);
//            }

//            List<GISModel>? gISModels = await gISModelPostgreSQLConverter.GetSerializableObjectsAsync<GISModel>(partitionReferences);

//            return Content(Core.Convert.ToSystem_String(gISModels) ?? string.Empty, "application/json");
//        }

//        [HttpPost("references")]
//        public async Task<IActionResult> GetReferencesAsync([FromBody] List<string>? references, [FromQuery(Name = "type")] Enums.Type? type)
//        {
//            if (type is null)
//            {
//                return BadRequest();
//            }

//            switch (type.Value)
//            {
//                case Enums.Type.Building2D:
//                    return await GetReferencesAsync_Building2D(references);

//                case Enums.Type.OrtoDatas:
//                    return await GetReferencesAsync_OrtoDatas(references);

//                case Enums.Type.GISModel:
//                    return await GetReferencesAsync_GISModel();

//                default:
//                    break;
//            }

//            return BadRequest();
//        }

//        [HttpPost("update")]
//        public async Task<IActionResult> UpdateAsync([FromBody] JsonObject? jsonObject, [FromQuery(Name = "reference")] string? reference)
//        {
//            if (gISModelPostgreSQLConverter is null)
//            {
//                return StatusCode(500);
//            }

//            string tranceIdentifier = HttpContext.TraceIdentifier;
//            if (string.IsNullOrWhiteSpace(tranceIdentifier))
//            {
//                return BadRequest();
//            }

//            IPAddress? iPAddress = HttpContext.Connection.RemoteIpAddress;
//            string? address = iPAddress?.ToString();
//            if (string.IsNullOrWhiteSpace(address))
//            {
//                return BadRequest();
//            }

//            string? fullTypeName = Core.Query.FullTypeName(jsonObject);
//            if (string.IsNullOrWhiteSpace(fullTypeName))
//            {
//                return BadRequest();
//            }

//            Type? type = Core.Query.Type(fullTypeName, true);
//            if (type is null)
//            {
//                return BadRequest();
//            }

//            if (type.IsAssignableFrom(typeof(GISModel)))
//            {
//                GISModel? gISModel = null;

//                try
//                {
//                    gISModel = Core.Create.SerializableObject<GISModel>(jsonObject);
//                }
//                catch
//                {
//                }

//                if (gISModel is null)
//                {
//                    return BadRequest();
//                }

//                return await UpdateAsync(gISModel);
//            }

//            if (type.IsAssignableFrom(typeof(OrtoDatas)))
//            {
//                if (string.IsNullOrWhiteSpace(reference))
//                {
//                    return BadRequest();
//                }

//                OrtoDatas? ortoDatas = null;

//                try
//                {
//                    ortoDatas = Core.Create.SerializableObject<OrtoDatas>(jsonObject);
//                }
//                catch
//                {
//                }

//                if (ortoDatas is null)
//                {
//                    return BadRequest();
//                }

//                return await UpdateAsync(ortoDatas, reference);
//            }

//            return BadRequest();
//        }

//        [HttpPost("upload")]
//        [RequestSizeLimit(200 * 1024 * 1024)]
//        public async Task<IActionResult> UploadAsync(IFormFile gISModelFile)
//        {
//            if (gISModelPostgreSQLConverter is null)
//            {
//                return StatusCode(500);
//            }

//            string tranceIdentifier = HttpContext.TraceIdentifier;
//            if (string.IsNullOrWhiteSpace(tranceIdentifier))
//            {
//                return BadRequest();
//            }

//            IPAddress? iPAddress = HttpContext.Connection.RemoteIpAddress;
//            string? address = iPAddress?.ToString();
//            if (string.IsNullOrWhiteSpace(address))
//            {
//                return BadRequest();
//            }

//            using (Stream zipStream = gISModelFile.OpenReadStream())
//            {
//                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
//                {
//                }
//            }

//            return Ok();
//        }

//        private async Task<IActionResult> GetReferencesAsync_Building2D(IEnumerable<string>? references)
//        {
//            if (references is null || !references.Any())
//            {
//                return BadRequest();
//            }

//            return Ok();
//        }

//        private async Task<IActionResult> GetReferencesAsync_GISModel()
//        {
//            return Ok();
//        }

//        private async Task<IActionResult> GetReferencesAsync_OrtoDatas(IEnumerable<string>? references)
//        {
//            if (references is null || !references.Any())
//            {
//                return BadRequest();
//            }

//            return Ok();
//        }

//        private async Task<IActionResult> UpdateAsync(GISModel? gISModel)
//        {
//            if (gISModel is null)
//            {
//                return BadRequest();
//            }

//            PartitionReference? partitionReference = await gISModelPostgreSQLConverter.UpdateAsync(gISModel);

//            return Ok(partitionReference?.UniqueId);
//        }

//        private async Task<IActionResult> UpdateAsync(OrtoDatas? ortoDatas, string? reference)
//        {
//            if (ortoDatas is null || string.IsNullOrWhiteSpace(reference))
//            {
//                return BadRequest();
//            }

//            return Ok();
//        }
//    }
//}