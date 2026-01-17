# NexusPOS (Enterprise Retail Core)

**NexusPOS** is a next-generation, Tesco-scale Point of Sale (POS) system designed for high resilience, offline-first capability, and premium user experience. Built with modern .NET technologies, it bridges the gap between physical retail hardware and enterprise microservices.

![NexusPOS Logo Placeholder](https://via.placeholder.com/150)

## 🚀 Key Features

*   **Thick Client Architecture**: Ensures continuous operation even during internet outages using local state (SQLite/LiteDB).
*   **Hardware Abstraction**: Decoupled interfaces for Scanners, Scales, and Printers using `IScanner` and `IScale` abstractions, enabling easy testing and hardware swapping.
*   **Touch-First Design**: Custom WPF/Avalonia UI styled specifically for touchscreen terminals with large hit targets and high-contrast accessibility.
*   **Scan-as-you-shop**: High-fidelity replication of modern self-checkout workflows, including "Hello" screens, weighing logic, and promotions.
*   **Enterprise Integration**: Backend ASP.NET Core microservices handling Price Lookups, Clubcard Membership, and Payment Gateways.
*   **Cloud Native Orchestration**: Uses **.NET Aspire** for seamless local development orchestration and cloud deployment.

## 🛠️ Tech Stack

*   **Frontend**: WPF (.NET 10) / Avalonia
*   **MVVM Framework**: CommunityToolkit.Mvvm
*   **Orchestration**: .NET Aspire
*   **Backend**: ASP.NET Core
*   **Database**: SQLite (Local), SQL Server/PostgreSQL (Cloud)
*   **Testing**: xUnit, Moq (Hardware Simulation)

## 📦 Getting Started

### Prerequisites
*   .NET 10 SDK
*   Visual Studio 2022 (v17.13+) or VS Code
*   Docker Desktop (for Aspire orchestration)

### Installation

1.  Clone the repository:
    ```bash
    git clone https://github.com/junaid109/Nexus-POS.git
    cd Nexus-POS
    ```

2.  Run the application with .NET Aspire:
    ```bash
    dotnet run --project NexusPOS.AppHost
    ```

## 🏗️ Architecture

The solution follows a Clean Architecture approach:

*   **NexusPOS.Shell**: The WPF Presentation layer (UI/ViewLogic).
*   **NexusPOS.Application**: Core business, interfaces, and use cases.
*   **NexusPOS.Domain**: Enterprise entities (Product, Basket, promotion).
*   **NexusPOS.Infrastructure**: External concerns (Hardware drivers, API clients, Database access).
*   **NexusPOS.ServiceDefaults**: Shared resilience, health checks, and OpenTelemetry configuration.

## 🤝 Contributing

1.  Fork the project.
2.  Create your feature branch (`git checkout -b feature/AmazingFeature`).
3.  Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4.  Push to the branch (`git push origin feature/AmazingFeature`).
5.  Open a Pull Request.

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

---
*Built with ❤️ for the future of retail.*
