

Create Partition Function Pt_DatePartition_fun (DATETIME)
as 
range Right for values
(
  '2019-11-02','2019-11-03','2019-11-04','2019-11-05','2019-11-06','2019-11-07','2019-11-08',
  '2019-11-09','2019-11-10','2019-11-11','2019-11-12','2019-11-13','2019-11-14','2019-11-15','2019-11-16',
  '2019-11-17','2019-11-18','2019-11-19','2019-11-20','2019-11-21','2019-11-22','2019-11-23','2019-11-24',
  '2019-11-25','2019-11-26','2019-11-27','2019-11-28','2019-11-29'
);

create Partition Scheme Pt_DatewisePartition_Scheme
As
Partition Pt_DatePartition_fun
To
(
  Date1,Date2,Date3,Date4,Date5,Date6,Date7,Date8,Date9,Date10,Date11,Date12,Date13,Date14,Date15,Date16,Date17,Date18
  ,Date19,Date20,Date21,Date22,Date23,Date24,Date25,Date26,Date27,Date28,Date29,Date30
)

select * from sys.filegroups

CREATE TABLE DatewisePartitionUser_engagement_MIS(
id int NOT NULL,
candidate_id int NOT NULL,
Date_Time  DATETIME NOT NULL,
Cpu_Count int NOT NULL,
Cpu_Working_Time Decimal(11,3) NOT NULL,
Cpu_idle_Time Decimal(11,3) NOT NULL,
cpu_percent Decimal(11,3) NOT NULL,
Usage_cpu_count int NOT NULL,
number_of_software_interrupts_since_boot Decimal(11,3) NOT NULL,
number_of_system_calls_since_boot int NOT NULL,
number_of_interrupts_since_boot int NOT NULL,
cpu_avg_load_over_1_min Decimal(11,3) NOT NULL,
cpu_avg_load_over_5_min   Decimal(11,3) NOT NULL,
cpu_avg_load_over_15_min Decimal(11,3) NOT NULL,
system_total_memory BIGINT NOT NULL,
system_used_memory BIGINT NOT NULL,
system_free_memory BIGINT NOT NULL,
system_active_memory BIGINT NOT NULL,
system_inactive_memory BIGINT NOT NULL,
system_buffers_memory BIGINT NOT NULL,
system_cached_memory BIGINT NOT NULL,
system_shared_memory BIGINT NOT NULL,
system_avalible_memory BIGINT NOT NULL,
disk_total_memory BIGINT NOT NULL,
disk_used_memory BIGINT NOT NULL,
disk_free_memory BIGINT NOT NULL,
disk_read_count BIGINT NOT NULL,
disk_write_count BIGINT NOT NULL,
disk_read_bytes BIGINT NOT NULL,
disk_write_bytes BIGINT NOT NULL,
time_spent_reading_from_disk BIGINT NOT NULL,
time_spent_writing_to_disk BIGINT NOT NULL,
time_spent_doing_actual_Input_Output BIGINT NOT NULL,
number_of_bytes_sent BIGINT NOT NULL,
number_of_bytes_received BIGINT NOT NULL,
number_of_packets_sent BIGINT NOT NULL,
number_of_packets_recived BIGINT NOT NULL,
total_number_of_errors_while_receiving BIGINT NOT NULL,
total_number_of_errors_while_sending BIGINT NOT NULL,
total_number_of_incoming_packets_which_were_dropped BIGINT NOT NULL,
total_number_of_outgoing_packets_which_were_dropped BIGINT NOT NULL,
boot_time varchar(100) NOT NULL,
keyboard int NOT NULL,
mouse int NOT NULL,
technology varchar(100) NOT NULL,
files_changed int NOT NULL,
CONSTRAINT FK_user_engagemnt_mis_candidates_id FOREIGN KEY (candidate_id) REFERENCES fellowship_candidates (id),
)On Pt_DatewisePartition_Scheme(Date_Time);


insert into DatewisePartitionUser_engagement_MIS(id,candidate_id,Date_Time,Cpu_Count,Cpu_Working_Time,Cpu_idle_Time,cpu_percent
,Usage_cpu_count,number_of_software_interrupts_since_boot,number_of_system_calls_since_boot,number_of_interrupts_since_boot,
cpu_avg_load_over_1_min,cpu_avg_load_over_5_min,cpu_avg_load_over_15_min,system_total_memory,system_used_memory,
system_free_memory,system_active_memory,system_inactive_memory,system_buffers_memory,system_cached_memory,system_shared_memory,
system_avalible_memory,disk_total_memory,disk_used_memory,disk_free_memory,disk_read_count,disk_write_count,disk_read_bytes,disk_write_bytes,
time_spent_reading_from_disk,time_spent_writing_to_disk,time_spent_doing_actual_Input_Output,number_of_bytes_sent,number_of_bytes_received,
number_of_packets_sent,number_of_packets_recived,total_number_of_errors_while_sending,total_number_of_errors_while_receiving,total_number_of_incoming_packets_which_were_dropped
,total_number_of_outgoing_packets_which_were_dropped,boot_time,keyboard,mouse,technology,files_changed)
(select * from user_engagement_MIS);


select $Partition.Pt_DatePartition_fun(Date_Time) as PartitionNumber ,*
from DatewisePartitionUser_engagement_MIS;

select * from DatewisePartitionUser_engagement_MIS;

select * from user_engagement_MIS

SELECT part.partition_number AS [Partition Number],
		fle.name AS [Partition Name],
		part.rows AS [Number of Rows]
FROM sys.partitions AS part
JOIN SYS.destination_data_spaces AS dest ON
part.partition_number = dest.destination_id
JOIN sys.filegroups AS fle ON
dest.data_space_id = fle.data_space_id
WHERE OBJECT_NAME(OBJECT_ID) = 'DatewisePartitionUser_engagement_MIS'

select * from sys.filegroups;

select * from sys.partitions;

select * from  SYS.destination_data_spaces