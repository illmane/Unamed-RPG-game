using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class InstantiateFireball : MonoBehaviour
{
   public GameObject FireballPrefab;

   public int randAmount;

    void Start()
    {
        StartCoroutine(ChangeToIdle());
    }

    private void CreateFireballs()
    {
        randAmount = Random.Range(5, 13);
        for (int i = 0; i < randAmount; i++){
        Instantiate(FireballPrefab, new Vector3(Random.Range(-9.72f, 10.14f), Random.Range(-5.73f, 5.48f), 0), Quaternion.identity);
        StartCoroutine(DelayFireballSpawn());

        }
    }

    private IEnumerator ChangeToIdle()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<BossAI>().changeState(BossStates.Idle);
    }

    private IEnumerator DelayFireballSpawn()
    {
        yield return new WaitForSeconds(2f);
    }
}
