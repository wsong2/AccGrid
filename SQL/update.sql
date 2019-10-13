USE [Recruitment]
GO

UPDATE [dbo].[Job_Contacts]
   SET [ctt_id] = <ctt_id, smallint,>
      ,[ctt_date] = <ctt_date, date,>
      ,[ctt_hhmm] = <ctt_hhmm, varchar(10),>
      ,[role] = <role, nvarchar(50),>
      ,[location] = <location, nvarchar(20),>
      ,[appli] = <appli, bit,>
      ,[reply] = <reply, bit,>
      ,[agency] = <agency, nvarchar(50),>
      ,[staff] = <staff, nvarchar(50),>
      ,[email] = <email, nvarchar(50),>
      ,[mobile] = <mobile, nvarchar(20),>
      ,[phone] = <phone, nvarchar(20),>
      ,[remark] = <remark, nvarchar(250),>
      ,[more] = <more, nvarchar(250),>
 WHERE <Search Conditions,,>
GO

