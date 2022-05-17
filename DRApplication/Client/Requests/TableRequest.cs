using MudBlazor;

namespace DRApplication.Client.Requests
{
    public class TableRequest<TEntity> where TEntity : class
    {
        /// <summary>
        /// This will the the part of the Route that is unique to the table
        /// Example: device/edit or device/details
        /// </summary>
        public string? UrlSegment { get; set; }
        
        /// <summary>
        /// An optional value to override the default icon assigned
        /// </summary>
        public string? Icon { get; set; }

        public IEnumerable<TEntity>? Data { get; set; }

    }
}