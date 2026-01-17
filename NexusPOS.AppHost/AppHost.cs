var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.NexusPOS_Shell>("nexuspos-shell");

builder.Build().Run();
