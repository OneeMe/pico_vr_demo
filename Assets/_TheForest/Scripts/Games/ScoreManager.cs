using TMPro;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class ScoreManager : MonoBehaviour
{
  int score = 0; // 分数

  [SerializeField] private TMP_Text scoreText; // 分数文字

  private GameManager gameManager;

  public static ScoreManager instance;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  void Start()
  {
    gameManager = GetComponent<GameManager>();
    gameManager.beginGameAction += BeginGame;
  }

  void Update()
  {
    scoreText.text = "分数：" + score.ToString();
  }

  // 游戏开始
  public void BeginGame()
  {
    // 初始化分数和时间
    score = 0;
  }

  // 增加分数
  public void AddScore(int value)
  {
    score += value;
    scoreText.text = "分数：" + score.ToString();
  }
}
