using System.Text.RegularExpressions;

namespace DirectoryService.Domain.Common;

internal static class DomainRules
{
    public static Guid RequiredId(Guid value, string parameterName)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Id не должен быть пустым", parameterName);
        }

        return value;
    }

    public static string RequiredText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Значение не должно быть пустым", parameterName);
        }

        return value.Trim();
    }

    public static bool IsValidSlug(string value)
    {
        return !string.IsNullOrWhiteSpace(value)
            && Regex.IsMatch(
                value,
                @"\A[a-z0-9]+(?:-[a-z0-9]+)*\z",
                RegexOptions.NonBacktracking);
    }

    public static string RequiredSlug(string value, string parameterName)
    {
        if (!IsValidSlug(value))
        {
            throw new ArgumentException("Некорректный slug", parameterName);
        }

        return value;
    }

    public static string RequiredPath(
        string value,
        string slug,
        string? parentPath,
        string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Путь обязателен", parameterName);
        }

        if (value.Split('/').Any(segment => !IsValidSlug(segment)))
        {
            throw new ArgumentException(
                "Каждый сегмент пути должен быть корректным slug",
                parameterName);
        }

        var expectedPath = parentPath is null ? slug : $"{parentPath}/{slug}";

        if (!string.Equals(value, expectedPath, StringComparison.Ordinal))
        {
            throw new ArgumentException(
                "Путь не соответствует родителю и slug",
                parameterName);
        }

        return value;
    }
}
