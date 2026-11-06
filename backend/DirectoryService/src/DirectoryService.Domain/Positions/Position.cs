using DirectoryService.Domain.Common;

namespace DirectoryService.Domain.Positions;

public class Position
{
    public Position(Guid id, string name)
    {
        Id = DomainRules.RequiredId(id, nameof(id));

        Name = DomainRules.RequiredText(name, nameof(name));
        
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }
    
    public Guid Id { get; }

    public string Name {get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }


    public void Rename(string name) {
        Name = DomainRules.RequiredText(name, nameof(name));
        UpdatedAt = DateTime.UtcNow;

    }
}
