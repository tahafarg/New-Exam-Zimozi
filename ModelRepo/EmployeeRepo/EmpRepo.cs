using Microsoft.EntityFrameworkCore;
using model;
using ModelRepo.Context;
using ModelRepo.GenralRepo;

namespace ModelRepo.EmployeeRepo
{
    public class EmpRepo : GenralRepo<Employee>, IEmpRepo
    {
        private readonly AppDbContext context;

        public EmpRepo(AppDbContext dContext) : base(dContext)
        {
            this.context = dContext;
        }

    }
}
