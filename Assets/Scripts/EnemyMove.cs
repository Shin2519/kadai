using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float amplitude = 1f;
    public float speed = 2f;

    private Vector3 startpos;
    private float phaseoffset;

    //enemy色の変化
    public static List<EnemyMove> allEnemies = new List<EnemyMove>();

    [HideInInspector] public Renderer rend;
    private Color originalColor;

    //enemy色の変化
    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color;
        }
    }

    //enemy移動
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

    //enemy色の変化
    void OnEnable()
    {
        allEnemies.Add(this);
    }

    void OnDisable()
    {
        allEnemies.Remove(this);
    }

    // 色を元に戻す
    public void ResetColor()
    {
        if (rend != null)
            rend.material.color = originalColor;
    }

    // ロックオン中の色に変更
    public void SetLockOnColor()
    {
        if (rend != null)
            rend.material.color = Color.red;
    }
}
