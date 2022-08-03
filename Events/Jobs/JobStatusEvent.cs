using practice_api.Events.CustomHandlerTypes;
using practice_api.Events.Jobs.Args;
using practice_api.Events.Jobs.Models;

namespace practice_api.Events.Jobs;

public class JobStatusEvent
{
    public event AsyncEventHandler<JobStatusEventArgs>? JobStatusChanged;

    public async void UpdateJobStatusAsync(JobStatusEnum status)
    {
        await OnJobStatusChanged(status);
    }

    protected async Task OnJobStatusChanged(JobStatusEnum status)
    {
        if (JobStatusChanged == null) return;
        
        await JobStatusChanged.Invoke(this, new JobStatusEventArgs { Status = status });
    }
}