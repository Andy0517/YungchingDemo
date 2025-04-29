# YungchingDemo

## 專案簡介
YungchingDemo 是一個基於 ASP.NET Core 開發的 Web API 和 MVC 網站專案，使用 Dapper 作為資料存取技術，並實現了基本的 CRUD 功能。專案採用分層式架構，並支援依賴注入（DI）以提升可維護性與擴展性。

---

## 專案架構
專案採用分層式架構，主要包含以下幾個部分：
- **Comm**: 包含通用服務類別，例如 `SqlService`，負責資料庫操作。
- **Controllers**: 包含 Web API 控制器，實現 CRUD 功能。
- **Models**: 包含資料模型，用於定義資料結構。
- **Pages**: 包含 Razor Pages，實現簡單的前端介面。

### 主要檔案與功能
- **Comm/SqlService.cs**: 
  - 提供資料庫操作功能，包括 `ReadOne`、`ReadMany` 和 `Execute` 方法。
  - 使用 Dapper 進行資料查詢與操作。
  - 支援依賴注入，從 `appsettings.json` 中讀取資料庫連線字串。

- **Controllers**:
  - `InsertController`: 負責新增資料。
  - `UpdateController`: 負責更新資料。
  - `DeleteController`: 負責刪除資料。
  - `QueryController`: 負責查詢資料。

- **Pages**:
  - 包含 Razor Pages，例如 `Index.cshtml`、`Insert.cshtml` 和 `Maintain.cshtml`，提供簡單的前端操作介面。

---

## 使用方式

### 環境需求
1. **開發工具**: Visual Studio 2019 或以上版本，或 Visual Studio Code。
2. **.NET Core SDK**: 2.2 或以上版本。
3. **資料庫**: 
   - 支援 LocalDB、SQLite 或 SQL Server。
   - 預設使用 SQL Server，需自行設定資料庫連線字串。

### 安裝與執行
1. **克隆專案**：
   ```bash
   git clone <GitHub Repository URL>
   cd YungchingDemo
   ```

2. **設定資料庫連線**：
   - 在 `appsettings.json` 中設定 `DefaultConnection` 的連線字串，例如：
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=Northwind;Trusted_Connection=True;"
     }
     ```

3. **建立資料庫**：
   - 如果使用 Northwind 資料庫，請從以下連結下載並安裝：
     [Northwind 資料庫](https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs)

4. **執行專案**：
   - 使用 Visual Studio 開啟專案，按下 `F5` 執行。

---

## 功能說明
1. **CRUD 操作**：
   - **新增資料**: 使用 `InsertController`。
   - **更新資料**: 使用 `UpdateController`。
   - **刪除資料**: 使用 `DeleteController`。
   - **查詢資料**: 使用 `QueryController`。

2. **依賴注入**：
   - 使用 ASP.NET Core 的內建 DI 容器，將 `SqlService` 注入至控制器。

3. **錯誤處理**：
   - 在 `SqlService` 中對資料庫操作進行基本的錯誤處理。
