CREATE TABLE [dbo].[Appointment] (
    [Id]                 BIGINT             IDENTITY (1, 1) NOT NULL,
    [CreatedBy]          BIGINT             NULL,
    [UpdatedBy]          BIGINT             NULL,
    [CreatedOn]          DATETIMEOFFSET (7) CONSTRAINT [DF_Appointment_CreatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [UpdatedOn]          DATETIMEOFFSET (7) CONSTRAINT [DF_Appointment_UpdatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [IsDeleted]          BIT                CONSTRAINT [DF_Appointment_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsActive]           BIT                CONSTRAINT [DF_Appointment_IsActive] DEFAULT ((1)) NOT NULL,
    [AppointmentDate]    DATETIMEOFFSET (7) CONSTRAINT [DF_Appointment_AppointmentDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NULL,
    [Note]               NVARCHAR (256)     NULL,
    [IsCancel]           BIT                CONSTRAINT [DF_Appointment_IsCancel] DEFAULT ((0)) NOT NULL,
    [CancellationReason] NVARCHAR (MAX)     NULL,
    [StartTime]          TIME (7)           NULL,
    [EndTime]            TIME (7)           NULL,
    [isAppointmentDone]  BIT                NULL,
    [FromUserId]         BIGINT             NULL,
    [ToUserId]           BIGINT             NULL,
    [Status]             NVARCHAR (50)      NULL,
    CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED ([Id] ASC)
);

