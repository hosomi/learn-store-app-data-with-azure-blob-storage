# learn-store-app-data-with-azure-blob-storage

https://docs.microsoft.com/ja-jp/learn/modules/store-app-data-with-azure-blob-storage/

## 環境

ローカル実装と動作確認を行います。  

* VisualStudio 2019
* Azure ストレージ エミュレーター  
[Azure ストレージ エミュレーターを使用した開発とテスト - Microsoft Docs](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-emulator)  

## 初期設定

プロジェクト直下の``appsettings.Development.json`` ファイルをローカルでデバッグ実行できるように構成します。  
（Azure は構成設定に設定する内容です。）  

``appsettings.Development.json`` :  

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AzureStorageConfig": {
    "ConnectionString": "UseDevelopmentStorage=true",
    "FileContainerName": "files"
  },
  "AllowedHosts": "*"
}
```

Azure App Service にデプロイ時は対象の構成設定の内容が適用されます。  

## 特記事項

現在非推奨になっている ``WindowsAzure.Storage`` から ``Azure.Storage.Blobs`` に変更してコードを書き直しています。  

変更差分：https://github.com/hosomi/learn-store-app-data-with-azure-blob-storage/commit/871430a2df6f734e32d979491f96c1bf887a578a  
