using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬을 불러올때 
using UnityEngine.UI;//유니티 UI관리 

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    public int score;       //점수

    float num;   //에너미 선택 순서
    float dTimer;//에너미 생성 스테이지
    float eDelay;//에너미 생성 딜레이
    float second;//게임 진행시간 (시간에 따라 생성되는 몬스터가 다르다)
    float enemySpawnRand;   //에너미생성 위치 
    float enemySpawnRandy;  //에너미생성 위치

    bool isGameOver;//게임오버 상태여부

    //에너미
    public GameObject enemy1;     //에너미1
    public GameObject enemy2;     //에너미2
    public GameObject enemy3;     //에너미3
    public GameObject enemy4;     //에너미4
    public GameObject enemy5;     //보스

    //public GameObject e3collider; //에너미3의 위치를 잡아주는 콜라이더
    
    public GameObject StageClearImg;//게임 클리어 이미지
    public GameObject gameOverImg;  //게임오버 이미지

    //스코어 이미지
    public Image image1;
    public Image image10;
    public Image image100;
    public Image image1000;

    public Text RestartText;

    void Start()
    {
        eDelay = 1;
        dTimer = 0;
        isGameOver = false;
        score = 0;
        StartCoroutine(BossIn());//시간이 되면 보스 등장
    }

 
    void Update()
    {
        if (isGameOver == true)
        {
            Restart();
        }
        //몬스터 소환
        SpawnEnemy();
        //Score UI관리
        ScoreUI();
    }

    void SpawnEnemy()
    {
        //시간이 지날수록 생성되는 몬스터가 다양해진다.
        second += Time.deltaTime;//스테이지 진행시간
        dTimer += Time.deltaTime;//몬스터 생성시간
        if (second <= 15)
        {
            if (dTimer >= eDelay)
            {
                num = 1;
                dTimer -= eDelay;
                enemySpawnRand = Random.Range(3.1f, -3.1f);
                SelectEnemy();

            }
        }
        else if (second > 15 && second < 30)
        {
            if (dTimer >= eDelay)
            {
                dTimer -= eDelay;
                num = Random.Range(1, 3);
                enemySpawnRand = Random.Range(3.1f, -3.1f);
                enemySpawnRandy = Random.Range(5f, 8.5f);
                SelectEnemy();
            }
        }
        else if (second > 30 && second < 45)
        {
            if (dTimer >= eDelay)
            {
                dTimer -= eDelay;
                num = Random.Range(2, 4);
                enemySpawnRand = Random.Range(3.1f, -3.1f);
                enemySpawnRandy = Random.Range(5f, 8.5f);
                SelectEnemy();
            }
        }
        else if (second > 45 && second < 60)
        {
            if (dTimer >= eDelay)
            {
                eDelay = 1.8f;
                dTimer -= eDelay;
                enemySpawnRand = Random.Range(3.1f, -3.1f);
                num = 4;
                SelectEnemy();
            }
        }
        else if (second > 60)
        {
            if (dTimer >= eDelay)
            {
                eDelay = 2f;
                dTimer -= eDelay;
                num = Random.Range(1, 5);
                enemySpawnRand = Random.Range(3.1f, -3.1f);
                enemySpawnRandy = Random.Range(5f, 8.5f);
                SelectEnemy();
            }
        }
    }

    void ScoreUI()
    {
        int n1000 = score / 1000;
        int n100 = (score % 1000) / 100;
        int n10 = (score % 100) / 10;
        int n1 = score % 10;

        string fileName = "UI/number";
        image1.sprite = Resources.Load<Sprite>(fileName + n1);
        image10.sprite = Resources.Load<Sprite>(fileName + n10);
        image100.sprite = Resources.Load<Sprite>(fileName + n100);
        image1000.sprite = Resources.Load<Sprite>(fileName + n1000);

        image1000.SetNativeSize();
        image100.SetNativeSize();
        image10.SetNativeSize();
        image1.SetNativeSize();
    }
    //1분후 보스가 생성되게 코루틴 함수 활용
    IEnumerator BossIn()
    {
        yield return new WaitForSeconds(60f);
        Instantiate(enemy5, new Vector3(15, 0, 0), Quaternion.identity);
        yield return null;
    }

    //게임오버
    public void gameOverFunc()
    {
        //게임오버시에 시간의 흐름을 조율
        Time.timeScale = 0;
        gameOverImg.SetActive(true);
        RestartText.enabled = true;
        isGameOver = true;
    }
    public void StageClear()
    {
        Time.timeScale = 0;
        StageClearImg.SetActive(true);
        RestartText.enabled = true;
        isGameOver = true;
    }
    //재시작 R버튼 눌렀을때 
    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("PlayScene");
        }
    }
    //랜덤으로 숫자가 선택되면 해당 에너미를 생성하는 함수
    void SelectEnemy()
    {
        switch (num)
        {
            case 1:
                Instantiate(enemy1, new Vector3(15, enemySpawnRand, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy2, new Vector3(enemySpawnRandy, 5, 0), Quaternion.identity);
                break;
            case 3:
                Instantiate(enemy3, new Vector3(15, enemySpawnRand, 0), Quaternion.identity);
                break;
            case 4:
                Instantiate(enemy4, new Vector3(15, enemySpawnRand, 0), Quaternion.identity);
                break;
        }
    }

}





