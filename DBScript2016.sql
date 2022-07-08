USE [RignCentral_Reporting]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Identities]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityGroups]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterventionComments]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interventions]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sources]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Threads]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 08-07-2022 22:02:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
