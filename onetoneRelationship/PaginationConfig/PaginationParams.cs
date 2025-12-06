namespace onetoneRelationship.PaginationConfig
{
    public class PaginationParams
    {
        private int MaxPageSize { get; set; } = 50;
        public int PageNumber { get; set; } = 1;
        public int _pageSize { get; set; }
        public void SetPageSize(int value)
        {
            _pageSize = Math.Min(value, MaxPageSize);
        }
    }
}