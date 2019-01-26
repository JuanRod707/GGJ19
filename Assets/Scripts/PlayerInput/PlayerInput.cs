using Movement;
using UnityEngine;

namespace PlayerInput
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
                ControlledNavigator.MoveTo(hit.point);
                MoveMarker.DisplayMarker(hit.point);
            }
        }
    }
}
