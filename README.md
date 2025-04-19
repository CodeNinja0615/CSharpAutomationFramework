# 🧪 Selenium Automation Framework with NUnit

![.NET](https://img.shields.io/badge/.NET-6.0-blueviolet)
![NUnit](https://img.shields.io/badge/NUnit-Testing-blue)
![Selenium](https://img.shields.io/badge/Selenium-WebDriver-green)
![Build](https://img.shields.io/badge/CI-Jenkins%20%7C%20Azure-blue)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)

A powerful and extensible automation framework built using **Selenium WebDriver**, **NUnit**, and **C#**. This framework is fully CI/CD-ready for **Jenkins** and **Azure Pipelines**, and supports **cross-browser testing** via configuration in `App.config`.

---

## 📌 Features

- 🔧 **Configurable browser execution** (`App.config`)
- 🧪 **NUnit-based test structure**
- 📂 **Supports JSON-based test data**
- ☁️ **Azure DevOps & Jenkins integration ready**
- 📦 **Extensible structure for page objects, utilities, and test categories**
- 🧵 Parallel test execution support

---

## ⚙️ Configuration Setup

### 🛠️ Browser Selection (`App.config`)

You can easily switch browsers by modifying the `App.config`:

```xml
<configuration>
  <appSettings>
    <add key="browser" value="chrome" />
    <!-- Available options: chrome, firefox, edge -->
  </appSettings>
</configuration>
```

# 🔄 .csproj Configuration
 To ensure your test data and config files are handled correctly during the build, add the following to your .csproj:

```xml
<ItemGroup>
  <None Update="testData\testData.json">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>
</ItemGroup>

<Target Name="CopyCustomContent" AfterTargets="AfterBuild">
  <Copy SourceFiles="App.config" DestinationFiles="$(OutDir)\testhost.dll.config" />
</Target>
```

# 💻 Running Tests via CLI
 Ensure you have the .NET SDK installed. Use the following commands to run your tests:

### ▶️ Run All Tests
```bash
dotnet test
```

### 📂 Run Tests by Category (e.g., Smoke)
```bash
dotnet test --filter TestCategory=Smoke
```

### 🧪 Run a Specific Test Method
```bash
dotnet test --filter FullyQualifiedName=YourNamespace.YourClass.YourTestMethod
```

# 🔁 CI/CD Integration

## ✅ Jenkins
 Add parameters for browser selection
 Use dotnet test in build steps
 Archive test results using NUnit XML output

## ✅ Azure DevOps
 Add dotnet test in a .yml pipeline

# 📊 Reporting (Optional Add-ons)
 🔍 Allure / ExtentReports / ReportUnit integration for enhanced visual test reports

# 🗂️ NUnit XML Output
 When you run tests with dotnet test, NUnit by default outputs TRX (Test Result XML format by Microsoft). But if you want NUnit-style XML, you can explicitly configure it.

### 💡 Run with NUnit XML output:
```bash
dotnet test --logger:nunit
```
# OR
 ```bash
 dotnet test --logger:"nunit;LogFilePath=TestResults/NUnitResults.xml"
```

## 🤝 Contributing
 Pull requests and feedback are always welcome. Let's build something better together!