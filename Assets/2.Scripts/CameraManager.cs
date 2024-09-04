using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    [SerializeField] private SpriteRenderer bgSrdr;

    float cameraWidth;

    public void Init()
    {
        Instance = this;
        Camera camera = Camera.main;
        float cameraHeight = camera.orthographicSize * 2f;
        cameraWidth = cameraHeight * camera.aspect;
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
            float bgRightX = bgSrdr.transform.position.x + bgSrdr.size.x;
            float cameraRightX = Camera.main.transform.position.x + cameraWidth / 2;

            if(bgRightX <= cameraRightX)
            {
                bgSrdr.size = new Vector2(bgSrdr.size.x + cameraWidth , bgSrdr.size.y);
            }
            yield return null;
        }
    }
}
