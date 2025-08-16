using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using System.Collections.Generic;

public class Createnemy : MonoBehaviour
{
    public static List<Createnemy> allEnemies = new List<Createnemy>();
    public Transform Player;
    public GameObject enemyPrefab;
    public float minDistance = 10f;
    public float maxDistance = 20f;
    public float width = 40f;
    public float height = 10f;

    public int spawnCount;

    [HideInInspector] public Renderer rend;
    private Color originalColor;

    void EnemySpawns()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            //プレイヤーの前方方向にランダム生成
            float distance = Random.Range(minDistance, maxDistance);

            //左右のランダム
            float offsetX = Random.Range(-width / 2f, width / 2f);

            //上下のランダム
            float offsetY = Random.Range(-height / 2f, height / 2f);

            //前方ベクトルと右方向ベクトルを使って座標計算
            Vector3 spawnPos = Player.position + Player.forward * distance + Player.right * offsetX + Player.up * offsetY;

            //オブジェクト作成
            Instantiate(enemyPrefab,spawnPos,Quaternion.identity);
        }
    }

    

    void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            originalColor = rend.material.color;
    }

    void Start()
    {
        EnemySpawns();
            if (enemyPrefab.GetComponent<EnemyMove>() == null)
            {
                //上下移動スクリプト追加
                enemyPrefab.AddComponent<EnemyMove>();
            }
    }

    
}
