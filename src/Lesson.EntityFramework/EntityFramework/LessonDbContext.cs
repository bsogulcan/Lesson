using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using Lesson.Authorization.Roles;
using Lesson.Authorization.Users;
using Lesson.Categories;
using Lesson.Classes;
using Lesson.Domain.Exams;
using Lesson.Domain.Homeworks;
using Lesson.Domain.LessonsOfClassRoom;
using Lesson.Domain.News;
using Lesson.Domain.RollCalls;
using Lesson.Domain.RollCallsDetail;
using Lesson.Domain.StudentOfClassRoom;
using Lesson.Domain.StudentsAnswerOfExam;
using Lesson.MultiTenancy;

namespace Lesson.EntityFramework
{
    public class LessonDbContext : AbpZeroDbContext<Tenant, Role, User>
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<ClassRoom> Classes { get; set; }
        public DbSet<StudentOfClassRoom> StudentsOfClassRoom { get; set; }
        public DbSet<Lesson.Domain.Lessons.Lesson> Lessons { get; set; }
        public DbSet<LessonOfClassRoom> LessonsOfClassRoom { get; set; }
        public DbSet<RollCall> RollCalls { get; set; }
        public DbSet<RollCallDetail> RollCallDetails { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Examination> Exams { get; set; }
        public DbSet<ExaminationQuestion> ExamQuestions { get; set; }
        public DbSet<ExaminationQuestionAnswer> ExamQuestionAnswers { get; set; }
        public DbSet<StudentsAnswerOfExam> StudentsAnswerOfExams { get; set; }
        public DbSet<News> News{ get; set; }

        public LessonDbContext()
            : base("Default")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in LessonDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of LessonDbContext since ABP automatically handles it.
         */
        public LessonDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public LessonDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public LessonDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);

            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<ClassRoom>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<ClassRoom>().Property(p => p.Branch).IsRequired().IsMaxLength();
            modelBuilder.Entity<ClassRoom>().Property(p => p.Description).IsMaxLength();


        }
    }
}
