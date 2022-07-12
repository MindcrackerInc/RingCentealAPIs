USE RingTest
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[id] [nvarchar](100) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[name] [nvarchar](150) NULL,
	[parent_id] [nvarchar](50) NULL,
	[unselectable] [bit] NULL,
	[mandatory] [bit] NULL,
	[post_qualification] [bit] NULL,
	[multiple] [bit] NULL,
	[color] [int] NULL,
	[source_ids] [nvarchar](max) NULL,
	[non_routable] [bit] NULL,
	[bot] [bit] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Identities]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Identities](
	[rowId] [bigint] IDENTITY(1,1) NOT NULL,
	[id] [varchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[community_id] [varchar](50) NULL,
	[community_url] [varchar](4000) NULL,
	[company] [varchar](500) NULL,
	[email] [varchar](500) NULL,
	[firstname] [varchar](500) NULL,
	[foreign_id] [varchar](50) NULL,
	[gender] [varchar](10) NULL,
	[home_phone] [varchar](500) NULL,
	[identity_group_id] [varchar](50) NULL,
	[lastname] [varchar](500) NULL,
	[mobile_phone] [varchar](500) NULL,
	[screenname] [varchar](500) NULL,
	[user_ids] [varchar](4000) NULL,
	[uuid] [varchar](500) NULL,
	[extra_values] [varchar](max) NULL,
	[display_name] [varchar](500) NULL,
	[avatar_url] [varchar](4000) NULL,
	[type] [varchar](500) NULL,
 CONSTRAINT [PK_Identities] PRIMARY KEY CLUSTERED 
(
	[rowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityGroups]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityGroups](
	[rowId] [bigint] IDENTITY(1,1) NOT NULL,
	[id] [varchar](500) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[custom_field_values] [varchar](max) NULL,
	[company] [varchar](500) NULL,
	[emails] [nvarchar](max) NULL,
	[firstname] [varchar](500) NULL,
	[lastname] [varchar](500) NULL,
	[gender] [varchar](10) NULL,
	[home_phones] [varchar](500) NULL,
	[mobile_phones] [varchar](500) NULL,
	[identity_ids] [varchar](500) NULL,
	[notes] [nvarchar](max) NULL,
	[read_only] [bit] NULL,
	[tag_ids] [nvarchar](1000) NULL,
	[avatar_url] [nvarchar](4000) NULL,
 CONSTRAINT [PK_IdentityGroups] PRIMARY KEY CLUSTERED 
(
	[rowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterventionComments]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterventionComments](
	[rowId] [bigint] IDENTITY(1,1) NOT NULL,
	[id] [varchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[body] [nvarchar](max) NULL,
	[identity_id] [varchar](50) NULL,
	[intervention_id] [varchar](50) NULL,
	[source_id] [varchar](50) NULL,
	[thread_id] [varchar](50) NULL,
	[user_id] [varchar](50) NULL,
 CONSTRAINT [PK_InterventionComments] PRIMARY KEY CLUSTERED 
(
	[rowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interventions]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interventions](
	[rowId] [bigint] IDENTITY(1,1) NOT NULL,
	[id] [varchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[custom_field_values] [nvarchar](max) NULL,
	[category_ids] [nvarchar](max) NULL,
	[closed] [bit] NULL,
	[closed_at] [datetime] NULL,
	[comments_count] [int] NULL,
	[content_id] [varchar](50) NULL,
	[deferred_at] [datetime] NULL,
	[first_user_reply_in] [int] NULL,
	[first_user_reply_in_bh] [int] NULL,
	[identity_id] [varchar](50) NULL,
	[last_user_reply_in] [int] NULL,
	[last_user_reply_in_bh] [int] NULL,
	[source_id] [varchar](50) NULL,
	[thread_id] [varchar](50) NULL,
	[user_id] [varchar](50) NULL,
	[user_replies_count] [int] NULL,
	[user_reply_in_average] [int] NULL,
	[user_reply_in_average_bh] [int] NULL,
	[user_reply_in_average_count] [int] NULL,
	[first_user_reply_id] [varchar](50) NULL,
	[status] [nvarchar](50) NULL,
	[satisfaction_grade] [varchar](500) NULL,
	[satisfaction_answered_at] [datetime] NULL,
	[satisfaction_sent_at] [datetime] NULL,
	[survey_response_id] [nvarchar](50) NULL,
	[survey_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_Interventions] PRIMARY KEY CLUSTERED 
(
	[rowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[rowid] [bigint] IDENTITY(1,1) NOT NULL,
	[id] [varchar](500) NULL,
	[created_at] [datetime] NULL,
	[source_id] [varchar](500) NULL,
	[source_type] [varchar](100) NULL,
	[source_name] [varchar](500) NULL,
	[content_thread_id] [varchar](500) NULL,
	[type] [varchar](100) NULL,
	[private_message] [varchar](max) NULL,
	[created_from] [varchar](500) NULL,
	[auto_submitted] [bit] NULL,
	[status] [char](20) NULL,
	[ignored_from] [varchar](500) NULL,
	[categories] [varchar](max) NULL,
	[intervention_id] [varchar](500) NULL,
	[initial_created_at] [datetime] NULL,
	[creator_id] [varchar](50) NULL,
	[creator_name] [varchar](100) NULL,
	[author_id] [varchar](500) NULL,
	[author_name] [varchar](100) NULL,
	[anonymized] [varchar](50) NULL,
	[body] [varchar](max) NULL,
	[body_as_text] [varchar](max) NULL,
	[body_as_html] [nvarchar](max) NULL,
	[title] [varchar](500) NULL,
	[foreign_categories] [varchar](max) NULL,
	[foreign_id] [varchar](500) NULL,
	[rating] [varchar](10) NULL,
	[published] [varchar](50) NULL,
	[approval_required] [bit] NULL,
	[remotely_deleted] [bit] NULL,
	[language] [varchar](50) NULL,
	[in_reply_to_id] [varchar](500) NULL,
	[in_reply_to_author_id] [varchar](500) NULL,
	[attachments_count] [int] NULL,
	[structured_reply_payload] [nvarchar](max) NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sources]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sources](
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[id] [varchar](500) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[active] [bit] NULL,
	[community_id] [nvarchar](500) NULL,
	[channel_id] [nvarchar](500) NULL,
	[name] [nvarchar](500) NULL,
	[status] [nvarchar](500) NULL,
	[color] [bigint] NULL,
	[sla_response] [bigint] NULL,
	[sla_expired_strategy] [nvarchar](500) NULL,
	[intervention_messages_boost] [bigint] NULL,
	[transferred_tasks_boost] [nvarchar](max) NULL,
	[hidden_from_stats] [bit] NULL,
	[default_category_ids] [nvarchar](max) NULL,
	[user_thread_default_category_ids] [nvarchar](max) NULL,
	[default_content_language] [nvarchar](50) NULL,
	[auto_detect_content_language] [bit] NULL,
	[time_sheet_ids] [nvarchar](500) NULL,
	[content_archiving_period] [bigint] NULL,
	[content_languages] [nvarchar](max) NULL,
	[type] [nvarchar](50) NULL,
	[error_message] [nvarchar](max) NULL,
	[live_chat] [bit] NULL,
	[enable_android] [bit] NULL,
	[enable_ios] [bit] NULL,
	[enable_web] [bit] NULL,
 CONSTRAINT [PK_Source] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Threads]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Threads](
	[RowId] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [varchar](500) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[category_ids] [nvarchar](max) NULL,
	[closed] [bit] NULL,
	[contents_count] [int] NULL,
	[extra_data] [nvarchar](max) NULL,
	[foreign_id] [nvarchar](500) NULL,
	[interventions_count] [int] NULL,
	[source_id] [varchar](500) NULL,
	[thread_category_ids] [nvarchar](max) NULL,
	[title] [varchar](5000) NULL,
	[last_content_at] [datetime] NULL,
	[first_categorization_at] [datetime] NULL,
	[first_content_id] [varchar](100) NULL,
	[first_content_author_id] [varchar](100) NULL,
	[last_content_id] [varchar](100) NULL,
	[intervention_user_ids] [nvarchar](max) NULL,
	[opened_intervention_user_ids] [nvarchar](max) NULL,
 CONSTRAINT [PK_Threads] PRIMARY KEY CLUSTERED 
(
	[RowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [varchar](100) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAllData]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteAllData]

AS
BEGIN

BEGIN TRY
--TRUNCATE TABLE Identities
truncate table [Identities]
truncate table IdentityGroups
truncate table InterventionComments
truncate table Interventions
truncate table Sources
truncate table Threads
truncate table Categories

			SELECT 1 AS IsCompleted,'Identities sync successfully.' As [Message] 
END TRY
BEGIN CATCH
			SELECT 0 AS IsCompleted,'Identities sync failed.' As [Message]  
END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[getData]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getData] --1,30,'20220606','20220706'
@PageNo INT,      
@RecordsPerPage INT,
@Startdate DateTime,
@EndDate DateTime
as 
begin
IF @PageNo < 1  
       SET @PageNo = 1 

 select * into #tempthreads from (select distinct id ,source_id,first_content_author_id,interventions_count,intervention_user_ids,category_ids from Threads) t1
 select * into #tempInterventions from ( select distinct id as interventionsid,category_ids,identity_id,updated_at,thread_id from Interventions where cast(Interventions.updated_at as date) between cast(@Startdate as date) and cast(@EndDate as date)) t2
  select * into #tempidentities from (Select distinct firstname,LastName,email,id as identitiesid,created_at,identity_group_id from Identities)t3
  --select * from #tempthreads
  select distinct firstname,lastname,email,cat.name as body,#tempInterventions.category_ids
  ,Ident.identitiesid as IdentitiesId, #tempthreads.id as transcriptid,
  #tempthreads.source_id
,first_content_author_id,interventions_count,intervention_user_ids,sources.name as source,Ident.created_at,identity_group_id
,#tempInterventions.updated_at
from #tempthreads left JOIN #tempInterventions
ON #tempthreads.id = #tempInterventions.thread_id
JOIN #tempidentities as ident 
on #tempInterventions.identity_id=ident.identitiesid
 join Sources on #tempthreads.source_id=sources.id
  JOIN  (select Name, id from Categories) cat
  on SUBSTRING(#tempthreads.category_ids,3,24)=cat.id

  
	   drop table #tempthreads
  drop table #tempInterventions
  drop table #tempidentities


--	   select  distinct firstname,lastname,email,cat.name as body,Interventions.category_ids,Ident.id as IdentitiesId,Threads.Id as transcriptid,threads.source_id
--,first_content_author_id,interventions_count,intervention_user_ids,sources.name as source,Ident.created_at,identity_group_id
--,Interventions.updated_at
--from Threads left JOIN Interventions
--ON Threads.id=Interventions.thread_id
---- JOIN InterventionComments on
----InterventionComments.intervention_id=Interventions.id
--JOIN
--(Select distinct firstname,LastName,email,id,created_at,identity_group_id from Identities)
--  as Ident 
--  on Ident.id=Interventions.identity_id
--  join Sources on Threads.source_id=sources.id
--  JOIN  (select Name, id from Categories) cat
--  on SUBSTRING(Threads.category_ids,3,24)=cat.id
 
--where cast(Interventions.updated_at as date) between cast(@Startdate as date) and cast(@EndDate as date)
--order by Interventions.updated_at desc
--OFFSET ( @PageNo - 1 ) * @RecordsPerPage ROWS  
--FETCH NEXT @RecordsPerPage ROWS ONLY  

--select  distinct firstname,lastname,email,body,Interventions.category_ids,Ident.id as IdentitiesId,Threads.Id as transcriptid,threads.source_id
--,first_content_author_id,interventions_count,intervention_user_ids,sources.name as source,Ident.created_at,identity_group_id
--,Interventions.updated_at
--from 
--(Select distinct firstname,LastName,email,id,created_at,identity_group_id from Identities)
--  as Ident 
-- join InterventionComments
--on Ident.id=InterventionComments.identity_id
--left JOIN Threads on Threads.Id=InterventionComments.thread_id
--left Join Sources on Threads.source_id=sources.id
--left Join Interventions on Ident.id=Interventions.identity_id
--and Interventions.thread_id=threads.id
--where cast(Interventions.updated_at as date) between cast(@Startdate as date) and cast(@EndDate as date)
----order by Interventions.updated_at desc
----OFFSET ( @PageNo - 1 ) * @RecordsPerPage ROWS  
----FETCH NEXT @RecordsPerPage ROWS ONLY  



End
GO
/****** Object:  StoredProcedure [dbo].[GetDataCount]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GetDataCount]
 
as 
begin
 
select Count(*)
from Identities join InterventionComments
on Identities.id=InterventionComments.identity_id
JOIN Threads on Threads.Id=InterventionComments.thread_id
Join Sources on Threads.source_id=sources.id
 
End
GO
/****** Object:  StoredProcedure [dbo].[Sync_Categories]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[Sync_Categories]
@json NVARCHAR(MAX)
AS
BEGIN

BEGIN TRY

--TRUNCATE TABLE Threads

INSERT INTO Categories SELECT  * 
FROM
    OPENJSON (@json)
    WITH (  
	id nvarchar(100),
	created_at datetime,
           updated_at datetime,
           name nvarchar(150),
           parent_id nvarchar(50),
           unselectable bit,
           mandatory bit,
           post_qualification bit,
           multiple bit,
           color int,
           source_ids nvarchar(max),
           non_routable bit,
           bot bit

			)

			SELECT 1 AS IsCompleted,'Threads sync successfully.' As Message 
END TRY
BEGIN CATCH
			SELECT 0 AS IsCompleted,'Threads sync failed.' As Message 
END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[Sync_Identities]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sync_Identities]
@json NVARCHAR(MAX)
AS
BEGIN

BEGIN TRY
--TRUNCATE TABLE Identities
INSERT INTO Identities SELECT  * 
FROM
    OPENJSON (@json)
    WITH (  
			   id varchar(50),
			   created_at datetime,
			   updated_at datetime,
			   community_id varchar(50),
			   community_url varchar(4000),
			   company varchar(500),
			   email varchar(500),
			   firstname varchar(500),
			   foreign_id varchar(50),
			   gender varchar(10),
			   home_phone varchar(500),
			   identity_group_id varchar(50),
			   lastname varchar(500),
			   mobile_phone varchar(500),
			   screenname varchar(500),
			   user_ids nvarchar(max) as json,
			   uuid varchar(500),
			   extra_values nvarchar(max) as json,
			   display_name varchar(500),
			   avatar_url varchar(4000),
			   [type] varchar(500)
		  )

			SELECT 1 AS IsCompleted,'Identities sync successfully.' As [Message] 
END TRY
BEGIN CATCH
			SELECT 0 AS IsCompleted,'Identities sync failed.' As [Message]  
END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[Sync_IdentityGroup]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sync_IdentityGroup]
@json NVARCHAR(MAX)
AS
BEGIN

BEGIN TRY

--TRUNCATE TABLE IdentityGroups

INSERT INTO IdentityGroups SELECT  * 
FROM
    OPENJSON (@json)
    WITH (  
			id NVARCHAR(500),
			created_at NVARCHAR(100),
			updated_at NVARCHAR(100),
			custom_field_values nvarchar(max) AS JSON,
			company NVARCHAR(500),
			emails nvarchar(max) AS JSON,
			firstname NVARCHAR(500),
			lastname NVARCHAR(500),
			gender NVARCHAR(10),
			home_phones nvarchar(max) AS JSON,
			identity_ids nvarchar(max) AS JSON,
			mobile_phones NVARCHAR(max) AS JSON,
			notes NVARCHAR(MAX),
			[read_only] BIT,
			tag_ids NVARCHAR(max) AS JSON,
			avatar_url NVARCHAR(4000)
			)

			SELECT 1 AS IsCompleted,'Identity groups sync successfully.' As [Message] 
END TRY
BEGIN CATCH
			SELECT 0 AS IsCompleted,'Identity groups sync failed.' As [Message]  
END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[Sync_InterventionComments]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sync_InterventionComments]
@json NVARCHAR(MAX)
AS
BEGIN

BEGIN TRY

--TRUNCATE TABLE InterventionComments

INSERT INTO InterventionComments SELECT  * 
FROM
    OPENJSON (@json)
    WITH (  
			id varchar(50),
			created_at datetime,
			updated_at datetime,
			body nvarchar(max),
			identity_id varchar(50),
			intervention_id varchar(50),
			source_id varchar(50),
			thread_id varchar(50),
			[user_id] varchar(50)

			)

	SELECT 1 AS IsCompleted,'Intervention comments sync successfully.' As Message 
END TRY
BEGIN CATCH
	SELECT 0 AS IsCompleted,'Intervention comments sync failed.' As Message 
END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[Sync_Interventions]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sync_Interventions]
@json NVARCHAR(MAX)
AS
BEGIN

BEGIN TRY
--TRUNCATE TABLE Interventions
INSERT INTO Interventions SELECT  * 
FROM
    OPENJSON (@json)
    WITH (  
		   [id] varchar(50),
           [created_at] datetime,
           [updated_at] datetime,
           [custom_field_values] nvarchar(max) AS JSON,
           [category_ids] nvarchar(max) AS JSON,
           [closed] bit,
           [closed_at] datetime,
           [comments_count] int,
           [content_id] varchar(50),
           [deferred_at] datetime,
           [first_user_reply_in] int,
           [first_user_reply_in_bh] int,
           [identity_id] varchar(50),
           [last_user_reply_in] int,
           [last_user_reply_in_bh] int,
           [source_id] varchar(50),
           [thread_id] varchar(50),
           [user_id] varchar(50),
           [user_replies_count] int,
           [user_reply_in_average] int,
           [user_reply_in_average_bh] int,
           [user_reply_in_average_count] int,
           [first_user_reply_id] varchar(50),
           [status] nvarchar(50),
           [satisfaction_grade] varchar(500),
           [satisfaction_answered_at] datetime,
           [satisfaction_sent_at] datetime,
           [survey_response_id] nvarchar(50),
           [survey_id] nvarchar(50)
		  )

			SELECT 1 AS IsCompleted,'Interventions sync successfully.' As [Message] 
END TRY
BEGIN CATCH
			SELECT 0 AS IsCompleted,'Interventions sync failed.' As [Message]  
END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[Sync_Sources]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[Sync_Sources]
@json NVARCHAR(MAX)
AS
BEGIN

BEGIN TRY

--TRUNCATE TABLE Threads

INSERT INTO Sources SELECT  * 
FROM
    OPENJSON (@json)
    WITH (  
			id varchar(500) ,
	created_at datetime ,
	updated_at datetime ,
	active bit ,
	community_id nvarchar(500) ,
	channel_id nvarchar(500) ,
	name nvarchar(500) ,
	status nvarchar(500) ,
	color bigint ,
	sla_response bigint ,
	sla_expired_strategy nvarchar(500) ,
	intervention_messages_boost bigint ,
	transferred_tasks_boost nvarchar(max) AS JSON,
	hidden_from_stats bit ,
	default_category_ids nvarchar(max)  AS JSON,
	user_thread_default_category_ids nvarchar(max) AS JSON,
	default_content_language nvarchar(50) ,
	auto_detect_content_language bit ,
	time_sheet_ids nvarchar(500) ,
	content_archiving_period bigint ,
	content_languages nvarchar(max) AS JSON,
	type nvarchar(50) ,
	error_message nvarchar(max) AS JSON,
	live_chat bit ,
	enable_android bit ,
	enable_ios bit ,
	enable_web bit
			)

			SELECT 1 AS IsCompleted,'Threads sync successfully.' As Message 
END TRY
BEGIN CATCH
			SELECT 0 AS IsCompleted,'Threads sync failed.' As Message 
END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[Sync_Thread]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sync_Thread]
@json NVARCHAR(MAX)
AS
BEGIN

BEGIN TRY

--TRUNCATE TABLE Threads

INSERT INTO Threads SELECT  * 
FROM
    OPENJSON (@json)
    WITH (  
			id NVARCHAR(50),
			created_at NVARCHAR(50),
			updated_at NVARCHAR(50),
			category_ids nvarchar(max) AS JSON,
			closed BIT,
			contents_count INT,
			extra_data NVARCHAR(MAX) AS JSON,
			foreign_id NVARCHAR(500),
			interventions_count INT,
			source_id NVARCHAR(500),
			thread_category_ids NVARCHAR(MAX) AS JSON,
			title NVARCHAR(MAX),
			last_content_at NVARCHAR(500),
			first_categorization_at NVARCHAR(500),
			first_content_id NVARCHAR(500),
			first_content_author_id NVARCHAR(500),
			last_content_id NVARCHAR(500),
			intervention_user_ids NVARCHAR(MAX) AS JSON,
			opened_intervention_user_ids NVARCHAR(MAX) AS JSON
			)

			SELECT 1 AS IsCompleted,'Threads sync successfully.' As Message 
END TRY
BEGIN CATCH
			SELECT 0 AS IsCompleted,'Threads sync failed.' As Message 
END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[UserSignIn]    Script Date: 08-07-2022 15:24:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UserSignIn]
@Email VARCHAR(250),
@Password VARCHAR(250)
AS
BEGIN

SELECT * FROM [dbo].[UserInfo] WHERE [Email] = @Email AND [Password] = @Password


END

GO
