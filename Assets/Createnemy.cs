using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Createnemy : MonoBehaviour
{
    public Transform Player;
    public GameObject enemy;
    public float minDistance = 10f;
    public float maxDistance = 20f;
    public float width = 40f;
    public float height = 10f;

    public int spawnCount = 10;

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
            Instantiate(enemy,spawnPos,Quaternion.identity);
        }
    }

    void Start()
    {
        EnemySpawns();
    }
}
