﻿using Abp.Application.Services;
using Lesson.Domain.Exams.Exam.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Exams.Exam
{
    public interface IExamApplicationService:IApplicationService
    {
        Task CreateAsync(CreateExamInput input);
        Task<List<ExaminationsFullOutPut>> GetListAsync();
        ExaminationsFullOutPut Get(GetExaminationInput input);
    }
}