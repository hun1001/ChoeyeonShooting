using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1P;
    [SerializeField]
    private GameObject enemy2P;
    [SerializeField]
    private GameObject enemy3P;

    [SerializeField]
    private GameObject scrapP;
    [SerializeField]
    private GameObject gunpowerP;
    [SerializeField]
    private GameObject engineP;

    [SerializeField]
    private GameObject playerbulletP;
    [SerializeField]
    private GameObject rightbulletP;
    [SerializeField]
    private GameObject leftbulletP;

    private GameObject[] enemy1;
    private GameObject[] enemy2;
    private GameObject[] enemy3;

    private GameObject[] scrap;
    private GameObject[] gunpower;
    private GameObject[] engine;

    private GameObject[] playerbullet;
    private GameObject[] rightbullet;
    private GameObject[] leftbullet;

    private GameObject[] target = null;

    private void Awake()
    {
        enemy1 = new GameObject[10];
        enemy2 = new GameObject[10];
        enemy3 = new GameObject[10];

        scrap = new GameObject[5];
        gunpower = new GameObject[5];
        engine = new GameObject[5];

        playerbullet = new GameObject[20];
        leftbullet = new GameObject[20];
        rightbullet = new GameObject[20];
        Generate();
    }

    private void Generate()
    {
        for(int i=0; i<enemy1.Length; i++)
        {
            enemy1[i] = Instantiate(enemy1P);
            enemy1[i].SetActive(false);
            enemy2[i] = Instantiate(enemy2P);
            enemy2[i].SetActive(false);
            enemy3[i] = Instantiate(enemy3P);
            enemy3[i].SetActive(false);
        }
        for (int i = 0; i < scrap.Length; i++)
        {
            scrap[i] = Instantiate(scrapP);
            scrap[i].SetActive(false);
            engine[i] = Instantiate(engineP);
            engine[i].SetActive(false);
            gunpower[i] = Instantiate(gunpowerP);
            gunpower[i].SetActive(false);
        }
        for (int i = 0; i < playerbullet.Length; i++)
        {
            playerbullet[i] = Instantiate(playerbulletP);
            playerbullet[i].SetActive(false);
            rightbullet[i] = Instantiate(rightbulletP);
            rightbullet[i].SetActive(false);
            leftbullet[i] = Instantiate(leftbulletP);
            leftbullet[i].SetActive(false);
        }
    }

    public GameObject Obj(int i)
    {

        switch(i)
        {
            case 1:
                target = enemy1;
                break;
            case 2:
                target = enemy2;
                break;
            case 3:
                target = enemy3;
                break;
            case 4:
                target = scrap;
                break;
            case 5:
                target = gunpower;
                break;
            case 6:
                target = engine;
                break;
            case 7:
                target = playerbullet;
                break;
            case 8:
                target = rightbullet;
                break;
            case 9:
                target = leftbullet;
                break;
        }

        for(int index=0; index<target.Length; index++)
        {
            if(!target[index].activeSelf)
            {
                target[index].SetActive(true);
                return target[index];
            }
        }
        return null;
    }
}
