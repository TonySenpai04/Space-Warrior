using UnityEngine;
using UnityEngine.UI;

public class TargetIconManager : MonoBehaviour
{
    public Image targetIcon; // Kéo và thả hình ảnh icon target vào Inspector

    public bool isSelectingTarget = false;
    public Enemy selectedEnemy;

    private void Update()
    {
        A();
        if (isSelectingTarget)
        {
            MoveTargetIconWithMouse();
        }

        if ( isSelectingTarget)
        {
            SelectTarget();
        }
    }
    public void A()
    {
        if (Input.GetKey(KeyCode.V)){
            isSelectingTarget=true;
            Time.timeScale = 0f;
        }
    }
    public void StartTargetSelection()
    {
        isSelectingTarget = true;
        targetIcon.gameObject.SetActive(true);
    }

    private void MoveTargetIconWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Đặt vị trí Z sao cho icon target xuất hiện trên mọi đối tượng khác trên Canvas
        targetIcon.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void SelectTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.GetComponent<Enemy>())
        {
            selectedEnemy = hit.collider.gameObject.GetComponent<Enemy>();
            if (selectedEnemy != null && selectedEnemy.currentHealth > 0)
            {
                // Đặt vị trí của icon target vào vị trí của quái
                targetIcon.transform.position = selectedEnemy.transform.position;
                // Tắt icon target
                //targetIcon.gameObject.SetActive(false);
                // Tiếp tục game
                ResumeGame();
            }
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Tiếp tục game
        isSelectingTarget = false; // Kết thúc việc chọn mục tiêu
    }
}
