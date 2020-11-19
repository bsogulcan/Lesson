using Abp.Authorization;
using Lesson.Categories;
using Lesson.Categories.Dto;
using Lesson.Roles;
using Lesson.Web.Models.Categories;
using Lesson.Web.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lesson.Web.Controllers
{
    public class CategoriesController : LessonControllerBase
    {
        // GET: Categories
        private readonly CategoryAppService _categoryAppService;
        private readonly IPermissionChecker _permissionChecker;

        public CategoriesController(CategoryAppService categoryAppService,IPermissionChecker permissionChecker)
        {
            _categoryAppService = categoryAppService;
            _permissionChecker= permissionChecker;
            
        }

        public ActionResult Index()
        {
            //_categoryAppService.CreateCategory(new CategoryInput { Name="Test"});
            CategoryList categoryList = new CategoryList();
            categoryList.Categories = _categoryAppService.GetAllList();
            categoryList._permissionChecker = _permissionChecker;
            return View(categoryList);
        }
        public ActionResult EditModal(int roleId)
        {
            var role = _categoryAppService.GetCategoryById(roleId);
            var model = new EditCategoryModalViewModel
            {
                Id = role.Id,
                Name=role.Name
            };
            return View("_EditModal", model);
        }

    }
}