# ApexLedger Implementation Plan

## Overview
ApexLedger is a high-performance, event-driven payment ledger system built on .NET 9/10. It uses a microservices architecture with Kafka for choreography, SQL Server for the ledger, and Redis for idempotency. The system orchestrates services using .NET Aspire and ensures resilience and observability through Polly and OpenTelemetry.

## Architecture
- **Microservices**:
  - `ApexLedger.PaymentGateway`: Web API entry point, idempotent with Redis.
  - `ApexLedger.SettlementService`: Event-driven worker (Kafka), Transactional Outbox.
  - `ApexLedger.ReconciliationWorker`: Background service for daily check & balance.
- **Data Stores**: SQL Server (Ledger), Redis (Idempotency cache).
- **Messaging**: Kafka (Choreography).
- **Observability**: OpenTelemetry, Jaeger.
- **Orchestration**: .NET Aspire.

## Phases

### Phase 1: Foundation & Infrastructure
- [ ] Create Solution `ApexLedger.sln`.
- [ ] Create `docker-compose.yml` for external dependencies (SQL, Kafka, Zookeeper, Redis, Jaeger).
- [ ] Scaffold projects with Clean Architecture (Domain, Application, Infrastructure, API/Worker) for:
  - `ApexLedger.PaymentGateway`
  - `ApexLedger.SettlementService`
  - `ApexLedger.ReconciliationWorker`
- [ ] Setup Git repository.

### Phase 2: Aspire Orchestration
- [ ] create `ApexLedger.AppHost` project.
- [ ] create `ApexLedger.ServiceDefaults` project.
- [ ] Register services in AppHost (SQL, Redis, Kafka, Projects).
- [ ] Wire up ServiceDefaults in all microservices.

### Phase 3: Payment Gateway (API & Idempotency)
- [ ] Implement `Domain` entities (Payment).
- [ ] Implement `Infrastructure` (Redis caching).
- [ ] Implement `Application` UseCases (ProcessPayment).
- [ ] Implement `API` Controller/Endpoints with `X-Idempotency-Key` middleware.
- [ ] Integrate Kafka Producer for `PaymentInitiated` event.

### Phase 4: Settlement Service (Transactional Outbox)
- [ ] Implement `Domain` entities (LedgerEntry).
- [ ] Implement `Infrastructure` with EF Core (SQL Server).
- [ ] Implement Transactional Outbox pattern.
- [ ] Implement Kafka Consumer for `PaymentInitiated`.
- [ ] Publish `PaymentValidated` / `SettlementCompleted` events.

### Phase 5: Reconciliation Worker
- [ ] Create mocked External Bank Source (CSV/JSON/Mock API).
- [ ] Implement Daily Reconciliation Job (IHostedService).
- [ ] Compare internal SQL Ledger vs External Bank source.
- [ ] Alerting/Event on discrepancy.

### Phase 6: Observability, Resilience & Testing
- [ ] Configure OpenTelemetry Tracing (propagating TraceID).
- [ ] Apply Polly retries/circuit breakers for external calls.
- [ ] Add xUnit tests for core logic.
- [ ] Add Pact.io CDC tests.

## Current Step
Generating `docker-compose.yml` and base project structure with Aspire.
