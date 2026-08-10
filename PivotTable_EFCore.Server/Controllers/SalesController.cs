using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Syncfusion.EJ2.Base;
using PivotTable_EFCore.Server.Data;

namespace PivotTable_EFCore.Server.Controllers
{
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesDbContext _db;

        /// <summary>
        /// Constructor that injects the DbContext for database access.
        /// </summary>
        public SalesController(SalesDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Handles GET requests to retrieve all sales data for the Pivot Table.
        /// This endpoint is called when the Pivot Table first loads or refreshes data.
        /// </summary>
        /// <returns>Returns a list of all sales records from the database.</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<List<SalesData>> GetSalesData()
        {
            return await _db.SalesData
                .AsNoTracking()
                .OrderBy(s => s.OrderID)
                .ToListAsync();
        }

        /// <summary>
        /// Handles POST requests from the Pivot Table DataManager.
        /// Processes the data request and returns formatted data for the component.
        /// </summary>
        /// <param name="DataManagerRequest">Contains the details of the data operation requested.</param>
        /// <returns>Returns the data records along with the total count.</returns>
        [HttpPost]
        [Route("api/[controller]")]
        public object Post([FromBody] DataManagerRequest DataManagerRequest)
        {
            // Retrieve all sales data from the database
            IQueryable<SalesData> DataSource = _db.SalesData.AsNoTracking();

            // Get the total number of records
            int totalRecordsCount = DataSource.Count();

            // Return data and count to the client
            return new { result = DataSource, count = totalRecordsCount };
        }

        /// <summary>
        /// Inserts a new sales record into the database.
        /// This method is called when a new row is added in the Pivot Table.
        /// </summary>
        /// <param name="value">Contains the new sales data to insert.</param>
        /// <returns>Returns the inserted record with its new OrderID.</returns>
        [HttpPost]
        [Route("api/[controller]/Insert")]
        public IActionResult Insert([FromBody] CRUDModel<SalesData> value)
        {
            if (value?.Value == null)
                return BadRequest("A sales record is required.");

            try
            {
                // EF Core assigns the new OrderID via IDENTITY after SaveChanges.
                _db.SalesData.Add(value.Value);
                _db.SaveChanges();

                return Ok(new { key = value.Value.OrderID, value = value.Value });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Insert failed", details = ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing sales record in the database.
        /// This method is called when a row is edited in the Pivot Table.
        /// </summary>
        /// <param name="value">Contains the updated sales data.</param>
        /// <returns>Returns the number of rows updated.</returns>
        [HttpPost]
        [Route("api/[controller]/Update")]
        public IActionResult Update([FromBody] CRUDModel<SalesData> value)
        {
            if (value?.Value == null || value.Value.OrderID == null)
                return BadRequest("OrderID and payload are required.");

            try
            {
                // EntityState.Modified tells EF Core to UPDATE every mapped column
                // of the row whose primary key matches value.value.OrderID.
                _db.Entry(value.Value).State = EntityState.Modified;
                _db.SaveChanges();

                return Ok(new { updated = 1, value = value.Value });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Update failed", details = ex.Message });
            }
        }
        /// <summary>
        /// Deletes a sales record from the database.
        /// This method is called when a row is deleted in the Pivot Table.
        /// </summary>
        /// <param name="value">Contains the OrderID of the record to delete.</param>
        /// <returns>Returns the number of rows deleted.</returns>
        [HttpPost]
        [Route("api/[controller]/Remove")]
        public IActionResult Remove([FromBody] CRUDModel<SalesData> value)
        {
            if (value?.Key == null)
                return BadRequest("Missing key.");

            if (!int.TryParse(value.Key.ToString(), out var id))
                return BadRequest("Invalid OrderID.");

            try
            {
                var existing = _db.SalesData.Find(id);
                if (existing == null)
                    return NotFound("Record not found.");

                _db.SalesData.Remove(existing);
                _db.SaveChanges();

                return Ok(new { deleted = 1, key = id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Delete failed", details = ex.Message });
            }
        }

        /// <summary>
        /// Generic model for handling CRUD operations from the Pivot Table.
        /// The Pivot Table uses this structure to send data to Insert, Update, and Remove endpoints.
        /// </summary>
        /// <typeparam name="T">The data type (e.g., SalesData)</typeparam>
        public class CRUDModel<T> where T : class
        {
            /// <summary>
            /// Action being performed (e.g., "insert", "update", "remove").
            /// </summary>
            public string? Action { get; set; }

            /// <summary>
            /// Primary key column name (e.g., "orderid").
            /// </summary>
            public string? KeyColumn { get; set; }

            /// <summary>
            /// The primary key value (e.g., the OrderID).
            /// </summary>
            public object? Key { get; set; }

            /// <summary>
            /// The single record being operated on (for Insert, Update operations).
            /// </summary>
            public T? Value { get; set; }

            /// <summary>
            /// Additional parameters sent by the client.
            /// </summary>
            public IDictionary<string, object>? Params { get; set; }
        }
    }
}