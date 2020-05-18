Create Trigger [Tr_UserEngagement_MIS_ForDelete]
On [User_Engagement_MIS]
For Delete as
Begin
  Delete from [MIS_Summary_Table]
  Where Id in (select Id from deleted)
End