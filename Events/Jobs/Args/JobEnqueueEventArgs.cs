using System.ComponentModel;
using practice_api.Events.Jobs.Models;

namespace practice_api.Events.Jobs.Args;

public class JobEnqueueEventArgs : CancelEventArgs
{
    public Job Job { get; set; }
}