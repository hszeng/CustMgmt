using CustMgmt.Helpers.Enums;

namespace CustMgmt.Models
{
    public class CustomerListRequest
    {
        public const int MaxPageSize = 50;
        private int _pageSize = 10;
        private int _privatePageIndex;

        public int PageIndex
        {
            get => _privatePageIndex -1 <= 0 ? 0 : _privatePageIndex -1;
            set => _privatePageIndex = value;
        }

        public string Name { get; set; }
        public string Email { get; set; }

        public bool? IsDeleted { get; set; }

        public CustomerStatus? Status { get; set; }

        public string OrderBy { get; set; }

        public SortDirection SortDirection { get; set; }

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

    }

}