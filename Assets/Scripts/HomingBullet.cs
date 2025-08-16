using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float turnRate = 5f;
    public float hitDistance = 1f;

    private Vector3 velocity;

    void Start()
    {
        if(velocity == Vector3.zero)
        {
            velocity = Vector3.forward;
        }

    }
    void Update()
    {
        if (target != null)
        {
            //ターゲット方向
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            //進行方向をターゲット方向への補正
            velocity = Vector3.Lerp(velocity, dirToTarget, turnRate * Time.deltaTime).normalized;
            //距離判定で命中判定
            float dist = Vector3.Distance(transform.position, target.position);
            if(dist < hitDistance)
            {
                EnemyMove e =target.GetComponent<EnemyMove>();
                if (e != null) 
                {
                    e.OnHit();
                }
                Destroy(gameObject);
                return;
            }
        }

        //移動
        transform.position += velocity * speed * Time.deltaTime;
    }

    public void SetInitialDirection(Vector3 dir)
    {
        velocity = dir.normalized;
    }
}
