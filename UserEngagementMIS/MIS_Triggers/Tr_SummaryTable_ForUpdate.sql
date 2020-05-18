
Create Trigger [Tr_UserEngagement_MIS_ForUpdate]
On [user_engagement_MIS]
For Update as
Declare @Id int;
Declare @Count int=(Select Count(Id) from inserted);
Declare [Cr_UpdateTrigger_FetchNextRow] Cursor Scroll for Select Id from [inserted]
open [Cr_UpdateTrigger_FetchNextRow]
Begin
    While(@Count>0)
	Begin
	Fetch Next from [Cr_UpdateTrigger_FetchNextRow] Into @Id;
	Update [UserEngagementDB].[dbo].[MIS_Summary_Table]
	SET
	Candidate_id=(select Candidate_id from inserted where Id=@Id),
	Cpu_Count=(select Cpu_Count from inserted where Id=@Id),
	Cpu_Working_Time=(select Cpu_Working_Time from inserted where Id=@Id),
    Cpu_idle_Time=(select Cpu_Working_Time from inserted where Id=@Id),
	cpu_percent=(select cpu_percent from inserted where Id=@Id),
	--Usage_cpu_count=(select cpu_percent from inserted),
	number_of_software_interrupts_since_boot=(select number_of_software_interrupts_since_boot from inserted where Id=@Id),
	number_of_system_calls_since_boot=(select number_of_system_calls_since_boot from inserted where Id=@Id),
	number_of_interrupts_since_boot=(select number_of_interrupts_since_boot from inserted where Id=@Id),
	cpu_avg_load_over_1_min=(select cpu_avg_load_over_1_min from inserted where Id=@Id),
	cpu_avg_load_over_5_min=(select cpu_avg_load_over_5_min from inserted where Id=@Id),
	cpu_avg_load_over_15_min=(select cpu_avg_load_over_15_min from inserted where Id=@Id),
	--system_total_memory=(select system_total_memory from inserted),
	system_used_memory=(select system_used_memory from inserted where Id=@Id),
	system_free_memory=(select system_free_memory from inserted where Id=@Id),
	system_active_memory=(select system_active_memory from inserted where Id=@Id),
	system_inactive_memory=(select system_inactive_memory from inserted where Id=@Id),
	system_buffers_memory=(select system_buffers_memory from inserted where Id=@Id),
	system_cached_memory=(select system_cached_memory from inserted where Id=@Id),
	system_shared_memory=(select system_shared_memory from inserted where Id=@Id),
	system_avalible_memory=(select system_avalible_memory from inserted where Id=@Id),
	disk_used_memory=(select disk_used_memory from inserted where Id=@Id),
	disk_free_memory=(select disk_free_memory from inserted where Id=@Id),
	disk_read_count=(select disk_read_count from inserted where Id=@Id),
	disk_write_count=(select disk_write_count from inserted where Id=@Id),
	disk_read_bytes=(select disk_read_bytes from inserted where Id=@Id),
	disk_write_bytes=(select disk_write_bytes from inserted where Id=@Id),
	time_spent_writing_to_disk=(select time_spent_writing_to_disk from inserted where Id=@Id),
	time_spent_reading_from_disk=(select time_spent_reading_from_disk from inserted where Id=@Id),
	time_spent_doing_actual_input_Output=(select time_spent_doing_actual_input_Output from inserted where Id=@Id),
	number_of_bytes_sent =(select number_of_bytes_sent from inserted where Id=@Id),
	number_of_bytes_received=(select number_of_bytes_sent from inserted where Id=@Id),
	number_of_packets_sent =(select number_of_bytes_sent from inserted where Id=@Id),
	number_of_packets_recived =(select number_of_bytes_sent from inserted where Id=@Id),
	files_changed=(select files_changed from inserted where Id=@Id);
	Set @Count=@Count-1
	End
	Close [Cr_UpdateTrigger_FetchNextRow]
	Deallocate [Cr_UpdateTrigger_FetchNextRow]
	select * from inserted
End

Update [user_engagement_MIS]
Set Cpu_Count=4
where candidate_id=1

exec Sp_MIS_SummaryTable;

select * from user_engagement_MIS;

select * from MIS_Summary_Table;
