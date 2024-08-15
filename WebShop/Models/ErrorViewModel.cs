namespace WebShop.Models
{
    public class ErrorViewModel
    {
        private bool showRequestId;

        public string? RequestId { get; set; }

        public int? StatusCode { get; set; }   // MyOwn

        public bool ShowRequestId { 
            
            get {
                return showRequestId;
            }

            set
            {
                showRequestId = !string.IsNullOrEmpty(RequestId);
            }      
        } 
    }
}
