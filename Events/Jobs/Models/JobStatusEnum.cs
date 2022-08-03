namespace practice_api.Events.Jobs.Models;

public enum JobStatusEnum
{
    NotRun,
    Running,
    Error,
    Warning,
    Completed,
    Cancelled
}