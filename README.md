# cron.net
CRON.NET Engine


A CRON expression is a string comprising five or six fields separated by white space that represents a set of times, normally as a schedule to execute some routine.

```
 ┌───────────── minute (0 - 59)
 │ ┌───────────── hour (0 - 23)
 │ │ ┌───────────── day of month (1 - 31)
 │ │ │ ┌───────────── month (1 - 12)
 │ │ │ │ ┌───────────── day of week (0 - 6) (Sunday to Saturday;
 │ │ │ │ │                                       7 is also Sunday on some systems)
 │ │ │ │ │
 │ │ │ │ │
 * * * * *  command to execute
(0 0 1 1 *) @yearly             Run once a year at midnight of 1 January
(0 0 1 * *) @monthly            Run once a month at midnight of the first day of the month
(0 0 * * 0) @weekly             Run once a week at midnight on Sunday morning
(0 0 * * *) @daily              Run once a day at midnight
(0 * * * *) @hourly             Run once an hour at the beginning of the hour
```

| Field          | Req. | Allowed Values              | Allowed characters | Remarks  |
|:---------------|:-----|:----------------------------|:-------------------|:---------|
| Minutes        | Yes  | ```0-59```	              |```* , -```         |          |
| Hours          | Yes  | ```0-23```                  |```* , -```         |          |
| Day of month   | Yes  | ```1-31```                  |```* , - ? L W```   |          |
| Month          | Yes  | ```1-12``` or ```JAN-DEC``` |```* , -```         |          |
| Day of week    | Yes  | ```0-6``` or ```SUN-SAT```  |```* , - ? L```     |          |
| Year           | No   | ```1-5000```                |```* , -```         | Not Sup. |

**Special characters**

Comma ( ```,``` )
> Commas are used to separate items of a list. For example, using "MON,WED,FRI" in the 5th field (day of week) means Mondays, Wednesdays and Fridays.

Hyphen ( ```-``` )
> Hyphens define ranges. For example, 2000-2010 indicates every year between 2000 and 2010, inclusive.

Hash ( ```#``` )
> '#' is allowed for the day-of-week field, and must be followed by a number between one and five. It allows you to specify constructs such as "the second Friday" of a given month. For example, entering ```5#3``` in the day-of-week field corresponds to the third Friday of every month.

```L```
> 'L' stands for "last". When used in the day-of-week field, it allows you to specify constructs such as "the last Friday" (```5L```) of a given month. In the day-of-month field, it specifies the last day of the month.

Question mark ( ```?``` )
> Not supported
> In some implementations, used instead of (```*```) for leaving either day-of-month or day-of-week blank. Other cron implementations substitute "?" with the start-up time of the cron daemon, so that ```? ? * * * *``` would be updated to ```25 8 * * * *``` if cron started-up on 8:25am, and would run at this time every day until restarted again.

```W```
> The 'W' character is allowed for the day-of-month field. This character is used to specify the weekday (Monday-Friday) nearest the given day. As an example, if you were to specify ```15W``` as the value for the day-of-month field, the meaning is: *the nearest weekday to the 15th of the month*. So, if the 15th is a Saturday, the trigger fires on Friday the 14th. If the 15th is a Sunday, the trigger fires on Monday the 16th. If the 15th is a Tuesday, then it fires on Tuesday the 15th. However, if you specify "1W" as the value for day-of-month, and the 1st is a Saturday, the trigger fires on Monday the 3rd, as it does not 'jump' over the boundary of a month's days. The 'W' character can be specified only when the day-of-month is a single day, not a range or list of days.
