using UnityEngine;
using System.Collections;

public class CometLooper : MonoBehaviour
{
    public Vector3 startPoint; // 혜성이 나타날 위치
    public Vector3 endPoint;   // 혜성이 사라질 위치
    public float duration = 5f; // 이동에 걸리는 시간
    public float delay = 3f;   // 혜성이 다시 등장하기 전 지연 시간

    private float timer = 0f;
    private bool isWaiting = false; // 대기 중인지 확인

    void Update()
    {
        if (!isWaiting)
        {
            timer += Time.deltaTime;

            // 혜성을 startPoint에서 endPoint로 이동
            transform.position = Vector3.Lerp(startPoint, endPoint, timer / duration);

            // 혜성이 endPoint에 도달하면 대기 시작
            if (timer >= duration)
            {
                StartCoroutine(WaitAndReset());
            }
        }
    }

    private IEnumerator WaitAndReset()
    {
        isWaiting = true; // 대기 상태로 설정
        timer = 0f;       // 타이머 초기화
        yield return new WaitForSeconds(delay); // delay만큼 대기
        transform.position = startPoint; // 혜성을 시작 위치로 이동
        isWaiting = false; // 대기 상태 해제
    }
}
