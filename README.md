# Inventory Management System

A modular console-based application built with C# and .NET to manage product inventory efficiently. This project focuses on clean code, Object-Oriented Programming (OOP) principles, and a decoupled architecture.

## 🚀 Features

- **Add Products:** Quickly register new items with unique IDs, names, and pricing.
- **Manage Stock:** Update, add, or subtract quantities for existing products.
- **Search & View:** Retrieve detailed product information or list the entire inventory.
- **Input Validation:** Robust handling of user input to prevent data errors.
- **Real-time Calculations:** Automatically calculates total inventory value.

## 🛠 Tech Stack & Architecture

- **Language:** C# (.NET)
- **Pattern:** Repository Pattern & Service-Based Architecture.
- **OOP Principles Applied:**
  - **Abstraction:** Extensive use of Interfaces (`IProductRepository`, `IInventoryManager`, etc.) to decouple logic.
  - **Encapsulation:** Private fields and properties to protect data integrity.
  - **Dependency Injection:** Constructors are used to inject dependencies, making the system modular and testable.

## 📁 Project Structure

- **/Interfaces:** Defines the contracts for repositories and services.
- **/Data:** Contains the `ProductRepository` and data models.
- **/Services:** Implements the core business logic (`InventoryManager`).
- **/Helper:** Contains `UserInput` and `Menu` for UI interactions.

## 🏃 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later recommended)

### Installation

1. Clone the repository:
   ```bash
   git clone [https://github.com/pregoadisaputro/inventory-management-system.git](https://github.com/pregoadisaputro/inventory-management-system.git)
   ```
