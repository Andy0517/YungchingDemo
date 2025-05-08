CREATE TABLE T_ESTATE_Data (
    ProjectID VARCHAR(10) NOT NULL PRIMARY KEY, -- �M�׽s��
    ProjectName NVARCHAR(40) NOT NULL,          -- �M�צW��
    Type VARCHAR(2) NOT NULL,                  -- �Ыκ��� (01: ��v, 02: �ӷ~, 03: �u�~)
    Address NVARCHAR(40) NOT NULL,              -- �ЫΦa�}
    Square DECIMAL(6, 2) NOT NULL,              -- �ЫΩW�� (�̤j�� 999.99)
    PublicRatio DECIMAL(4, 2) NOT NULL,         -- ���]�� (%) (�̤j�� 99.99)
    Price INT NOT NULL,                         -- �Ыλ��� (�U) (�̤j�� 99990000)
    HaveSpace VARCHAR(1) NOT NULL,                     -- �O�_�������� (1: �O, 0: �_)
    Remark NVARCHAR(MAX) NULL                   -- �Ƶ�
);