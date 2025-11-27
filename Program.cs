class Program
{
    static void Main()
    {
        
    } 


    static void Options(int number)
    {

        Console.WriteLine(@"What would you like to do?
        1. View Mileage
        2. Input Mileage");

        switch (number)
        {
            case 1:
                break;
            case 2: 
                int mileage = Getinput("What was last weeks mileage? ");
                int crossTraining = Getinput("How long did you spend cross training? ");
                break;
        }

    }
    static void LoadFile(string filelocation)
    {
        string[] file = File.ReadAllLines(filelocation);
    }
    static int Getinput(string message)
    {
        bool success = false;
        int mileage = 0;
        while (!success) 
        {    
            Console.Clear();
            Console.Write(message);
            string? input = Console.ReadLine();
            success = Int32.TryParse(input, out mileage);
        }
        return mileage;
    }

    static List<TrainingEntry> ReadFile(string file)
    {
        List<TrainingEntry> info = new List<TrainingEntry>();

        string[] fileinfo = File.ReadAllLines(file);
        foreach (string line in fileinfo)
        {
            string[] part = line.Split(',');

            info.Add(new TrainingEntry()
            {
                date = DateTime.Parse(part[0]),
                mileage = Int32.Parse(part[1]),
                crossTraining = Int32.Parse(part[2])
            }
            );
        }
        return info;
    }

    class TrainingEntry
    {
        public DateTime date {get; set;}
        public int mileage {get; set;}
        public int crossTraining {get; set;}
    }

}