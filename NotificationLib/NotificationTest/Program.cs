using NotificationLib;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var service = new NotificationService();

var list = new List<Notification>
{
    new Notification { Id = 1, Title = "qwerty", Content = "тест 123", Type = NotificationType.System, CreatedAt = new DateTime(2026, 11, 1), Priority = 2, IsRead = true },
    new Notification { Id = 2, Title = "zzz", Content = "ололо", Type = NotificationType.Error, CreatedAt = new DateTime(2026, 11, 3), Priority = 5, IsRead = false },
    new Notification { Id = 3, Title = "привет", Content = null, Type = NotificationType.Info, CreatedAt = new DateTime(2026, 11, 2), Priority = 1, IsRead = false },
    new Notification { Id = 4, Title = "abc", Content = "бла бла бла", Type = NotificationType.Warning, CreatedAt = new DateTime(2026, 11, 4), Priority = 4, IsRead = false },
    new Notification { Id = 5, Title = "123", Content = "тест", Type = NotificationType.Info, CreatedAt = new DateTime(2026, 10, 30), Priority = 0, IsRead = true }
};

Print("1. Без фильтров", service.FilterAndSort(list, new NotificationFilterOptions()));

Print("2. Только непрочитанные", service.FilterAndSort(list, new NotificationFilterOptions { IsRead = false }));

Print("3. Типы Error и Warning", service.FilterAndSort(list, new NotificationFilterOptions {Types = new NotificationType[] { NotificationType.Error, NotificationType.Warning }}));

Print("4. Поиск 'сервер'", service.FilterAndSort(list, new NotificationFilterOptions { SearchText = "сервер" }));

Print("5. Приоритет >= 3, по убыванию приоритета", service.FilterAndSort(list, new NotificationFilterOptions
{
    MinPriority = 3,
    SortBy = NotificationSortBy.Priority,
    Descending = true
}));

Print("6. Сортировка по названию", service.FilterAndSort(list, new NotificationFilterOptions{SortBy = NotificationSortBy.Title}));

Print("7. Сортировка по дате, сначала новые", service.FilterAndSort(list, new NotificationFilterOptions{SortBy = NotificationSortBy.Date,Descending = true}));

Print("8. Непрочитанные, приоритет >= 2, cортировка по дате", service.FilterAndSort(list, new NotificationFilterOptions
{IsRead = false, MinPriority = 2, SortBy = NotificationSortBy.Date}));

Console.WriteLine("Тест завершён");

static void Print(string title, IEnumerable<Notification> items)
{
    Console.WriteLine(title+ ":");
    foreach (var n in items)
    {
        Console.WriteLine($"{n.Id} | {n.Title} | {n.Type} | приоритет: {n.Priority} | {n.CreatedAt:dd.MM.yyyy} | прочитано: {n.IsRead}");
    }
    Console.WriteLine();
}