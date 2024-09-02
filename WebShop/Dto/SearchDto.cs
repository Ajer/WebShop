using WebShop.Models;

namespace WebShop.Dto
{
    public class SearchDto
    {

        public List<ProductDto> ProdDtos { get; set; } = new List<ProductDto>();

        public List<Category> Categories { get; set; } = new List<Category>();

        public string SearchString { get; set; }

        public int ShowPage { get; set; }  // For pagination

        public int MaxPageIndex { get; set; }

        public int Rest { get; set; }

    }
}
