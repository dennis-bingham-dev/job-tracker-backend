using practice_api.Events.Jobs.Subscribers.Interfaces;

namespace practice_api.Events.Jobs.Helpers;

public static class SubscriptionsExtension
{
   public static void SubscribeToJob(this IJobSubscriber subscriber, JobEvent jobEvent)
   {
      jobEvent.JobEnqueued += subscriber.OnJobEnqueued;
      jobEvent.JobPreExecute += subscriber.OnJobPreExecute;
      jobEvent.JobExecute += subscriber.OnJobExecute;
      jobEvent.JobPostExecute += subscriber.OnJobPostExecute;
      jobEvent.JobExecuted += subscriber.OnJobExecuted;
   }
}