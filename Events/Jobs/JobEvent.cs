using practice_api.Events.CustomHandlerTypes;
using practice_api.Events.Jobs.Args;
using practice_api.Events.Jobs.Models;

namespace practice_api.Events.Jobs;

public class JobEvent
{
    private readonly ILogger<JobEvent> _logger;
    private readonly int _jobID;
    
    public JobEvent(int jobID, ILogger<JobEvent> logger)
    {
        _jobID = jobID;
        _logger = logger;
    }
    
    public event AsyncEventHandler<JobEnqueueEventArgs>? JobEnqueued; 
    public event AsyncEventHandler<JobEnqueueEventArgs>? JobPreExecute; 
    public event AsyncEventHandler<JobEnqueueEventArgs>? JobExecute; 
    public event AsyncEventHandler<JobEnqueueEventArgs>? JobPostExecute; 
    public event AsyncEventHandler<JobEnqueueEventArgs>? JobExecuted; 
   
    public async void RunAsync(Job job)
    { 
        Console.WriteLine($"Enqueuing Job: {job.ID}\n");
        Thread.Sleep(2000);

        await OnJobEnqueued(job);
    }
    
    protected async Task OnJobEnqueued(Job job)
    {
        try
        {
            if (JobEnqueued == null) throw new Exception("");
            
            job.Status = JobStatusEnum.Running;
            await JobEnqueued.Invoke(this, new JobEnqueueEventArgs { Job = job });
            await OnJobPreExecute(job);
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while enqueueing job: {job.ID} with {e}");
            Console.WriteLine(e);
        }
    }
    
    
    protected async Task OnJobPreExecute(Job job)
    {
        try
        {
            if (JobPreExecute == null) throw new Exception("");
            
            job.Step = JobStepEnum.PreExecute;
            await JobPreExecute.Invoke(this, new JobEnqueueEventArgs { Job = job });
            await OnJobExecute(job);
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred before executing job: {job.ID} with: {e}");
            Console.WriteLine(e);
        }
    }
    
    protected async Task OnJobExecute(Job job)
    {
        try
        {
            if (JobExecute == null) throw new Exception("");
            
            job.Step = JobStepEnum.Execute;
            await JobExecute.Invoke(this, new JobEnqueueEventArgs { Job = job });
            await OnJobPostExecute(job);
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while executing job: {job.ID} with: {e}");
            Console.WriteLine(e);
        }
    }
    
    protected async Task OnJobPostExecute(Job job)
    {
        try
        {
            if (JobPostExecute == null) throw new Exception("");
            
            job.Step = JobStepEnum.PostExecute;
            await JobPostExecute.Invoke(this, new JobEnqueueEventArgs { Job = job });
            await OnJobExecuted(job);
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred after executing job: {job.ID} with: {e}");
            Console.WriteLine(e);
        }
    }
    
    protected async Task OnJobExecuted(Job job)
    {
        try
        {
            if (JobExecuted == null) throw new Exception("");
            
            job.Step = JobStepEnum.Executed;
            job.Status = JobStatusEnum.Completed;
            await JobExecuted.Invoke(this, new JobEnqueueEventArgs { Job = job });
        }
        catch (Exception e)
        {
            _logger.LogError($"An error occurred while completing job: {job.ID} with: {e}");
            Console.WriteLine(e);
        }
    }

    private static Task CompleteTask() => Task.CompletedTask;
}