namespace Easycom.Core.Interfaces
{
    using Easycom.Core.DTO;
    using Easycom.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAsync(int index, int size);
        Task<Student> GetByIdAsync(int id);
        Task<Student> AddAsync(StudentDTO entity);
        Task<Student> UpdateAsync(int id, StudentDTO entity);
        Task<bool?> DeleteAsync(int id);
    }
}
