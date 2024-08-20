using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public void Init()
    {
        Instance = this;
    }
    public void OnFollow(Vector2 targetPos)
    {
        StartCoroutine(OnFollowCor(targetPos));
    }


    public IEnumerator OnFollowCor(Vector2 targetPos)
    {
        while (0.1f<Vector3.Distance(transform.position, targetPos))
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * DataBaseManager.Instance.followSpeed);
            yield return null;
        }
    }
}
