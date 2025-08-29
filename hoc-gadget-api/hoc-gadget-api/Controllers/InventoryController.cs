using hoc_gadget_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace hoc_gadget_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpPost]
        public ActionResult SaveInventoryData(InventoryRequestDto requestDto)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = "Server=LAPTOP-OP51S33J\\SQLEXPRESS;Database=gadgetShop;Integrated Security=True;TrustServerCertificate=True;"
            };

            SqlCommand command = new SqlCommand
            {
                CommandText = "sp_SaveInventoryData",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            command.Parameters.AddWithValue("@ProductId", requestDto.ProductId);
            command.Parameters.AddWithValue("@ProductName", requestDto.ProductName);
            command.Parameters.AddWithValue("@AvailableQnt", requestDto.AvailableQnt);
            command.Parameters.AddWithValue("@ReOrderPoint", requestDto.ReOrderPoint);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            return Ok();
        }

        [HttpGet]
        public ActionResult GetInventoryData()
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = "Server=LAPTOP-OP51S33J\\SQLEXPRESS;Database=gadgetShop;Integrated Security=True;TrustServerCertificate=True;"
            };

            SqlCommand command = new SqlCommand
            {
                CommandText = "sp_GetInventory_Date",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            connection.Open();

            List<InventoryDto> response = new List<InventoryDto>();

            using (SqlDataReader sqlDataReader = command.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    InventoryDto inventoryDto = new InventoryDto();
                    inventoryDto.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
                    inventoryDto.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
                    inventoryDto.AvailableQnt = Convert.ToInt32(sqlDataReader["AvailableQnt"]);
                    inventoryDto.ReOrderPoint = Convert.ToInt32(sqlDataReader["ReOrderPoint"]);

                    response.Add(inventoryDto);
                }
            };

            connection.Close();

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpDelete]
        public ActionResult DeleteInventoryData(int productId)
        {
            SqlConnection connection = new SqlConnection
            {
                ConnectionString = "Server=LAPTOP-OP51S33J\\SQLEXPRESS;Database=gadgetShop;Integrated Security=True;TrustServerCertificate=True;"
            };

            SqlCommand command = new SqlCommand
            {
                CommandText = "sp_DeleteInventoryDetails",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            connection.Open();

            command.Parameters.AddWithValue("@ProductId", productId);
            command.ExecuteNonQuery();

            connection.Close();

            return Ok();
        }
    }
}
