using CompanyG02.BLL.Interfaces;
using CompanyG02.DAL.Contexts;
using System.Threading.Tasks;

namespace CompanyG02.BLL.Repositories
{
    public class UnitOfWok : IUnitOfWok
    {
        private readonly CompanyDbContext dbContext;

        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public IMyServiceRepository MyServiceRepository { get; set; }

        public UnitOfWok(CompanyDbContext dbContext)
        {
            EmployeeRepository = new EmployeeRepository(dbContext);
            DepartmentRepository = new DepartmentRepository(dbContext);
            ProjectRepository = new ProjectRepository(dbContext);
            MyServiceRepository = new MyServiceRepository(dbContext);

            this.dbContext = dbContext;
        }

        public async Task<int> Compelete()
       => await dbContext.SaveChangesAsync();

        public void Dispose()
              => dbContext.Dispose();

    }
}
