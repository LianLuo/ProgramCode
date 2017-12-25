CREATE TABLE `actions` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `ActionName` varchar(254) DEFAULT NULL COMMENT '功能名称',
  `Action_Desc` varchar(254) DEFAULT NULL COMMENT '功能描述',
  `Action_Url` varchar(254) DEFAULT NULL COMMENT '功能连接',
  `Action_Ico` varchar(254) DEFAULT NULL COMMENT '功能图标',
  `IsDel` bit(1) DEFAULT NULL COMMENT '是否删除',
  `CreateID` int(11) DEFAULT NULL COMMENT '创建人',
  `CreateTime` int(11) DEFAULT NULL COMMENT '创建时间',
  `ModifyID` int(11) DEFAULT NULL COMMENT '修改人',
  `ModifyTime` int(11) DEFAULT NULL COMMENT '修改时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO

CREATE TABLE `buildings` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `BuildingName` varchar(254) DEFAULT NULL COMMENT '建筑物名称',
  `BuildingNo` int(11) DEFAULT NULL COMMENT '建筑物编号',
  `SchoolNo` int(11) DEFAULT NULL COMMENT '所在校区',
  `Position` varchar(254) DEFAULT NULL COMMENT '具体位置',
  `Responsibility` int(11) DEFAULT NULL COMMENT '负责人编号',
  `CreateID` int(11) DEFAULT NULL COMMENT '创建人',
  `CreateTime` int(11) DEFAULT NULL COMMENT '创建时间',
  `ModifyTime` int(11) DEFAULT NULL COMMENT '修改时间',
  `ModifyID` int(11) DEFAULT NULL COMMENT '修改人',
  `IsDel` bit(1) DEFAULT b'0' COMMENT '是否删除',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO

CREATE TABLE `customer_role` (
  `UserID` int(11) DEFAULT NULL,
  `RoleID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO

CREATE TABLE `customers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `LoginName` varchar(254) DEFAULT NULL COMMENT '登录名',
  `UserName` varchar(254) DEFAULT NULL COMMENT '用户名',
  `LoginPwd` varchar(254) DEFAULT NULL COMMENT '登录密码',
  `Tel` varchar(254) DEFAULT NULL COMMENT '电话号码',
  `Gender` bit(1) DEFAULT NULL COMMENT '性别',
  `Brithday` date DEFAULT NULL COMMENT '出生日期',
  `Address` varchar(254) DEFAULT NULL COMMENT '家庭住址',
  `DepartID` int(11) DEFAULT NULL COMMENT '所属部门',
  `Social_Role` varchar(254) DEFAULT NULL COMMENT '社会角色',
  `IsActivit` bit(1) DEFAULT NULL COMMENT '是否激活',
  `IsDel` bit(1) DEFAULT NULL COMMENT '是否删除',
  `CreateTime` int(11) DEFAULT NULL COMMENT '创建时间',
  `CreateID` int(11) DEFAULT NULL COMMENT '创建人',
  `ModifyTime` int(11) DEFAULT NULL COMMENT '修改时间',
  `ModifyID` int(11) DEFAULT NULL COMMENT '修改人',
  `QQ` varchar(254) DEFAULT NULL COMMENT 'QQ 号码',
  `Email` varchar(254) DEFAULT NULL COMMENT '邮箱',
  `Home_Tel` varchar(254) DEFAULT NULL COMMENT '家里电话',
  `Emergency` varchar(254) DEFAULT NULL COMMENT '紧急联系人',
  `Emergency_Tel` varchar(254) DEFAULT NULL COMMENT '紧急电话',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO

CREATE TABLE `drugcabs` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `CabName` varchar(254) DEFAULT NULL COMMENT '药瓶柜名称',
  `CabNo` varchar(254) DEFAULT NULL COMMENT '编号',
  `BuildingID` int(11) DEFAULT NULL COMMENT '所在大楼',
  `LabID` int(11) DEFAULT NULL COMMENT '所在实验室',
  `Cab_Desc` varchar(254) DEFAULT NULL COMMENT '储存描述',
  `Responsibility` int(11) DEFAULT NULL COMMENT '负责人',
  `CreateID` int(11) DEFAULT NULL COMMENT '创建人',
  `CreateTime` int(11) DEFAULT NULL COMMENT '创建时间',
  `ModifyID` int(11) DEFAULT NULL COMMENT '修改人',
  `ModifyTime` int(11) DEFAULT NULL COMMENT '修改时间',
  `IsDel` bit(1) DEFAULT b'0' COMMENT '是否删除',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO

CREATE TABLE `drugs` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `DrugName` varchar(254) DEFAULT NULL COMMENT '药品名称',
  `CASNO` varchar(254) DEFAULT NULL COMMENT 'CASNO',
  `MDLNO` varchar(254) DEFAULT NULL COMMENT 'MDLNO',
  `InNumber` int(11) DEFAULT NULL COMMENT '入库数量',
  `Unit` varchar(254) DEFAULT NULL COMMENT '单位',
  `Batch` varchar(254) DEFAULT NULL COMMENT '批次',
  `Codes` varchar(254) DEFAULT NULL COMMENT '条码',
  `Position` varchar(254) DEFAULT NULL COMMENT '存放位置',
  `Drug_Desc` varchar(254) DEFAULT NULL COMMENT '描述',
  `CreateTime` int(11) DEFAULT NULL COMMENT '创建时间',
  `CreateID` int(11) DEFAULT NULL COMMENT '创建人',
  `ModifyTime` int(11) DEFAULT NULL COMMENT '修改时间',
  `ModifyID` int(11) DEFAULT NULL COMMENT '修改人',
  `IsDel` bit(1) DEFAULT b'0' COMMENT '是否删除',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO

CREATE TABLE `labs` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `LabName` varchar(254) DEFAULT NULL COMMENT '实验室名称',
  `LabNo` int(11) DEFAULT NULL COMMENT '实验室编号',
  `SchoolNo` int(11) DEFAULT NULL COMMENT '所在校区',
  `Position` varchar(254) DEFAULT NULL COMMENT '位置',
  `Responsibility` int(11) DEFAULT NULL COMMENT '负责人',
  `CreateID` int(11) DEFAULT NULL COMMENT '创建人',
  `CreateTime` int(11) DEFAULT NULL COMMENT '创建时间',
  `ModifyID` int(11) DEFAULT NULL COMMENT '修改人',
  `ModifyTime` int(11) DEFAULT NULL COMMENT '修改时间',
  `IsDel` bit(1) DEFAULT b'0' COMMENT '是否删除',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO

CREATE TABLE `role_action` (
  `RoleID` int(11) DEFAULT NULL,
  `ActionID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO

CREATE TABLE `roles` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `RoleName` varchar(254) DEFAULT NULL COMMENT '角色名称',
  `Role_Desc` varchar(254) DEFAULT NULL COMMENT '角色描述',
  `Role_Ico` varchar(254) DEFAULT NULL COMMENT '角色图标',
  `CreateID` int(11) DEFAULT NULL COMMENT '创建人',
  `CreateTime` int(11) DEFAULT NULL COMMENT '创建时间',
  `ModifyID` int(11) DEFAULT NULL COMMENT '修改人',
  `ModifyTime` int(11) DEFAULT NULL COMMENT '修改时间',
  `IsDel` bit(1) DEFAULT NULL COMMENT '是否删除',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8
GO