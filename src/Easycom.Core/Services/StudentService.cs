namespace Easycom.Core.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Easycom.Core.DTO;
    using Easycom.Core.Entities;
    using Easycom.Core.Interfaces;
    using Easycom.Core.Interfaces.Repository;

    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public async Task<Student> AddAsync(StudentDTO dto)
        {
            var student = new Student(dto.Name, dto.LastName, dto.Phone, dto.Address, dto.City, dto.State, dto.Country);
            return await _repository.AddAsync(student);
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Student>> ListAsync(int index, int pagesize)
        {
            return await _repository.ListAsync(index, pagesize);
        }

        public async Task<Student> UpdateAsync(int id, StudentDTO dto)
        {
            var student = new Student(
                           dto.Name,
                           dto.LastName,
                           dto.Phone,
                           dto.Address,
                           dto.City,
                           dto.State,
                           dto.Country
                           )
            {
                ID = id
            };
            await _repository.UpdateAsync(id, student);
            return await GetByIdAsync(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return null;

            await _repository.DeleteAsync(student);
            return true;
        }
    }
}
