using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField] private Transform targetPositionTranform;

    private EnemyTrainComands enemyComands;
    private Vector3 targetPosition;
    float stoppingDistance = 10f;
    float stoppingSpeed = 40f;
    float forwardAmount = 0f;
    float turnAmount = 0f;

    float reachedTargetDistance = 15f;

    private void Awake() {
        enemyComands = GetComponent<EnemyTrainComands>();
    }

    private void Update() {
        SetTargetPosition(targetPositionTranform.position);


        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        if (distanceToTarget > reachedTargetDistance) {

            Vector3 dirToMovePosition = (targetPosition - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, dirToMovePosition);

            if (dot > 0) {

                forwardAmount = 1f;
                if (distanceToTarget < stoppingDistance && enemyComands.GetSpeed() > stoppingSpeed) {

                    forwardAmount = -1f;
                }
            } else {

                float reverseDistance = 25f;
                if (distanceToTarget > reverseDistance) {

                    forwardAmount = 1f;
                } else {
                    forwardAmount = -1f;
                }
            }

            float angleToDir = Vector3.SignedAngle(transform.forward, dirToMovePosition, Vector3.up);

            if (angleToDir > 0) {
                turnAmount = 1f;
            } else {
                turnAmount = -1f;
            }
        } else {

            if (enemyComands.GetSpeed() > 15f) {
                forwardAmount = -1f;
            } else {
                forwardAmount = 0f;
            }
            turnAmount = 0f;
        }

        enemyComands.SetInputs(forwardAmount, turnAmount);
    }

    public void SetTargetPosition(Vector3 targetPosition) {
        this.targetPosition = targetPosition;
    }

}
