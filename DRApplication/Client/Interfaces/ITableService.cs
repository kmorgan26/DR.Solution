namespace DRApplication.Client.Interfaces
{
    public interface ITableService<TItem> where TItem : class
    {
        Task<IEnumerable<string>> GetHeaderNamesAsync(IEnumerable<TItem> items);

    }
}
