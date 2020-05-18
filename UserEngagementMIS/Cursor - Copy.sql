
create procedure Sp_GetAllUsers
As
Begin
Select * from user_engagement_MIS
End

Exec Sp_GetAllUsers


create procedure Sp_UserEngagementCursor
as
Begin
Declare Csr_GetFirstUser Cursor Scroll For select * from user_engagement_MIS
open Csr_GetFirstUser
Fetch First From Csr_GetFirstUser 
Fetch Last From Csr_GetFirstUser 
Fetch Prior From Csr_GetFirstUser 
Fetch Absolute 7 From Csr_GetFirstUser 
Fetch Relative -2 From Csr_GetFirstUser 
Fetch Next From Csr_GetFirstUser 
Close Csr_GetFirstUser
Deallocate Csr_GetFirstUser
End

exec Sp_UserEngagementCursor;

select * from fellowship_candidates