using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerUserEngagementReports.Models
{
    public class SummaryTableViewModel
    {
        public string Full_Name { get; set; }
        public string User_Email { get; set; }
        public int Total_Cpu_Count { get; set; }
        public Decimal Total_Cpu_Working_Time { get; set; }
        public Decimal Total_Cpu_idle_Time { get; set; }
        public Double Avg_Cpu_Percent { get; set; }
        public Decimal Total_nuber_of_software_interrupts_since_boot { get; set; }
        public Decimal Avg_Cpu_load_over_in_1_min { get; set; }
        public Decimal Avg_Cpu_load_over_5_min { get; set; }
        public Decimal Avg_Cpu_load_over_15_min { get; set; }
        public long system_used_memory { get; set; }
        public long System_free_memory { get; set; }
        public long System_active_memory { get; set; }
        public long System_inactive_memory { get; set; }
        public long Avg_system_buffers_memory { get; set; }
        public long system_cached_memory { get; set; }
        public long Total_number_of_bytes_sent { get; set; }
        public long Total_number_of_bytes_received { get; set; }
        public long Total_number_of_packets_sent { get; set; }
        public long Total_number_of_packets_receieved { get; set; }
        public int Total_number_of_files_changed { get; set; }
    }
}
