using System;
using Helpers;
using Items;
using Movement;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public BasicNavigator ControlledNavigator;
        public LayerMask InteractableLayer;
        public MoveMarker MoveMarker;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                NavigateToMouse();
        }

        private void NavigateToMouse()
        {
            var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(mouseRay, out hit, 200f, InteractableLayer))
            {
                var item = hit.collider.GetComponent<SpookItem>();

                if (IsItem(item))
                {
                    if (!IsInRange(item))
                        MoveToPoint(hit.point, item);
                }
                else
                    MoveToPoint(hit.point);
            }
        }

        private bool IsItem(SpookItem item) => item != null;

        private bool IsInRange(SpookItem item) => item.GhostIsInRange;

        private void MoveToPoint(Vector3 target)
        {
            ControlledNavigator.MoveTo(target);
            MoveMarker.DisplayMarker(target);
        }

        private void MoveToPoint(Vector3 target, SpookItem targetItem)
        {
            ControlledNavigator.MoveTo(target, targetItem);
            MoveMarker.DisplayMarker(target);
        }
    }
}
