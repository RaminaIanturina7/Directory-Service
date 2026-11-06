using DirectoryService.Domain.Common;
using DirectoryService.Domain.Locations;

namespace DirectoryService.Domain.Departments;

public class DepartmentLocation
{
    public DepartmentLocation(Guid id, Department department, Location location, bool isPrimary = true)
    {
        Id = DomainRules.RequiredId(id, nameof(id));

        ArgumentNullException.ThrowIfNull(department);
        ArgumentNullException.ThrowIfNull(location);
        DepartmentId = department.Id;
        LocationId = location.Id;
        
        IsPrimary = isPrimary;

    }

    public Guid Id { get; }

    public Guid DepartmentId { get; }

    public Guid LocationId { get; }

    public bool IsPrimary { get; private set; }

    public void SetPrimary(bool isPrimary)
    {
        IsPrimary = isPrimary;
    }
}
