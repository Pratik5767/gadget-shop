namespace hoc_gadget_api.Models
{
    public class InventoryRequestDto
    {
        # region Properties
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int AvailableQnt { get; set; }

        public int ReOrderPoint { get; set; }
        #endregion
    }
}