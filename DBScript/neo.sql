/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2018/5/31 15:39:34                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseMemberOrganization') and o.name = 'FK_BASEMEMB_FK_MEMBER_MEMBER')
alter table BaseMemberOrganization
   drop constraint FK_BASEMEMB_FK_MEMBER_MEMBER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseMemberOrganization') and o.name = 'FK_BASEMEMB_FK_MEMBER_ORGANIZA')
alter table BaseMemberOrganization
   drop constraint FK_BASEMEMB_FK_MEMBER_ORGANIZA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseModule') and o.name = 'FK_BASEMODU_FK_MODULE_BASEMODU')
alter table BaseModule
   drop constraint FK_BASEMODU_FK_MODULE_BASEMODU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BasePermission') and o.name = 'FK_BASEPERM_FK_PERMIS_BASEMODU')
alter table BasePermission
   drop constraint FK_BASEPERM_FK_PERMIS_BASEMODU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseRoleModule') and o.name = 'FK_BASEROLE_FK_ROLEMO_BASEMODU')
alter table BaseRoleModule
   drop constraint FK_BASEROLE_FK_ROLEMO_BASEMODU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseRoleModule') and o.name = 'FK_BASEROLE_FK_ROLEMO_BASEROLE')
alter table BaseRoleModule
   drop constraint FK_BASEROLE_FK_ROLEMO_BASEROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseRoleOrganization') and o.name = 'FK_BASEROLE_FK_ROLEOR_ORGANIZA')
alter table BaseRoleOrganization
   drop constraint FK_BASEROLE_FK_ROLEOR_ORGANIZA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseRoleOrganization') and o.name = 'FK_BASEROLE_FK_ROLEOR_BASEROLE')
alter table BaseRoleOrganization
   drop constraint FK_BASEROLE_FK_ROLEOR_BASEROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseRolePermission') and o.name = 'FK_BASEROLE_FK_ROLEPE_BASEPERM')
alter table BaseRolePermission
   drop constraint FK_BASEROLE_FK_ROLEPE_BASEPERM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BaseRolePermission') and o.name = 'FK_BASEROLE_FK_ROLEPE_BASEROLE')
alter table BaseRolePermission
   drop constraint FK_BASEROLE_FK_ROLEPE_BASEROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Member') and o.name = 'FK_MEMBER_FK_MEMBER_BASEROLE')
alter table Member
   drop constraint FK_MEMBER_FK_MEMBER_BASEROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Member') and o.name = 'FK_MEMBER_FK_MEMBER_PROFILE')
alter table Member
   drop constraint FK_MEMBER_FK_MEMBER_PROFILE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Organization') and o.name = 'FK_ORGANIZA_FK_ORGANI_ORGANIZA')
alter table Organization
   drop constraint FK_ORGANIZA_FK_ORGANI_ORGANIZA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaseMemberOrganization')
            and   type = 'U')
   drop table BaseMemberOrganization
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaseModule')
            and   type = 'U')
   drop table BaseModule
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BasePermission')
            and   type = 'U')
   drop table BasePermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaseRole')
            and   type = 'U')
   drop table BaseRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaseRoleModule')
            and   type = 'U')
   drop table BaseRoleModule
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaseRoleOrganization')
            and   type = 'U')
   drop table BaseRoleOrganization
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaseRolePermission')
            and   type = 'U')
   drop table BaseRolePermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Member')
            and   type = 'U')
   drop table Member
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Organization')
            and   type = 'U')
   drop table Organization
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Profile')
            and   type = 'U')
   drop table Profile
go

/*==============================================================*/
/* Table: BaseMemberOrganization                                */
/*==============================================================*/
create table BaseMemberOrganization (
   Id                   int                  not null,
   MemberId             int                  null,
   OrganizationId       int                  null,
   constraint PK_BASEMEMBERORGANIZATION primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组织表',
   'user', @CurrentUser, 'table', 'BaseMemberOrganization'
go

/*==============================================================*/
/* Table: BaseModule                                            */
/*==============================================================*/
create table BaseModule (
   Id                   int                  identity,
   ParentId             int                  null,
   Code                 varchar(64)          not null,
   Name                 varchar(64)          null,
   IsPublic             bit                  not null,
   Expand               bit                  not null,
   IsLeaf               bit                  not null,
   NavigateUrl          varchar(256)         null,
   Priority             int                  not null,
   Deleted              bit                  not null,
   Remark               varchar(1024)        null,
   CreatedDate          datetime             not null,
   CreatedBy            varchar(128)         not null,
   CreatedById          int                  null,
   ModifyDate           datetime             not null,
   ModifyBy             varchar(128)         not null,
   ModifyById           int                  null,
   constraint PK_BASEMODULE primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单表',
   'user', @CurrentUser, 'table', 'BaseModule'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单编号',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'Code'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单名称',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'Name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否公开',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'IsPublic'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否展开',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'Expand'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单节点',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'IsLeaf'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '导航地址',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'NavigateUrl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '优先级',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'Priority'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'Deleted'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'Remark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'CreatedDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'CreatedById'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'ModifyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'ModifyBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人Id',
   'user', @CurrentUser, 'table', 'BaseModule', 'column', 'ModifyById'
go

/*==============================================================*/
/* Table: BasePermission                                        */
/*==============================================================*/
create table BasePermission (
   Id                   int                  not null,
   ParentModuleId       int                  null,
   Code                 varchar(64)          not null,
   Name                 varchar(128)         not null,
   Remark               varchar(1024)        null,
   CreatedDate          datetime             not null,
   CreatedBy            varchar(128)         not null,
   CreatedById          int                  null,
   ModifyDate           datetime             not null,
   ModifyBy             varchar(128)         not null,
   ModifyById           int                  null,
   constraint PK_BASEPERMISSION primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '功能表',
   'user', @CurrentUser, 'table', 'BasePermission'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '功能编号',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'Code'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '功能名称',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'Name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'Remark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'CreatedDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'CreatedById'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'ModifyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'ModifyBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人Id',
   'user', @CurrentUser, 'table', 'BasePermission', 'column', 'ModifyById'
go

/*==============================================================*/
/* Table: BaseRole                                              */
/*==============================================================*/
create table BaseRole (
   Id                   int                  identity,
   Code                 varchar(128)         null,
   Name                 varchar(256)         null,
   IsPublish            bit                  not null,
   Enabled              bit                  not null,
   Deleted              bit                  not null,
   Remark               varchar(1024)        null,
   CreatedDate          datetime             not null,
   CreatedBy            varchar(128)         not null,
   CreatedById          int                  null,
   ModifyDate           datetime             not null,
   ModifyBy             varchar(128)         not null,
   ModifyById           int                  null,
   constraint PK_BASEROLE primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户角色表',
   'user', @CurrentUser, 'table', 'BaseRole'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色编号',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'Code'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色名称',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'Name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否公开',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'IsPublish'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否激活',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'Enabled'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'Deleted'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'Remark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'CreatedDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'CreatedById'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'ModifyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'ModifyBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人Id',
   'user', @CurrentUser, 'table', 'BaseRole', 'column', 'ModifyById'
go

/*==============================================================*/
/* Table: BaseRoleModule                                        */
/*==============================================================*/
create table BaseRoleModule (
   Id                   int                  not null,
   RoleId               int                  null,
   ModuleId             int                  null,
   constraint PK_BASEROLEMODULE primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色菜单表',
   'user', @CurrentUser, 'table', 'BaseRoleModule'
go

/*==============================================================*/
/* Table: BaseRoleOrganization                                  */
/*==============================================================*/
create table BaseRoleOrganization (
   Id                   int                  not null,
   RoleId               int                  null,
   OrganizationId       int                  null,
   constraint PK_BASEROLEORGANIZATION primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色组织表',
   'user', @CurrentUser, 'table', 'BaseRoleOrganization'
go

/*==============================================================*/
/* Table: BaseRolePermission                                    */
/*==============================================================*/
create table BaseRolePermission (
   Id                   int                  not null,
   RoleId               int                  null,
   PermissionId         int                  null,
   constraint PK_BASEROLEPERMISSION primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色功能关系表',
   'user', @CurrentUser, 'table', 'BaseRolePermission'
go

/*==============================================================*/
/* Table: Member                                                */
/*==============================================================*/
create table Member (
   Id                   int                  not null,
   Uid                  varchar(128)         not null,
   Password             varchar(256)         not null,
   Salt                 varchar(32)          not null,
   ProfileId            int                  null,
   RoleId               int                  null,
   OrganizationId       int                  null,
   AccessToken          varchar(256)         null,
   AccessTokenExpiry    datetime             null,
   CreatedDate          datetime             not null,
   CreatedBy            varchar(128)         not null,
   CreatedById          int                  null,
   ModifyDate           datetime             not null,
   ModifyBy             varchar(128)         not null,
   ModifyById           int                  null,
   constraint PK_MEMBER primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户登录表',
   'user', @CurrentUser, 'table', 'Member'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户名称',
   'user', @CurrentUser, 'table', 'Member', 'column', 'Uid'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户密码',
   'user', @CurrentUser, 'table', 'Member', 'column', 'Password'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户密钥',
   'user', @CurrentUser, 'table', 'Member', 'column', 'Salt'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户信息',
   'user', @CurrentUser, 'table', 'Member', 'column', 'ProfileId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户角色',
   'user', @CurrentUser, 'table', 'Member', 'column', 'RoleId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '组织架构Id',
   'user', @CurrentUser, 'table', 'Member', 'column', 'OrganizationId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Token码',
   'user', @CurrentUser, 'table', 'Member', 'column', 'AccessToken'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '有效时间',
   'user', @CurrentUser, 'table', 'Member', 'column', 'AccessTokenExpiry'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', @CurrentUser, 'table', 'Member', 'column', 'CreatedDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'Member', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', @CurrentUser, 'table', 'Member', 'column', 'CreatedById'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', @CurrentUser, 'table', 'Member', 'column', 'ModifyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', @CurrentUser, 'table', 'Member', 'column', 'ModifyBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人Id',
   'user', @CurrentUser, 'table', 'Member', 'column', 'ModifyById'
go

/*==============================================================*/
/* Table: Organization                                          */
/*==============================================================*/
create table Organization (
   Id                   int                  identity,
   Code                 varchar(64)          not null,
   Name                 varchar(64)          not null,
   ParentId             int                  null,
   CategoryId           int                  null,
   IsPublic             bit                  not null,
   Enabled              bit                  not null,
   Deleted              bit                  not null,
   Remark               varchar(1024)        null,
   CreatedDate          datetime             not null,
   CreatedBy            varchar(128)         not null,
   CreatedById          int                  null,
   ModifyDate           datetime             not null,
   ModifyBy             varchar(128)         not null,
   ModifyById           int                  null,
   constraint PK_ORGANIZATION primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '组织结构',
   'user', @CurrentUser, 'table', 'Organization'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '组织编号',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'Code'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '组织名称',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'Name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '组织分类',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'CategoryId'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否公开',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'IsPublic'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否激活',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'Enabled'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'Deleted'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'Remark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'CreatedDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'CreatedById'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'ModifyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'ModifyBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人Id',
   'user', @CurrentUser, 'table', 'Organization', 'column', 'ModifyById'
go

/*==============================================================*/
/* Table: Profile                                               */
/*==============================================================*/
create table Profile (
   Id                   int                  identity,
   NickName             varchar(128)         null,
   Name                 varchar(64)          null,
   Gender               int                  not null,
   Birthday             datetime             null,
   Tel                  varchar(64)          null,
   Email                varchar(128)         null,
   Remark               varchar(1024)        null,
   CreatedDate          datetime             not null,
   CreatedBy            varchar(128)         not null,
   CreatedById          int                  null,
   ModifyDate           datetime             not null,
   ModifyBy             varchar(128)         not null,
   ModifyById           int                  null,
   constraint PK_PROFILE primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户信息表',
   'user', @CurrentUser, 'table', 'Profile'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '昵称',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'NickName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '姓名',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'Name'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '性别',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'Gender'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '生日',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'Birthday'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '电话',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'Tel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邮箱',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'Email'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'Remark'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建日期',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'CreatedDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'CreatedBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人Id',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'CreatedById'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新日期',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'ModifyDate'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'ModifyBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '更新人Id',
   'user', @CurrentUser, 'table', 'Profile', 'column', 'ModifyById'
go

alter table BaseMemberOrganization
   add constraint FK_BASEMEMB_FK_MEMBER_MEMBER foreign key (MemberId)
      references Member (Id)
go

alter table BaseMemberOrganization
   add constraint FK_BASEMEMB_FK_MEMBER_ORGANIZA foreign key (OrganizationId)
      references Organization (Id)
go

alter table BaseModule
   add constraint FK_BASEMODU_FK_MODULE_BASEMODU foreign key (ParentId)
      references BaseModule (Id)
go

alter table BasePermission
   add constraint FK_BASEPERM_FK_PERMIS_BASEMODU foreign key (ParentModuleId)
      references BaseModule (Id)
go

alter table BaseRoleModule
   add constraint FK_BASEROLE_FK_ROLEMO_BASEMODU foreign key (ModuleId)
      references BaseModule (Id)
go

alter table BaseRoleModule
   add constraint FK_BASEROLE_FK_ROLEMO_BASEROLE foreign key (RoleId)
      references BaseRole (Id)
go

alter table BaseRoleOrganization
   add constraint FK_BASEROLE_FK_ROLEOR_ORGANIZA foreign key (OrganizationId)
      references Organization (Id)
go

alter table BaseRoleOrganization
   add constraint FK_BASEROLE_FK_ROLEOR_BASEROLE foreign key (RoleId)
      references BaseRole (Id)
go

alter table BaseRolePermission
   add constraint FK_BASEROLE_FK_ROLEPE_BASEPERM foreign key (PermissionId)
      references BasePermission (Id)
go

alter table BaseRolePermission
   add constraint FK_BASEROLE_FK_ROLEPE_BASEROLE foreign key (RoleId)
      references BaseRole (Id)
go

alter table Member
   add constraint FK_MEMBER_FK_MEMBER_BASEROLE foreign key (RoleId)
      references BaseRole (Id)
go

alter table Member
   add constraint FK_MEMBER_FK_MEMBER_PROFILE foreign key (ProfileId)
      references Profile (Id)
go

alter table Organization
   add constraint FK_ORGANIZA_FK_ORGANI_ORGANIZA foreign key (ParentId)
      references Organization (Id)
go

