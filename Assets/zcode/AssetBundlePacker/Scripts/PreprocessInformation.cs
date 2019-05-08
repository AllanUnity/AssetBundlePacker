namespace GS.AssetBundlePacker
{
    /// <summary>预加载信息</summary>
    public class PreprocessInformation
    {
        /// <summary>当前状态</summary>
        public emPreprocessState State { get; private set; }

        /// <summary>当前状态的进度</summary>
        public float Progress { get; private set; }

        /// <summary>当前状态的的总量值</summary>
        public float Total { get; private set; }

        /// <summary>当前状态的进度</summary>
        public float CurrentStateProgressPercent { get { return Total != 0 ? Progress / Total : 0f; } }

        /// <summary>是否需要拷贝所有配置文件</summary>
        public bool NeedCopyAllConfig;

        public PreprocessInformation()
        {
            this.State = emPreprocessState.None;
            this.Progress = 0f;
            this.Total = 1f;
        }

        /// <summary>更新</summary>
        public void UpdateState(emPreprocessState state)
        {
            this.State = state;
            this.Progress = 0f;
            this.Total = 1f;
        }

        /// <summary>更新</summary>
        public void UpdateProgress(float value, float total)
        {
            this.Progress = value;
            this.Total = total;
        }
    }
}