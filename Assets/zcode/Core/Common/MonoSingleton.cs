using UnityEngine;

/// <summary>继承MonoBehaviour的单例创建单例成功的回调</summary>
public delegate void DelegateMonoSlingletonCreateCallBack(bool down);

/// <summary>继承MonoBehaviour的单例</summary>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    /// <summary>单例实例</summary>
	private static T instance_ = null;
    public static T Instance
    {
        get
        {
            if (instance_ == null)
            {
                CreateSingleton(null, null);
            }
            return instance_;
        }
    }


    /// <summary>创建单例实例</summary>
    public static T CreateSingleton(DelegateMonoSlingletonCreateCallBack cb, Transform parent = null)
    {
        Debug.Log("初始化管理类 : " + typeof(T));
        if (instance_ != null)
        {
            return instance_;
        }

        GameObject go = new GameObject(typeof(T).Name);
        DontDestroyOnLoad(go);
        if (parent != null)
        {
            go.transform.SetParent(parent);
        }
        instance_ = go.AddComponent<T>();
        Instance.Init(cb);
        return Instance;
    }
    protected virtual void Init(DelegateMonoSlingletonCreateCallBack cb)
    {

    }

    /// <summary>确保在程序退出时销毁实例。</summary>
    protected virtual void OnApplicationQuit()
    {
        Quit();
        instance_ = null;
    }
    protected virtual void Quit()
    {

    }
}