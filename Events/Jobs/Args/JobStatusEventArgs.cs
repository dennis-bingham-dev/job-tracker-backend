using System.ComponentModel;
using practice_api.Events.Jobs.Models;

namespace practice_api.Events.Jobs.Args;

public class JobStatusEventArgs : CancelEventArgs
{
    public JobStatusEnum Status { get; set; }
}