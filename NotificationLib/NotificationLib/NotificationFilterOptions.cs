namespace NotificationLib;

public class NotificationFilterOptions
{
    public bool? IsRead { get; set; }
    public NotificationType[]? Types { get; set; }
    public string? SearchText { get; set; }
    public int? MinPriority { get; set; }
    public NotificationSortBy? SortBy { get; set; }
    public bool Descending { get; set; }
}