using System.Globalization;

namespace ExersiceModel
{
    internal class ExersiceDTO
    {
        public int Id { get; set; }
        public string comment { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public TimeSpan Duration {
			get { return DateEnd - DateStart; }
        }
        internal static ExersiceDTO GenerateShift()
        {
            System.Console.WriteLine("What is the name of the task");
            string inputName = System.Console.ReadLine();
            if (string.IsNullOrEmpty(inputName))
            {
                System.Console.WriteLine("Please enter a valid name");
                inputName = System.Console.ReadLine();
            }
            System.Console.WriteLine("What time you have started the session? format(MM-dd-HH-mm)");
            var startTime = DateTime.ParseExact(System.Console.ReadLine(), "MM-dd-HH-mm",CultureInfo.InvariantCulture);

            System.Console.WriteLine("What time you have ended the session? format(MM-dd-HH-mm)");
            var EndTime = DateTime.ParseExact(System.Console.ReadLine(), "MM-dd-HH-mm",CultureInfo.InvariantCulture);

            ExersiceDTO Exersice = new ExersiceDTO();
            Exersice.comment = inputName;
            Exersice.DateStart = startTime;
            Exersice.DateEnd = EndTime;
            return Exersice;
        }
    }
}