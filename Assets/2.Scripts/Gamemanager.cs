using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager Instance;

    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Player player;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private DataBaseManager dataBaseManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject retryBtnObj;



    public void CallBtnRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void OnGameOver()
    {
        retryBtnObj.SetActive(true);
    }

    private void Awake()
    {
        Instance = this;
        dataBaseManager.Init();

        player.Init();
        platformManager.Init();
        cameraManager.Init();
        scoreManager.Init();
        soundManager.Init();
    }

    private void Start()
    {
        platformManager.Active();
        scoreManager.Active();
        soundManager.PlayBgm(Define.BgmType.Main);

        int a = 123456;
        Debug.Log("Extension Test int : " + a.ToString());

        float b = 123456.789f;
        Debug.Log("Extension Test int : " + b.ToFormatString(1));
        Debug.Log("Extension Test int : " + b.ToFormatString(2));
        Debug.Log("Extension Test int : " + b.ToFormatString(3));

    }
}
