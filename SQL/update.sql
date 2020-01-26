USE [Recruitment]
GO

UPDATE [dbo].[Job_Contacts_2]
   SET [ctt_id] = <ctt_id, smallint,>
      ,[ctt_date] = <ctt_date, date,>
      ,[ctt_hhmm] = <ctt_hhmm, varchar(10),>
      ,[role] = <role, nvarchar(50),>
      ,[client] = <client, nvarchar(50),>
      ,[location] = <location, nvarchar(30),>
      ,[appli] = <appli, bit,>
      ,[reply] = <reply, bit,>
      ,[agency] = <agency, nvarchar(50),>
      ,[staff] = <staff, nvarchar(100),>
      ,[email] = <email, nvarchar(100),>
      ,[phones] = <phones, nvarchar(100),>
      ,[remark] = <remark, nvarchar(250),>
      ,[more] = <more, nvarchar(250),>
 WHERE <Search Conditions,,>
GO

