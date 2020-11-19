using Lesson.Categories;
using Lesson.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson.Web.Models.Categories
{
    public class CategoryList:Category
    {
        public List<Lesson.Categories.Category> Categories { get; set; }
        public Abp.Authorization.IPermissionChecker _permissionChecker { get; set; }
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
        public string HasPermission(string permissionName)
        {
            return _permissionChecker.IsGranted(permissionName)?string.Empty: "display:none;";
        }
        public string HasPermissionAny()
        {
            if (_permissionChecker.IsGranted(Lesson.Authorization.PermissionNames.Category_UpdateCategory))
            {
                return string.Empty;
            }
            else if (_permissionChecker.IsGranted(Lesson.Authorization.PermissionNames.Category_DeleteCategory))
            {
                return string.Empty;

            }
            else 
            {
                return "display:none;";
            }
        }
    }
}