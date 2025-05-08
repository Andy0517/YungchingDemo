CREATE TABLE T_ESTATE_Data (
    ProjectID VARCHAR(10) NOT NULL PRIMARY KEY, -- 專案編號
    ProjectName NVARCHAR(40) NOT NULL,          -- 專案名稱
    Type VARCHAR(2) NOT NULL,                  -- 房屋種類 (01: 住宅, 02: 商業, 03: 工業)
    Address NVARCHAR(40) NOT NULL,              -- 房屋地址
    Square DECIMAL(6, 2) NOT NULL,              -- 房屋坪數 (最大值 999.99)
    PublicRatio DECIMAL(4, 2) NOT NULL,         -- 公設比 (%) (最大值 99.99)
    Price INT NOT NULL,                         -- 房屋價錢 (萬) (最大值 99990000)
    HaveSpace VARCHAR(1) NOT NULL,                     -- 是否附停車位 (1: 是, 0: 否)
    Remark NVARCHAR(MAX) NULL                   -- 備註
);