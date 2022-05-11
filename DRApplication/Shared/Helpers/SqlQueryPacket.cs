using Dapper;

namespace DRApplication.Shared.Responses
{
    public  class SqlQueryPacket
    {
        /// <summary>
        /// The SQL Query that will be executed
        /// </summary>
        public string? SqlQuery { get; set; }
        /// <summary>
        /// The Dynamic Parameters that will be passed to the Db Connection
        /// </summary>
        public DynamicParameters? DynamicParameters { get; set; }
    }
}
