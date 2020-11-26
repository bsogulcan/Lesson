using AutoMapper;
using Lesson.Classes;
using Lesson.Classes.Dto;
using Lesson.Domain.Classes.Dto;
using Lesson.Domain.ClassRooms.Dto;
using Lesson.Domain.Exams;
using Lesson.Domain.Exams.Exam.Dto;
using Lesson.Domain.Homeworks;
using Lesson.Domain.Homeworks.Dto;
using Lesson.Domain.Lessons.Dto;
using Lesson.Domain.LessonsOfClassRoom;
using Lesson.Domain.LessonsOfClassRoom.Dto;
using Lesson.Domain.News;
using Lesson.Domain.News.Dto;
using Lesson.Domain.RollCallDetails.Dto;
using Lesson.Domain.RollCalls;
using Lesson.Domain.RollCalls.Dto;
using Lesson.Domain.RollCallsDetail;
using Lesson.Domain.StudentOfClassRoom;
using Lesson.Domain.StudentsAnswerOfExam;
using Lesson.Domain.StudentsAnswersOfExam.Dto;
using Lesson.Domain.StudentsOfClassRoom.Dto;
using Lesson.Domain.SubmittedHomeworks;
using Lesson.Domain.SubmittedHomeworks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Manager
{
    public class MapperManager
    {
        public static void DtosToDomain(IMapperConfigurationExpression cfg)
        {
            // ClassRoom
            cfg.CreateMap<ClassRoom, CreateClassRoomInput>();
            cfg.CreateMap<ClassRoom, DeleteClassRoomInput>();
            cfg.CreateMap<ClassRoom, EditClassRoomInput>();
            cfg.CreateMap<ClassRoom, GetClassRoomInput>();
            cfg.CreateMap<ClassRoom, ClassRoomFullOutPut>();
            cfg.CreateMap<ClassRoom, ClassRoomPartOutPut>();

            // StudentOfClassRoom
            cfg.CreateMap<StudentOfClassRoom, CreateStudentOfClassRoomInput>();
            cfg.CreateMap<StudentOfClassRoom, UpdateStudentOfClassRoomInput>();
            cfg.CreateMap<StudentOfClassRoom, DeleteStudentOfClassRoomInput>();
            cfg.CreateMap<StudentOfClassRoom, GetStudentsOfClassRoomInput>();
            cfg.CreateMap<StudentOfClassRoom, StudentsOfClassRoomFullOutPut>();
            cfg.CreateMap<StudentOfClassRoom, LessonOfClassRoomFullOutPut>();
            
            // Lesson
            cfg.CreateMap<Lesson.Domain.Lessons.Lesson, CreateLessonInput>();
            cfg.CreateMap<Lesson.Domain.Lessons.Lesson, UpdateLessonInput>();
            cfg.CreateMap<Lesson.Domain.Lessons.Lesson, DeleteLessonInput>();
            cfg.CreateMap<Lesson.Domain.Lessons.Lesson, GetLessonInput>();
            cfg.CreateMap<Lesson.Domain.Lessons.Lesson, LessonFullOutPut>();

            // LessonOfClassRoom
            cfg.CreateMap<LessonOfClassRoom, CreateLessonOfClassRoomInput>();
            cfg.CreateMap<LessonOfClassRoom, UpdateLessonsOfClassRoomInput>();
            cfg.CreateMap<LessonOfClassRoom, DeleteLessonOfClassRoomInput>();
            cfg.CreateMap<LessonOfClassRoom, GetLessonOfClassRoomInput>();
            cfg.CreateMap<LessonOfClassRoom, LessonOfClassRoomFullOutPut>();
            cfg.CreateMap<LessonOfClassRoom, LessonFullOutPut>();

            // RollCall
            cfg.CreateMap<RollCall, CreateRollCallInput>();
            cfg.CreateMap<RollCall, DeleteRollCallInput>();
            cfg.CreateMap<RollCall, GetRollCallInput>();
            cfg.CreateMap<RollCall, UpdateRollCallInput>();
            cfg.CreateMap<RollCall, RollCallFullOutPut>();

            // RollCallDetail
            cfg.CreateMap<RollCallDetail, CreateRollCallDetailInput>();
            cfg.CreateMap<RollCallDetail, DeleteRollCallDetailInput>();
            cfg.CreateMap<RollCallDetail, GetRollCallDetailInput>();
            cfg.CreateMap<RollCallDetail, UpdateRollCallDetailInput>();
            cfg.CreateMap<RollCallDetail, RollCallDetailFullOutPut>();

            // Homework
            cfg.CreateMap<Homework, CreateHomeworkInput>();
            cfg.CreateMap<Homework, UpdateHomeworkInput>();
            cfg.CreateMap<Homework, DeleteHomeworkInput>();
            cfg.CreateMap<Homework, GetHomeworkInput>();
            cfg.CreateMap<Homework, HomeworkFullOutPut>();
            
            // Exam
            cfg.CreateMap<Examination, ExaminationsFullOutPut>(); 
            
            // StudentsAnswerOfExam
            cfg.CreateMap<StudentsAnswerOfExam, StudentsAnswerOfExamFullOutPut>(); 
            
            // News
            cfg.CreateMap<News, NewsFullOutPut>();  
            
            // SubmittedHomework
            cfg.CreateMap<SubmittedHomeworks, SubmittedHomeworksFullOutPut>(); 

        } 
    }
}
