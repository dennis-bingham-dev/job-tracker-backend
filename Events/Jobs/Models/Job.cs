namespace practice_api.Events.Jobs.Models;

public class Job
{
    public int ID { get; set; }
    public dynamic Payload { get; set; }
    public JobStepEnum Step { get; set; } = JobStepEnum.Enqueue;
    public JobStatusEnum Status { get; set; } = JobStatusEnum.NotRun;
}