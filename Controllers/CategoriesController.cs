namespace TravelPlannerServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TravelPlannerServices.Models;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Commands;

[ApiController]
[Route("categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;


    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;

    }

    //curl -X POST -H "Content-Type: application/json" -d @payloads/expenseItem.json http://localhost:5137/expense_items | jq
    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveCategories validator = new ValidateSaveCategories(hash);
        validator.Execute();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {

            var item = new BuildCategories(hash);

            Category categories = item.Execute();
            _categoryService.Save(categories);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Ok");

            return Ok(message);
        }


    }

    // curl http://localhost:5137/expense_items | jq
    [HttpGet("")] //routes to method below
    public IActionResult Index()
    {

        List<Category> categories = _categoryService.GetAll();
        return Ok(categories);
    }


    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        var item = _categoryService.FindById(id);
        return Ok(item);
    }





}