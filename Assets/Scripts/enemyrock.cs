using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class enemyrock : MonoBehaviour
{
    public float lockOnRange = 1000f;
    public float frontAngle = 70f;
    public int maxLockOnTargets = 8;

    public List<Transform> lockedTargets = new List<Transform>();
    private List<EnemyMove> previousLocked = new List<EnemyMove>();

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
            FindLockOnTargets();

        if(Input.GetKeyUp(KeyCode.Z))
        {
            // 前回のロックオン色をリセット
            foreach (EnemyMove e in previousLocked)
                e.ResetColor();
        }
    }
    //Enemy色変化
    void FindLockOnTargets()
    {
        // 前回のロックオン色をリセット
        foreach (EnemyMove e in previousLocked)
            e.ResetColor();

        previousLocked.Clear();
        lockedTargets.Clear();

        List<Transform> candidates = new List<Transform>();

        foreach (EnemyMove enemy in EnemyMove.allEnemies)
        {
            if (enemy == null) continue;

            Vector3 toTarget = enemy.transform.position - transform.position;
            float distance = toTarget.magnitude;

            if (distance > lockOnRange) continue;

            Vector3 dirToTarget = toTarget.normalized;
            float dot = Vector3.Dot(transform.forward, dirToTarget);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (angle < frontAngle * 0.5f)
                candidates.Add(enemy.transform);
        }

        candidates.Sort((a, b) =>
            Vector3.Distance(transform.position, a.position)
            .CompareTo(Vector3.Distance(transform.position, b.position)));

        for (int i = 0; i < Mathf.Min(maxLockOnTargets, candidates.Count); i++)
        {
            Transform t = candidates[i];
            lockedTargets.Add(t);

            EnemyMove e = t.GetComponent<EnemyMove>();
            if (e != null)
            {
                e.SetLockOnColor();
                previousLocked.Add(e);
            }
        }
    }
}
