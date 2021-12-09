namespace Final_Project
{
    public class Work
    {
        private int assignmentDifficulty { get; set; }

        private int assignmentId { get; set; }

        private double completeTime { get; set; }

        public Work()
        {
            this.assignmentDifficulty = 0;
            this.assignmentId = 0;
            this.completeTime = 0;
        }

        public Work(int _assignmentDif, int _assignmentId, double _completeTime)
        {
            this.assignmentDifficulty = _assignmentDif;
            this.assignmentId = _assignmentId;
            this.completeTime = _completeTime;
        }

        override
        public string ToString()
        {
            return ("Assignment Difficulty: " + assignmentDifficulty + ", Assignment Id: " + assignmentId + ", Time to Complete: " + completeTime);
        }
    }
}
