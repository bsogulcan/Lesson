using Abp.Application.Services;
using Lesson.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        void CreateCategory(CategoryInput input);
        List<Category> GetAllList();
        void Delete(int id);
        Category GetCategoryById(int id);
        void Update(Category category);
    }
}
