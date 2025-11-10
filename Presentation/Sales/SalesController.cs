using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.BespokedBikes.Application.Sales.Commands.CreateSale;
using App.BespokedBikes.Application.Sales.Queries.GetSaleDetail;
using App.BespokedBikes.Application.Sales.Queries.GetSalesList;
using App.BespokedBikes.Application.Sales.Queries.GetCommissionBySalesperson;
using App.BespokedBikes.Presentation.Sales.Models;
using App.BespokedBikes.Presentation.Sales.Services;

namespace App.BespokedBikes.Presentation.Sales
{
    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly IGetSalesListQuery _salesListQuery;
        private readonly IGetSaleDetailQuery _saleDetailQuery;
        private readonly ICreateSaleViewModelFactory _factory;
        private readonly ICreateSaleCommand _createCommand;
        private readonly IGetCommissionBySalespersonQuery _commissionQuery;

        public SalesController(
            IGetSalesListQuery salesListQuery,
            IGetSaleDetailQuery saleDetailQuery,
            ICreateSaleViewModelFactory factory,
            ICreateSaleCommand createCommand,
            IGetCommissionBySalespersonQuery commissionQuery)
        {
            _salesListQuery = salesListQuery;
            _saleDetailQuery = saleDetailQuery;
            _factory = factory;
            _createCommand = createCommand;
            _commissionQuery = commissionQuery;
        }

        // GET /sales?startDate=2025-01-01&endDate=2025-02-01
        [Route("")]
        public ViewResult Index(DateTime? startDate, DateTime? endDate)
        {
            var sales = _salesListQuery.Execute(startDate, endDate);

            // preserve filter values so view can repopulate the form
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            return View(sales);
        }

        [Route("report")]
        public ViewResult CommissionReport(int quarter = 1, int? year = null)
        {
            var y = year ?? DateTime.Today.Year;
            quarter = Math.Clamp(quarter, 1, 4);

            var report = _commissionQuery.Execute(quarter, y);

            ViewBag.SelectedQuarter = quarter;
            ViewBag.SelectedYear = y;

            return View(report);
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var sale = _saleDetailQuery.Execute(id);

            return View(sale);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(CreateSaleViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var model = viewModel.Sale;

            _createCommand.Execute(model);

            return RedirectToAction("index", "sales");
        }
    }
}