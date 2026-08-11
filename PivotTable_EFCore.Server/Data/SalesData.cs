using System.ComponentModel.DataAnnotations;

namespace PivotTable_EFCore.Server.Data
{
    /// <summary>
    /// Data model that represents the structure of a sales record.
    /// This class maps to the columns in the 'salesdata' table in SQL Server.
    /// </summary>
    public class SalesData
    {
        /// <summary>
        /// Unique identifier for each order (Primary Key).
        /// The [Key] attribute marks this as the primary key for CRUD operations.
        /// </summary>
        [Key]
        public int? OrderID { get; set; }

        /// <summary>
        /// Name of the customer who placed the order.
        /// </summary>
        public string? CustomerName { get; set; }

        /// <summary>
        /// Geographic region where the customer is located.
        /// Useful for regional analysis in the pivot table.
        /// </summary>
        public string? Region { get; set; }

        /// <summary>
        /// Country where the order was placed.
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Category of the product (e.g., Electronics, Furniture).
        /// Used as a dimension in the pivot table analysis.
        /// </summary>
        public string? ProductCategory { get; set; }

        /// <summary>
        /// Name of the specific product ordered.
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// Date when the order was placed.
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Number of units ordered.
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Price per unit of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Total cost of the order (typically quantity × unitprice).
        /// Used as a measure/aggregate value in pivot table analysis.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Name of the sales representative who handled the order.
        /// </summary>
        public string? SalesPerson { get; set; }
    }
}
