using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using newWebAppA00272195.Models;

namespace newWebAppA00272195.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
       Todo record = new Todo();

      // Get list of InComplete and Completed Todos
       record.InCompleteTodoList = TodoItem.GetAll().Where(t => t.IsCompleted == false).ToList();
       record.CompletedTodoList = TodoItem.GetAll().Where(t => t.IsCompleted == true).ToList();

      return View(record);
    }


    [HttpPost]
    public ActionResult Create(string description)
    {
      // Initialize model constructor and create a new todo
      var myTodoItem = new TodoItem(description);
      return RedirectToAction("Index");
    }

    [HttpPost("/index/markascompleted")]
    public ActionResult MarkAsCompleted(int[] todoIds)
    {
      // call method that marks checked todo as completed
      TodoItem.MarkAsCompleted(todoIds);
      return RedirectToAction("Index");
    }

    [HttpPost("/index/delete")]
    public ActionResult DeleteAll()
    {
      // Bonus feature to Clear all todo item
      TodoItem.ClearAll();
      return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
