using DirectoryService.Domain.Common;

namespace DirectoryService.Domain.Locations;

public class Location {
    public Location(Guid id, string name, string address) {

        Id = DomainRules.RequiredId(id, nameof(id));

        Name = DomainRules.RequiredText(name, nameof(name));

        Address = DomainRules.RequiredText(address, nameof(address));

        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;

    }

    public Guid Id { get; }

    public string Name { get; private set;}

    public string Address { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    public void Rename(string name) {
        Name = DomainRules.RequiredText(name, nameof(name));
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeAddress(string address) {
        Address = DomainRules.RequiredText(address, nameof(address));
        UpdatedAt = DateTime.UtcNow;
    }
}
