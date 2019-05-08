namespace GS.AssetBundlePacker
{
    /// <summary>错误代码</summary>
    public enum emErrorCode
    {
        /// <summary>无</summary>
        None = 0,
        /// <summary>参数错误</summary>
        ParameterError = 1,
        /// <summary>超时</summary>
        TimeOut = 2,
        /// <summary>预处理错误</summary>
        PreprocessError = 3,
        /// <summary>存储空间已满</summary>
        DiskFull = 4,
        /// <summary>写入异常</summary>
        WriteException = 5,

        //Load
        /// <summary>载入AssetBundleManifest错误</summary>
        LoadMainManifestFailed = 101,
        /// <summary>载入ResourcesManifest错误</summary>
        LoadResourcesManifestFailed = 102,
        /// <summary>载入ResourcesPackages错误</summary>
        LoadResourcesPackagesFailed = 103,
        /// <summary>载入新的AssetBundleManifest错误</summary>
        LoadNewMainManifestFailed = 104,
        /// <summary>载入新的ResourcesManifest错误</summary>
        LoadNewResourcesManiFestFailed = 105,


        //Find
        /// <summary>未找到有效的AssetBundle</summary>
        NotFindAssetBundle = 201,

        //Download
        /// <summary>未能识别URL服务器</summary>
        InvalidURL = 1001,
        /// <summary>服务器未响应</summary>
        ServerNoResponse = 1002,
        /// <summary>下载失败</summary>
        DownloadFailed = 1003,
        /// <summary>主配置文件下载失败</summary>
        DownloadMainConfigFileFailed = 1004,
        /// <summary>AssetBundle下载失败</summary>
        DownloadAssetBundleFailed = 1005,

        //PackageDownloader
        /// <summary>无效的包名</summary>
        InvalidPackageName = 2001,      
    }
}
