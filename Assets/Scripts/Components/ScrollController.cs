using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public ScrollRect scrollView1;
    public Button leftButton1;
    public Button rightButton1;

    public ScrollRect scrollView2;
    public Button leftButton2;
    public Button rightButton2;

    private void Start()
    {
        // Attach button click events for ScrollView1
        leftButton1.onClick.AddListener(() => ScrollLeft(scrollView1));
        rightButton1.onClick.AddListener(() => ScrollRight(scrollView1));

        // Attach button click events for ScrollView2
        leftButton2.onClick.AddListener(() => ScrollLeft(scrollView2));
        rightButton2.onClick.AddListener(() => ScrollRight(scrollView2));
    }

    private void ScrollLeft(ScrollRect scrollView)
    {
        // Scroll left to the previous image for the specified ScrollView
        scrollView.horizontalNormalizedPosition = Mathf.Max(0f, scrollView.horizontalNormalizedPosition - 1f / (scrollView.content.childCount - 1));
    }

    private void ScrollRight(ScrollRect scrollView)
    {
        // Scroll right to the next image for the specified ScrollView
        scrollView.horizontalNormalizedPosition = Mathf.Min(1f, scrollView.horizontalNormalizedPosition + 1f / (scrollView.content.childCount - 1));
    }
}
