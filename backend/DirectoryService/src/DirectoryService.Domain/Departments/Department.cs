using DirectoryService.Domain.Common;

namespace DirectoryService.Domain.Departments;

public class Department {
    public Department(Guid id, string name, string slug, string path, Guid? parentId = null, Department? parent = null) {
        Id = DomainRules.RequiredId(id, nameof(id));

        Name = DomainRules.RequiredText(name, nameof(name));

        Slug = DomainRules.RequiredSlug(slug, nameof(slug));

        if (parentId is not null) {
            DomainRules.RequiredId(parentId.Value, nameof(parentId));
        }
        if (parentId == id) {
            throw new ArgumentException("Id родителя не должен совпадать с собственным Id", nameof(parentId));
        }

        if (parentId is null && parent is not null)
        {
            throw new ArgumentException("У корневого подразделения не должно быть родителя", nameof(parent));
        }

        if (parentId is not null)
        {
            ArgumentNullException.ThrowIfNull(parent);

            if (parent.Id != parentId)
            {
                throw new ArgumentException("Переданный родитель не соответствует parentId", nameof(parentId));
            }
        }

        Path = DomainRules.RequiredPath(path, Slug, parent?.Path, nameof(path));
        ParentId = parentId;

        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;

    }

    public Guid Id { get; }

    public string Name { get; private set; }

    public string Slug { get; }

    public string Path { get; }

    public Guid? ParentId { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set;}

    public void Rename(string name) {
        Name = DomainRules.RequiredText(name, nameof(name));
        UpdatedAt = DateTime.UtcNow;
    }

}
