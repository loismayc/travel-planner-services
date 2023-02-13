namespace TravelPlannerServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TravelPlannerServices.Models;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Commands;

[ApiController]
[Route("expense_items")]
public class ExpenseItemsController : ControllerBase
{
    private readonly IExpenseItemsServices _expenseItemsService;


    public ExpenseItemsController(IExpenseItemsServices expenseItemsService)
    {
        _expenseItemsService = expenseItemsService;

    }

    //curl -X POST -H "Content-Type: application/json" -d @payloads/expenseItem.json http://localhost:5137/expense_items | jq
    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        try
        {
            Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());
            ValidateSaveExpenseItems validator = new ValidateSaveExpenseItems(hash);
            validator.Execute();

            if (validator.HasErrors())
            {
                return UnprocessableEntity(validator.Errors);
            }
            else
            {

                var item = new BuildExpenseItem(hash);

                ExpenseItem expenseItem = item.Execute();
                _expenseItemsService.Save(expenseItem);

                return Ok(expenseItem);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error saving items");

        }

    }

    [HttpPut("{id}")]
    public IActionResult Update([FromBody] object payload)
    {
        try
        {
            Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());
            ValidateSaveExpenseItems validator = new ValidateSaveExpenseItems(hash);
            validator.Execute();

            if (validator.HasErrors())
            {
                return UnprocessableEntity(validator.Errors);
            }
            else
            {

                var item = new BuildExpenseItem(hash);

                ExpenseItem expenseItem = item.Execute();
                _expenseItemsService.Save(expenseItem);

                return Ok(expenseItem);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error saving items");

        }
    }

    // curl http://localhost:5137/expense_items | jq
    [HttpGet("")] //routes to method below
    public IActionResult Index()
    {
        try
        {
            List<ExpenseItem> expenseItems = _expenseItemsService.GetAll();
            return Ok(expenseItems);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error getting items");

        }


    }


    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        try
        {
            var item = _expenseItemsService.FindById(id);
            return Ok(item);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error displaying item");

        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _expenseItemsService.Delete(id);
            var result = new { Message = "Item deleted from backend" };
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting item");

        }
    }

}