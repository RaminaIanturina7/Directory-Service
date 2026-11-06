using DirectoryService.Domain.Common;
using DirectoryService.Domain.Positions;

namespace DirectoryService.Domain.Departments;

public class DepartmentPosition
{
    public DepartmentPosition(Guid id, Department department, Position position)
    {
        Id = DomainRules.RequiredId(id, nameof(id));
        
        ArgumentNullException.ThrowIfNull(department);
        ArgumentNullException.ThrowIfNull(position);
        DepartmentId = department.Id;
        PositionId = position.Id;
    }

    public Guid Id { get; }

    public Guid DepartmentId { get; }

    public Guid PositionId { get; }

}
