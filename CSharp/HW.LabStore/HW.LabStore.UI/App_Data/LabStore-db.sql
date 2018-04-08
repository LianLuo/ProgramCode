CREATE TABLE [dbo].[IPMS_TBL_Approval_Condition_Setup] (
	[ConditionId] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Description] nvarchar(254) NOT NULL, 
	[Condition] nvarchar(254) NOT NULL, 
	[IsActive] bit NOT NULL DEFAULT ((1)), 
	[CreatedBy] int NOT NULL DEFAULT ((1)), 
	[CreatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[LastUpdatedBy] int NOT NULL DEFAULT ((1)), 
	[LastUpdatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[TransactionId] nvarchar(50) NOT NULL DEFAULT (' ')
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IPMS_TBL_Approval_Action_Setup] (
	[ActionId] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Description] nvarchar(254), 
	[ConditionId] int NOT NULL, 
	[PID] int NOT NULL DEFAULT ((0)), 
	[IsEnd] bit NOT NULL DEFAULT ((0)), 
	[Sequence] int NOT NULL, 
	[AutoApproval] bit NOT NULL, 
	[Message] nvarchar(254), 
	[ApprovalRequired] bit NOT NULL DEFAULT ((1)), 
	[MaxApproval] nvarchar(254), 
	[CCEmail] nvarchar(254), 
	[IsActive] bit NOT NULL DEFAULT ((1)), 
	[CreatedBy] int NOT NULL DEFAULT ((1)), 
	[CreatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[LastUpdatedBy] int NOT NULL DEFAULT ((1)), 
	[LastUpdatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[TransactionId] nvarchar(254) NOT NULL DEFAULT (' '), 
	FOREIGN KEY ([ConditionId])
		REFERENCES [dbo].[IPMS_TBL_Approval_Condition_Setup] ([ConditionId])
		ON UPDATE NO ACTION ON DELETE NO ACTION
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'当前条件是否为最后条件',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'IPMS_TBL_Approval_Action_Setup',@level2type=N'Column',@level2name=N'IsEnd';
GO

CREATE TABLE [dbo].[IPMS_TBL_Approval_Flow] (
	[FlowId] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[NextFlowId] int, 
	[CurrentProcessRole] nvarchar(254), 
	[ApprovalId] int NOT NULL DEFAULT ((1)), 
	[StatusId] int NOT NULL DEFAULT ((0)), 
	[IsEProject] bit NOT NULL DEFAULT ((0)), 
	[RevisionNo] int NOT NULL DEFAULT ((1)), 
	[VersionNo] int NOT NULL DEFAULT ((1)), 
	[CreatedBy] int NOT NULL DEFAULT ((1)), 
	[CreatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[LastUpdatedBy] int NOT NULL DEFAULT ((1)), 
	[LastUpdatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[TransactionId] nvarchar(50) NOT NULL DEFAULT (' ')
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IPMS_TBL_Approval_Setup] (
	[AppId] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Description] nvarchar(254), 
	[Category] nvarchar(254), 
	[Sequence] int NOT NULL, 
	[IsActive] bit NOT NULL DEFAULT ((1)), 
	[CreatedBy] int NOT NULL DEFAULT ((1)), 
	[CreatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[LastUpdatedBy] int NOT NULL DEFAULT ((1)), 
	[LastUpdatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[TransactionId] nvarchar(50) NOT NULL DEFAULT (' ')
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IPMS_TBL_Approval_User] (
	[LevelId] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[PID] int NOT NULL, 
	[CommonRemarks] nvarchar(254), 
	[ApprovalRequired] bit NOT NULL DEFAULT ((1)), 
	[CreatedBy] int NOT NULL DEFAULT ((1)), 
	[CreatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[LastUpdatedBy] int NOT NULL DEFAULT ((1)), 
	[LastUpdatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[TransactionId] nvarchar(50) NOT NULL DEFAULT (' ')
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[IPMS_TBL_Budget_IntermediateResult] (
	[CalcId] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[ProjectId] int NOT NULL, 
	[ProjectBudgetId] int NOT NULL, 
	[PTDRevenue] decimal(38, 0) NOT NULL, 
	[PTDCost] decimal(38, 0) NOT NULL, 
	[PTDMargin] decimal(38, 0) NOT NULL, 
	[PTDMarginPrecent] decimal(38, 0) NOT NULL, 
	[FirstRevenue] decimal(38, 0), 
	[FirstCost] decimal(38, 0), 
	[FirstMargin] decimal(38, 0), 
	[FirstMarginPrecent] decimal(38, 0), 
	[RevisedRevenue] decimal(38, 0), 
	[RevisedCost] decimal(38, 0), 
	[RevisedMargin] decimal(38, 0), 
	[RevisedMarginPrecent] decimal(38, 0), 
	[ProposedRevenue] decimal(38, 0) NOT NULL, 
	[ProposedCost] decimal(38, 0) NOT NULL, 
	[ProposedMargin] decimal(38, 0) NOT NULL, 
	[PropsoedMarginPrecent] decimal(38, 0) NOT NULL, 
	[VarianceRevenue] decimal(38, 0) NOT NULL, 
	[VarianceCost] decimal(38, 0) NOT NULL, 
	[VarianceMargin] decimal(38, 0) NOT NULL, 
	[VarianceMarginPrecent] decimal(38, 0) NOT NULL, 
	[NetRevenue] decimal(38, 0) NOT NULL, 
	[NetCost] decimal(38, 0) NOT NULL, 
	[NetMargin] decimal(38, 0) NOT NULL, 
	[NetMarginPrecent] decimal(38, 0) NOT NULL, 
	[CostSheetRevenue] decimal(38, 0), 
	[CostSheetCost] decimal(38, 0), 
	[CostSheetMargin] decimal(38, 0), 
	[CostSheetMarginPrecent] decimal(38, 0), 
	[MarginErosion] decimal(38, 0) NOT NULL, 
	[VersionNo] int NOT NULL DEFAULT ((1)), 
	[RevisedNo] int NOT NULL DEFAULT ((1)), 
	[IsEProject] bit NOT NULL DEFAULT ((0)), 
	[CreatedBy] int NOT NULL DEFAULT ((1)), 
	[CreatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[LastUpdatedBy] int NOT NULL DEFAULT ((1)), 
	[LastUpdatedDate] datetime NOT NULL DEFAULT (getdate()), 
	[TransactionId] nvarchar(50) NOT NULL DEFAULT (' ')
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'修改一次版本加一',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'IPMS_TBL_Budget_IntermediateResult',@level2type=N'Column',@level2name=N'VersionNo';
GO

CREATE PROCEDURE [dbo].[GetAllCondition] (@projectId INT)
AS
BEGIN
	DECLARE cur CURSOR FOR SELECT ActionId FROM IPMS_TBL_Approval_Action_Setup as tb_action Where tb_action.isEnd = 1 AND tb_action.isActive = 1
	DECLARE @actionId INT;
	OPEN cur
	FETCH NEXT FROM cur INTO @actionId;
	WHILE @@FETCH_STATUS =0
	BEGIN
		print @actionId;
		FETCH NEXT FROM cur INTO @actionId;
	END
	
	CLOSE cur;
	DEALLOCATE cur;
END
GO

CREATE PROCEDURE [dbo].[GetAllConditionByActionId] (@actionId INT)
AS
BEGIN
	DECLARE @t TABLE(ID INT)
	INSERT @t SELECT PID FROM IPMS_TBL_Approval_Action_Setup WHERE ActionId = @actionId;
	WHILE(@@rowcount <> 0)
	BEGIN
		INSERT @t SELECT PID FROM IPMS_TBL_Approval_Action_Setup as A INNER JOIN @t B
		ON a.ActionId = B.Id AND
		NOT EXISTS (SELECT 1 FROM @t WHERE ID = A.PID);
	END
	DECLARE @sqlstr VARCHAR(MAX);
	DECLARE @temp VARCHAR(1000);
	/*SELECT @sqlstr = STUFF((
	SELECT ' AND ('+c.Condition+')' FROM @t as a
	LEFT JOIN IPMS_TBL_Approval_Action_Setup as b
	ON a.ID = b.ActionId
	LEFT JOIN IPMS_TBL_Approval_Condition_Setup as c
	ON b.ConditionId = c.ConditionId
	FOR XML PATH('')),1,1,'') */
	SELECT @temp = '('+Condition+')' FROM IPMS_TBL_Approval_Action_Setup as tbAction
	LEFT JOIN IPMS_TBL_Approval_Condition_Setup as tbCondition
	ON tbAction.ConditionId = tbCondition.ConditionId
	WHERE tbAction.ActionId = @actionId;
	Set @sqlstr = @temp;
	
	DECLARE @cid INT
	
	DECLARE cur CURSOR FOR SELECT * FROM @t
	OPEN cur;
	FETCH NEXT FROM cur INTO @cid
	WHILE @@FETCH_STATUS = 0 AND @cid <> 0
	BEGIN
		SELECT @temp = ' AND ('+Condition+')' FROM IPMS_TBL_Approval_Action_Setup as tbAction
		LEFT JOIN IPMS_TBL_Approval_Condition_Setup as tbCondition
		ON tbAction.ConditionId = tbCondition.ConditionId
		WHERE tbAction.ActionId = @cid;
		SET @sqlstr = @sqlstr + @temp;
		FETCH NEXT FROM cur INTO @cid
	END
	CLOSE cur;
	DEALLOCATE cur;
	SELECT @sqlstr;
END
GO

CREATE PROCEDURE [dbo].[IPMS_sp_GetApprovalFlowInfo] (
	@projectId INT,
	@projectBudgetId INT
)
AS
BEGIN
	DECLARE @nullComeCs BIT,@argementStatus VARCHAR(50),@isComeCs BIT
	DECLARE @netRevenue DECIMAL = 0,@netCost DECIMAL = 0,@proposedCost DECIMAL = 0,@ptdCost DECIMAL = 0,@proposedMarginPrecent DECIMAL = 0,@revisedMarginPrecent DECIMAL = 0;
	DECLARE @eProposedMarginPrecent DECIMAL = 0,@eFirstMarginPrecent DECIMAL = 0,@eLatestMarginPrecent DECIMAL = 0,@eVarMarginPrecent DECIMAL = 0,@eVarMarginErosion DECIMAL = 0,@eVarMargin DECIMAL = 0
	
	-- 获取当前Budget下面是否有来至Cost Sheet的，
	SET @nullComeCs = 1;
	-- 如果当前Budget是来至Cost Sheet，那么获取argementStatus的状态。
	SET @argementStatus = 'Awarded';
	-- 获取当前Budget是否来至Cost Sheet
	SET @isComeCs = 0;
	
	-- set r-project parameters
	SELECT 
	@netRevenue = NetRevenue,
	@netCost = NetCost,
	@proposedCost = ProposedCost,
	@ptdCost = PTDCost,
	@proposedMarginPrecent = PropsoedMarginPrecent,
	@revisedMarginPrecent = RevisedMarginPrecent
	FROM IPMS_TBL_Budget_IntermediateResult WHERE projectId = @projectId AND ProjectBudgetId = @projectBudgetId AND IsEproject = 0;
	
	-- set E-Project parameters
	SELECT 
	@eProposedMarginPrecent = PropsoedMarginPrecent,
	@eFirstMarginPrecent = FirstMarginPrecent,
	@eLatestMarginPrecent = RevisedMarginPrecent,
	@eVarMarginPrecent = VarianceMarginPrecent,
	@eVarMarginErosion = MarginErosion,
	@eVarMargin = VarianceMargin
	FROM IPMS_TBL_Budget_IntermediateResult WHERE projectId = @projectId AND ProjectBudgetId = @projectBudgetId AND IsEproject = 1;
	
	DECLARE @sqlstr VARCHAR(1000);
	DECLARE @temp VARCHAR(1000);
	DECLARE @tempResult BIT
	DECLARE @actionId INT,@finalActionId INT = -1;
	
	SET @sqlstr = 'DECLARE @nullComeCs BIT = '+CONVERT(VARCHAR,@nullComeCs)+',@argementStatus VARCHAR(50) = '+CONVERT(VARCHAR,@argementStatus)+',@isComeCs BIT ='+CONVERT(VARCHAR,@isComeCs)+';';
	SET @sqlstr = @sqlstr +'DECLARE @netRevenue DECIMAL = '+CONVERT(VARCHAR,@netRevenue)+',@netCost DECIMAL = '+CONVERT(VARCHAR,@netCost)+',@proposedCost DECIMAL = '+CONVERT(VARCHAR,@proposedCost)+',@ptdCost DECIMAL = '+CONVERT(VARCHAR,@ptdCost)+',@proposedMarginPrecent DECIMAL = '+CONVERT(VARCHAR,@proposedMarginPrecent)+',@revisedMarginPrecent DECIMAL = '+CONVERT(VARCHAR,@revisedMarginPrecent)+';';
	SET @sqlstr = @sqlstr +'DECLARE @eProposedMarginPrecent DECIMAL = '+CONVERT(VARCHAR,@eProposedMarginPrecent)+',@eFirstMarginPrecent DECIMAL = '+CONVERT(VARCHAR,@eFirstMarginPrecent)+',@eLatestMarginPrecent DECIMAL = '+CONVERT(VARCHAR,@eLatestMarginPrecent)+',@eVarMarginPrecent DECIMAL = '+CONVERT(VARCHAR,@eVarMarginPrecent)+',@eVarMarginErosion DECIMAL = '+CONVERT(VARCHAR,@eVarMarginErosion)+',@eVarMargin DECIMAL = '+CONVERT(VARCHAR,@eVarMargin)+';';
	
	DECLARE cur CURSOR FOR SELECT ActionId FROM IPMS_TBL_Approval_Action_Setup WHERE IsEnd = 1 AND IsActive = 1;
	OPEN cur
	FETCH NEXT FROM cur INTO @actionId
	WHILE @@FETCH_STATUS = 0 
		BEGIN
			SELECT @temp = [dbo].[uf_GetAllConditionByActionId](@actionId);
			SET @temp = 'IF '+@temp+' > 1 BEGIN	SET @tempResult= 1;END else BEGIN  SET @tempResult = 0;END'
			PRINT @temp;
			SET @temp = @sqlstr + @temp;
			PRINT @temp;
			exec(@temp);
			IF(@tempResult = 1)
			BEGIN
				SET @finalActionId = @actionId;
				break;
			END			
			FETCH NEXT FROM cur INTO @actionId
		END
	CLOSE cur
	DEALLOCATE cur;	
	SELECT * FROM IPMS_TBL_Approval_Action_Setup WHERE ActionId = @finalActionId;
END
GO

-- test function :SELECT * FROM uf_GetAllChildId(3)
-- --
-- Created Date:
-- Created By:
-- --
CREATE FUNCTION [dbo].[uf_GetAllChildId] (@pid INT)
RETURNS @t TABLE(ID INT)
AS
BEGIN
	INSERT @t SELECT f.ActionId FROM IPMS_TBL_Approval_Action_Setup as f WHERE f.PID = @pid;
	WHILE @@rowcount <> 0
	BEGIN
		INSERT @t SELECT A.ActionId FROM IPMS_TBL_Approval_Action_Setup as A INNER JOIN @t b
		ON A.PID = b.id AND 
		NOT EXISTS(SELECT 1 FROM @t WHERE id = A.ActionId)
	END
	RETURN
END
GO

CREATE FUNCTION [dbo].[uf_GetAllConditionByActionId] (@actionid INT)
RETURNS VARCHAR(1000)
AS
BEGIN
	DECLARE @t TABLE(ID INT)
	INSERT @t SELECT PID FROM IPMS_TBL_Approval_Action_Setup WHERE ActionId = @actionId;
	WHILE(@@rowcount <> 0)
	BEGIN
		INSERT @t SELECT PID FROM IPMS_TBL_Approval_Action_Setup as A INNER JOIN @t B
		ON a.ActionId = B.Id AND
		NOT EXISTS (SELECT 1 FROM @t WHERE ID = A.PID);
	END
	DECLARE @sqlstr VARCHAR(MAX);
	DECLARE @temp VARCHAR(1000);
	SELECT @temp = '('+Condition+')' FROM IPMS_TBL_Approval_Action_Setup as tbAction
	LEFT JOIN IPMS_TBL_Approval_Condition_Setup as tbCondition
	ON tbAction.ConditionId = tbCondition.ConditionId
	WHERE tbAction.ActionId = @actionId;
	Set @sqlstr = @temp;
	
	DECLARE @cid INT
	
	DECLARE cur CURSOR FOR SELECT * FROM @t
	OPEN cur;
	FETCH NEXT FROM cur INTO @cid
	WHILE @@FETCH_STATUS = 0 AND @cid <> 0
	BEGIN
		SELECT @temp = ' AND ('+Condition+')' FROM IPMS_TBL_Approval_Action_Setup as tbAction
		LEFT JOIN IPMS_TBL_Approval_Condition_Setup as tbCondition
		ON tbAction.ConditionId = tbCondition.ConditionId
		WHERE tbAction.ActionId = @cid;
		SET @sqlstr = @sqlstr + @temp;
		FETCH NEXT FROM cur INTO @cid
	END
	
	RETURN @sqlstr;
END
GO

CREATE FUNCTION [dbo].[uf_GetAllParentId] (@actionId INT)
RETURNS @t TABLE(ID INT)
AS
BEGIN
	INSERT @t SELECT PID FROM IPMS_TBL_Approval_Action_Setup WHERE ActionId = @actionId;
	WHILE(@@rowcount <> 0)
	BEGIN
		INSERT @t SELECT PID FROM IPMS_TBL_Approval_Action_Setup as A INNER JOIN @t B
		ON a.ActionId = B.Id AND
		NOT EXISTS (SELECT 1 FROM @t WHERE ID = A.PID);
	END
	RETURN
END
GO