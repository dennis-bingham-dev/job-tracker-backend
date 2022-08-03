namespace practice_api.Events.Jobs.Models;

public enum JobStepEnum
{
    Enqueue,
    PreExecute,
    Execute,
    PostExecute,
    Executed
}