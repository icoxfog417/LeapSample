using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;
using Parse;

namespace LeapSample
{
    class Circle
    {
        public int CircleId = -1;
        public int State = 1; //1:start 0:update -1:stop
        public bool Direction = true; //true: up false:down
        public float Progress = 0;
        public float Radius = 0;
        public float Angle = 0;

        public Circle(int id, Gesture.GestureState state, bool direction, float progress, float radius, float angle)
        {
            this.CircleId = id;
            switch(state)
            {
                case Gesture.GestureState.STATE_START:
                    this.State = 1;
                    break;
                case Gesture.GestureState.STATE_UPDATE:
                    this.State = 0;
                    break;
                case Gesture.GestureState.STATE_STOP:
                    this.State = -1;
                    break;
            }
            this.Direction = direction;
            this.Progress = progress;
            this.Radius = radius;
            this.Angle = angle;
        }

        public string StateText()
        {
            string result = "START";
            switch (this.State) 
            {
                case 1:
                    result = "START";
                    break;
                case 0:
                    result = "UPDATE";
                    break;
                case -1:
                    result = "END";
                    break;
            }

            return result;        
        }


        public string DirectionText()
        {
            if (this.Direction)
            {
                return "Scroll Up";
            }
            else {
                return "Scroll Down";
            }
        }

        public async void Save()
        {
            var c = new ParseObject("Circle");
            c["CircleId"] = this.CircleId;
            c["State"] = this.State;
            c["Direction"] = this.Direction;
            c["Progress"] = this.Progress;
            c["Radius"] = this.Radius;
            c["Angle"] = this.Angle;
            c["LoggedAt"] = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            await c.SaveAsync();
        }

        public override string ToString()
        {
            return "Circle id: " + this.CircleId
                    + ", " + this.StateText()
                    + ", " + this.DirectionText()
                    + ", progress: " + this.Progress
                    + ", radius: " + this.Radius
                    + ", angle: " + this.Angle;
        }

    }
}
