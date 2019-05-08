using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using zcode;
using zcode.AssetBundlePacker;

/// <summary>展示插件启动、使用等功能</summary>
public class Example0 : MonoBehaviour
{
    /// <summary>缓存目录</summary>
    //public const string PATH = "Assets/AssetBundlePacker-Examples/Cache/Version_1/AssetBundle";
    public const string PATH = "Assets/PersistentAssets/AssetBundle";

    void Start()
    {
        //此层次下的所有对象禁止被删除
        DontDestroyOnLoad(transform.gameObject);

        var array = GameObject.FindObjectsOfType<Example0>();
        if (array.Length > 1)
        {
            GameObject.Destroy(this.gameObject);
        }
        InitPreparationWork();
        InitExample();
        InitLoadAssets();
    }

    #region PreparationWork
    public GameObject startPanel;
    public Text showNoteText;
    public Button startBtn;
    public Button copyStartBtn;
    const string NOTE =
        "1. 启动例子会从缓存目录中拷贝例子数据至StreamingAssets目录，拷贝执行前会先清空StreamingAssets目录，请注意先转移此目录下的数据。\n"
      + "2. 例子所有使用的AssetBundle原资源放置于\"" + PATH + "\"";
    /// <summary>准备工作</summary>
    void InitPreparationWork()
    {
        showNoteText.text = NOTE;
        startBtn.onClick.AddListener(() =>
        {
            //设定资源加载模式为仅加载AssetBundle资源
            ResourcesManager.LoadPattern = new AssetBundleLoadPattern();
            //设定场景加载模式为仅加载AssetBundle资源
            SceneResourcesManager.LoadPattern = new AssetBundleLoadPattern();

            startPanel.SetActive(false);
            ExamplePanel.SetActive(true);
            StartCoroutine(LoadExample());
        });

        copyStartBtn.onClick.AddListener(() =>
        {
            if (Directory.Exists(Common.INITIAL_PATH))
                Directory.Delete(Common.INITIAL_PATH, true);

            //拷贝例子资源
            FileHelper.CopyDirectoryAllChildren(PATH, Common.INITIAL_PATH);

            //设定资源加载模式为仅加载AssetBundle资源
            ResourcesManager.LoadPattern = new AssetBundleLoadPattern();
            //设定场景加载模式为仅加载AssetBundle资源
            SceneResourcesManager.LoadPattern = new AssetBundleLoadPattern();

            startPanel.SetActive(false);
            ExamplePanel.SetActive(true);
            StartCoroutine(LoadExample());
        });
    }
    IEnumerator LoadExample()
    {
        ExampleTipsText.gameObject.SetActive(true);
        ExampleTipsText.text = "AssetBundlePacker is launching！";
        yield return !AssetBundleManager.Instance.WaitForLaunch();
        ExampleTipsText.text = "AssetBundlePacker is Over";
        while (!AssetBundleManager.Instance.IsReady)
        {
            if (AssetBundleManager.Instance.IsFailed)
            {
                ExampleTipsText.text = "<color=red>AssetBundlePacker launch occur error!</color>";
            }
            yield return null;
        }
        ExampleTipsText.gameObject.SetActive(false);
        btns.SetActive(true);
    }
    #endregion

    #region Example
    public GameObject ExamplePanel;
    public GameObject btns;
    public Button LoadTextBtn;
    public Button LoadMeshBtn;
    public Button LoadModelBtn;
    public Button LoadSceneBtn;
    public Text ExampleTipsText;
    void InitExample()
    {
        LoadTextBtn.onClick.AddListener(LoadText);
        LoadMeshBtn.onClick.AddListener(LoadTexture);
        LoadModelBtn.onClick.AddListener(LoadModel);
        LoadSceneBtn.onClick.AddListener(LoadScene);
    }

    const string TEXT_FILE = "Assets/Resources/Version_1/Text/Text.txt";
    void LoadText()
    {
        TextAsset text_asset = ResourcesManager.Load<TextAsset>(TEXT_FILE);

        if (text_asset != null)
        {
            SetShowText(text_asset.text);
        }

        OpenContentPanel("文本(" + TEXT_FILE + ")", () =>
        {
            SetShowText(null);
        });
    }

    const string TEXTURE_FILE = "Assets/Resources/Version_1/Texture/Tex_1.png";
    void LoadTexture()
    {
        Texture texture_ = ResourcesManager.Load<Texture2D>(TEXTURE_FILE);
        if (texture_ != null)
        {
            SetShowTexture(texture_);
        }

        OpenContentPanel("纹理(" + TEXTURE_FILE + ")", () =>
        {
            SetShowTexture(null);
        });
    }

    const string MODEL_FILE = "Assets/Resources/Version_1/Models/Sphere/Sphere.Prefab";
    void LoadModel()
    {
        GameObject model_ = null;
        GameObject prefab = ResourcesManager.Load<GameObject>(MODEL_FILE);
        if (prefab != null)
        {
            model_ = GameObject.Instantiate(prefab);
            model_.transform.position = Vector3.zero;
        }

        OpenContentPanel("模型(" + MODEL_FILE + ")", () =>
        {
            if (model_ != null)
                GameObject.Destroy(model_);
        });
    }

    const string SCENE_FILE = "SimpleScene";
    void LoadScene()
    {
        string original_scene = SceneManager.GetActiveScene().name;
        original_scene = SceneManager.GetActiveScene().name;
        SceneResourcesManager.LoadSceneAsync(SCENE_FILE);

        OpenContentPanel("场景(" + SCENE_FILE + ")", () =>
        {
            SceneManager.LoadScene(original_scene);
        });
    }
    #endregion

    #region LoadAssets
    public GameObject contentPanel;
    public Text LoadAssetsName;
    public Text showText;
    public RawImage showTexture;
    public Button BackBtn;
    public UnityAction backAction;
    void InitLoadAssets()
    {
        showText.gameObject.SetActive(false);
        showTexture.gameObject.SetActive(false);
        BackBtn.onClick.AddListener(() =>
        {
            if (backAction != null) backAction();
            contentPanel.SetActive(false);

        });
    }
    void OpenContentPanel(string loadassetsname, UnityAction back)
    {
        contentPanel.SetActive(true);
        LoadAssetsName.text = loadassetsname;
        backAction = back;
    }

    void SetShowText(string content)
    {
        if (string.IsNullOrEmpty(content))
        {
            showText.text = null;
            showText.gameObject.SetActive(false);
        }
        else
        {
            showText.gameObject.SetActive(true);
            showText.text = content;
        }
    }
    void SetShowTexture(Texture content)
    {
        if (content == null)
        {
            showTexture.texture = null;
            showTexture.gameObject.SetActive(false);
        }
        else
        {
            showTexture.gameObject.SetActive(true);
            showTexture.texture = content;
        }
    }

    #endregion
}
