using practice_api.Events.Jobs.Args;

namespace practice_api.Events.Jobs.Subscribers.Interfaces;

public interface IJobSubscriber
{
    public Task OnJobEnqueued(object source, JobEnqueueEventArgs args);
    public Task OnJobPreExecute(object source, JobEnqueueEventArgs args);
    public Task OnJobExecute(object source, JobEnqueueEventArgs args);
    public Task OnJobPostExecute(object source, JobEnqueueEventArgs args);
    public Task OnJobExecuted(object source, JobEnqueueEventArgs args);
}