﻿
CREATE OR ALTER PROCEDURE AP2SP_PF_AG_011After
	 @HistoryID nvarchar(40)
	 ,@ContractNumber nvarchar(20)
AS
BEGIN
	SELECT '' as ProjectName, '' as CustomerName, '' as CustFullAddress, '' as ProductType, '' as ContractNumber, '' as ContractDate, '' as CompanyID, '' as CompanyName, '' as ModelHomeThai, '' as UnitNumber, '' as FloorID, '' as Area,
	'' as CustNameAdd, '' as CustFullAddressAdd, '' as CustNameTel, '' as SignDate, '' as Age, '' as ForType, '' as TypeDesc from ReportTemplate
END
GO

exec AP2SP_PF_AG_011After