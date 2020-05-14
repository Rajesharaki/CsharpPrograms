select * from UserEngagementDB.dbo.user_engagement_MIS

Use UserEngagementDB
Go

Create Procedure Sp_MIS_SummaryTable
As 
Begin
Select ConCat(first_name,' ',middle_name,' ',last_name) as Full_Name,
email as User_Email,
Sum(Cpu_Count) as Total_CPU_Count,
Sum(Cpu_Working_Time) as Total_Cpu_Working_Time,
Sum(Cpu_idle_Time) as Total_Cpu_idle_Time,
Avg(cpu_percent) as Avg_Cpu_Percent,
Sum(number_of_software_interrupts_since_boot) as Total_number_of_software_interrupts_since_boot,
Sum(number_of_system_calls_since_boot) as Total_number_of_system_calls_since_boot,
Sum(number_of_interrupts_since_boot) as Total_number_of_interrupts_since_boot,
Avg(cpu_avg_load_over_1_min) as Avg_Cpu_load_over_in_1_min,
Avg(cpu_avg_load_over_15_min) as Avg_Cpu_load_over_5_min,
Avg(cpu_avg_load_over_15_min) as Avg_Cpu_load_over_15_min,
Max(system_used_memory) as  system_used_memory,
Min(system_free_memory) as System_free_memory,
Max(system_active_memory) as System_active_memory,
Max(system_inactive_memory) as System_inactive_memory,
Avg(system_buffers_memory) as Avg_system_buffers_memory,
Avg(system_cached_memory) as system_cached_memory,
Max(system_shared_memory) as Max_system_shared_memory,
Min(system_avalible_memory) as system_avalible_memory,
Max(disk_used_memory) as Max_disk_used_Memory,
Min(disk_free_memory) as Disk_free_Memory,
Max(disk_read_count) as Max_Disk_read_count,
Max(disk_write_count) as Max_Disk_write_count,
Max(disk_read_bytes) as Max_Disk_Read_Bytes,
Max(disk_write_bytes) as Max_Disk_Write_Bytes,
Sum(time_spent_reading_from_disk) as Total_Time_Spent_Reading_from_Disk,
Avg(time_spent_reading_from_disk) as Avg_Time_Spent_Reading_from_Disk,
Sum(time_spent_writing_to_disk) as Total_Time_Spent_Writing_to_Disk,
Avg(time_spent_writing_to_disk) as Avg_Time_Spent_Writing_to_Disk,
Sum(time_spent_doing_actual_Input_Output) as Total_time_spent_doing_actual_Input_Output,
Avg(time_spent_doing_actual_Input_Output) as Avg_time_spent_doing_actual_Input_Output,
Sum(number_of_bytes_sent) as Total_number_of_bytes_sent,
Sum(number_of_bytes_received) as Total_number_of_bytes_received,
Sum(number_of_packets_sent) as Total_number_of_packets_sent,
Sum(number_of_packets_recived) as Total_number_of_packets_recived,
Sum(files_changed) as Total_number_of_files_changed
from user_engagement_MIS
Join fellowship_candidates
On user_engagement_MIS.candidate_id=fellowship_candidates.id
group By candidate_id,email,first_name,middle_name,last_name
End

Exec Sp_MIS_SummaryTable;
Go
SET SHOWPLAN_ALL Off;

 
select * from user_engagement_MIS

