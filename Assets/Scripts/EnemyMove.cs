using System.Collections.Generic;
using UnityEngine;

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
}
