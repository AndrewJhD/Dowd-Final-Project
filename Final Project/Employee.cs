namespace Final_Project
{
    public class Employee
    {
        private string Name { get; set; }
        private int idNumber { get; set; }

        public Employee(string name, int empId)
        {
            this.Name = name;
            this.idNumber = empId;
        }

        public Employee()
        {
            this.Name = "";
            this.idNumber = 0;
        }

        override
        public string ToString()
        {
            return ("Employee name: " + Name + ", Employee id: " + idNumber);
        }




    }
}
