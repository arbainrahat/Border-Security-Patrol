//using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using Invector;
using System.Net.WebSockets;
using System.Collections.Generic;


public class GameController : MonoBehaviour
{
    #region DataFields

    [Header("Scenes")]
    //[SerializeField] private Scenes NextScene;
    //[SerializeField] private Scenes PreviousScene;

    [Header("UI")]
    //[SerializeField] private Canvas canvas;
    [SerializeField] private GameObject loadingScreen;
    //[SerializeField] private GameObject blackScreenInOutPanel;
    [SerializeField] private GameObject objectivePanel;
    [SerializeField] private Text objectiveText;
    [SerializeField] private GameObject missionObjectivePanel;
    [SerializeField] private Text missionObjectiveText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject failedPanel;
    //[SerializeField] private Text timerText;
    //[SerializeField] private GameObject controls;
    //[SerializeField] private GameObject inGame;
    [SerializeField] private Text levelRewardText;
    [SerializeField] private Text bonusText;
    [SerializeField] private Text totalRewardText;
    //[SerializeField] private Text levelCount;
    //[SerializeField] private GameObject getExtraTimePanel;
    //[SerializeField] private GameObject noticePanel;
    [SerializeField] private GameObject hudNavCanvas;

    [Header("Player Reference")]
    public GameObject player;
    //public Transform playerFps;
    //[SerializeField] private GameObject mobileCanvas;
    //[SerializeField] private Camera playerTpsCamera;

    [Header("Car Reference")]
    public GameObject car;
    public GameObject xRayCar;
    //public GameObject rccCanvas;
    //public GameObject rccCamera;
    //public Camera rccCarCamera;


    [Header("References")]
    [SerializeField] private Level[] levelData;
    [SerializeField] private AudioSource win;
    [SerializeField] private AudioSource loose;


    //[Header("Hud Reference")]
    //[SerializeField] private HUDNavigationSystem hudNavigationSystem;
    


    [Header("Debug")]
    [SerializeField] private int levelNo;
    public List<GameObject> enemyList;


    private bool timerOn = false;
    private float timeLeft = 600f;
    AsyncOperation async;


    #endregion

    private void Start()
    {
        //enemyList = new List<GameObject>();

        //GameManager.instance.currentLevel = PlayerPrefs.GetInt("lvl");
        //GameManager.instance.currentLevel = PlayerPrefs.GetInt("curntlvl");
        //levelNo = GameManager.instance.currentLevel;

        //Level Activate
        //levelData[levelNo].levelObject.SetActive(true);
        //EnableDisableCarSound();
    }


    private void Update()
    {
        //if (timerOn)
        //{
        //    if (timeLeft > 0)
        //    {
        //        timeLeft -= Time.deltaTime;
        //        DisplayTime(timeLeft);
        //    }
        //    else
        //    {
        //        Time.timeScale = 0f;
        //        //getExtraTimePanel.SetActive(true);
        //        //SetCanvasSortOrder();
        //        timerOn = false;
        //        timeLeft = 0;

                
        //    }
        //}
    }

    //private void EnableDisableCarSound()
    //{
    //    if (PlayerPrefsManager.Sound == 0)
    //    {
    //        AudioListener.volume = 1f;
    //    }
    //    else
    //    {
    //        AudioListener.volume = 0f;
    //    }
    //}

    //void DisplayTime(float timeToDisplay)
    //{
    //    timeToDisplay += 1;
    //    float minutes = Mathf.FloorToInt(timeToDisplay / 60);
    //    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    //    timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    //}



    //public void SetObjective(string objective)
    //{
    //    string text = "";

    //    objectivePanel.SetActive(true);
    //    DOTween.To(() => text, x => text = x, objective, objective.Length / 15f).OnUpdate(() =>
    //    {
    //        objectiveText.text = text;
    //    });

    //    //SetCanvasSortOrder();
    //}

    //public void SetMissionObjective(string objective)
    //{
    //    string text = "";

    //    missionObjectivePanel.SetActive(true);
    //    DOTween.To(() => text, x => text = x, objective, objective.Length / 15f).OnUpdate(() =>
    //    {
    //        missionObjectiveText.text = text;
    //    });
    //}

    //public void DelaySetObjective(string objective)
    //{
    //    StartCoroutine(_DelaySetObjective(objective));
    //}

    //private IEnumerator _DelaySetObjective(string objective)
    //{
    //    yield return new WaitForSeconds(4f);
    //    SetObjective(objective);
    //}

    //public void SetCanvasSortOrder()
    //{
    //    canvas.sortingOrder = 2;
    //}

    //public void ReSetCanvasSortOrder()
    //{
    //    canvas.sortingOrder = 0;
    //}

    public void SetPlayer_PositionAndRotation(Transform transform)
    {
        player.SetActive(true);
        player.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }

    public void SetCar_PositionAndRotation(Transform transform)
    {
        car.SetActive(true);
        car.transform.SetPositionAndRotation(transform.localPosition, transform.localRotation);
    }

    //public void PlayerObjectsEnableDisable(bool isEnable)
    //{
    //    if (isEnable)
    //    {
    //        mobileCanvas.SetActive(true);
            
    //    }
    //    else
    //    {
    //        mobileCanvas.SetActive(false);
            
    //    }
    //}

    //public void CarObjectsEnableDisable(bool isEnable)
    //{
    //    if (isEnable)
    //    {
    //        rccCanvas.SetActive(true);
    //        rccCamera.SetActive(true);
    //    }
    //    else
    //    {
    //        rccCanvas.SetActive(false);
    //        rccCamera.SetActive(false);
    //    }
    //}

    //public void SpwanEnemies()
    //{

    //    foreach (Transform t in levelData[levelNo].enemyData.spwanPoints1)
    //    {
    //        GameObject go = Instantiate(levelData[levelNo].enemyData.enemyObject1, t.position, t.rotation) as GameObject;
    //        enemyList.Add(go);
    //    }

    //    foreach (Transform t in levelData[levelNo].enemyData.spwanPoints2)
    //    {
    //        GameObject go = Instantiate(levelData[levelNo].enemyData.enemyObject2, t.position, t.rotation) as GameObject;
    //        enemyList.Add(go);
    //    }

    //    Add Enemies in map after respwan
    //    player.GetComponent<HUDNavigationSystem>().enabled = false;
    //    car.GetComponent<HUDNavigationSystem>().enabled = false;
    //    player.GetComponent<HUDNavigationSystem>().enabled = true;
    //    car.GetComponent<HUDNavigationSystem>().enabled = true;


    //}

    //public void Set_playerHudNavigation()
    //{
    //    hudNavigationSystem.ChangeHudNavSystem_PlayerCamAndTransform(playerTpsCamera, playerFps);
    //}

    //public void Set_carHudNavigation()
    //{
    //    hudNavigationSystem.ChangeHudNavSystem_PlayerCamAndTransform(rccCarCamera, car.transform);
    //}


    //public void CarStop()
    //{
    //    car.GetComponent<Rigidbody>().isKinematic = true;
    //}

    public void LevelWin()
    {
        StartCoroutine(LevelReward());
    }

    //private void LoadScene(Scenes scene)
    //{
    //    StartCoroutine(_LoadScene(scene.ToString()));
    //}

    //IEnumerator _LoadScene(string scene)
    //{
    //    async = SceneManager.LoadSceneAsync(scene.ToString());
    //    async.allowSceneActivation = false;

    //    loadingScreen.SetActive(true);

    //    yield return new WaitForSeconds(4.5f);

    //    async.allowSceneActivation = true;
    //}

    public void LevelFailed()
    {
        StartCoroutine(Level_Failed());
    }

    IEnumerator Level_Failed()
    {
        //player.GetComponent<Rigidbody>().isKinematic = true;
        //loose.Play();
        //controls.SetActive(false);
        //inGame.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        failedPanel.SetActive(true);
        //PlayerObjectsEnableDisable(false);
        hudNavCanvas.SetActive(false);
        player.SetActive(false);
        //SetCanvasSortOrder();

        
    }

    IEnumerator LevelReward()
    {
        //Calculate Bonus
        int bonusCount = UnityEngine.Random.Range(1, 4);

        //win.Play();
        int bonus = 20 * bonusCount;
        int totalReward = levelData[levelNo].reward + bonus;
        levelRewardText.text = levelData[levelNo].reward.ToString();
        bonusText.text = bonus.ToString();
        totalRewardText.text = totalReward.ToString();

        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + totalReward);

        yield return new WaitForSeconds(1.5f);
        winPanel.SetActive(true);
        //PlayerObjectsEnableDisable(false);
        hudNavCanvas.SetActive(false);
        player.SetActive(false);
        //SetCanvasSortOrder();

        //controls.SetActive(false);
        //inGame.SetActive(false);
        //winPanel.SetActive(true);

        //if (GameManager.instance.currentLevel < GameManager.instance.totalLevels)
        //{
        //    PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl") + 1);

        //    PlayerPrefs.SetInt("curntlvl", PlayerPrefs.GetInt("lvl"));
        //}
        

        

    }



    //public void SetBlackScreenInOut()
    //{
    //    StartCoroutine(BlackScreenInOut());
    //}

    //private IEnumerator BlackScreenInOut()
    //{
    //    blackScreenInOutPanel.SetActive(true);
    //    yield return new WaitForSeconds(1f);
    //    blackScreenInOutPanel.SetActive(false);
    //}


    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Next()
    {
        //PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl") + 1);
        //LoadScene(NextScene);
    }

    public void Restart()
    {
        //LoadScene(NextScene);
    }

    public void Home()
    {
        //LoadScene(PreviousScene);
    }

    //public void SetTimer(float t)
    //{
    //    timeLeft = t;
    //    timerOn = true;
    //}


    //Test
    bool IsScan = true;

    public void ScanCar()
    {
        if(IsScan)
        {
            xRayCar.transform.SetPositionAndRotation(car.transform.position, car.transform.rotation);
            car.SetActive(false);
            xRayCar.SetActive(true);

            //Test Only
            IsScan = false;
        }
        else
        {
            xRayCar.SetActive(false);
            car.SetActive(true);

            //Test Only
            IsScan = true;
        }
    }
}

[Serializable]
public class Level
{
    public GameObject levelObject;
    //public Transform playerSpwanPoint;
    //public Transform carSpwanPoint;
    public int reward;
    //public int totalEnemies;
}
