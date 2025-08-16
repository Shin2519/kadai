using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public float amplitude = 1f;
    public float speed = 2f;

    private Vector3 startpos;
    private float phaseoffset;

    //enemy�F�̕ω�
    public static List<EnemyMove> allEnemies = new List<EnemyMove>();

    [HideInInspector] public Renderer rend;
    private Color originalColor;
    private Vector3 originalpos;
    private Coroutine hitRoutine;

    //enemy�F�̕ω�
    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color;
        }
    }

    //enemy�ړ�
    void Start()
    {
        startpos = transform.position;
        phaseoffset = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        float Yoffset = Mathf.Sin(Time.time * speed + phaseoffset) * amplitude;
        transform.position = startpos + new Vector3(0, Yoffset, 0);
    }

    //enemy�F�̕ω�
    void OnEnable()
    {
        allEnemies.Add(this);
    }

    void OnDisable()
    {
        allEnemies.Remove(this);
    }

    // �F�����ɖ߂�
    public void ResetColor()
    {
        if (rend != null)
            rend.material.color = originalColor;
    }

    // ���b�N�I�����̐F�ɕύX
    public void SetLockOnColor()
    {
        if (rend != null)
            rend.material.color = Color.red;
    }

    public void OnHit()
    {
        if(hitRoutine != null)
        {
            StopCoroutine(hitRoutine);
        }
        hitRoutine = StartCoroutine(HitEffect());
    }

    private IEnumerator HitEffect()
    {
        originalpos = transform.position;

        //�F�����F�ɕύX
        if (rend != null)
        {
            rend.material.color = Color.yellow;
        }

        float duration = 0.3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            //�����_���ɏ����h�炷
            float shakeAmout = 0.05f;
            Vector3 offset = new Vector3(Mathf.Sin(Time.time * 50f) * shakeAmout, Mathf.Cos(Time.time * 60f) * shakeAmout, 0);
            transform.position = originalpos + offset;
            elapsed += Time.deltaTime;
            yield return null;
        }
        //���ɖ߂�
        transform.position = originalpos;
        if(rend != null)
        {
            rend.material.color = originalColor;
        }

        hitRoutine = null;
        
    }
}
