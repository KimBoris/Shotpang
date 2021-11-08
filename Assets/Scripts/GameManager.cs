using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //���� �ҷ��ö� 
using UnityEngine.UI;//����Ƽ UI���� 

public class GameManager : MonoBehaviour
{
    //�̱���
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
    public int score;       //����

    float num;   //���ʹ� ���� ����
    float dTimer;//���ʹ� ���� ��������
    float eDelay;//���ʹ� ���� ������
    float second;//���� ����ð� (�ð��� ���� �����Ǵ� ���Ͱ� �ٸ���)
    float enemySpawnRand;   //���ʹ̻��� ��ġ 
    float enemySpawnRandy;  //���ʹ̻��� ��ġ

    bool isGameOver;//���ӿ��� ���¿���

    //���ʹ�
    public GameObject enemy1;     //���ʹ�1
    public GameObject enemy2;     //���ʹ�2
    public GameObject enemy3;     //���ʹ�3
    public GameObject enemy4;     //���ʹ�4
    public GameObject enemy5;     //����

    //public GameObject e3collider; //���ʹ�3�� ��ġ�� ����ִ� �ݶ��̴�
    
    public GameObject StageClearImg;//���� Ŭ���� �̹���
    public GameObject gameOverImg;  //���ӿ��� �̹���

    //���ھ� �̹���
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
        StartCoroutine(BossIn());//�ð��� �Ǹ� ���� ����
    }

 
    void Update()
    {
        if (isGameOver == true)
        {
            Restart();
        }
        //���� ��ȯ
        SpawnEnemy();
        //Score UI����
        ScoreUI();
    }

    void SpawnEnemy()
    {
        //�ð��� �������� �����Ǵ� ���Ͱ� �پ�������.
        second += Time.deltaTime;//�������� ����ð�
        dTimer += Time.deltaTime;//���� �����ð�
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
    //1���� ������ �����ǰ� �ڷ�ƾ �Լ� Ȱ��
    IEnumerator BossIn()
    {
        yield return new WaitForSeconds(60f);
        Instantiate(enemy5, new Vector3(15, 0, 0), Quaternion.identity);
        yield return null;
    }

    //���ӿ���
    public void gameOverFunc()
    {
        //���ӿ����ÿ� �ð��� �帧�� ����
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
    //����� R��ư �������� 
    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("PlayScene");
        }
    }
    //�������� ���ڰ� ���õǸ� �ش� ���ʹ̸� �����ϴ� �Լ�
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





