# learn-store-app-data-with-azure-blob-storage

https://docs.microsoft.com/ja-jp/learn/modules/store-app-data-with-azure-blob-storage/

## ��

���[�J�������Ɠ���m�F���s���܂��B  

* VisualStudio 2019
* Azure �X�g���[�W �G�~�����[�^�[  
[Azure �X�g���[�W �G�~�����[�^�[���g�p�����J���ƃe�X�g - Microsoft Docs](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-emulator)  

## �����ݒ�

�v���W�F�N�g������``appsettings.Development.json`` �t�@�C�������[�J���Ńf�o�b�O���s�ł���悤�ɍ\�����܂��B  
�iAzure �͍\���ݒ�ɐݒ肷����e�ł��B�j  

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

Azure App Service �Ƀf�v���C���͑Ώۂ̍\���ݒ�̓��e���K�p����܂��B  

## ���L����

���ݔ񐄏��ɂȂ��Ă��� ``WindowsAzure.Storage`` ���� ``Azure.Storage.Blobs`` �ɕύX���ăR�[�h�����������Ă��܂��B  

�ύX�����Fhttps://github.com/hosomi/learn-store-app-data-with-azure-blob-storage/commit/871430a2df6f734e32d979491f96c1bf887a578a  
