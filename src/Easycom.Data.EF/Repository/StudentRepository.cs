using Easycom.Core.Entities;
using Easycom.Core.Interfaces.Repository;
using Easycom.Data.EF.Data;

namespace Easycom.Data.EF.Repository
{
    public class StudentRepository : EFRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppContext dbContext) : base(dbContext)
        {
        }
    }
}
