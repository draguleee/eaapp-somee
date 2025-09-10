# Testing the eaapp-somee website using Selenium & .NET

## Project Overview  
This repository contains automated UI test scripts written in C# language, using Selenium WebDriver.  
It demonstrates best practices for writing, organizing, and executing UI automation tests for web applications.  


## Structure
```
eaapp-somee/  
├── pages/
|   ├── configuration files (bin, obj, .csproj files)
|   ├── HomePage.cs
|   ├── LoginPage.cs
|   ├── RegisterPage.cs
|   └── other pages (WIP)
└── tests/
    ├── configuration files (bin, obj, .csproj files)
    ├── HomePageTest.cs
    ├── LoginPageTest.cs
    ├── RegisterPage.cs
    └── other files...
```

* `pages`: Page Object Model (POM) classes containing element locators and interactions for UI components.
* `tests`: Test classes and methods that use the POM classes to perform UI validations.
* **Other files** — (e.g., solution/project files, configuration files, utility helpers).


## Getting Started

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download)
* IDE (Visual Studio Community / Visual Studio Code)
* Matching browser driver (for example, ChromeDriver)
* Selenium WebDriver packages (via NuGet Package Manager)

### Setup & Run Tests
```bash
git clone https://github.com/draguleee/eaapp-somee.git
cd eaapp-somee
dotnet restore
dotnet test
```
