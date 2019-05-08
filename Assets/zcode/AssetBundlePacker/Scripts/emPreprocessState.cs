namespace GS.AssetBundlePacker
{
    /// <summary>状态</summary>
    public enum emPreprocessState
    {
        /// <summary>无</summary>
        None,
        /// <summary>安装包资源初始化</summary>
        Install,
        /// <summary>最新版本资源拷贝</summary>
        Update,
        /// <summary>游戏初始资源加载</summary>
        Load,
        /// <summary>后备工作</summary>
        Dispose,
        /// <summary>完成</summary>
        Completed,
        /// <summary>失败</summary>
        Failed,          
    }
}