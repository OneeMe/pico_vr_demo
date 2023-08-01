using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameState
{
  Playing,
  Idle,
}

public class GameManager : MonoBehaviour
{
  public bool isBeginImmediately = false; // 是否立即开始游戏

  [SerializeField] private GameObject uiPanel; // UI面板

  [SerializeField] private TMP_Text timeText; // 时间文字

  public event Action beginGameAction; // 游戏开始事件
  public event Action endGameAction; // 游戏开始事件

  private GameState gameState = GameState.Idle; // 游戏状态

  public float gameDuration = 60.0f; // 游戏时长
  private float timeRemaining; // 剩余时间

  private void Start()
  {
    if (isBeginImmediately)
    {
      BeginGame();
    }
  }

  void Update()
  {
    if (!isGamePlaying())
    {
      return;
    }
    // 更新剩余时间
    timeRemaining -= Time.deltaTime;
    timeText.text = "剩余时间：" + Mathf.RoundToInt(timeRemaining).ToString() + "s";
    if (timeRemaining <= 0)
    {
      EndGame();
    }
  }

  // 点击按钮后开始游戏，并让 GhostSpawnArea 开始生成幽灵
  public void BeginGame()
  {
    gameState = GameState.Playing;
    timeRemaining = gameDuration;
    beginGameAction?.Invoke();
  }

  public void EndGame()
  {
    gameState = GameState.Idle;
    endGameAction?.Invoke();
  }

  public bool isGamePlaying()
  {
    return gameState == GameState.Playing;
  }
}
