# cron.net
CRON.NET Engine


A CRON expression is a string comprising five or six fields separated by white space that represents a set of times, normally as a schedule to execute some routine.

`
 ┌───────────── minute (0 - 59)
 │ ┌───────────── hour (0 - 23)
 │ │ ┌───────────── day of month (1 - 31)
 │ │ │ ┌───────────── month (1 - 12)
 │ │ │ │ ┌───────────── day of week (0 - 6) (Sunday to Saturday;
 │ │ │ │ │                                       7 is also Sunday on some systems)
 │ │ │ │ │
 │ │ │ │ │
 * * * * *  command to execute
`

| Field          | Req. | Allowed Values  | Allowed chars | Remarks  |
|----------------|------|-----------------|---------------|----------|
| Minutes        | Yes  | 0-59	          | * , -         |          |
| Hours          | Yes  | 0-23            | * , -         |          |
| Day of month   | Yes  | 1-31            | * , - ? L W   |          |
| Month          | Yes  | 1-12 or JAN-DEC | * , -         |          |
| Day of week    | Yes  | 0-6 or SUN-SAT  | * , - ? L     |          |
| Year           | No   | 1-5000          | * , -         | Not Sup. |

(0 0 1 1 *)	@yearly		Run once a year at midnight of 1 January
(0 0 1 * *)	@monthly	Run once a month at midnight of the first day of the month
(0 0 * * 0)	@weekly		Run once a week at midnight on Sunday morning
(0 0 * * *)	@daily		Run once a day at midnight
(0 * * * *) @hourly		Run once an hour at the beginning of the hour

