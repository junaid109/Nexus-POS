var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");

var kafka = builder.AddKafka("kafka")
                   .WithDataVolume()
                   .WithLifetime(ContainerLifetime.Persistent);

var sql = builder.AddSqlServer("sqlserver")
                 .WithDataVolume()
                 .WithLifetime(ContainerLifetime.Persistent)
                 .AddDatabase("ledgerdb");

var gateway = builder.AddProject<Projects.ApexLedger_PaymentGateway>("paymentgateway")
                     .WithReference(redis)
                     .WithReference(kafka)
                     .WithExternalHttpEndpoints();

var settlement = builder.AddProject<Projects.ApexLedger_SettlementService>("settlementservice")
                        .WithReference(kafka)
                        .WithReference(sql);

var reconciliation = builder.AddProject<Projects.ApexLedger_ReconciliationWorker>("reconciliationworker")
                            .WithReference(sql);

builder.Build().Run();
