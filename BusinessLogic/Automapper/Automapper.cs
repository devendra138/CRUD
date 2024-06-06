using AutoMapper;
using APICRUDOperations.Models;
using DataAccess.Models;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Employees, Employee>();
        CreateMap<Employee, Employees>();
    }
}
