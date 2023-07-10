

namespace Infrastructure.Models
{
    public class PaginationOptions
    {

        // Default PageNumber = 1 
        private int _pageNumber = 1;
        public int PageNumber
        {
            get { return _pageNumber; }
            init { _pageNumber = (value <= 0) ? 1 : value; }
        }

        //  // Default PageSize = 10 
        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value <= 0) ? 10 : value; }
        }

  
    }
}
