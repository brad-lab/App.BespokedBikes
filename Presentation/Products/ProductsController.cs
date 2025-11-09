using App.BespokedBikes.Application.Products.Queries.GetProductById;
using App.BespokedBikes.Application.Products;
using App.BespokedBikes.Application.Products.Commands.CreateProduct;
using App.BespokedBikes.Application.Products.Commands.UpdateProduct;
using App.BespokedBikes.Application.Products.Queries.GetProductsList;
using App.BespokedBikes.Presentation.Products.Models;
using App.BespokedBikes.Presentation.Products.Services;
using App.BespokedBikes.Presentation.Sales.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.BespokedBikes.Presentation.Products
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IGetProductsListQuery _query;
        private readonly ICreateProductViewModelFactory _factory;
        private readonly ICreateProductCommand _createcommand;
        private readonly IProductValidator _productValidator;
        // new dependencies for edit
        private readonly IGetProductByIdQuery _getById;
        private readonly IUpdateProductCommand _updateCommand;
        private readonly IUpdateProductViewModelFactory _updateFactory;

        public ProductsController(IGetProductsListQuery query,
                                    ICreateProductViewModelFactory factory,
                                    ICreateProductCommand command,
                                    IProductValidator productValidator,
                                    IGetProductByIdQuery getProductByIdQuery,
                                    IUpdateProductCommand updateCommand,
                                    IUpdateProductViewModelFactory updateFactory)
        {
            _query = query;
            _factory = factory;
            _createcommand = command;
            _productValidator = productValidator;
            _getById = getProductByIdQuery;
            _updateCommand = updateCommand;
            _updateFactory = updateFactory;
        }
        [Route("index")]
        public ViewResult Index()
        {
            var products = _query.Execute();

            return View(products);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var model = viewModel.Product;

            // Application-layer validation to prevent duplicates and return user-friendly message
            var validation = await _productValidator.ValidateNoDuplicateAsync(model.Name, model.Manufacturer, model.Style);
            if (!validation.IsValid)
            {
                ModelState.AddModelError(string.Empty, validation.ErrorMessage);
                return View(viewModel);
            }

            _createcommand.Execute(model);

            return RedirectToAction("index", "products");
        }

        // GET: products/edit/{id}
        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(int id)
        {
            var productdto = _getById.Execute(id);
            if (productdto == null)
                return NotFound();

            var vm = _updateFactory.Create();

            // map fields from query model to presentation view model
            vm.Product.Id = productdto.Id;
            vm.Product.Name = productdto.Name;
            vm.Product.Manufacturer = productdto.Manufacturer;
            vm.Product.Style = productdto.Style;
            vm.Product.PurchasePrice = productdto.PurchasePrice;
            vm.Product.SalePrice = productdto.SalePrice;
            vm.Product.QuantityOnHand = productdto.QuantityOnHand;
            vm.Product.CommissionPercentage = productdto.CommissionPercentage;

            return View(vm);
        }

        // POST: products/edit
        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // optional: application-level duplicate check (adjust if validator needs current id excluded)
            var validation = await _productValidator.ValidateNoDuplicateAsync(viewModel.Product.Name, viewModel.Product.Manufacturer, viewModel.Product.Style);
            if (!validation.IsValid)
            {
                ModelState.AddModelError(string.Empty, validation.ErrorMessage);
                return View(viewModel);
            }

            // map presentation model to application command model
            var appModel = new UpdateProductModel
            {
                Id = viewModel.Product.Id,
                Name = viewModel.Product.Name,
                Manufacturer = viewModel.Product.Manufacturer,
                Style = viewModel.Product.Style,
                PurchasePrice = viewModel.Product.PurchasePrice,
                SalePrice = viewModel.Product.SalePrice,
                QuantityOnHand = viewModel.Product.QuantityOnHand,
                CommissionPercentage = viewModel.Product.CommissionPercentage
            };

            _updateCommand.Execute(appModel);

            return RedirectToAction("index", "products");
        }
    }
}