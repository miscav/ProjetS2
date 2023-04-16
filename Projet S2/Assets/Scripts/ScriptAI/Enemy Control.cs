using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControl : MonoBehaviour
{
    // Stockage du navmesh (pathfinding) et la distance de d�placement automatique
    private NavMeshAgent navAgent;
    private float wanderDistance = 4;

    // Variable contenant le fichier de notre ennemi (contenant les caract�ristiques : nom, description, mod�le 3D, etc.)
    public EnemyData enemyData;

    private void Start()
    {
        // S'il y a un NavMeshAgent sur l'empty, on le recup�re (toujours appel� avec notre exemple)
        if (navAgent == null)
        {
            navAgent = GetComponent<NavMeshAgent>();
        }

        // Si enemyData n'est pas vide, on va charger l'ennemi bas� sur les infos qu'on a
        if (enemyData != null)
        {
            LoadEnemy(enemyData);
        }
    }


    private void LoadEnemy(EnemyData _data)
    {
        // Supprime tous les child de l'empty s'il y en a 
        foreach (Transform child in transform)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(child.gameObject);
            }
            else
            {
                Destroy(child.gameObject);
            }
        }

        // Fait apparaitre le mod�le 3D de notre ennemi et le configure
        GameObject visuals = Instantiate(enemyData.enemyModel);
        visuals.transform.SetParent(transform);
        visuals.transform.localPosition = Vector3.zero;
        visuals.transform.rotation = Quaternion.identity;

        // Recup�re la vitesse dans enemyData et l'attribue au navmesh
        navAgent.speed = enemyData.speed;
    }

    private void Update()
    {
        // Si enemyData n'est pas assign�, on ne fait rien dans Update
        if (enemyData == null)
        {
            return;
        }

        // Si l'ennemi a atteint sa destination, on lui attribue une nouvelle destination
        // Cette partie ne concerne pas le tutoriel sur les Scriptable Objects)
        if (navAgent.remainingDistance < 1f)
        {
            GetNewDestination();
        }
    }

    // Recup�re une nouvelle destination a proximit� (bas� sur la var wanderDistance)
    private void GetNewDestination()
    {
        Vector3 nextDestination = transform.position;
        nextDestination += wanderDistance * new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, 3f, NavMesh.AllAreas))
        {
            navAgent.SetDestination(hit.position);
        }
    }

}
