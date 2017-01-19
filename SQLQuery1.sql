select  op.Name--, AVG(opr.ExecTimeMs)
from OperationResult as opr
left join Operation as op ON op.Id = opr.OperationID
--where opr.ArgumentCount = 1
GROUP BY op.Name
having AVG(opr.ExecTimeMs) > 7000