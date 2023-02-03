namespace TravelPlannerServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TravelPlannerServices.Models;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Commands;

[ApiController]
[Route("travel_items")]
public class TravelItemsController : ControllerBase
{
    private readonly ITravelItemsService _travelItemsService;

    public TravelItemsController(ITravelItemsService travelItemsService)
    {
        _travelItemsService = travelItemsService;

    }

    //curl -X POST -H "Content-Type: application/json" -d @payloads/travelItem.json http://localhost:5137/travel_items | jq
    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveTravelItems validator = new ValidateSaveTravelItems(hash);
        validator.Execute();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {

            var item = new BuildTravelItem(hash);

            Item travelItem = item.Execute();
            _travelItemsService.Save(travelItem);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Ok");

            return Ok(message);
        }
    }

    // curl http://localhost:5137/travel_items | jq
    [HttpGet("")] //routes to method below
    public IActionResult Index()
    {
        Dictionary<string, object> message = new Dictionary<string, object>();
        message.Add("travel_items", _travelItemsService.GetAll());

        return Ok(message);
    }


    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        var item = _travelItemsService.FindById(id);
        return Ok(item);
    }

    // command: curl -X DELETE http://localhost:5137/travel_items/{}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _travelItemsService.Delete(id);
        return Ok("Item deleted");
    }



}