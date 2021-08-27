using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoSingleton<Player>
{

    private Vector2 targetPosition = Vector2.zero;
    [SerializeField]
    private float speed = 15.7f;

    [SerializeField]
    private GameObject[] bulletPrefab = null;

    [SerializeField]
    private Transform bulletPosition = null;

    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Sprite[] sprite = null;

    [SerializeField]
    private int hp = 100;

    [SerializeField]
    private int item = 0;

    private bool isDamaged = false;
    [SerializeField]
    private AudioClip[] clip;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(Fire());
        ChangeBody(Body.bodyType);
        hp = (Body.bodyType + 1) * 100 + (WeaponA.wpAType + 1) * 5 + (WeaponB.wpBType + 1) * 5;
        speed = ((3 - Body.bodyType) * 2) + ((3 - WeaponA.wpAType + 1) * 2) + ((3 - WeaponB.wpBType + 1) * 2);
        //MainTextManager.Instance.SetValue(0, hp);
        //MainTextManager.Instance.SetValue(2, item);
    }

    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, GameManager.Instance.minPosition.x, GameManager.Instance.maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, GameManager.Instance.minPosition.y, GameManager.Instance.maxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }

    private IEnumerator Fire()
    {
      
        while (GameManager.Instance.GetisGameOver()==false)
        {
            GameObject bullet = null;
            MainSoundManager.Instance.SFXPlay("4 딱총", clip[0]);
            bullet = Instantiate(bulletPrefab[Body.bodyType], bulletPosition);
            bullet.transform.localScale = new Vector3(1.4f, 1.4f, 1);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds((Body.bodyType+1) * 0.25f);
        }
    }

    public void ChangeBody(int type)
    {
        spriteRenderer.sprite = sprite[type];
    }

    public IEnumerator Damaged(int damage)
    {
        if (!isDamaged)
        {
            isDamaged = true;
            MainSoundManager.Instance.SFXPlay("5 플레이어 피격", clip[1]);
            hp -= damage;
            //MainTextManager.Instance.SetValue(0, hp);
            if (hp < 1)
            {
                spriteRenderer.enabled = false;
                GameManager.Instance.SetisGameOver(true);
                StartCoroutine(GameOver());
            }
            for (int i = 0; i < 3; i++)
            {
                spriteRenderer.enabled = false;
                yield return new WaitForSeconds(0.157f);
                spriteRenderer.enabled = true;
                yield return new WaitForSeconds(0.157f);
            }
            isDamaged = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(Damaged(20)); // 여기부분 수정해야됨
        }
    }

    IEnumerator GameOver()
    {
        MainSoundManager.Instance.SFXPlay("7 플레이어 사망", clip[2]); // 이거 코루틴으로 해야될 듯
        //애니매이션 추가 하는 코드가 들어갈 자리
        yield return new WaitForSeconds(0.5f);
        GameOverScreenManager.Instance.GameOver();
    }
}