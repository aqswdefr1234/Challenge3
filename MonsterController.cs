using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    public float updateInterval = 0.1f; // ������ ���� ����

    private float timer;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // NavMeshAgent ����
        //navMeshAgent.updateRotation = false;

        navMeshAgent.speed = 20.0f; // �ӵ��� �������� �� ������ �����̵��� ��
        navMeshAgent.acceleration = 100f; // ���ӵ��� �������� �� ������ �ӵ��� �ø����� ��
        navMeshAgent.angularSpeed = 3600f; // ���ӵ��� �������� �� ������ ���� ��ȯ�ϵ��� ��
        navMeshAgent.stoppingDistance = 0; // ��ǥ�������� �� ��Ȯ�ϰ� ���ߵ��� ��
        navMeshAgent.autoBraking = false;
        navMeshAgent.radius = 1f;
        navMeshAgent.height = 2f;
        navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            if (player != null && navMeshAgent.isOnNavMesh)
            {
                navMeshAgent.SetDestination(player.position);
                //RotateAgent();
            }
            timer = 0f;
        }
    }
    void RotateAgent()
    {
        Vector2 forward = new Vector2(transform.position.z, transform.position.x);
        Vector2 steeringTarget = new Vector2(navMeshAgent.steeringTarget.z, navMeshAgent.steeringTarget.x);

        //������ ���� ��, ���Լ��� ���� ���Ѵ�.
        Vector2 dir = steeringTarget - forward;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //���� ����
        transform.eulerAngles = Vector3.up * angle;
    }
}
