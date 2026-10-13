# KuaiShou

KuaiShou 是一个基于 .NET 8 的高德到店核销API封装SDK，使用WPF制作的测试工具。

---

## 目录

- [项目结构](#项目结构)
- [技术栈](#技术栈)
- [快速开始](#快速开始)

---

## 项目结构

```
KuaiShou/
├── KuaiShouOpen/              # API 封装
├── KuaiShouApiTest/          # 测试工具
```

---

## 技术栈

### 核心框架
| 技术 | 版本 | 用途 |
|-----|------|-----|
| **.NET** | 8.0 | 运行时框架 |
| **WPF** | 8.0 | 桌面程序 |
---

## 快速开始

### 环境要求

- .NET 8.0 SDK

```bash
# 1. 克隆代码
git clone https://github.com/609394359/KuaiShou.git
```

```bash
# 2. 单文件编译命令
dotnet publish -c Release --self-contained -r win-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:DebugType=none
```

```bash
# 3. 单文件编译 FolderProfile.pubxml 配置
<Project>
  <PropertyGroup>
    <Configuration>Release</Configuration>
    <Platform>Any CPU</Platform>
    <PublishDir>bin\Release\net8.0-windows\publish\win-x64\</PublishDir>
    <PublishProtocol>FileSystem</PublishProtocol>
    <_TargetId>Folder</_TargetId>
    <TargetFramework>net8.0-windows</TargetFramework>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <SelfContained>true</SelfContained>
    <PublishSingleFile>true</PublishSingleFile>
    <PublishReadyToRun>false</PublishReadyToRun>
	  <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
	  <DebugType>none</DebugType>
	  <DebugSymbols>false</DebugSymbols>
  </PropertyGroup>
</Project>
```

