using TestNinja.Mocking;

namespace PrimeService.mocking
{
    public interface IEmployeeStorage
    {
        void DeleteEmployee(int id);
    }

    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _db;

        public EmployeeStorage(EmployeeContext db)
        {
            _db = db;
        }
        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if(employee == null) return;

            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}