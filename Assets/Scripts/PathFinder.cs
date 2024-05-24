using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private WaveConfigSO waveConfig;
    private List<Transform> _wayPoints;
    private int _wayPointIndex = 0;
    void Start()
    {
        _wayPoints = waveConfig.GetWaypoints();
        transform.position = _wayPoints[_wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        // If not at last way point
        if (_wayPointIndex < _wayPoints.Count)
        {
            Vector2 targetPosition = _wayPoints[_wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position.Equals(targetPosition))
            {
                _wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
