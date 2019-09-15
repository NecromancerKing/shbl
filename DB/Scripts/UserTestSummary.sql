select 
FullName = ps.FirstName + ' ' + ps.LastName ,
act.ActivityName,
sua.StartDate,
sua.FinishDate,
Cnt = (select count(*) from SptUserActivityDetail suad where suad.UserActivityId = sua.Id and suad.Result is not null),
Crt = (select count(*) from SptUserActivityDetail suad where suad.UserActivityId = sua.Id and suad.Result = 1),
Wng = (select count(*) from SptUserActivityDetail suad where suad.UserActivityId = sua.Id and suad.Result = 0)
from SptUser usr
inner join Person ps on ps.Id = usr.PersonId
inner join SptUserActivity sua on sua.SptUserId = usr.Id
inner join Activity act on act.Id = sua.ActivityId
order by usr.Id, act.Id