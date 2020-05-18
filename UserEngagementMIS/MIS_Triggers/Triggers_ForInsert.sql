Use [UserEngagementDB]
GO

Create Trigger Tr_UserEngagement_MIS_ForInsert
on [user_engagement_MIS]
For Insert as
Begin
Insert into [MIS_Summary_Table](candidate_id,Cpu_Count,Cpu_Working_Time,Cpu_idle_Time,cpu_percent
,number_of_software_interrupts_since_boot,number_of_system_calls_since_boot,number_of_interrupts_since_boot,
cpu_avg_load_over_1_min,cpu_avg_load_over_5_min,cpu_avg_load_over_15_min,system_used_memory,
system_free_memory,system_active_memory,system_inactive_memory,system_buffers_memory,system_cached_memory,system_shared_memory,
system_avalible_memory,disk_used_memory,disk_free_memory,disk_read_count,disk_write_count,disk_read_bytes,disk_write_bytes,
time_spent_reading_from_disk,time_spent_writing_to_disk,time_spent_doing_actual_Input_Output,number_of_bytes_sent,number_of_bytes_received,
number_of_packets_sent,number_of_packets_recived,total_number_of_errors_while_sending,total_number_of_errors_while_receiving,total_number_of_incoming_packets_which_were_dropped
,total_number_of_outgoing_packets_which_were_dropped,files_changed)
(Select candidate_id,Cpu_Count,Cpu_Working_Time,Cpu_idle_Time,cpu_percent
,number_of_software_interrupts_since_boot,number_of_system_calls_since_boot,number_of_interrupts_since_boot,
cpu_avg_load_over_1_min,cpu_avg_load_over_5_min,cpu_avg_load_over_15_min,system_used_memory,
system_free_memory,system_active_memory,system_inactive_memory,system_buffers_memory,system_cached_memory,system_shared_memory,
system_avalible_memory,disk_used_memory,disk_free_memory,disk_read_count,disk_write_count,disk_read_bytes,disk_write_bytes,
time_spent_reading_from_disk,time_spent_writing_to_disk,time_spent_doing_actual_Input_Output,number_of_bytes_sent,number_of_bytes_received,
number_of_packets_sent,number_of_packets_recived,total_number_of_errors_while_sending,total_number_of_errors_while_receiving,total_number_of_incoming_packets_which_were_dropped
,total_number_of_outgoing_packets_which_were_dropped,files_changed  from inserted)
End


Select * from MIS_Summary_Table