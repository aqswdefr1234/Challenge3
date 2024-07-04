using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    public float updateInterval = 0.1f; // 목적지 갱신 간격

    private float timer;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // NavMeshAgent 설정
        //navMeshAgent.updateRotation = false;

        navMeshAgent.speed = 20.0f; // 속도를 증가시켜 더 빠르게 움직이도록 함
        navMeshAgent.acceleration = 100f; // 가속도를 증가시켜 더 빠르게 속도를 올리도록 함
        navMeshAgent.angularSpeed = 3600f; // 각속도를 증가시켜 더 빠르게 방향 전환하도록 함
        navMeshAgent.stoppingDistance = 0; // 목표지점에서 더 정확하게 멈추도록 함
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

        //방향을 구한 뒤, 역함수로 각을 구한다.
        Vector2 dir = steeringTarget - forward;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //방향 적용
        transform.eulerAngles = Vector3.up * angle;
    }
}
