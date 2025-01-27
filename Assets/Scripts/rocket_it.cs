using UnityEngine;
using System.Collections;


public class Rocket : MonoBehaviour
{
    public float speed = 5f;           // 로켓 이동 속도
    public float returnDelay = 2f;    // 로켓이 원래 위치로 돌아오는 시간
    private bool isLaunched = false;  // 로켓 발사 여부
    private Vector3 originalPosition; // 로켓의 초기 위치 저장

    void Start()
    {
        // 원래 위치를 저장
        originalPosition = transform.position;

			Launch();
		

	}

    void Update()
    {
        if (isLaunched)
        {
            // 로켓을 Y축으로 이동
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    private void ReturnToOriginalPosition()
    {
        // 원래 위치로 이동하고 발사 상태 초기화
        transform.position = originalPosition;
        isLaunched = false;
    }

    private IEnumerator ReturnToOriginalPositionWithLerp()
    {
        float elapsedTime = 0f;
        float duration = 1f; // 복귀 애니메이션 지속 시간
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, originalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition; // 위치를 정확히 원래 위치로 설정
        isLaunched = false; // 발사 상태 초기화
		yield return new WaitForSeconds(2);
		Launch();
    }

    public void Launch()
    {
        if (!isLaunched)
        {
            isLaunched = true;
            Invoke(nameof(StartReturnCoroutine), returnDelay);
        }
    }

    private void StartReturnCoroutine()
    {
        StartCoroutine(ReturnToOriginalPositionWithLerp());
    }
}




