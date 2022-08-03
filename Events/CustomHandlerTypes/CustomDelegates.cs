namespace practice_api.Events.CustomHandlerTypes;

public delegate Task AsyncEventHandler<in TArgs>(object sender, TArgs e);