using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;

namespace PianoStoreProject.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private IProductRepository _product { get; set; }
        public ProductController(IProductRepository product)
        {
            _product = product;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductListing()
        {
            return PartialView("_ProductListing", _product.GetAllProducts());
        }

        public IActionResult Add()
        {
            ViewBag.PageTitle = "Add a new product";
            ViewBag.PageTagLine = "You can add a new product by completing the following steps.";
            return View(_product.InitProduct());
        }

        public IActionResult Edit(int Id)
        {
            ViewBag.PageTitle = "Update product";
            ViewBag.PageTagLine = "You can update a product by completing the following steps.";
            return View("Add", _product.EditProduct(Id));
        }

        [HttpPost]
        public IActionResult AddOrUpdateProduct(ProductViewModel dto)
        {
            try
            {
                if (dto.Id != 0)
                {
                    int _id = _product.UpdateProduct(dto);
                    return Json(new { key = true, value = "Product updated successfully", id = _id });
                }
                else
                {
                    int _id = _product.AddProduct(dto);
                    return Json(new { key = true, value = "Product added Successfully", id = _id });
                }
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin." });
            }
        }

        [HttpPost]
        public IActionResult DeleteProduct(int Id)
        {
            try
            {
                bool result = _product.DeleteProduct(Id);
                if (result)
                {
                    return Json(new { key = true, value = "Product deleted successfully" });
                }
                else
                {
                    return Json(new { key = false, value = "Unable to find Product Record or Product already deleted" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }
        }

        [HttpGet]
        public ActionResult UploadProductImages(int ProductId)
        {
            ProductPhotosViewModel dto = new ProductPhotosViewModel()
            {
                ProductId = ProductId
            };
            return PartialView("_UploadProductImages", dto);
        }

        [HttpPost]
        public ActionResult AddProductImages(ProductPhotosViewModel Images)
        {
            try
            {
                _product.AddImage(Images);
                return Json(new { key = true, value = "Product Images added successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }
        }

        public IActionResult Photos(int productId)
        {
            return PartialView(_product.ProductPhotoListing(productId));
        }

        [HttpPost]
        public IActionResult DeleteProductImage(int Id)
        {
            try
            {
                bool result = _product.DeleteProductImage(Id);
                if (result)
                {
                    return Json(new { key = true, value = "Product Image deleted successfully" });
                }
                else
                {
                    return Json(new { key = false, value = "Unable to find Product Image Record or Product Image already deleted" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }
        }


        #region Product Detail
        [AllowAnonymous]
        public IActionResult Detail(int Id)
        {
            return View(_product.GetItemDetails(Id));
        }
        #endregion
    }
}
