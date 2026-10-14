using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MedalManager : MonoBehaviour
{
    public static MedalManager instance;

    public int coinCount = 0;

    public TextMeshProUGUI coinText;
    public Image medal1;
    public Image medal2;
    public Image medal3;
    public Image medal4;

    [SerializeField] private Sprite collectedSprite;
    [SerializeField] private Sprite notCollectedSprite;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        coinText = GameObject.Find("CoinCount")?.GetComponent<TextMeshProUGUI>();
        medal1 = GameObject.Find("Medal1")?.GetComponent<Image>();
        medal2 = GameObject.Find("Medal2")?.GetComponent<Image>();
        medal3 = GameObject.Find("Medal3")?.GetComponent<Image>();
        medal4 = GameObject.Find("Medal4")?.GetComponent<Image>();

        UpdateUI();
        UpdateMedals();
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateUI();
        UpdateMedals();
    }

    public void UpdateUI()
    {
        if (coinText != null)
            coinText.text = coinCount.ToString();
    }

    public void UpdateMedals()
    {
        if (medal1 != null) medal1.sprite = coinCount >= 28 ? collectedSprite : notCollectedSprite;
        if (medal2 != null) medal2.sprite = coinCount >= 56 ? collectedSprite : notCollectedSprite;
        if (medal3 != null) medal3.sprite = coinCount >= 84 ? collectedSprite : notCollectedSprite;
        if (medal4 != null) medal4.sprite = coinCount >= 112 ? collectedSprite : notCollectedSprite;
    }

    public void ResetCoins()
    {
        coinCount = 0;
        UpdateUI();
        UpdateMedals();
    }
}
