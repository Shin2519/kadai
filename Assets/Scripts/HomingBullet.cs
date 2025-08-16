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
            //�^�[�Q�b�g����
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            //�i�s�������^�[�Q�b�g�����ւ̕␳
            velocity = Vector3.Lerp(velocity, dirToTarget, turnRate * Time.deltaTime).normalized;
            //��������Ŗ�������
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

        //�ړ�
        transform.position += velocity * speed * Time.deltaTime;
    }

    public void SetInitialDirection(Vector3 dir)
    {
        velocity = dir.normalized;
    }
}
