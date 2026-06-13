<div align="center">

#AmexFileParser

**A C# console application that parses AMEX**  
**fixed-width settlement files into structured data.**

![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Type](https://img.shields.io/badge/Type-Console%20App-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Active-brightgreen?style=for-the-badge)

> Built to replace **manual data extraction** from AMEX reports with a programmatic, structured pipeline .

</div>

## 📁 Project Structure
```
AmexFileParser/
├── Configuration/          # Header markers and parser configuration
├── Entity/                 # Domain model classes
│   ├── FileTracking.cs
│   ├── Nostro.cs
│   └── SettlementSummary.cs
├── FileHandler/            # File reading — loads report lines
├── Parser/                 # Section-specific parsers
│   ├── FileTrackingParser.cs
│   ├── NostroParser.cs
│   └── SettlementSummaryParser.cs
├── Sections/               # Report section extraction (ReportSectionIdentifier)
├── Services/               # Orchestration and supporting services
├── Summarizer/             # Post-parse aggregation (SettlementSummarizer)
├── Utility/                # Shared helpers
├── Program.cs              # Entry point
└── AmexParser.csproj
```

## ⚙️ How It Works

```
┌─────────────────────┐
│   Raw  File         │  Fixed-width text report from AMEX
└────────┬────────────┘
         │
         ▼
┌─────────────────────┐
│    FileReader       │  Loads all report lines → List<string>
└────────┬────────────┘
         │
         ▼
┌──────────────────────────────┐
│  ReportSectionIdentifier     │  Extracts lines per section by header match
└────────┬─────────────────────┘
         │
         ▼
┌──────────────────────────────┐
│     Section Parsers          │  Parses fixed-width lines → typed entity lists
│  FileTracking | Nostro       │
│  Issuer | Acquirer           │
└────────┬─────────────────────┘
         │
         ▼
┌──────────────────────────────┐
│   SettlementSummarizer       │  Groups acquirer records by category
└────────┬─────────────────────┘
         │
         ▼
┌──────────────────────────────┐
│     Console Output           │  Pipe-delimited records per section
└──────────────────────────────┘
```


## Output
<img width="1360" height="586" alt="image" src="https://github.com/user-attachments/assets/5f0597dc-8442-4cf1-b2f7-1abc71ef9dfb" />

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later

### Run

```bash
git clone https://github.com/amritsyangtan-sudo/AmexFileParser.git
cd AmexFileParser
dotnet run
```

> Place your AMEX report file in the configured input path before running.

---
