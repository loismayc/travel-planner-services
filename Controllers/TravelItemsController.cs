namespace TravelPlannerServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TravelPlannerServices.Models;
using TravelPlannerServices.Interfaces;


[ApiController]
[Route("travel_items")]
public class TravelItemsController : ControllerBase
{
    private List<Item> travelItems = new List<Item>();
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

        int id = int.Parse(hash["id"].ToString());
        string location = hash["location"].ToString();
        string date = hash["date"].ToString();
        string user = hash["user"].ToString();

        Item travelItem = new Item { Id = id, Location = location, Date = date, User = user };
        _travelItemsService.Save(travelItem);

        Dictionary<string, object> message = new Dictionary<string, object>();
        message.Add("message", "Ok");

        return Ok(message);
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