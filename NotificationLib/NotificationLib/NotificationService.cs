namespace NotificationLib;

public class NotificationService
{
    public IEnumerable<Notification> FilterAndSort(
        IEnumerable<Notification> notifications,
        NotificationFilterOptions options)
    {
        var result = notifications;

        if (options.IsRead != null)
        {
            result = result.Where(n => n.IsRead == options.IsRead);
        }

        if (options.Types != null && options.Types.Length > 0)
        {
            result = result.Where(n => options.Types.Contains(n.Type));
        }

        if (!string.IsNullOrEmpty(options.SearchText))
        {
            result = result.Where(n => n.Title.Contains(options.SearchText)
                || (n.Content != null && n.Content.Contains(options.SearchText)));
        }

        if (options.MinPriority != null)
        {
            result = result.Where(n => n.Priority >= options.MinPriority);
        }

        switch (options.SortBy)
        {
            case NotificationSortBy.Date:
                result = options.Descending ? result.OrderByDescending(n => n.CreatedAt) : result.OrderBy(n => n.CreatedAt);
                break;
            case NotificationSortBy.Priority:
                result = options.Descending ? result.OrderByDescending(n => n.Priority) : result.OrderBy(n => n.Priority);
                break;
            case NotificationSortBy.Title:
                result = options.Descending ? result.OrderByDescending(n => n.Title) : result.OrderBy(n => n.Title);
                break;
        }
        return result;
    }
}