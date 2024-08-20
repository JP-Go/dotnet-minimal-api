namespace MinimalApi.Domain.Service;

using MinimalApi.Domain.Entity;
using MinimalApi.Dtos;
using MinimalApi.Infrastructure.Db;

public class AdministratorService : IAdministratorService
{

    private readonly MySqlDBContext _dbContext;

    public AdministratorService(MySqlDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Administrator? Login(LoginDTO loginDTO)
    {
        return _dbContext.Administrators
            .Where(adm => adm.Email == loginDTO.Email && adm.Password == loginDTO.Password)
            .FirstOrDefault();
    }
}
