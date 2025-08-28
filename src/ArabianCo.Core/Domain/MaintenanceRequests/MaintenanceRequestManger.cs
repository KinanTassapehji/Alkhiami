using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Domain.Entities;

namespace ArabianCo.Domain.MaintenanceRequests;

internal class MaintenanceRequestManger : DomainService, IMaintenanceRequestsManger
{
    private readonly IRepository<MaintenanceRequest> _repository;

    public MaintenanceRequestManger(IRepository<MaintenanceRequest> repository)
    {
        _repository = repository;
    }

    public async Task<MaintenanceRequest> GetEntityByIdAsync(int id)
    {
        var entity = await _repository.GetAll().Where(x=>x.Id==id)
            .Include(x=>x.Brand)
            .Include(x=>x.Category)
            .Include(x=>x.Address).ThenInclude(a=>a.City).ThenInclude(c=>c.Translations)
            .Include(x=>x.Address).ThenInclude(a=>a.City).ThenInclude(c=>c.Country).ThenInclude(c=>c.Translations).FirstOrDefaultAsync();
        if (entity == null)
            throw new EntityNotFoundException(typeof(MaintenanceRequest), id);
        return entity;
    }

    public async Task InsertAsync(MaintenanceRequest maintenanceRequest)
    {
        await _repository.InsertAsync(maintenanceRequest);
    }
}
