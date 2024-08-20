using MinimalApi.Domain.Entity;
using MinimalApi.Dtos;

namespace MinimalApi.Domain.Service;


public interface IAdministratorService
{

    Administrator? Login(LoginDTO loginDTO);
}
