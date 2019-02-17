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

                if (!IsInRange(item))
                {
                    ControlledNavigator.MoveTo(hit.point);
                    MoveMarker.DisplayMarker(hit.point);
                }
            }
        }

        private bool IsInRange(SpookItem item) => item != null && item.GhostIsInRange;
    }
}
