using GS.AssetBundlePacker;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>展示插件启动、使用等功能</summary>
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //此层次下的所有对象禁止被删除
            DontDestroyOnLoad(transform.gameObject);
            Init();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
    #region Init
    void Init()
    {
        //设定资源加载模式为仅加载AssetBundle资源
        ResourcesManager.LoadPattern = new AssetBundleLoadPattern();
        //设定场景加载模式为仅加载AssetBundle资源
        SceneResourcesManager.LoadPattern = new AssetBundleLoadPattern();

        AssetBundleManager.CreateSingleton(LoadExample);

        InitPreparationWork();
        InitExample();
        InitLoadAssets();
    }


    /// <summary>准备工作</summary>
    void InitPreparationWork()
    {
        ExamplePanel.SetActive(true);
        ExampleTipsText.gameObject.SetActive(true);
        ExampleTipsText.text = "AssetBundlePacker is launching！";
    }
    private void LoadExample(bool level)
    {
        if (level)
        {
            ExampleTipsText.text = "AssetBundlePacker is Over";
            ExampleTipsText.gameObject.SetActive(false);
            btns.SetActive(true);
        }
        else
        {
            ExampleTipsText.text = "<color=red>AssetBundlePacker launch occur error!</color>";
            btns.SetActive(false);
        }
    }
    #endregion

    #region Example
    public GameObject ExamplePanel;
    public GameObject btns;
    public Button LoadTextBtn;
    public Button LoadTextureBtn;
    public Button LoadModelBtn;
    public Button LoadSceneBtn;
    public Text ExampleTipsText;
    void InitExample()
    {
        LoadTextBtn.onClick.AddListener(LoadText);
        LoadTextureBtn.onClick.AddListener(LoadTexture);
        LoadModelBtn.onClick.AddListener(LoadModel);
        LoadSceneBtn.onClick.AddListener(LoadScene);
    }

    const string TEXT_FILE = "Assets/Resources/Version_1/Text/Text.txt";
    void LoadText()
    {
        TextAsset text_asset = ResourcesManager.Load<TextAsset>(TEXT_FILE);
        Debug.Log(System.DateTime.Now.Millisecond);
        if (text_asset != null)
        {
            SetShowText(text_asset.text);
        }

        OpenContentPanel("文本(" + TEXT_FILE + ")", () =>
        {
            SetShowText(null);
        });
    }

    const string TEXTURE_FILE = "Assets/Resources/Version_1/Texture/office.png";
    void LoadTexture()
    {
        Texture texture_ = ResourcesManager.Load<Texture2D>(TEXTURE_FILE);
        Debug.Log(System.DateTime.Now.Millisecond);
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
        Debug.Log(System.DateTime.Now);
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
