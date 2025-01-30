using Dapper;
using System.Data;

namespace Bookify.Infrastructure.Data
{
    /// <summary>
    /// class provide a date only parsing operation from and to Database
    /// </summary>
    internal sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            parameter.DbType = DbType.DateTime;
            parameter.Value = value;
        }

        public override DateOnly Parse(object value)
        {
            return DateOnly.FromDateTime((DateTime)value);
        }
    }
}
