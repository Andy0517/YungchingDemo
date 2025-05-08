CREATE TABLE T_DropdownOptions (
    Unicode NVARCHAR(50) PRIMARY KEY,  -- Unicode 欄位作為主鍵
    GroupName NVARCHAR(50) NOT NULL,  -- 下拉選單組別名稱
    OptionCode NVARCHAR(10) NOT NULL, -- 選項代號
    OptionName NVARCHAR(50) NOT NULL  -- 選項名稱
);