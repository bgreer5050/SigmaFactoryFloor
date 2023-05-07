using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SigmaSight.Infrastructure.Enumerations;
using SigmaSight.Infrastructure.Interfaces;
using SigmaSight.Models.Shared;
using SigmaSight.Models.ViewModels;
using System.Net;
using System.Text.Json.Serialization;

namespace SigmaSight.Api.Controllers;

[Route("api/[controller]")]
public class ValuesController : BaseController
{
    private readonly ISQSService sqsService;

    public ValuesController(ISQSService sqsService, IEnvironmentService environmentService): base(environmentService)
    {
        this.sqsService = sqsService;
    }

    [HttpPost]
    [Route("AddMachineRuntimeEvent")]
    public ActionResult<ServiceResponse<string>> AddMachineRuntimeEvent([FromBody] AddMachineRuntimeEventViewModel viewModel)
    {
        var result = new ServiceResponse<string>();
        if(viewModel != null)
        {
            try
            {
                string messageId;
                var json = JsonConvert.SerializeObject(viewModel);
                if(sqsService.Send(SQSQueue.AddMachineRuntimeEvent, "0", json, out messageId))
                {
                    result.Data = "Queued";
                    result.Code = HttpStatusCode.OK;
                }
                else
                {
                    result.HasError = true;
                    result.Message = "Not Queued";
                    result.Code = HttpStatusCode.InternalServerError;
                }
            }
            catch (Exception ex)
            {
                result.Data =ex.Message;
                result.HasError = true;
                result.Message = ex.Message;
                result.Code = HttpStatusCode.InternalServerError;
            }
        }
        return StatusCode((int)result.Code, result);
    }

    // GET api/values
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    //// GET api/values/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/values
    //[HttpPost]
    //public void Post([FromBody]string value)
    //{
    //}

    //// PUT api/values/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody]string value)
    //{
    //}

    //// DELETE api/values/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}