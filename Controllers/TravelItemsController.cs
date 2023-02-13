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
        try
        {
            Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

            ValidateSaveTravelItems validator = new ValidateSaveTravelItems(hash, _travelItemsService);
            validator.Execute();

            if (validator.HasErrors())
            {
                return UnprocessableEntity(validator.Errors);
            }
            else
            {

                var item = new BuildTravelItem(hash);

                TravelItem travelItem = item.Execute();
                _travelItemsService.Save(travelItem);
                return Ok(travelItem);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error saving items");

        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] object payload)
    {
        try
        {
            Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

            ValidateSaveTravelItems validator = new ValidateSaveTravelItems(hash, _travelItemsService);
            validator.Execute();

            if (validator.HasErrors())
            {
                return UnprocessableEntity(validator.Errors);
            }
            else
            {

                var item = new BuildTravelItem(hash);

                TravelItem travelItem = item.Execute();
                _travelItemsService.Save(travelItem);
                return Ok(travelItem);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error saving items");

        }
    }


    // curl http://localhost:5137/travel_items | jq
    [HttpGet("")] //routes to method below
    public IActionResult Index()
    {
        try
        {
            List<TravelItem> travelItems = _travelItemsService.GetAll();
            return Ok(travelItems);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error getting travel items");

        }

    }


    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        try
        {
            var item = _travelItemsService.FindById(id);
            return Ok(item);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error showing item");

        }

    }

    // command: curl -X DELETE http://localhost:5137/travel_items/{}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _travelItemsService.Delete(id);
            var result = new { Message = "Item deleted from backend" };
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting item");

        }



    }
}