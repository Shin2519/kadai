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
            //�v���C���[�̑O�������Ƀ����_������
            float distance = Random.Range(minDistance, maxDistance);

            //���E�̃����_��
            float offsetX = Random.Range(-width / 2f, width / 2f);

            //�㉺�̃����_��
            float offsetY = Random.Range(-height / 2f, height / 2f);

            //�O���x�N�g���ƉE�����x�N�g�����g���č��W�v�Z
            Vector3 spawnPos = Player.position + Player.forward * distance + Player.right * offsetX + Player.up * offsetY;

            //�I�u�W�F�N�g�쐬
            Instantiate(enemy,spawnPos,Quaternion.identity);
        }
    }

    void Start()
    {
        EnemySpawns();
    }
}
