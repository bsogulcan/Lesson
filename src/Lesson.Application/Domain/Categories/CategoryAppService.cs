using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Categories.Dto
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //[Abp.Authorization.AbpAuthorize(Lesson.Authorization.PermissionNames.Category_AddCategory)]
        public void CreateCategory(CategoryInput input)
        {
            var category = _categoryRepository.FirstOrDefault(p => p.Name == input.Name);

            if (category != null)
            {
                throw new UserFriendlyException("There is already a category as same name");
            }

            category = new Category { Name = input.Name };
            _categoryRepository.Insert(category);
        }

        //[Abp.Authorization.AbpAuthorize(Lesson.Authorization.PermissionNames.Category_DeleteCategory)]
        public void Delete(int id)
        {
            var category = _categoryRepository.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                throw new UserFriendlyException("There is no availeble category");
            }
            else
            {
                _categoryRepository.Delete(category);
            }
        }

        //[Abp.Authorization.AbpAuthorize(Lesson.Authorization.PermissionNames.Category_Categories)]
        public List<Category> GetAllList()
        {
            return _categoryRepository.GetAllList();
        }

        //[Abp.Authorization.AbpAuthorize(Lesson.Authorization.PermissionNames.Category_AddCategory)]
        public Category GetCategoryById(int id)
        {
            var category = _categoryRepository.Get(id);
            if (category==null)
            {
                throw new UserFriendlyException("There is no availeble category");
            }
            else
            {
                return category;
            }
        }

        //[Abp.Authorization.AbpAuthorize(Lesson.Authorization.PermissionNames.Category_UpdateCategory)]
        public void Update(Category category)
        {
            var _category = _categoryRepository.FirstOrDefault(x=>x.Id== category.Id);
            if (category == null)
            {
                throw new UserFriendlyException("There is no availeble category");
            }
            else
            {
                _category.Name = category.Name;
            }
        }
    }
}
