using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.searchType = "All";
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.searchType = searchType;
            ViewBag.searchTerm = searchTerm;
            List<Job> jobs;
            if (String.IsNullOrEmpty(searchTerm) || String.IsNullOrEmpty(searchType))
            {
                jobs = JobData.FindAll();
                ViewBag.title = "Invalid entry: Showing all jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Job results for '" + searchTerm + "' in category '" + searchType + "'";
            }

            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;

            return View("Index");
        }
    }
}
