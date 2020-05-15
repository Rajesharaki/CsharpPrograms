using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using UserEngagementReport.Models;

namespace UserEngagementReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerMachineLogController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConsumerMachineLogController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("ExecelReport")]
        public  async Task<IActionResult> ExecelReport()
        {
            string cs = _configuration.GetConnectionString("DBCS");
            List<SummaryTableViewModel> list = new List<SummaryTableViewModel>();

            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Sp_MIS_SummaryTable",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    SummaryTableViewModel model = new SummaryTableViewModel();
                    model.Full_Name = reader["Full_Name"].ToString();
                    model.User_Email = reader["User_Email"].ToString();
                    model.Total_Cpu_Count = Convert.ToInt32(reader["Total_Cpu_Count"]);
                    model.Total_Cpu_Working_Time = Convert.ToDecimal(reader["Total_Cpu_Working_Time"]);
                    model.Total_Cpu_idle_Time= Convert.ToDecimal(reader["Total_Cpu_idle_Time"]);
                    model.Avg_Cpu_Percent = Convert.ToDouble(reader["Avg_Cpu_Percent"]);
                    model.Total_number_of_bytes_received = Convert.ToInt64(reader["Total_number_of_bytes_received"]);
                    model.Total_number_of_bytes_sent = Convert.ToInt64(reader["Total_number_of_bytes_sent"]);
                    model.Total_number_of_files_changed = Convert.ToInt32(reader["Total_number_of_files_changed"]);
                    model.Total_number_of_packets_receieved = Convert.ToInt64(reader["Total_number_of_packets_recived"]);
                    model.Total_number_of_packets_sent =Convert.ToInt64(reader["Total_number_of_packets_sent"]);
                    model.Total_nuber_of_software_interrupts_since_boot = Convert.ToDecimal(reader["Total_number_of_software_interrupts_since_boot"]);
                    model.Avg_Cpu_load_over_in_1_min = Convert.ToDecimal(reader["Avg_Cpu_load_over_in_1_min"]);
                    model.Avg_Cpu_load_over_5_min = Convert.ToDecimal(reader["Avg_Cpu_load_over_5_min"]);
                    model.Avg_Cpu_load_over_15_min = Convert.ToDecimal(reader["Avg_Cpu_load_over_15_min"]);
                    model.System_active_memory = Convert.ToInt64(reader["System_active_memory"]);
                    model.system_cached_memory = Convert.ToInt64(reader["system_cached_memory"]);
                    model.System_free_memory = Convert.ToInt64(reader["System_free_memory"]);
                    model.System_inactive_memory = Convert.ToInt64(reader["System_inactive_memory"]);
                    model.system_used_memory = Convert.ToInt64(reader["system_used_memory"]);
                    model.Avg_system_buffers_memory = Convert.ToInt64(reader["Avg_system_buffers_memory"]);
                    list.Add(model);
                }
                con.Close();
            }

            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserEngagementMISReport.xlsx");
        }
    }
}