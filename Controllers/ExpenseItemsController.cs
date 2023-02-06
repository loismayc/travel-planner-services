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
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());


        var item = new BuildExpenseItem(hash);

        ExpenseItem expenseItem = item.Execute();
        _expenseItemsService.Save(expenseItem);

        Dictionary<string, object> message = new Dictionary<string, object>();
        message.Add("message", "Ok");

        return Ok(message);

    }

    // curl http://localhost:5137/expense_items | jq
    [HttpGet("")] //routes to method below
    public IActionResult Index()
    {
        Dictionary<string, object> message = new Dictionary<string, object>();
        message.Add("expense_items", _expenseItemsService.GetAll());

        return Ok(message);
    }


    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        var item = _expenseItemsService.FindById(id);
        return Ok(item);
    }





}